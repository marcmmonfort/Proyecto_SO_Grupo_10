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

        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaActualizar(string nombre, string YESorNO);

        // Booleans:
        bool Loged = false;
        bool Connect = false;
        bool Conect_Click = false;

        bool creandoPartida = false; // Si acaba el tiempo de espera o bien uno o más usuarios rechazan la partida, directamente ya no se sigue creando.
        bool partidaCreada = false; // Define si se ha creado o no la partida.
        bool hasInvitado = false; // Declara si es la persona que ha invitado a las demás o no.
        bool AceptanTodos = false; // Si han aceptado todos, cuando acaba el tiempo se abre para cada usuario el tablero.

        // - - - - - - - - - - - - - - - - - - - - PARÁMETROS - - - - - - - - - - - - - - - - - - - -

        // 1. Identificación del usuario que está usando el programa de cliente.
        string user;
        string password;

        // 2. Fecha de partida que está usando el programa de cliente.
        string fecha;

        //Atendemos al servidor
        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                switch (codigo)
                {
                    case 1: // Respuesta a la Petición 1.
                        
                        MessageBox.Show(user + " tiene " + mensaje + " puntos después de ganar el día " + fechaPartida.Text);
                        break;

                    case 2: // Respuesta a la Petición 2.

                        MessageBox.Show(user + " ha jugado " + mensaje + " partidas.");
                        break;

                    case 3: // Respuesta a la Petición 3.

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
                        break;

                    case 12: // Estás recibiendo una respuesta a la invitación de una partida.

                        // Solo la atiendes si eres el que has invitado:

                        if (hasInvitado == true)
                        {
                            // Recibimos: 'YES-Marc' o 'NO-Marc'.
                            char delimeter = '-';
                            string[] split = mensaje.Split(delimeter);
                            string nombre = split[0];
                            string YESorNO = split[1];
                            if (YESorNO == "NO")
                            {
                                AceptanTodos = false; // Cuando alguien rechaza la partida, ya no se juega.
                            }
                            MessageBox.Show(nombre);
                            DelegadoParaActualizar delegat = new DelegadoParaActualizar(ActualizarEstados);
                            gridListaConectados.Invoke(delegat, new object[] {nombre, YESorNO});
                        }
                        break;

                    case 13: // Si alguien ha rechazado la partida y, por lo tanto, no se crea:

                        MessageBox.Show("No todos los jugadores han aceptado la partida. Prueba de nuevo.");
                        break;

                    case 55: // Si todos han aceptado las partidas y, por lo tanto, se juega:

                        interfaz_Grafica frm = new interfaz_Grafica();
                        frm.Show();
                        break;
                }
            }
        }

        public void ActualizarEstados(string nombre, string YESorNO)
        {
            string row = "Does " + nombre + " Play? " + YESorNO;
            estadoInvitados.Rows.Add(row);
            estadoInvitados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            estadoInvitados.ClearSelection();
        }

        public void PonListaConectados(string mensaje)
        {
            gridListaConectados.Rows.Clear();
            gridListaConectados.ColumnCount = 1;
            gridListaConectados.GridColor = Color.LightGray;

            if (mensaje != null)
            {
                char delimeter = '-';
                string[] split = mensaje.Split(delimeter);
                int i = 1;
                while (i < split.Length)
                {
                    gridListaConectados.Rows.Add(split[i]);
                    i = i + 1;
                }
                gridListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            gridListaConectados.ClearSelection();
        }

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


        // - - - - - - - - - - - - - - - - - - - - BOTÓN DESCONECTAR - - - - - - - - - - - - - - - - - - - -

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

        private void openGame_Click(object sender, EventArgs e)
        {
            interfaz_Grafica frm = new interfaz_Grafica();
            frm.Show();
        }

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

            // Te incluyes a ti mismo como que tu si que juegas:

            DelegadoParaActualizar delegat = new DelegadoParaActualizar(ActualizarEstados);
            gridListaConectados.Invoke(delegat, new object[] { user, "YES" });
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
                hasInvitado = false; // Ya no has invitado.
                if (AceptanTodos == false)
                {
                    // No se crea la partida. Avisar a todos los usuarios.
                    string mensaje = "13/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                else if (AceptanTodos == true)
                {
                    // Se crea la partida y, por lo tanto, se abren los tableros en todos los usuarios.
                    string mensaje = "55/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // YA NO USAMOS LA PETICIÓN 'DAME LISTA DE CONECTADOS'.

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }
}
