using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace WindowsFormsApplication1
{
    public partial class Home : Form
    {
        Socket server;
        Thread atender;

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // JUEGO ABIERTO (Formulario de la Interfaz Gráfica):

        interfaz_Grafica IG;

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // Delegados del programa:

        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaActualizar(string nombre, string YESorNO);
        delegate void DelegadoTimer(string RS);
        delegate void DelegadoChat(string mensaje);

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // Booleans:
        bool Loged = false;
        bool Connect = false;
        bool Conect_Click = false;

        bool creandoPartida = false; // Si acaba el tiempo de espera o bien uno o más usuarios rechazan la partida, directamente ya no se sigue creando.
        bool partidaCreada = false; // Define si se ha creado o no la partida.
        bool hasInvitado = false; // Declara si es la persona que ha invitado a las demás o no, declara si eres el anfitrión.
        bool AceptanTodos = true; // Si han aceptado todos, cuando acaba el tiempo se abre para cada usuario el tablero.

        // - - - - - - - - - - - - - - - - - - - - PARÁMETROS - - - - - - - - - - - - - - - - - - - -

        // 1. Identificación del usuario que está usando el programa de cliente.
        string user;
        string password;

        // 2. Fecha de partida que está usando el programa de cliente.
        string fecha;

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
        // ATENDER SERVIDOR DES DEL MENÚ (HOME).

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                // MessageBox.Show(trozos[0]); // TEST.
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                switch (codigo)
                {
                    case 1: // Respuesta a la Petición 1.
                        if (mensaje == "-1")
                            MessageBox.Show(user + " no tiene puntos.");
                        else
                            MessageBox.Show(user + " tiene " + mensaje + " puntos después de ganar el día " + fechaPartida.Text);
                        break;

                    case 2: // Respuesta a la Petición 2.

                        if (mensaje == "-1")
                            MessageBox.Show(user + " no ha jugado ninguna partida.");
                        else if (mensaje == "1")
                            MessageBox.Show(user + " ha jugado " + mensaje + " partida.");
                        else
                            MessageBox.Show(user + " ha jugado " + mensaje + " partidas.");
                        break;

                    case 3: // Respuesta a la Petición 3.

                        if (mensaje == "-1")
                            MessageBox.Show(user + " no ha ganado a nadie.");
                        else
                            MessageBox.Show(user + " ha ganado a: " + mensaje);
                        break;

                    case 5: // Respuesta a la Petición 5. // ¿ESTO NO ESTÁ DUPLICADO?

                        MessageBox.Show(user + " tiene " + mensaje + " puntos después de ganar el día " + fechaPartida.Text);
                        break;

                    case 6: // Notificación.

                        DelegadoParaEscribir delegado = new DelegadoParaEscribir(PonListaConectados);
                        gridListaConectados.Invoke(delegado, new object[] {mensaje});
                        break;

                    case 10: // Te estan invitando a una partida.

                        // Delegado para arrancar el Timer en todos los formularios:
                        string RS = "R"; // Queremos que el timer arranque.
                        DelegadoTimer D = new DelegadoTimer(ControlarReloj);
                        Invoke(D, new object[] { RS });

                        if (hasInvitado == false) // Si no eres tu el que has invitado...
                        {
                            DialogResult dialogResult = MessageBox.Show(user + ", ¿quieres unirte a una partida?", "Invitación", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes) // SI ACEPTAMOS PARTICIPAR.
                            {
                                string answer = "11/YES-" + user;
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(answer);
                                server.Send(msg);
                            }
                            else if (dialogResult == DialogResult.No) // NO ACEPTAMOS PARTICIPAR.
                            {
                                string answer = "11/NO-" + user;
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes(answer);
                                server.Send(msg);
                            }
                        }
                        else if (hasInvitado == true) // Si eres el que invita, claramente vas a jugar.
                        {
                            string answer = "11/YES-" + user;
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(answer);
                            server.Send(msg);
                        }
                        break;

                    case 12: // Estás recibiendo una respuesta a la invitación de una partida.
                        
                        char delimeter = '-';
                        string[] split = mensaje.Split(delimeter);
                        string nombre = split[0];
                        string YESorNO = split[1];

                        if (YESorNO == "NO")
                        {
                            AceptanTodos = false; // Cuando alguien rechaza la partida, ya no se juega.
                        }

                        DelegadoParaActualizar delegat = new DelegadoParaActualizar(ActualizarEstados);
                        Invoke(delegat, new object[] {nombre, YESorNO});

                        break;

                    case 13: // Si alguien ha rechazado la partida y, por lo tanto, no se crea:

                        MessageBox.Show("No todos los jugadores han aceptado la partida. Prueba de nuevo.");
                        break;

                    case 55: // Si todos han aceptado las partidas y, por lo tanto, se juega:

                        ThreadStart ts = delegate { PonerEnMarchaInterfazGrafica(); };
                        Thread Open = new Thread(ts);
                        Open.Start();
                        break;

                    case 15:
                        MessageBox.Show(mensaje + " Has sido invitado.");
                        break;

                    case 28: // Cuando se recibe la notificación de un mensaje nuevo:
                        DelegadoChat delegated = new DelegadoChat(IG.ActualizarChat);
                        Invoke(delegated, new object[] { mensaje});
                        break;
                }
            }
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

        // - - - - - - - - - - Función que se usará para abrir la Interfaz Gráfica: - - - - - - - - - -

        private void PonerEnMarchaInterfazGrafica()
        {
            interfaz_Grafica frm = new interfaz_Grafica(server, user);
            this.IG = frm;
            // frm.Show(); 
            frm.ShowDialog();
        }

        // - - - - - - - - - - Funciones que se usarán con delegados: - - - - - - - - - -



        public void ControlarReloj(string RS)
        {
            if (RS == "R") // (R)un: Arranca el Timer.
            {
                cuentaAtras.Start();
                tiempo.ForeColor = Color.LightGray;
                tiempo.Text = "30";

            }
            else if (RS == "S") // (S)top: Para el Timer.
            {
                cuentaAtras.Stop();
            }
        }

        // - - - - - - - - - - - - - - - - - - - -

        public void ActualizarEstados(string nombre, string YESorNO)
        {
            estadoInvitados.ColumnCount = 2;
            estadoInvitados.GridColor = Color.LightGray;
            estadoInvitados.Columns[0].HeaderText = "Invitado";
            estadoInvitados.Columns[1].HeaderText = "¿Acepta?";
            estadoInvitados.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            estadoInvitados.EnableHeadersVisualStyles = false;

            estadoInvitados.Rows.Add(nombre, YESorNO);
            estadoInvitados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            estadoInvitados.ClearSelection();
        }

        // - - - - - - - - - - - - - - - - - - - -

        public void PonListaConectados(string mensaje)
        {
            gridListaConectados.Rows.Clear();
            gridListaConectados.ColumnCount = 2; // Columna 1: Nombre. + Columna 2: Socket.
            gridListaConectados.Columns[0].HeaderText = "User";
            gridListaConectados.Columns[1].HeaderText = "Socket";
            gridListaConectados.GridColor = Color.LightGray;
            gridListaConectados.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            gridListaConectados.EnableHeadersVisualStyles = false;

            if (mensaje != null)
            {
                char delimeter = '-';
                string[] split = mensaje.Split(delimeter);
                int i = 1;
                while (i < split.Length)
                {
                    string pack = split[i];
                    string[] nameSocket = pack.Split('|');
                    string usuario = nameSocket[0];
                    int soquet = Convert.ToInt32(nameSocket[1]);
                    gridListaConectados.Rows.Add(usuario, soquet);
                    i = i + 1;
                }
                gridListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            gridListaConectados.ClearSelection();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public Home()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false;
       
            // CANVI
            // pongo en marcha el thread que atenderá los mensajes del servidor
            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
        }

        // Función SET para pasar la conexión del form Inicio al form Home.

        public void SetConnection(Socket S)
        {
            this.server = S;
        }

        // Función SET para pasar la conexión del form Inicio al form Home.

        public void SetUserAndPassword(string U, string P)
        {
            this.user = U;
            this.password = P;
        }

        // - - - - - - - - - - - - - - - - - - - - BOTÓN ENVIAR PETICIÓN - - - - - - - - - - - - - - - - - - - -

        private void button2_Click(object sender, EventArgs e) // Botón Enviar.
        {

            // ---> PETICIÓN DE ALBA A LA BASE DE DATOS (Radio Button): - - - - - - - - - -

            if (Petición_Alba.Checked)
            {
                string mensaje = "1/" + user + "/" + fechaPartida.Text;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                if (fechaPartida.Text == "") // Si se nos olvida rellenar el campo de la fecha...
                {
                    MessageBox.Show("[!] Debes introducir la fecha primero! [!]");
                }
                else // Envía el mensaje.
                {
                    server.Send(msg);
                }

            }
            // ---> PETICIÓN DE MARC A LA BASE DE DATOS (Radio Button): - - - - - - - - - -
            else if (Petición_Marc.Checked)
            {
                string mensaje = "2/" + user;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }

            // ---> PETICIÓN DE ELOI A LA BASE DE DATOS (Radio Button): - - - - - - - - - -

            else if (Petición_Eloi.Checked)
            {
                string mensaje = "3/" + user;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void Home_Load(object sender, EventArgs e)
        {
            cuentaAtras.Interval = 1000;
        }

        private void crearPartida_Click(object sender, EventArgs e)
        {
            cuentaAtras.Start();
            hasInvitado = true; // Declaramos que ha sido este cliente el que ha invitado a los demás.
            AceptanTodos = true; // Consideramos para empezar que nadie rechaza la partida.
            tiempo.ForeColor = Color.LightGray;
            creandoPartida = true; // Se inicia el proceso de creación de la partida.
            tiempo.Text = "30";

            // COMO SE HACE LA INVITACIÓN:

            string mensaje = "10/"; // Se invita a todo el mundo.
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // CUANDO INVITAS, CREAS DIRECTAMENTE EL DATAGRIDVIEW DE ESTADOS DE INVITACIONES:

            estadoInvitados.Rows.Clear();
            estadoInvitados.ColumnCount = 1;
            estadoInvitados.GridColor = Color.LightGray;
        }

        private void cuentaAtras_Tick(object sender, EventArgs e)
        {
            int time = Convert.ToInt32(tiempo.Text);
            time = time - 1;
            tiempo.Text = Convert.ToString(time);
            if (time <= 10)
            {
                if (time%2 == 0)
                {
                    tiempo.ForeColor = Color.Yellow;
                }
                else
                {
                    tiempo.ForeColor = Color.Black;
                }
            }
            if (time == 0)
            {
                cuentaAtras.Stop();
                creandoPartida = false; // El proceso de creación de la partida se para.
                if (AceptanTodos == false)
                {
                    // No se crea la partida. Avisar a todos los usuarios.
                    string mensaje = "13/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    hasInvitado = false; // Ya no has invitado.
                }
                else if (AceptanTodos == true)
                {
                    // Se crea la partida y, por lo tanto, se abren los tableros en todos los usuarios.
                    string mensaje = "55/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    hasInvitado = false; // Ya no has invitado.
                }
            }
            if (AceptanTodos == false)
            {
                cuentaAtras.Stop();
                creandoPartida = false; // El proceso de creación de la partida se para.
                hasInvitado = false; // Ya no has invitado.
                // No se crea la partida. Avisar a todos los usuarios.
                string mensaje = "13/"; // ¡PARA AQUÍ!
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        // - - - - - - - - - - - - - - - - - - - - DESCONECTAR - - - - - - - - - - - - - - - - - - - -

        // CERRAR POT BOTÓN.
        private void Desconectar_Click_1(object sender, EventArgs e)
        {
            atender.Abort();
            string mensaje = "0/" + user;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

            server.Send(msg);
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            this.Close();
        }

        // CERRAR POR PESTAÑA 'X'.
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            atender.Abort();
            string mensaje = "0/" + user;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

            cuentaAtras.Stop(); // Paramos la cuenta atrás en caso de que estubiera contando.

            server.Send(msg);
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void gridListaConectados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var nombre = gridListaConectados.Rows[e.RowIndex].Cells[0].Value;
            var socket = gridListaConectados.Rows[e.RowIndex].Cells[1].Value;


            

           
            string mensaje = "15/" + nombre.ToString(); // Se invita a un usuario
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            hasInvitado = true;
            string answer = "11/YES-" + user;
            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(answer);
            server.Send(msg2);



            estadoInvitados.Rows.Clear();
            estadoInvitados.ColumnCount = 1;
            estadoInvitados.GridColor = Color.LightGray;
        }
    }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
}

