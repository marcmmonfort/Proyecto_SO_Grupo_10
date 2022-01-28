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

        // JUGADORES DE LA PARTIDA:

        string user1 = "";
        string user2 = "";
        string user3 = "";
        string user4 = "";

        // NUMERO DE USUARIO QUE CORRESPONDE A ESTE CLIENTE:

        int idFichaUser;

        // NUMERO DE PARTIDA EN LA QUE ESTA JUGANDO ESTE CLIENTE:

        int idPartida;

        // INVITADOS:

        string invitados = "15/";

        // NUMERO DE INVITADOS INDIVIDUALES:

        int contador = 0;

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        // >>> Delegados de Home:

        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaActualizar(string nombre, string YESorNO);
        delegate void DelegadoTimer(string RS);
        delegate void NotificacionesRespuestaPeticiones(string mensaje);

        // >>> Delegados de la Interfaz Gráfica:
        delegate void DelegadoChat(string mensaje);
        delegate void DelegadoNotificacion(string mensaje);
        delegate void DelegadoTurno(int torn);
        delegate void DelegadoFichas(int IDF, string CX, string CY);
        delegate void DelegadoDinero(int IDF, double dinero);
        delegate void DelegadoCreditos(int IDF, double creditos);
        delegate void DelegadoOwners(string USUARI, int IDPOS);
        delegate void DelegadoAcabarPartida(string n1, double c1, string n2, double c2, string n3, double c3, string n4, double c4);

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
                byte[] msg2 = new byte[300];
                server.Receive(msg2);
                string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');

                // MessageBox.Show("El usuario "+user+"ha recibido: "+trozos[0]); // #AQUI

                int codigo = Convert.ToInt32(trozos[0]);
                string mensaje = trozos[1].Split('\0')[0];
                switch (codigo)
                {
                    /*
                    case 1: // Respuesta a la Petición 1.
                        if (mensaje == "-1")
                        {
                            string comentari = user + " no tiene puntos.";
                            NotificacionesRespuestaPeticiones escriure1 = new NotificacionesRespuestaPeticiones(EscribirEnHome);
                            notificacionHome.Invoke(escriure1, new object[] { comentari });
                        }
                        else
                        {
                            string comentari = user + " tiene " + mensaje + " puntos después de ganar el día " + fechaPartida.Text;
                            NotificacionesRespuestaPeticiones escriure2 = new NotificacionesRespuestaPeticiones(EscribirEnHome);
                            notificacionHome.Invoke(escriure2, new object[] { comentari });
                        }
                        break;
                    */

                    case 2: // Respuesta a la Petición 2.

                        if (mensaje == "-1")
                        {
                            string comentari = user + " no ha jugado ninguna partida.";
                            NotificacionesRespuestaPeticiones escriure3 = new NotificacionesRespuestaPeticiones(EscribirEnHome);
                            notificacionHome.Invoke(escriure3, new object[] { comentari });
                        }
                        else if (mensaje == "1")
                        {
                            string comentari = user + " ha jugado " + mensaje + " partida.";
                            NotificacionesRespuestaPeticiones escriure4 = new NotificacionesRespuestaPeticiones(EscribirEnHome);
                            notificacionHome.Invoke(escriure4, new object[] { comentari });
                        }
                        else
                        {
                            string comentari = user + " ha jugado " + mensaje + " partidas.";
                            NotificacionesRespuestaPeticiones escriure5 = new NotificacionesRespuestaPeticiones(EscribirEnHome);
                            notificacionHome.Invoke(escriure5, new object[] { comentari });
                        }
                        break;

                    case 3: // Respuesta a la Petición 3.

                        if (mensaje == "-1")
                        {
                            string comentari = user + " no ha ganado a nadie.";
                            NotificacionesRespuestaPeticiones escriure6 = new NotificacionesRespuestaPeticiones(EscribirEnHome);
                            notificacionHome.Invoke(escriure6, new object[] { comentari });
                        }
                        else
                        {
                            string jugador1 = mensaje;
                            string jugador2 = trozos[2];
                            string jugador3 = trozos[3];

                            string comentari = user + " ha ganado a:\n" + jugador1 +"\n" + jugador2 + "\n" + jugador3;
                            NotificacionesRespuestaPeticiones escriure7 = new NotificacionesRespuestaPeticiones(EscribirEnHome);
                            notificacionHome.Invoke(escriure7, new object[] { comentari });
                        }
                        break;
                    
                    /*
                    case 5: // Respuesta a la Petición 5. // ¿ESTO NO ESTÁ DUPLICADO?

                        string comentari2 = user + " tiene " + mensaje + " puntos después de ganar el día " + fechaPartida.Text;
                        NotificacionesRespuestaPeticiones escriure8 = new NotificacionesRespuestaPeticiones(EscribirEnHome);
                        notificacionHome.Invoke(escriure8, new object[] { comentari2 });
                        break;
                    */

                    case 6: // Notificación de actualizar la lista de conectados.

                        DelegadoParaEscribir delegado = new DelegadoParaEscribir(PonListaConectados);
                        gridListaConectados.Invoke(delegado, new object[] {mensaje});
                        break;

                    case 10: // Te estan invitando a una partida.
                        if (mensaje == "-1")
                        {
                            MessageBox.Show("No puedes iniciar otra partida");
                        }
                        else
                        {
                            // Delegado para arrancar el Timer en todos los formularios:
                            string RS = "R"; // Queremos que el timer arranque.
                            DelegadoTimer D = new DelegadoTimer(ControlarReloj);
                            Invoke(D, new object[] { RS });
                            string[] trocitos = mensaje.Split(',');
                            string creador = trocitos[0];
                            int idPartida = Convert.ToInt32(trocitos[1]);

                            if (hasInvitado == false) // Si no eres tu el que has invitado...
                            {
                                DialogResult dialogResult = MessageBox.Show(user + ", ¿quieres unirte a una partida?", "Invitación", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes) // SI ACEPTAMOS PARTICIPAR.
                                {
                                    string answer = "11/YES/" + user + "/" + idPartida.ToString();
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(answer);
                                    server.Send(msg);
                                }
                                else if (dialogResult == DialogResult.No) // NO ACEPTAMOS PARTICIPAR.
                                {
                                    string answer = "11/NO/" + user + "/" + idPartida.ToString();
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(answer);
                                    server.Send(msg);
                                }
                            }
                        }
                       
                        break;

                    case 12: // Estás recibiendo una respuesta a la invitación de una partida.

                        // AQUÍ SE RECIBE "12/1-Marc|1-Eloi|1-Vinicius|1-RDT|1"
                        // mensaje: "1-Marc|1-Eloi|1-Vinicius|1-RDT|1"

                        if (mensaje =="-1")
                        {
                            MessageBox.Show("Esta partida no está disponible");
                        }
                        else if (mensaje == "-2")

                        {
                            MessageBox.Show("Esta partida ya está completa");
                        }
                        else
                        {
                            DelegadoParaEscribir delegat = new DelegadoParaEscribir(PonListaPartidas);
                            estadoInvitados.Invoke(delegat, new object[] { mensaje });
                        }

                        break;

                    case 13: // Si alguien ha rechazado la partida y, por lo tanto, no se crea:

                        MessageBox.Show("No todos los jugadores han aceptado la partida. Prueba de nuevo.");
                        break;

                    case 14: // La partida ya está completa y se abre el tablero de juego.

                        // mensaje: "Marc|Eloi|Alba|Miguel"

                        // 1. Se asignan los nombres a cada jugador:
                        char delimeter = '|';
                        string[] split = mensaje.Split(delimeter);
                        user1 = split[0];
                        user2 = split[1];
                        user3 = split[2];
                        user4 = split[3];

                        // 2. Identificamos que jugador somos:
                        if (user1 == user)
                        {
                            idFichaUser = 1;
                        }
                        else if (user2 == user)
                        {
                            idFichaUser = 2;
                        }
                        else if (user3 == user)
                        {
                            idFichaUser = 3;
                        }
                        else if (user4 == user)
                        {
                            idFichaUser = 4;
                        }

                        // 3. Abrimos la interfaz gráfica:
                        ThreadStart ts1 = delegate { PonerEnMarchaInterfazGrafica(); };
                        Thread Open1 = new Thread(ts1);
                        Open1.Start();
                        break;

                    /*case 55: // Si todos han aceptado las partidas y, por lo tanto, se juega:
                        ThreadStart ts2 = delegate { PonerEnMarchaInterfazGrafica(); };
                        Thread Open2 = new Thread(ts2);
                        Open2.Start();
                        break;*/

                    case 28: // Cuando se recibe la notificación de un mensaje nuevo:
                        DelegadoChat delegated1 = new DelegadoChat(IG.ActualizarChat);
                        Invoke(delegated1, new object[] { mensaje});
                        break;

                    case 52: // Llega una notificacion para escribir en el formulario:
                        // 'mensaje' es todo lo que llega despues del 52.
                        // Deberíamos recibir el formato: '52/[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500€.'.
                        DelegadoNotificacion delegated2 = new DelegadoNotificacion(IG.UseEscribirNotificacion);
                        Invoke(delegated2, new object[] { mensaje });
                        break;

                    case 53: // Nos llega información de un turno a gestionar:
                        // Deberíamos recibir el formato: '53/turno'.
                        // mensaje seria el turno (en string).
                        int turno = Convert.ToInt32(mensaje);
                        DelegadoTurno delegated3 = new DelegadoTurno(IG.UseGestorDeTurnos);
                        Invoke(delegated3, new object[] { turno });
                        break;

                    case 54: // Nos llega información de la posición de una nueva ficha.
                        // Formato que nos llega:'54/numFicha-PosX-PosY'.
                        // mensaje: 'numFicha-PosX-PosY'.
                        char separador1 = '|';
                        string[] parte1 = mensaje.Split(separador1);
                        int idFitxa = Convert.ToInt32(parte1[0]);
                        string PositionX = parte1[1];
                        string PositionY = parte1[2];
                        DelegadoFichas delegated4 = new DelegadoFichas(IG.UsoGestorFichas);
                        Invoke(delegated4, new object[] { idFitxa, PositionX, PositionY });
                        break;

                    case 58: // Nos llega información de un usuario, cuyo dinero hay que modificar:
                        // Nos llega: 'fitxa|dinero'.
                        char separador2 = '|';
                        string[] parte2 = mensaje.Split(separador2);
                        int IDFitxaA = Convert.ToInt32(parte2[0]);
                        double dinero = Convert.ToDouble(parte2[1]);

                        DelegadoDinero delegate5 = new DelegadoDinero(IG.UsoGestorDinero);
                        Invoke(delegate5, new object[] { IDFitxaA, dinero });

                        break;
                    case 59: // Nos llega información de un usuario, cuyos creditos hay que modificar:
                        // Nos llega: 'fitxa|creditos'.
                        char separador3 = '|';
                        string[] parte3 = mensaje.Split(separador3);
                        int IDFitxaB = Convert.ToInt32(parte3[0]);
                        double creditos = Convert.ToDouble(parte3[1]);

                        DelegadoCreditos delegate6 = new DelegadoCreditos(IG.UsoGestorCreditos);
                        Invoke(delegate6, new object[] { IDFitxaB, creditos });

                        break;

                    case 61: // Nos llega el nombre de un usuario y el índice de la casilla que ha suspendido:
                        // Formato de mensaje: 'user|idPosOwners'.
                        char separador4 = '|';
                        string[] parte4 = mensaje.Split(separador4);
                        string usuari = parte4[0];
                        int idPositionOwners = Convert.ToInt32(parte4[1]);

                        DelegadoOwners delegate7 = new DelegadoOwners(IG.UsoGestorOwners);
                        Invoke(delegate7, new object[] { usuari, idPositionOwners });

                        break;

                    case 77: // Nos llega la notificación de fin de partida, con los resultados de esta:
                        // Formato: 'nomP1|cP1|nomP2|cP2|nomP3|cP3|nomP4|cP4'.

                        char separador5 = '|';
                        string[] parte5 = mensaje.Split(separador5);

                        string NomP1 = parte5[0]; double CreditsP1 = Convert.ToDouble(parte5[1]);
                        string NomP2 = parte5[2]; double CreditsP2 = Convert.ToDouble(parte5[3]);
                        string NomP3 = parte5[4]; double CreditsP3 = Convert.ToDouble(parte5[5]);
                        string NomP4 = parte5[6]; double CreditsP4 = Convert.ToDouble(parte5[7]);

                        // delegate void DelegadoAcabarPartida(string n1, double c1, string n2, double c2, string n3, double c3, string n4, double c4);
                        DelegadoAcabarPartida delegate8 = new DelegadoAcabarPartida(IG.UsoResultadosPartida);
                        Invoke(delegate8, new object[] { NomP1, CreditsP1, NomP2, CreditsP2, NomP3, CreditsP3, NomP4, CreditsP4 });

                        break;
                }
            }
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

        // - - - - - - - - - - Función que se usará para escribir notificaciones en Home: - - - - - - - - - -

        public void EscribirEnHome(string mensaje)
        {
            notificacionHome.Text = mensaje;
        }

        // - - - - - - - - - - Función que se usará para abrir la Interfaz Gráfica: - - - - - - - - - -

        private void PonerEnMarchaInterfazGrafica()
        {
            interfaz_Grafica frm = new interfaz_Grafica(server, user, user1, user2, user3, user4, idFichaUser, idPartida);
            this.IG = frm;
            // frm.Show(); 
            // MessageBox.Show("¡Partida lista! Pulsa [OK] para abrir el tablero. | LA ID DE LA PARTIDA DE ESTE USUARIO ES:" + idPartida); // #ERRORES
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
        public void PonListaPartidas(string mensaje)
        {
            estadoInvitados.Rows.Clear();
            estadoInvitados.ColumnCount = 2; // Columna 1: Nombre. + Columna 2: idPartida.
            estadoInvitados.Columns[0].HeaderText = "User";
            estadoInvitados.Columns[1].HeaderText = "idPartida";
            estadoInvitados.GridColor = Color.LightGray;
            estadoInvitados.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            estadoInvitados.EnableHeadersVisualStyles = false;

            // mensaje: "1-Marc|1-Eloi|1-Vinicius|1-RDT|1"

            // split[1] : "Marc|1"
            // split[2] : "Eloi|1"
            // split[3] : "Vinicius|1"
            // split[4] : "RDT|1"

            if (mensaje != null)
            {
                char delimeter = '-';
                string[] split = mensaje.Split(delimeter);
                int i = 1;
                while (i < split.Length)
                {
                    string pack = split[i];
                    string[] nameIDP = pack.Split('|');

                    string usuario = nameIDP[0];
                    int IDP = Convert.ToInt32(nameIDP[1]);

                    // SI UNO DE LOS NOMBRES ES EL NUESTRO, GUARDAMOS LA ID DE LA PARTIDA:
                    if (usuario==user)
                    {
                        this.idPartida = IDP;
                    }

                    estadoInvitados.Rows.Add(usuario, IDP);
                    i = i + 1;
                }
                estadoInvitados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            estadoInvitados.ClearSelection();
        }
        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        public Home()
        {
            InitializeComponent();

            // CheckForIllegalCrossThreadCalls = false;
            // CANVI!
            // Pongo en marcha el thread que atenderá los mensajes del servidor:

            ThreadStart ts0 = delegate { AtenderServidor(); };
            atender = new Thread(ts0);
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

            /*
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
            */
            // ---> PETICIÓN DE MARC A LA BASE DE DATOS (Radio Button): - - - - - - - - - -
            if (Petición_Marc.Checked)
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

            // Ponemos el nombre del usuario al que pertenece el formulario.
            idUsuario.Text = user;

            // MÉTODO PARA QUE SE ABRA EL FORMULARIO EN EL CENTRO DE CUALQUIER PANTALLA.
            // (Sea cual sea el tamaño de la pantalla).
            int screenH = Screen.PrimaryScreen.Bounds.Height;
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int formH = 554;
            int formW = 711;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((screenW / 2 - formW / 2), (screenH / 2 - formH / 2));

            // BLOQUEA EL MOVIMIENTO DEL FORMULARIO.
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

            string mensaje = "10/"+user; // Se invita a todo el mundo.
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
                    /*
                    // Se crea la partida y, por lo tanto, se abren los tableros en todos los usuarios.
                    string mensaje = "55/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    hasInvitado = false; // Ya no has invitado.
                    */
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

        // INVITAR SELECCIONANDO A TUS AMIGOS.

        private void InvitarAmigos_Click(object sender, EventArgs e)
        {
            cuentaAtras.Start();
            hasInvitado = true; // Declaramos que ha sido este cliente el que ha invitado a los demás.
            AceptanTodos = true; // Consideramos para empezar que nadie rechaza la partida.
            tiempo.ForeColor = Color.LightGray;
            creandoPartida = true; // Se inicia el proceso de creación de la partida.
            tiempo.Text = "30";

            if (contador == 3) // CUANDO HAS INVITADO A 3.
            {
                // COMO SE HACE LA INVITACIÓN:

                string mensaje = invitados; // Se invita a todo el mundo.
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // CUANDO INVITAS, CREAS DIRECTAMENTE EL DATAGRIDVIEW DE ESTADOS DE INVITACIONES:

                estadoInvitados.Rows.Clear();
                estadoInvitados.ColumnCount = 1;
                estadoInvitados.GridColor = Color.LightGray;

                contador = 0;
            }
        }

        private void gridListaConectados_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            // Sumamos uno al contador de invitados:
            contador = contador + 1;

            string nombre = Convert.ToString(gridListaConectados.Rows[row].Cells[0].Value);
            string[] trozos1 = nombre.Split('\0');
            if (trozos1[0] != user)
            {
                if (gridListaConectados.Rows[row].Cells[0].Style.BackColor == Color.Green)
                {
                    string mensaje = "15/" + user + "/";
                    string[] trozos2 = invitados.Split('/');
                    int i = 2;
                    while (i < trozos2.Length && trozos2[i] != "")
                    {
                        nombre = Convert.ToString(gridListaConectados.Rows[row].Cells[0].Value);
                        trozos1 = nombre.Split('\0');
                        if (trozos2[i] != trozos1[0])
                        {
                            mensaje = mensaje + trozos2[i] + "/";
                        }
                        i = i + 1;
                    }
                    invitados = mensaje;
                    gridListaConectados.Rows[row].Cells[0].Style.BackColor = Color.LightGray;
                }
                else
                {
                    nombre = Convert.ToString(gridListaConectados.Rows[row].Cells[0].Value);
                    trozos1 = nombre.Split('\0');
                    invitados = invitados + user + "/" + trozos1[0] + "/";
                    gridListaConectados.Rows[row].Cells[0].Style.BackColor = Color.Green;
                }
            }
            else
                MessageBox.Show("No puedes seleccionarte a ti mismo.");
        }

        private void eliminarUsuario_Click(object sender, EventArgs e)
        {
            string mensaje = "85/" + user + ",";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // DEIXEM TEMPS PERQUE EL SERVIDOR ENS BORRI DE LA BBDD:
            Thread.Sleep(200);

            // ENS DESCONECTEM:
            atender.Abort();
            string mensaje2 = "0/" + user;
            byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje2);
            server.Send(msg2);
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            this.Close();
        }
    }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
}

