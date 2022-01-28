using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class interfaz_Grafica : Form
    {
        // * * * * * * * * * * * * * * * * * * * VARIABLES GLOBALES * * * * * * * * * * * * * * * * * * * * * 

        // ---> 1. Socket y nombre de usuario:
        
        Socket server;
        string user;
        int playerID; // ¿Que número de jugador somos?

        // ---> 2. Nombres de los 4 jugadores:

        string nombre1 = "";
        string nombre2 = "";
        string nombre3 = "";
        string nombre4 = "";

        // ---> 3. Casillas de los 4 jugadores:

        int casilla1;
        int casilla2;
        int casilla3;
        int casilla4;

        // ---> 4. Dinero de cada usuario:

        double dinero1;
        double dinero2;
        double dinero3;
        double dinero4;

        // ---> 5. Creditos de cada usuario:

        double creditos1;
        double creditos2;
        double creditos3;
        double creditos4;

        // ---> 6. Dinero inicial:

        double startingMoney = 1750; // (€).
        // Consideramos: 1 CREDITO = 25 €.

        // ---> 7. ID de la partida.

        int idGame;

        // ---> 8. ID del turno actual.

        int torn;

        // ---> 9. Resultados de una partida:

        string nP1; double cP1;
        string nP2; double cP2;
        string nP3; double cP3;
        string nP4; double cP4;

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

        private void interfaz_Grafica_Load(object sender, EventArgs e)
        {
            // EL RELOJ DEL JUEGO CUENTA CADA 1 SEGUNDO (1000 ms):
            time.Interval = 1000;
            time.Start();

            // EL RELOJ DE TURNO CUENTA CADA 1 SEGUNDO:
            tiempoTurno.Interval = 1000;
            tiempoTurno.Start();

            // MÉTODO PARA QUE SE ABRA EL FORMULARIO EN EL CENTRO DE CUALQUIER PANTALLA (Sea cual sea el tamaño de la pantalla):
            int screenH = Screen.PrimaryScreen.Bounds.Height;
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int formH = 680;
            int formW = 947;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((screenW / 2 - formW / 2), (screenH / 2 - formH / 2));

            // BLOQUEA EL MOVIMIENTO DEL FORMULARIO.
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            // PONEMOS TODAS LAS FICHAS EN LA POSICIÓN DE SALIDA:
            casilla1 = 0;
            casilla2 = 0;
            casilla3 = 0;
            casilla4 = 0;

            // FIJAMOS EL DINERO DE CADA USUARIO AL EMPEZAR ...
            dinero1 = startingMoney; 
            dinero2 = startingMoney;
            dinero3 = startingMoney;
            dinero4 = startingMoney;

            // ... Y LO PONEMOS EN EL FORM:
            money1.Text = Convert.ToString(dinero1);
            money2.Text = Convert.ToString(dinero2);
            money3.Text = Convert.ToString(dinero3);
            money4.Text = Convert.ToString(dinero4);

            // FIJAMOS LOS CREDITOS DE CADA USUARIO AL EMPEZAR ...
            creditos1 = 0;
            creditos2 = 0;
            creditos3 = 0;
            creditos4 = 0;

            // ... Y LO PONEMOS EN EL FORM:
            credits1.Text = Convert.ToString(creditos1);
            credits2.Text = Convert.ToString(creditos2);
            credits3.Text = Convert.ToString(creditos3);
            credits4.Text = Convert.ToString(creditos4);

            // PONEMOS LOS NOMBRES DE LOS JUGADORES EN LOS FORMS:
            user1.Text = nombre1;
            user2.Text = nombre2;
            user3.Text = nombre3;
            user4.Text = nombre4;

            // PONER EL DIBUJO DE TIRAR DADOS AL CARGAR:
            dado.BackgroundImage = Properties.Resources.Tirar_Dados;

            // PREPARAMOS EL DATAGRID CON LOS PROPIETARIOS DE LAS ASIGNATURAS:
            ActualizaGridMaterias();

            // CUANDO SE CARGA EL TABLERO, POR DEFINICION, EL QUE EMPEZARÁ A JUGAR SERÁ EL JUGADOR CON ID1.
            // EMPEZAMOS TAMBIEN SU TIMER DE TURNO DE JUEGO.
            if (playerID == 1)
            {
                dado.Enabled = true;

            }
            else
            {
                dado.Enabled = false;
            }

            // CUANDO SE CARGA EL TABLERO, DECLARAMOS EL TURNO 1:
            torn = 1;
            flecha1.Visible = true; turno1.Visible = true; flecha2.Visible = false; turno2.Visible = false; flecha3.Visible = false; turno3.Visible = false; flecha4.Visible = false; turno4.Visible = false;
            turno1.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.

            // CUANDO SE ABRE LA INTERFAZ, DEBEMOS OCULTAR LAS COSAS DEL PODIO:
            cerrarPartida.Visible = false;
            creditosFinales1.Visible = false;
            creditosFinales2.Visible = false;
            creditosFinales3.Visible = false;
            nombreFinal1.Visible = false;
            nombreFinal2.Visible = false;
            nombreFinal3.Visible = false;
        }

        // * * * * * * * * * * * * * FUNCIÓN QUE PONE LOS PROPIETARIOS DE CADA MATERIA * * * * * * * * * * * * * 

        public void ActualizaGridMaterias()
        {
            propietariosAsignaturas.Columns.Clear();
            propietariosAsignaturas.ColumnCount = 2;
            propietariosAsignaturas.Columns[0].HeaderText = "POS.";
            propietariosAsignaturas.Columns[1].HeaderText = "OWNER";
            propietariosAsignaturas.EnableHeadersVisualStyles = false;
            string nombreCasilla = "";
            string propietario = "";
            for (int i = 0; i < Precios.Length; i++)
            {
                nombreCasilla = Asuntos[i];
                propietario = Owners[i];
                if (Subject[i] == true) // Comprobamos que sea una materia:
                {
                    propietariosAsignaturas.Rows.Add(nombreCasilla, propietario);
                }
            }
            propietariosAsignaturas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            propietariosAsignaturas.ClearSelection();
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

        public interfaz_Grafica(Socket server, string user, string user1, string user2, string user3, string user4, int idFichaUser, int idPartida)
        {
            InitializeComponent();
            this.server = server;
            this.user = user;
            userName.Text = user;
            this.nombre1 = user1;
            this.nombre2 = user2;
            this.nombre3 = user3;
            this.nombre4 = user4;
            // Los nombres en el formulario ya los pone el load.
            this.playerID = idFichaUser;
            idUsuari.Text = Convert.ToString(idFichaUser);
            this.idGame = idPartida;
        }

        // * * * * * * * * * * * * * TODOS LOS DELEGADOS DE LA INTERFAZ * * * * * * * * * * * * *

        // >>> D1: Delegado para ir escribiendo en el chat:
        delegate void MoverElChat(string mensaje);

        // >>> D2: Delegado para escribir las notificaciones:
        delegate void EscribirNotificaciones(string mensaje);

        // >>> D3: Delegado para gestionar los turnos:
        delegate void GestionarTurnos(int turno);

        // >>> D4: Delegado para gestionar el movimiento de las fichas de otros formularios:
        delegate void GestionarFichas(int idFitxa, string PosX, string PosY);

        // >>> D5: Delegado para actualizar la lista de propietarios de las asignaturas en los demas formularios:

        // >>> D6: Delegado para actualizar tu dinero en los demas formularios:
        delegate void GestionarDinero(int idFitxa, double diners);

        // >>> D7: Delegado para actualizar tus creditos en los demas formularios:
        delegate void GestionarCreditos(int idFitxa, double credits);

        // >>> D8: Delegado para actualizar los Owners y la lista de asignaturas aprobadas en los demas formularios:
        delegate void GestionarOwners(string usuari, int idPositionOwners);

        // >>> D9: Delegado para establecer el fin de la partida:
        delegate void GestionarFinPartida(string n1, double c1, string n2, double c2, string n3, double c3, string n4, double c4);

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

        // FUNCIONES QUE SE USAN EN LOS DELEGADOS:

        // ---> (A). Dar los resultados de la partida:

        public void UsoResultadosPartida(string n1, double c1, string n2, double c2, string n3, double c3, string n4, double c4)
        {
            GestionarFinPartida delegado5 = new GestionarFinPartida(ResultadosPartida);
            Invoke(delegado5, new object[] { n1, c1, n2, c2, n3, c3, n4, c4 });
        }

        public void ResultadosPartida(string n1, double c1, string n2, double c2, string n3, double c3, string n4, double c4)
        {
            // PRIMERO PARAMOS LA PARTIDA:
            tiempoTurno.Stop();
            
            // ACTIVAMOS TODO LO QUE CORRESPONDE A FIN DE PARTIDA:
            this.BackgroundImage = Properties.Resources.Interfaz_Resultados_V1;
            cerrarPartida.Visible = true;
            creditosFinales1.Visible = true;
            creditosFinales2.Visible = true;
            creditosFinales3.Visible = true;
            nombreFinal1.Visible = true;
            nombreFinal2.Visible = true;
            nombreFinal3.Visible = true;
            creditosFinales1.Text = Convert.ToString(c1);
            creditosFinales2.Text = Convert.ToString(c2);
            creditosFinales3.Text = Convert.ToString(c3);
            nombreFinal1.Text = n1;
            nombreFinal2.Text = n2;
            nombreFinal3.Text = n3;

            // GUARDAMOS LOS RESULTADOS EN NUESTRO CLIENTE:
            nP1 = n1; nP2 = n2; nP3 = n3; nP4 = n4;
            cP1 = c1; cP2 = c2; cP3 = c3; cP4 = c4;

            // DESACTIVAMOS TODO LO ANTERIOR:
            dado.Visible = false;
            turno1.Visible = false; turno2.Visible = false; turno3.Visible = false; turno4.Visible = false;
            flecha1.Visible = false; flecha2.Visible = false; flecha3.Visible = false; flecha4.Visible = false;
            panel1.Visible = false; panel2.Visible = false; panel3.Visible = false; panel4.Visible = false;
            money1.Visible = false; money2.Visible = false; money3.Visible = false; money4.Visible = false;
            credits1.Visible = false; credits2.Visible = false; credits3.Visible = false; credits4.Visible = false;
            propietariosAsignaturas.Visible = false;
            message1.Visible = false; message2.Visible = false; message3.Visible = false; message4.Visible = false;
            creditsText.Visible = false; moneyText.Visible = false;
            userName.Visible = false; idUsuari.Visible = false;
            salir.Visible = false;
            label2.Visible = false; escrito.Visible = false; sendMessage.Visible = false;
            notificacion.Visible = false;
            fitxa1.Visible = false; fitxa2.Visible = false; fitxa3.Visible = false; fitxa4.Visible = false;
            user1.Visible = false; user2.Visible = false; user3.Visible = false; user4.Visible = false;
            temps.Visible = false;
            comunidadPanel.Visible = false;
            SIAPanel.Visible = false;

        }

        // ---> (B). Actualizar la lista de Owners y el data grid de Asignaturas Aprobadas:

        public void UsoGestorOwners(string usuari, int idPositionOwners)
        {
            GestionarOwners delegado4 = new GestionarOwners(GestorOwners);
            Invoke(delegado4, new object[] { usuari, idPositionOwners });
        }

        public void GestorOwners(string usuari, int idPositionOwners)
        {
            // I. Posem, com de normal, el nou nom a la llista de propietaris.
            if (usuari != "-1")
            {
                Owners[idPositionOwners] = usuari; // Posem el nou usuari.
            }
            else
            {
                Owners[idPositionOwners] = ""; // Borrem el nom de l'usuari.
            }

            // II. Actualitzem el data grid view d'assignatures aprovades.
            ActualizaGridMaterias();

            // III. Si totes les matèries estan ocupades, i som el jugador 1, avisem al servidor de que s'ha acabat la partida.
            // Si totes les matèries estan comprades, i som el jugador 1, s'ha acabat la partida.
            int contador = 0;
            for (int i = 0; i < 40; i++)
            {
                if (Owners[i] != "")
                {
                    contador = contador + 1;
                }
            }
            if (contador == 22) // Totes les matèries ja tenen propietari.
            {
                if (playerID == 1) // Si som el usuari 1 (per evitat que tots li enviin alhora)...
                {
                    // Se acabó la partida. Debemos determinar los ganadores:
                    string nomP1; double creditsP1;
                    string nomP2; double creditsP2;
                    string nomP3; double creditsP3;
                    string nomP4; double creditsP4;
                    // COLOCAMOS, DE SERIE, AL JUGADOR 1 EN P1 PROVISIONAL:
                    nomP1 = nombre1; creditsP1 = creditos1;
                    // COMPARAMOS EL JUGADOR 2 CON EL P1 PROVISONAL:
                    if (creditos2 > creditsP1)
                    {
                        nomP1 = nombre2; creditsP1 = creditos2;
                        nomP2 = nombre1; creditsP2 = creditos1;
                    }
                    else
                    {
                        nomP2 = nombre2; creditsP2 = creditos2;
                    }
                    // AHORA COMPARAMOS EL 3 CON LOS 2 ANTERIORES:
                    if (creditos3 > creditsP1)
                    {
                        // DESPLAZAMOS EL 1 Y EL 2 ABAJO:
                        nomP3 = nomP2; creditsP3 = creditsP2;
                        nomP2 = nomP1; creditsP2 = creditsP1;
                        nomP1 = nombre3; creditsP1 = creditos3;
                    }
                    else
                    {
                        // DEBEMOS COMPARAR ENTRE 2 Y 3:
                        if (creditos3 > creditsP2)
                        {
                            nomP3 = nomP2; creditsP3 = creditsP2;
                            nomP2 = nombre3; creditsP2 = creditos3;
                        }
                        else
                        {
                            nomP3 = nombre3; creditsP3 = creditos3;
                        }
                    }
                    // FINALMENTE, COMPARAMOS EL 4 CON EL 1, 2 Y 3:
                    if (creditos4 > creditsP1)
                    {
                        // DESPLAZAMOS EL 1, EL 2 Y EL 3 ABAJO:
                        nomP4 = nomP3; creditsP4 = creditsP3;
                        nomP3 = nomP2; creditsP3 = creditsP2;
                        nomP2 = nomP1; creditsP2 = creditsP1;
                        nomP1 = nombre4; creditsP1 = creditos4;
                    }
                    else
                    {
                        // SI ESTÁ EN SEGUNDO LUGAR:
                        if (creditos4 > creditsP2)
                        {
                            nomP4 = nomP3; creditsP4 = creditsP3;
                            nomP3 = nomP2; creditsP3 = creditsP2;
                            nomP2 = nombre4; creditsP2 = creditos4;
                        }
                        else
                        {
                            // SI ESTÁ EN TERCER LUGAR:
                            if (creditos4 > creditsP3)
                            {
                                nomP4 = nomP3; creditsP4 = creditsP3;
                                nomP3 = nombre4; creditsP3 = creditos4;
                            }
                            else // Si es el peor, lo colocamos en cuarto lugar.
                            {
                                nomP4 = nombre4; creditsP4 = creditos4;
                            }
                        }
                    }

                    // Se envia algo como: '77/Marc-1/nomP1|cP1|nomP2|cP2|nomP3|cP3|nomP4|cP4':
                    string FINPARTIDA = "77/" + user + "-" + idGame + "/" + nomP1 + "|" + creditsP1 + "|" + nomP2 + "|" + creditsP2 + "|" + nomP3 + "|" + creditsP3 + "|" + nomP4 + "|" + creditsP4;
                    byte[] finpartida = System.Text.Encoding.ASCII.GetBytes(FINPARTIDA);
                    Thread.Sleep(200);
                    server.Send(finpartida);
                }
            }
        }

        // ---> (C). Actualizar el dinero:

        public void UsoGestorDinero(int idFitxa, double diners)
        {
            GestionarDinero delegado4 = new GestionarDinero(GestorDinero);
            Invoke(delegado4, new object[] { idFitxa, diners });
        }
        public void GestorDinero(int idFitxa, double diners)
        {
            // Ponemos los valores tanto en los parametros del usuario como en los TextBox del formulario:
            if (idFitxa == 1)
            {
                this.dinero1 = diners;
                this.money1.Text = Convert.ToString(diners);
            }
            else if (idFitxa == 2)
            {
                this.dinero2 = diners;
                this.money2.Text = Convert.ToString(diners);
            }
            else if (idFitxa == 3)
            {
                this.dinero3 = diners;
                this.money3.Text = Convert.ToString(diners);
            }
            else if (idFitxa == 4)
            {
                this.dinero4 = diners;
                this.money4.Text = Convert.ToString(diners);
            }
        }

        // ---> (D). Actualizar los creditos:

        public void UsoGestorCreditos(int idFitxa, double credits)
        {
            GestionarCreditos delegado4 = new GestionarCreditos(GestorCreditos);
            Invoke(delegado4, new object[] { idFitxa, credits });
        }
        public void GestorCreditos(int idFitxa, double credits)
        {
            // Ponemos los valores tanto en los parametros del usuario como en los TextBox del formulario:
            if (idFitxa == 1)
            {
                this.creditos1 = credits;
                this.credits1.Text = Convert.ToString(credits);
            }
            else if (idFitxa == 2)
            {
                this.creditos2 = credits;
                this.credits2.Text = Convert.ToString(credits);
            }
            else if (idFitxa == 3)
            {
                this.creditos3 = credits;
                this.credits3.Text = Convert.ToString(credits);
            }
            else if (idFitxa == 4)
            {
                this.creditos4 = credits;
                this.credits4.Text = Convert.ToString(credits);
            }
        }

        // ---> (0). Actualizar la posicion de las fichas de otros jugadores.
        public void UsoGestorFichas(int idFitxa, string PosX, string PosY)
        {
            GestionarFichas delegado4 = new GestionarFichas(GestorFichas);
            Invoke(delegado4, new object[] { idFitxa, PosX, PosY });
        }
        public void GestorFichas(int idFitxa, string PosX, string PosY)
        {
            // Obtenemos las coordenadas a partir de los strings identificatorios de posiciones:
            int posX = getCoordinate(PosX);
            int posY = getCoordinate(PosY);
            if (idFitxa == 1) {
                fitxa1.Location = new Point(posX, posY);
            }
            else if (idFitxa == 2) {
                fitxa2.Location = new Point(posX, posY);
            }
            else if (idFitxa == 3) {
                fitxa3.Location = new Point(posX, posY);
            }
            else if (idFitxa == 4) {
                fitxa4.Location = new Point(posX, posY);
            }
        }
        
        // ---> (1). Gestionar turnos.
        public void UseGestorDeTurnos(int turno)
        {
            GestionarTurnos delegado3 = new GestionarTurnos(GestorDeTurnos);
            Invoke(delegado3, new object[] { turno });
        }
        public void GestorDeTurnos(int turno) // turno es un int del playerID que puede jugar.
        {
            if (turno == playerID) // Si es nuestro turno...
            {
                // Como estamos en un nuevo turno, quitamos las fotos que teníamos del turno de antes de Comunidad y SIA:
                comunidadPanel.BackgroundImage = null;
                SIAPanel.BackgroundImage = null;
                // Tambien quitamos la notificacion de antes:
                notificacion.Text = null;
                // Activamos el dado...
                dado.Enabled = true;
                // Activamos el tiempo del turno...
                tiempoTurno.Start();

                if (playerID == 1)
                {
                    flecha1.Visible = true; turno1.Visible = true; flecha2.Visible = false; turno2.Visible = false; flecha3.Visible = false; turno3.Visible = false; flecha4.Visible = false; turno4.Visible = false;
                    turno1.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.
                }
                else if (playerID == 2)
                {
                    flecha1.Visible = false; turno1.Visible = false; flecha2.Visible = true; turno2.Visible = true; flecha3.Visible = false; turno3.Visible = false; flecha4.Visible = false; turno4.Visible = false;
                    turno2.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.
                }
                else if (playerID == 3)
                {
                    flecha1.Visible = false; turno1.Visible = false; flecha2.Visible = false; turno2.Visible = false; flecha3.Visible = true; turno3.Visible = true; flecha4.Visible = false; turno4.Visible = false;
                    turno3.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.
                }
                else if (playerID == 4)
                {
                    flecha1.Visible = false; turno1.Visible = false; flecha2.Visible = false; turno2.Visible = false; flecha3.Visible = false; turno3.Visible = false; flecha4.Visible = true; turno4.Visible = true;
                    turno4.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.
                }
            }
            else // Si no es nuestro turno ...
            {
                // Como estamos en un nuevo turno, quitamos las fotos que teníamos del turno de antes de Comunidad y SIA:
                comunidadPanel.BackgroundImage = null;
                SIAPanel.BackgroundImage = null;
                // Tambien quitamos la notificacion de antes:
                notificacion.Text = null;
                // Dejamos el dado desactivado y sin poner ningun número...
                dado.BackgroundImage = Properties.Resources.Tirar_Dados;
                dado.Enabled = false;
                // Empezamos a contar a la vez que los otros forms el tiempo del turno...
                tiempoTurno.Start();

                if (turno == 1)
                {
                    flecha1.Visible = true; turno1.Visible = true; flecha2.Visible = false; turno2.Visible = false; flecha3.Visible = false; turno3.Visible = false; flecha4.Visible = false; turno4.Visible = false;
                    turno1.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.
                }
                else if (turno == 2)
                {
                    flecha1.Visible = false; turno1.Visible = false; flecha2.Visible = true; turno2.Visible = true; flecha3.Visible = false; turno3.Visible = false; flecha4.Visible = false; turno4.Visible = false;
                    turno2.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.
                }
                else if (turno == 3)
                {
                    flecha1.Visible = false; turno1.Visible = false; flecha2.Visible = false; turno2.Visible = false; flecha3.Visible = true; turno3.Visible = true; flecha4.Visible = false; turno4.Visible = false;
                    turno3.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.
                }
                else if (turno == 4)
                {
                    flecha1.Visible = false; turno1.Visible = false; flecha2.Visible = false; turno2.Visible = false; flecha3.Visible = false; turno3.Visible = false; flecha4.Visible = true; turno4.Visible = true;
                    turno4.Text = "20"; // Ponemos el contador del tiempo del turno a 20 segundos.
                }
            }
        }

        // ---> (2). Ir moviendo el chat.
        public void ActualizarChat(string missatge)
        {
            MoverElChat delegado1 = new MoverElChat(MoverChat);
            Invoke(delegado1, new object[] { missatge });
        }
        public void MoverChat(string mssg)
        {
            message1.Text = message2.Text;
            message2.Text = message3.Text;
            message3.Text = message4.Text;
            message4.Text = mssg;
        }

        // > < > < > < > < > < > < > < > < > < > < > < > < > < > < > < > <

        // ---> (3). Escribir notificaciones.
        public void UseEscribirNotificacion(string missatge)
        {
            EscribirNotificaciones delegado2 = new EscribirNotificaciones(EscribirNotificacion);
            Invoke(delegado2, new object[] { missatge });
        }
        public void EscribirNotificacion(string missatge)
        {
            notificacion.Text = missatge;
        }

        // * * * * * * * * * * * * * * * * VARIABLES GLOBALES COMUNIDAD Y SIA * * * * * * * * * * * * * * * * 

        int idCartaComunidad;
        int idCartaSIA;

        // * * * * * * * * * * * * * * * * * * * * SACAR CARTA DE COMUNIDAD * * * * * * * * * * * * * * * * * * * * 

        public double randomComunidad()
        {
            // VALOR A AÑADIR / DESCONTAR DEL DINERO DEL JUGADOR:
            double tasa = 0;

            // Genera un número aleatorio del 1 al 5 para importar una carta de comunidad diferente.
            Random myObject = new Random();
            int Num = myObject.Next(1, 8);
            idCartaComunidad = Num; // Guardamos la carta para comunicarla a los demás.
            if (Num == 1) {
                comunidadPanel.BackgroundImage = Properties.Resources.COMUNIDAD1;
                tasa = -10;
            }
            else if (Num == 2) {
                comunidadPanel.BackgroundImage = Properties.Resources.COMUNIDAD2;
                tasa = -20;
            }
            else if (Num == 3) {
                comunidadPanel.BackgroundImage = Properties.Resources.COMUNIDAD3;
                tasa = -6.50;
            }
            else if (Num == 4) {
                comunidadPanel.BackgroundImage = Properties.Resources.COMUNIDAD4;
                tasa = -15;
            }
            else if (Num == 5) {
                comunidadPanel.BackgroundImage = Properties.Resources.COMUNIDAD5;
                tasa = -25;
            }
            else if (Num == 6) {
                comunidadPanel.BackgroundImage = Properties.Resources.COMUNIDAD6;
                tasa = 50;
            }
            else if (Num == 7) {
                comunidadPanel.BackgroundImage = Properties.Resources.COMUNIDAD7;
                tasa = 100;
            }
            else {
                comunidadPanel.BackgroundImage = Properties.Resources.COMUNIDAD8;
                tasa = 5;
            }

            return tasa;
        }

        // * * * * * * * * * * * * * * * * * * * * SACAR CARTA DE SIA * * * * * * * * * * * * * * * * * * * * 

        public int randomSIA()
        {
            // Creditos que va a descontar cada carta:
            int idSubject = 0;
            
            // Genera un número aleatorio del 1 al 2 para importar una carta de comunidad diferente.
            Random myObject = new Random();
            int Num = myObject.Next(1, 23);
            idCartaSIA = Num; // Guardamos la carta para comunicarla a los demás.
            if (Num == 1) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA1;
                idSubject = 1;
            }
            else if (Num == 2) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA2;
                idSubject = 3;
            }
            else if (Num == 3) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA3;
                idSubject = 6;
            }
            else if (Num == 4) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA4;
                idSubject = 8;
            }
            else if (Num == 5) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA5;
                idSubject = 9;
            }
            else if (Num == 6) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA6;
                idSubject = 11;
            }
            else if (Num == 7) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA7;
                idSubject = 12;
            }
            else if (Num == 8) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA8;
                idSubject = 14;
            }
            else if (Num == 9) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA9;
                idSubject = 16;
            }
            else if (Num == 10) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA10;
                idSubject = 18;
            }
            else if (Num == 11) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA11;
                idSubject = 19;
            }
            else if (Num == 12) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA12;
                idSubject = 21;
            }
            else if (Num == 13) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA13;
                idSubject = 23;
            }
            else if (Num == 14) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA14;
                idSubject = 24;
            }
            else if (Num == 15) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA15;
                idSubject = 26;
            }
            else if (Num == 16) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA16;
                idSubject = 27;
            }
            else if (Num == 17) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA17;
                idSubject = 29;
            }
            else if (Num == 18) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA18;
                idSubject = 31;
            }
            else if (Num == 19) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA19;
                idSubject = 32;
            }
            else if (Num == 20) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA20;
                idSubject = 34;
            }
            else if (Num == 21) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA21;
                idSubject = 37;
            }
            else {
                SIAPanel.BackgroundImage = Properties.Resources.SIA22;
                idSubject = 39;
            }

            return idSubject; // Devolvemos el ID (Casilla) de la materia que se ha suspendido.
        }

        // GESTIÓN DE LOS TIMERS DE LA INTERFAZ GRÁFICA:

        // (1). Timer para poner la hora en la interfaz gráfica ...
        private void time_Tick(object sender, EventArgs e)
        {
            temps.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        // (2). Timer para tener cronometrados los turnos ...
        private void tiempoTurno_Tick(object sender, EventArgs e)
        {
            // (Solo se verá el tiempo del que esté visible).
            turno1.Text = Convert.ToString(Convert.ToInt32(turno1.Text) - 1);
            turno2.Text = Convert.ToString(Convert.ToInt32(turno2.Text) - 1);
            turno3.Text = Convert.ToString(Convert.ToInt32(turno3.Text) - 1);
            turno4.Text = Convert.ToString(Convert.ToInt32(turno4.Text) - 1);

            // Cuando el tiempo sea cero, se enviará al servidor un aviso de fin de turno.
            // Entonces, el servidor enviará ese aviso a todos los demás conectados.
            // Los demás usarán la función 'gestorDeTurnos(int turno)' para empezar un nuevo turno.
            if ((turno1.Text == "0") && (torn == 1))
            {
                tiempoTurno.Stop();
                // El siguiente turno debe ser el 2.
                // Se envia algo como: '53/Marc-1/2':
                string mensaje = "53/" + user + "-" + idGame + "/" + "2";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Thread.Sleep(200);
                server.Send(msg);
                torn = 2;
            }
            else if ((turno2.Text == "0") && (torn == 2))
            {
                tiempoTurno.Stop();
                // El siguiente turno debe ser el 3.
                // Se envia algo como: '53/Marc-1/3':
                string mensaje = "53/" + user + "-" + idGame + "/" + "3";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Thread.Sleep(200);
                server.Send(msg);
                torn = 3;
            }
            else if ((turno3.Text == "0") && (torn == 3))
            {
                tiempoTurno.Stop();
                // El siguiente turno debe ser el 4.
                // Se envia algo como: '53/Marc-1/4':
                string mensaje = "53/" + user + "-" + idGame + "/" + "4";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Thread.Sleep(200);
                server.Send(msg);
                torn = 4;
            }
            else if ((turno4.Text == "0") && (torn == 4))
            {
                tiempoTurno.Stop();
                // El siguiente turno debe ser el 1.
                // Se envia algo como: '53/Marc-1/1':
                string mensaje = "53/" + user + "-" + idGame + "/" + "1";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Thread.Sleep(200);
                server.Send(msg);
                torn = 1;
            }
        }


        // - - - - - - - - - - - - - - - - - - - - DESCONECTAR - - - - - - - - - - - - - - - - - - - -

        // CERRAR POT BOTÓN.
        private void salir_Click(object sender, EventArgs e)
        {
            // AQUÍ ES COMO SI SE HUBIERA ACABADO LA PARTIDA PARA TODOS:
            // Se acabó la partida. Debemos determinar los ganadores:
            string nomP1; double creditsP1;
            string nomP2; double creditsP2;
            string nomP3; double creditsP3;
            string nomP4; double creditsP4;
            // COLOCAMOS, DE SERIE, AL JUGADOR 1 EN P1 PROVISIONAL:
            nomP1 = nombre1; creditsP1 = creditos1;
            // COMPARAMOS EL JUGADOR 2 CON EL P1 PROVISONAL:
            if (creditos2 > creditsP1)
            {
                nomP1 = nombre2; creditsP1 = creditos2;
                nomP2 = nombre1; creditsP2 = creditos1;
            }
            else
            {
                nomP2 = nombre2; creditsP2 = creditos2;
            }
            // AHORA COMPARAMOS EL 3 CON LOS 2 ANTERIORES:
            if (creditos3 > creditsP1)
            {
                // DESPLAZAMOS EL 1 Y EL 2 ABAJO:
                nomP3 = nomP2; creditsP3 = creditsP2;
                nomP2 = nomP1; creditsP2 = creditsP1;
                nomP1 = nombre3; creditsP1 = creditos3;
            }
            else
            {
                // DEBEMOS COMPARAR ENTRE 2 Y 3:
                if (creditos3 > creditsP2)
                {
                    nomP3 = nomP2; creditsP3 = creditsP2;
                    nomP2 = nombre3; creditsP2 = creditos3;
                }
                else
                {
                    nomP3 = nombre3; creditsP3 = creditos3;
                }
            }
            // FINALMENTE, COMPARAMOS EL 4 CON EL 1, 2 Y 3:
            if (creditos4 > creditsP1)
            {
                // DESPLAZAMOS EL 1, EL 2 Y EL 3 ABAJO:
                nomP4 = nomP3; creditsP4 = creditsP3;
                nomP3 = nomP2; creditsP3 = creditsP2;
                nomP2 = nomP1; creditsP2 = creditsP1;
                nomP1 = nombre4; creditsP1 = creditos4;
            }
            else
            {
                // SI ESTÁ EN SEGUNDO LUGAR:
                if (creditos4 > creditsP2)
                {
                    nomP4 = nomP3; creditsP4 = creditsP3;
                    nomP3 = nomP2; creditsP3 = creditsP2;
                    nomP2 = nombre4; creditsP2 = creditos4;
                }
                else
                {
                    // SI ESTÁ EN TERCER LUGAR:
                    if (creditos4 > creditsP3)
                    {
                        nomP4 = nomP3; creditsP4 = creditsP3;
                        nomP3 = nombre4; creditsP3 = creditos4;
                    }
                    else // Si es el peor, lo colocamos en cuarto lugar.
                    {
                        nomP4 = nombre4; creditsP4 = creditos4;
                    }
                }
            }

            // Se envia algo como: '77/Marc-1/nomP1|cP1|nomP2|cP2|nomP3|cP3|nomP4|cP4':
            string FINPARTIDA = "77/" + user + "-" + idGame + "/" + nomP1 + "|" + creditsP1 + "|" + nomP2 + "|" + creditsP2 + "|" + nomP3 + "|" + creditsP3 + "|" + nomP4 + "|" + creditsP4;
            byte[] finpartida = System.Text.Encoding.ASCII.GetBytes(FINPARTIDA);
            Thread.Sleep(200);
            server.Send(finpartida);

        }

        // CERRAR POR PESTAÑA 'X'.
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            time.Stop();
            tiempoTurno.Stop();
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToString("HH:mm");

            // Se envía: "28/user-IDP/(13:36) Marc: Hola!"
            string mensaje = "28/"+ user +"-" + idGame + "/" + "(" + hora + ") " + user + ": " + escrito.Text;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

            if (escrito.Text == "") // Si se nos olvida rellenar el campo de mensaje...
            {
                MessageBox.Show("¡No has escrito nada!");
            }
            else // Envía el mensaje.
            {
                Thread.Sleep(200);
                server.Send(msg);

                // MOVEMOS EL CHAT DEL QUE ENVÍA:
                message1.Text = message2.Text;
                message2.Text = message3.Text;
                message3.Text = message4.Text;
                message4.Text = "(" + hora + ") " + user + ": " + escrito.Text;

                escrito.Text = "";
            }
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

        // LOCALIZACIÓN ASOCIADA A CADA CASILLA PARA CADA JUGADOR.

        int getCoordinate(string name)
        {
            // Vector con todas las coordenadas.
            int[] listaCoordenadas = { 531, 546, 551, 546, 531, 566, 551, 566, 483, 546, 503, 546, 483, 566, 503, 566, 435, 546, 455, 546, 435, 566, 455, 566, 387, 546, 407, 546, 387, 566, 407, 566, 339, 546, 359, 546, 339, 566, 359, 566, 291, 546, 311, 546, 291, 566, 311, 566, 243, 546, 263, 546, 243, 566, 263, 566, 195, 546, 215, 546, 195, 566, 215, 566, 147, 546, 167, 546, 147, 566, 167, 566, 99, 546, 119, 546, 99, 566, 119, 566, 51, 546, 71, 546, 51, 566, 71, 566, 51, 496, 71, 496, 51, 516, 71, 516, 51, 446, 71, 446, 51, 466, 71, 466, 51, 396, 71, 396, 51, 416, 71, 416, 51, 346, 71, 346, 51, 366, 71, 366, 51, 296, 71, 296, 51, 316, 71, 316, 51, 246, 71, 246, 51, 266, 71, 266, 51, 196, 71, 196, 51, 216, 71, 216, 51, 146, 71, 146, 51, 166, 71, 166, 51, 96, 71, 96, 51, 116, 71, 116, 51, 46, 71, 46, 51, 66, 71, 66, 99, 46, 119, 46, 99, 66, 119, 66, 147, 46, 167, 46, 147, 66, 167, 66, 195, 46, 215, 46, 195, 66, 215, 66, 243, 46, 263, 46, 243, 66, 263, 66, 291, 46, 311, 46, 291, 66, 311, 66, 339, 46, 359, 46, 339, 66, 359, 66, 387, 46, 407, 46, 387, 66, 407, 66, 435, 46, 455, 46, 435, 66, 455, 66, 483, 46, 503, 46, 483, 66, 503, 66, 531, 46, 551, 46, 531, 66, 551, 66, 531, 96, 551, 96, 531, 116, 551, 116, 531, 146, 551, 146, 531, 166, 551, 166, 531, 196, 551, 196, 531, 216, 551, 216, 531, 246, 551, 246, 531, 266, 551, 266, 531, 296, 551, 296, 531, 316, 551, 316, 531, 346, 551, 346, 531, 366, 551, 366, 531, 396, 551, 396, 531, 416, 551, 416, 531, 446, 551, 446, 531, 466, 551, 466, 531, 496, 551, 496, 531, 516, 551, 516 };
            // Vector con los nombres de las coordenadas.
            string[] listaNombres = { "j1c0_X", "j1c0_Y", "j2c0_X", "j2c0_Y", "j3c0_X", "j3c0_Y", "j4c0_X", "j4c0_Y", "j1c1_X", "j1c1_Y", "j2c1_X", "j2c1_Y", "j3c1_X", "j3c1_Y", "j4c1_X", "j4c1_Y", "j1c2_X", "j1c2_Y", "j2c2_X", "j2c2_Y", "j3c2_X", "j3c2_Y", "j4c2_X", "j4c2_Y", "j1c3_X", "j1c3_Y", "j2c3_X", "j2c3_Y", "j3c3_X", "j3c3_Y", "j4c3_X", "j4c3_Y", "j1c4_X", "j1c4_Y", "j2c4_X", "j2c4_Y", "j3c4_X", "j3c4_Y", "j4c4_X", "j4c4_Y", "j1c5_X", "j1c5_Y", "j2c5_X", "j2c5_Y", "j3c5_X", "j3c5_Y", "j4c5_X", "j4c5_Y", "j1c6_X", "j1c6_Y", "j2c6_X", "j2c6_Y", "j3c6_X", "j3c6_Y", "j4c6_X", "j4c6_Y", "j1c7_X", "j1c7_Y", "j2c7_X", "j2c7_Y", "j3c7_X", "j3c7_Y", "j4c7_X", "j4c7_Y", "j1c8_X", "j1c8_Y", "j2c8_X", "j2c8_Y", "j3c8_X", "j3c8_Y", "j4c8_X", "j4c8_Y", "j1c9_X", "j1c9_Y", "j2c9_X", "j2c9_Y", "j3c9_X", "j3c9_Y", "j4c9_X", "j4c9_Y", "j1c10_X", "j1c10_Y", "j2c10_X", "j2c10_Y", "j3c10_X", "j3c10_Y", "j4c10_X", "j4c10_Y", "j1c11_X", "j1c11_Y", "j2c11_X", "j2c11_Y", "j3c11_X", "j3c11_Y", "j4c11_X", "j4c11_Y", "j1c12_X", "j1c12_Y", "j2c12_X", "j2c12_Y", "j3c12_X", "j3c12_Y", "j4c12_X", "j4c12_Y", "j1c13_X", "j1c13_Y", "j2c13_X", "j2c13_Y", "j3c13_X", "j3c13_Y", "j4c13_X", "j4c13_Y", "j1c14_X", "j1c14_Y", "j2c14_X", "j2c14_Y", "j3c14_X", "j3c14_Y", "j4c14_X", "j4c14_Y", "j1c15_X", "j1c15_Y", "j2c15_X", "j2c15_Y", "j3c15_X", "j3c15_Y", "j4c15_X", "j4c15_Y", "j1c16_X", "j1c16_Y", "j2c16_X", "j2c16_Y", "j3c16_X", "j3c16_Y", "j4c16_X", "j4c16_Y", "j1c17_X", "j1c17_Y", "j2c17_X", "j2c17_Y", "j3c17_X", "j3c17_Y", "j4c17_X", "j4c17_Y", "j1c18_X", "j1c18_Y", "j2c18_X", "j2c18_Y", "j3c18_X", "j3c18_Y", "j4c18_X", "j4c18_Y", "j1c19_X", "j1c19_Y", "j2c19_X", "j2c19_Y", "j3c19_X", "j3c19_Y", "j4c19_X", "j4c19_Y", "j1c20_X", "j1c20_Y", "j2c20_X", "j2c20_Y", "j3c20_X", "j3c20_Y", "j4c20_X", "j4c20_Y", "j1c21_X", "j1c21_Y", "j2c21_X", "j2c21_Y", "j3c21_X", "j3c21_Y", "j4c21_X", "j4c21_Y", "j1c22_X", "j1c22_Y", "j2c22_X", "j2c22_Y", "j3c22_X", "j3c22_Y", "j4c22_X", "j4c22_Y", "j1c23_X", "j1c23_Y", "j2c23_X", "j2c23_Y", "j3c23_X", "j3c23_Y", "j4c23_X", "j4c23_Y", "j1c24_X", "j1c24_Y", "j2c24_X", "j2c24_Y", "j3c24_X", "j3c24_Y", "j4c24_X", "j4c24_Y", "j1c25_X", "j1c25_Y", "j2c25_X", "j2c25_Y", "j3c25_X", "j3c25_Y", "j4c25_X", "j4c25_Y", "j1c26_X", "j1c26_Y", "j2c26_X", "j2c26_Y", "j3c26_X", "j3c26_Y", "j4c26_X", "j4c26_Y", "j1c27_X", "j1c27_Y", "j2c27_X", "j2c27_Y", "j3c27_X", "j3c27_Y", "j4c27_X", "j4c27_Y", "j1c28_X", "j1c28_Y", "j2c28_X", "j2c28_Y", "j3c28_X", "j3c28_Y", "j4c28_X", "j4c28_Y", "j1c29_X", "j1c29_Y", "j2c29_X", "j2c29_Y", "j3c29_X", "j3c29_Y", "j4c29_X", "j4c29_Y", "j1c30_X", "j1c30_Y", "j2c30_X", "j2c30_Y", "j3c30_X", "j3c30_Y", "j4c30_X", "j4c30_Y", "j1c31_X", "j1c31_Y", "j2c31_X", "j2c31_Y", "j3c31_X", "j3c31_Y", "j4c31_X", "j4c31_Y", "j1c32_X", "j1c32_Y", "j2c32_X", "j2c32_Y", "j3c32_X", "j3c32_Y", "j4c32_X", "j4c32_Y", "j1c33_X", "j1c33_Y", "j2c33_X", "j2c33_Y", "j3c33_X", "j3c33_Y", "j4c33_X", "j4c33_Y", "j1c34_X", "j1c34_Y", "j2c34_X", "j2c34_Y", "j3c34_X", "j3c34_Y", "j4c34_X", "j4c34_Y", "j1c35_X", "j1c35_Y", "j2c35_X", "j2c35_Y", "j3c35_X", "j3c35_Y", "j4c35_X", "j4c35_Y", "j1c36_X", "j1c36_Y", "j2c36_X", "j2c36_Y", "j3c36_X", "j3c36_Y", "j4c36_X", "j4c36_Y", "j1c37_X", "j1c37_Y", "j2c37_X", "j2c37_Y", "j3c37_X", "j3c37_Y", "j4c37_X", "j4c37_Y", "j1c38_X", "j1c38_Y", "j2c38_X", "j2c38_Y", "j3c38_X", "j3c38_Y", "j4c38_X", "j4c38_Y", "j1c39_X", "j1c39_Y", "j2c39_X", "j2c39_Y", "j3c39_X", "j3c39_Y", "j4c39_X", "j4c39_Y" };

            int coordinate = 0;

            for (int i=0; i<listaNombres.Length; i++)
            {
                if (name == listaNombres[i])
                {
                    coordinate = listaCoordenadas[i];
                    break;
                }
            }

            return coordinate;
        }

        // * * * * * * * * * * * * * * * * * * VARIABLES GLOBALES * * * * * * * * * * * * * * * * * *

        // PRECIOS (0 a 39, 40 en total):
        double[] Precios = { 0, 6 * 26, 0, 3 * 25, 0, 10, 6 * 25, 0, 7.5 * 25, 6 * 25, 0, 6 * 25, 4.5 * 25, 0, 6 * 25, 10, 6 * 25, 0, 6 * 25, 7.5 * 25, 0, 6 * 25, 0, 6 * 25, 3 * 25, 10, 6 * 25, 6 * 25, 0, 7.5 * 25, 0, 6 * 25, 6 * 25, 0, 6 * 25, 10, 0, 6 * 25, 0 * 25, 6 * 25 };
        // De momento solo consideramos los precios de las asignaturas.
        // Las penalizaciones / ganancias por comunidad, suerte, salida, ... las consideraremos despues.
        // Precio Rodalies = 10€.

        // CREDITOS (0 a 39, 40 en total):
        double[] Creditos = { 0, 6, 0, 3, 0, 0, 6, 0, 7.5, 6, 0, 6, 4.5, 0, 6, 0, 6, 0, 6, 7.5, 0, 6, 0, 6, 3, 0, 6, 6, 0, 7.5, 0, 6, 6, 0, 6, 0, 0, 6, 0, 6 };
        // SALIDA, CÁRCEL, BAR, SEGURATA, COMUNIDAD Y SUERTE NO TIENEN CREDITOS:
        // 0, 2, 4, 7, 10, 13, 17, 20, 22, 28, 30, 33, 36, 38. 

        // PROPIETARIOS (0 a 39, 40 en total), al empezar vacíos:
        string[] Owners = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        // SALIDA, CÁRCEL, BAR, SEGURATA, COMUNIDAD Y SUERTE NO PUEDEN TENER PROPIETARIOS:
        // 0, 2, 4, 7, 10, 13, 17, 20, 22, 28, 30, 33, 36, 38. 
        // Suerte: 4, 13, 28, 33, 38.
        // Comunidad: 2, 7, 17, 22, 36.

        // NOMBRES DE LAS CASILLAS:
        string[] Asuntos = { "Salida", "Empresa", "Comunidad", "SEA", "Suerte", "Renfe", "TAE", "Comunidad", "ITA", "EA", "Cárcel", "FT", "Info 2", "Suerte", "PDS", "Renfe", "Càlcul", "Comunidad", "AM1", "AM2", "Bar", "Química", "Comunidad", "Termo", "Meteo", "Renfe", "Física", "Mecànica", "Suerte", "MF", "Segurata", "CTM", "CSD", "Suerte", "SO", "Renfe", "Comunidad", "EG", "Suerte", "Aero" };

        // VECTOR QUE NOS DICE SI UNA CASILLA ES UNA MATERIA O NO:
        bool[] Subject = { false, true, false, true, false, false, true, false, true, true, false, true, true, false, true, false, true, false, true, true, false, true, false, true, true, false, true, true, false, true, false, true, true, false, true, false, false, true, false, true};

        // VECTOR QUE NOS DICE SI UNA CASILLA ES DE SUERTE:
        bool[] CasillasSuerte = { false, false, false, false, true, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, true, false, false, false, false, true, false };

        // VECTOR QUE NOS DICE SI UNA CASILLA ES DE COMUNIDAD:
        bool[] CasillasComunidad = { false, false, true, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false };

        // VECTOR QUE NOS DICE SI UNA CASILLA ES DE RENFE:
        bool[] CasillasRenfe = { false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false };

        // * * * * * * * * * * * * * * FUNCIÓN PARA CADA CASILLA * * * * * * * * * * * * * *

        public void CasillaNueva (int nC, int idUser) // nC: numCasilla.
        {
            double precioComprar = Precios[nC];
            double creditos = Creditos[nC];
            string propietari = Owners[nC];
            string asignatura = Asuntos[nC];

            string jugador = ""; // Apuntamos aquí el nombre del jugador.
            if (idUser == 1)
            {
                jugador = nombre1;
            }
            else if (idUser == 2)
            {
                jugador = nombre2;
            }
            else if (idUser == 3)
            {
                jugador = nombre3;
            }
            else if (idUser == 4)
            {
                jugador = nombre4;
            }

            // ---> CASILLA DEL TIPO SUERTE:
            if (CasillasSuerte[nC] == true) 
            {
                int idCasilla = randomSIA();
                string materia = Asuntos[idCasilla];
                double credits = Creditos[idCasilla];
                if (jugador == Owners[idCasilla]) // Si el que ha caido en Suerte tiene comprada / aprobada la materia que ha suspendido...
                {
                    notificacion.Text = "[Casilla Suerte] ---> Has suspendido " + materia + "! Te descontaremos " + credits + " creditos y dejarás de ser el propietario.";

                    // Avisamos a los demás clientes de que una asignatura deja de tener propietario:
                    // Formato: '61/user-idGame/-1|idPosOwners'
                    int idPosOwners = idCasilla;
                    string aviso = "61/" + user + "-" + idGame + "/-1|" + idPosOwners;
                    byte[] mstge = System.Text.Encoding.ASCII.GetBytes(aviso);
                    Thread.Sleep(200);
                    server.Send(mstge);

                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás de que ha suspendido una materia.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha suspendido materia, con lo que se descuentan credits creditos.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha suspendido "+materia+", con lo que se descuentan "+credits+" creditos.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);

                    Owners[idCasilla] = "";
                    ActualizaGridMaterias();
                    if (idUser == 1)
                    {
                        creditos1 = creditos1 - credits;
                        credits1.Text = Convert.ToString(creditos1);
                        // Mensaje para actualizar los creditos:
                        // Formato: '59/user-idGame/fitxa|creditos'
                        string MNSJ = "59/" + user + "-" + idGame + "/" + idUser + "|" + creditos1;
                        byte[] mnsj = System.Text.Encoding.ASCII.GetBytes(MNSJ);
                        Thread.Sleep(200);
                        server.Send(mnsj);
                    }
                    else if (idUser == 2)
                    {
                        creditos2 = creditos2 - credits;
                        credits2.Text = Convert.ToString(creditos2);
                        // Mensaje para actualizar los creditos:
                        // Formato: '59/user-idGame/fitxa|creditos'
                        string MNSJ = "59/" + user + "-" + idGame + "/" + idUser + "|" + creditos2;
                        byte[] mnsj = System.Text.Encoding.ASCII.GetBytes(MNSJ);
                        Thread.Sleep(200);
                        server.Send(mnsj);
                    }
                    else if (idUser == 3)
                    {
                        creditos3 = creditos3 - credits;
                        credits3.Text = Convert.ToString(creditos3);
                        // Mensaje para actualizar los creditos:
                        // Formato: '59/user-idGame/fitxa|creditos'
                        string MNSJ = "59/" + user + "-" + idGame + "/" + idUser + "|" + creditos3;
                        byte[] mnsj = System.Text.Encoding.ASCII.GetBytes(MNSJ);
                        Thread.Sleep(200);
                        server.Send(mnsj);
                    }
                    else if (idUser == 4)
                    {
                        creditos4 = creditos4 - credits;
                        credits4.Text = Convert.ToString(creditos4);
                        // Mensaje para actualizar los creditos:
                        // Formato: '59/user-idGame/fitxa|creditos'
                        string MNSJ = "59/" + user + "-" + idGame + "/" + idUser + "|" + creditos4;
                        byte[] mnsj = System.Text.Encoding.ASCII.GetBytes(MNSJ);
                        Thread.Sleep(200);
                        server.Send(mnsj);
                    }
                }
                else
                {
                    notificacion.Text = "[Casilla Suerte] ---> Te has salvado! No te quitamos " + materia + " porque aún no la tienes!";
                    
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás de que no ha suspendido una materia.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> ¡Lastima! Como aun no habia aprobado "+materia+", no se le puede suspender.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Lastima! Como aun no habia aprobado " + materia + ", no se le puede suspender.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
            }

            // ---> CASILLA DEL TIPO COMUNIDAD:
            if (CasillasComunidad[nC] == true)
            {
                double dineroTasa = randomComunidad();
                if (idUser == 1)
                {
                    dinero1 = dinero1 + dineroTasa;
                    money1.Text = Convert.ToString(dinero1);
                    // Mensaje para actualizar el dinero:
                    // Formato: '58/user-idGame/fitxa|dinero'
                    string mensaje = "58/" + user + "-" + idGame + "/"+idUser+"|"+dinero1;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                else if (idUser == 2)
                {
                    dinero2 = dinero2 + dineroTasa;
                    money2.Text = Convert.ToString(dinero2);
                    // Mensaje para actualizar el dinero:
                    // Formato: '58/user-idGame/fitxa|dinero'
                    string mensaje = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero2;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                else if (idUser == 3)
                {
                    dinero3 = dinero3 + dineroTasa;
                    money3.Text = Convert.ToString(dinero3);
                    // Mensaje para actualizar el dinero:
                    // Formato: '58/user-idGame/fitxa|dinero'
                    string mensaje = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero3;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                else if (idUser == 4)
                {
                    dinero4 = dinero4 + dineroTasa;
                    money4.Text = Convert.ToString(dinero4);
                    // Mensaje para actualizar el dinero:
                    // Formato: '58/user-idGame/fitxa|dinero'
                    string mensaje = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero4;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }

                if (dineroTasa < 0)
                {
                    notificacion.Text = "[Casilla Comunidad] ---> Se te han descontado correctamente los " + dineroTasa*(-1) + " €!";

                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás de que la delegacion le ha quitado dinero.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> La delegacion le ha descontado +dineroTasa*(-1)+ Euros.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> La delegacion le ha descontado "+dineroTasa+" Euros.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                else
                {
                    notificacion.Text = "[Casilla Comunidad] ---> Se te han añadido correctamente los " + dineroTasa + " €!";

                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás de que la delegacion le ha dado dinero.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> La delegacion le ha pagado +dineroTasa*(-1)+ Euros.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> La delegacion le ha pagado " + dineroTasa + " Euros.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
            }

            // ---> CASILLA DEL TIPO RENFE:
            if (CasillasRenfe[nC] == true) // Si estamos en una casilla del tipo Renfe:
            {
                notificacion.Text = "[Casilla Renfe] ---> Pierdes 100€ por comprar la T-Jove!";

                // NOTIFICACIÓN:
                // ---> Avisamos a los demás de que has caido en la casilla de Renfe.
                // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha comprado la T-Jove, que le ha costado 100 Euros.'
                string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha comprado la T-Jove, que le ha costado 100 Euros.";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                Thread.Sleep(200);
                server.Send(msg);

                if (idUser == 1)
                {
                    dinero1 = dinero1 - 100;
                    money1.Text = Convert.ToString(dinero1);
                    // Mensaje para actualizar el dinero:
                    // Formato: '58/user-idGame/fitxa|dinero'
                    string missatge = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero1;
                    byte[] msge = System.Text.Encoding.ASCII.GetBytes(missatge);
                    Thread.Sleep(200);
                    server.Send(msge);
                }
                else if (idUser == 2)
                {
                    dinero2 = dinero2 - 100;
                    money2.Text = Convert.ToString(dinero2);
                    // Mensaje para actualizar el dinero:
                    // Formato: '58/user-idGame/fitxa|dinero'
                    string missatge = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero2;
                    byte[] msge = System.Text.Encoding.ASCII.GetBytes(missatge);
                    Thread.Sleep(200);
                    server.Send(msge);
                }
                else if (idUser == 3)
                {
                    dinero3 = dinero3 - 100;
                    money3.Text = Convert.ToString(dinero3);
                    // Mensaje para actualizar el dinero:
                    // Formato: '58/user-idGame/fitxa|dinero'
                    string missatge = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero3;
                    byte[] msge = System.Text.Encoding.ASCII.GetBytes(missatge);
                    Thread.Sleep(200);
                    server.Send(msge);
                }
                else if (idUser == 4)
                {
                    dinero4 = dinero4 - 100;
                    money4.Text = Convert.ToString(dinero4);
                    // Mensaje para actualizar el dinero:
                    // Formato: '58/user-idGame/fitxa|dinero'
                    string missatge = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero4;
                    byte[] msge = System.Text.Encoding.ASCII.GetBytes(missatge);
                    Thread.Sleep(200);
                    server.Send(msge);
                }
            }

            // ---> CASILLA DEL TIPO ASIGNATURA:
            // Asignaturas: 1,3,6,8,9,11,12,14,16,18,19,21,23,24,26,27,29,31,32,34,37,39.
            if ((nC == 1) || (nC == 3) || (nC == 6) || (nC == 8) || (nC == 9) || (nC == 11) || (nC == 12) || (nC == 14) || (nC == 16) || (nC == 18) || (nC == 19) || (nC == 21) || (nC == 23) || (nC == 24) || (nC == 26) || (nC == 27) || (nC == 29) || (nC == 31) || (nC == 32) || (nC == 34) || (nC == 37) || (nC == 39))
            {
                // La casilla no tiene propietario:
                if (propietari == "")
                {
                    if (idUser == 1) // La ficha que ha caido en esa casilla es del jugador 1:
                    {
                        if (precioComprar <= dinero1) // El usuario tiene suficiente dinero para comprar la casilla:
                        {
                            // Preguntamos al jugador si quiere comprar (aprobar) la asignatura:
                            DialogResult dr = MessageBox.Show("Do you want to buy " + Asuntos[nC] + "? [Precio: " + Precios[nC] + "] [Créditos: " + Creditos[nC] + "]", "Matrícula EETAC", MessageBoxButtons.YesNo);
                            switch (dr)
                            {
                                case DialogResult.Yes:

                                    // Compramos la asignatura:
                                    dinero1 = dinero1 - precioComprar; // Se le quita el dinero al usuario.
                                    money1.Text = Convert.ToString(dinero1); // Actualizamos el dinero que tiene este usuario.
                                    creditos1 = creditos1 + creditos; // Se le suman los creditos al usuario.
                                    credits1.Text = Convert.ToString(creditos1); // Actualizamos los creditos que tiene este usuario.
                                    Owners[nC] = nombre1; // La casilla pasa a tener propietario.

                                    // Avisamos a los demás clientes de cual es el nuevo propietario de la asignatura:
                                    // Formato: '61/user-idGame/user|idPosOwners'
                                    int idPosOwners = nC;
                                    string aviso = "61/" + user + "-" + idGame + "/" + user + "|" + idPosOwners;
                                    byte[] mstge = System.Text.Encoding.ASCII.GetBytes(aviso);
                                    Thread.Sleep(200);
                                    server.Send(mstge);

                                    // Mensaje para actualizar el dinero:
                                    // Formato: '58/user-idGame/fitxa|dinero'
                                    string missatge = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero1;
                                    byte[] msge = System.Text.Encoding.ASCII.GetBytes(missatge);
                                    Thread.Sleep(200);
                                    server.Send(msge);

                                    // Mensaje para actualizar los creditos:
                                    // Formato: '59/user-idGame/fitxa|creditos'
                                    string MNSJ = "59/" + user + "-" + idGame + "/" + idUser + "|" + creditos1;
                                    byte[] mnsj = System.Text.Encoding.ASCII.GetBytes(MNSJ);
                                    Thread.Sleep(200);
                                    server.Send(mnsj);

                                    // Nos avisamos a nosotros mismos para confirmar:
                                    notificacion.Text = "[Casilla "+Asuntos[nC]+"]---> Has aprobado (ehem, comprado por " + precioComprar+" Euros) "+Asuntos[nC]+". Se te han sumado " +creditos+" Creditos.";

                                    // NOTIFICACIÓN:
                                    // ---> Avisamos a los demás de que has comprado (aprobado) una asignatura.
                                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha aprobado (ehem, comprado por +precioComprar+ Euros) asignatura. Se le han sumado +creditos+ Creditos.'
                                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha aprobado (ehem, comprado por "+precioComprar+ " Euros) "+Asuntos[nC]+". Se le han sumado " + creditos+" Creditos.";
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                                    Thread.Sleep(200);
                                    server.Send(msg);

                                    // Actualizar el DataGrid:
                                    ActualizaGridMaterias();
                                    
                                    // Si totes les matèries estan comprades, i som el jugador 1, s'ha acabat la partida.
                                    int contador = 0;
                                    for (int i = 0; i < 40; i++)
                                    {
                                        if (Owners[i] != "")
                                        {
                                            contador = contador + 1;
                                        }
                                    }
                                    if (contador == 22) // Totes les matèries ja tenen propietari.
                                    {
                                        if (playerID == 1) // Si som el usuari 1 (per evitat que tots li enviin alhora)...
                                        {
                                            // Se acabó la partida. Debemos determinar los ganadores:
                                            string nomP1; double creditsP1;
                                            string nomP2; double creditsP2;
                                            string nomP3; double creditsP3;
                                            string nomP4; double creditsP4;
                                            // COLOCAMOS, DE SERIE, AL JUGADOR 1 EN P1 PROVISIONAL:
                                            nomP1 = nombre1; creditsP1 = creditos1;
                                            // COMPARAMOS EL JUGADOR 2 CON EL P1 PROVISONAL:
                                            if (creditos2 > creditsP1)
                                            {
                                                nomP1 = nombre2; creditsP1 = creditos2;
                                                nomP2 = nombre1; creditsP2 = creditos1;
                                            }
                                            else
                                            {
                                                nomP2 = nombre2; creditsP2 = creditos2;
                                            }
                                            // AHORA COMPARAMOS EL 3 CON LOS 2 ANTERIORES:
                                            if (creditos3 > creditsP1)
                                            {
                                                // DESPLAZAMOS EL 1 Y EL 2 ABAJO:
                                                nomP3 = nomP2; creditsP3 = creditsP2;
                                                nomP2 = nomP1; creditsP2 = creditsP1;
                                                nomP1 = nombre3; creditsP1 = creditos3;
                                            }
                                            else
                                            {
                                                // DEBEMOS COMPARAR ENTRE 2 Y 3:
                                                if (creditos3 > creditsP2)
                                                {
                                                    nomP3 = nomP2; creditsP3 = creditsP2;
                                                    nomP2 = nombre3; creditsP2 = creditos3;
                                                }
                                                else
                                                {
                                                    nomP3 = nombre3; creditsP3 = creditos3;
                                                }
                                            }
                                            // FINALMENTE, COMPARAMOS EL 4 CON EL 1, 2 Y 3:
                                            if (creditos4 > creditsP1)
                                            {
                                                // DESPLAZAMOS EL 1, EL 2 Y EL 3 ABAJO:
                                                nomP4 = nomP3; creditsP4 = creditsP3;
                                                nomP3 = nomP2; creditsP3 = creditsP2;
                                                nomP2 = nomP1; creditsP2 = creditsP1;
                                                nomP1 = nombre4; creditsP1 = creditos4;
                                            }
                                            else
                                            {
                                                // SI ESTÁ EN SEGUNDO LUGAR:
                                                if (creditos4 > creditsP2)
                                                {
                                                    nomP4 = nomP3; creditsP4 = creditsP3;
                                                    nomP3 = nomP2; creditsP3 = creditsP2;
                                                    nomP2 = nombre4; creditsP2 = creditos4;
                                                }
                                                else
                                                {
                                                    // SI ESTÁ EN TERCER LUGAR:
                                                    if (creditos4 > creditsP3)
                                                    {
                                                        nomP4 = nomP3; creditsP4 = creditsP3;
                                                        nomP3 = nombre4; creditsP3 = creditos4;
                                                    }
                                                    else // Si es el peor, lo colocamos en cuarto lugar.
                                                    {
                                                        nomP4 = nombre4; creditsP4 = creditos4;
                                                    }
                                                }
                                            }

                                            // Se envia algo como: '77/Marc-1/nomP1|cP1|nomP2|cP2|nomP3|cP3|nomP4|cP4':
                                            string FINPARTIDA = "77/" + user + "-" + idGame + "/" + nomP1 + "|" + creditsP1 + "|" + nomP2 + "|" + creditsP2 + "|" + nomP3 + "|" + creditsP3 + "|" + nomP4 + "|" + creditsP4;
                                            byte[] finpartida = System.Text.Encoding.ASCII.GetBytes(FINPARTIDA);
                                            Thread.Sleep(200);
                                            server.Send(finpartida);
                                        }
                                    }

                                    break;

                                case DialogResult.No:
                                    // ¡No hace nada!
                                    break;
                            }
                        }
                    }

                    // LO MISMO PARA USER 2:

                    else if (idUser == 2) // La ficha que ha caido en esa casilla es del jugador 1:
                    {
                        if (precioComprar <= dinero2) // El usuario tiene suficiente dinero para comprar la casilla:
                        {
                            // Preguntamos al jugador si quiere comprar (aprobar) la asignatura:
                            DialogResult dr = MessageBox.Show("Do you want to buy " + Asuntos[nC] + "? [Precio: " + Precios[nC] + "] [Créditos: " + Creditos[nC] + "]", "Matrícula EETAC", MessageBoxButtons.YesNo);
                            switch (dr)
                            {
                                case DialogResult.Yes:

                                    // Compramos la asignatura:
                                    dinero2 = dinero2 - precioComprar; // Se le quita el dinero al usuario.
                                    money2.Text = Convert.ToString(dinero2); // Actualizamos el dinero que tiene este usuario.
                                    creditos2 = creditos2 + creditos; // Se le suman los creditos al usuario.
                                    credits2.Text = Convert.ToString(creditos2); // Actualizamos los creditos que tiene este usuario.
                                    Owners[nC] = nombre2; // La casilla pasa a tener propietario.

                                    // Avisamos a los demás clientes de cual es el nuevo propietario de la asignatura:
                                    // Formato: '61/user-idGame/user|idPosOwners'
                                    int idPosOwners = nC;
                                    string aviso = "61/" + user + "-" + idGame + "/" + user + "|" + idPosOwners;
                                    byte[] mstge = System.Text.Encoding.ASCII.GetBytes(aviso);
                                    Thread.Sleep(200);
                                    server.Send(mstge);

                                    // Mensaje para actualizar el dinero:
                                    // Formato: '58/user-idGame/fitxa|dinero'
                                    string missatge = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero2;
                                    byte[] msge = System.Text.Encoding.ASCII.GetBytes(missatge);
                                    Thread.Sleep(200);
                                    server.Send(msge);

                                    // Mensaje para actualizar los creditos:
                                    // Formato: '59/user-idGame/fitxa|creditos'
                                    string MNSJ = "59/" + user + "-" + idGame + "/" + idUser + "|" + creditos2;
                                    byte[] mnsj = System.Text.Encoding.ASCII.GetBytes(MNSJ);
                                    Thread.Sleep(200);
                                    server.Send(mnsj);

                                    // Nos avisamos a nosotros mismos para confirmar:
                                    notificacion.Text = "[Casilla " + Asuntos[nC] + "]---> Has aprobado (ehem, comprado por " + precioComprar + " Euros) " + Asuntos[nC] + ". Se te han sumado " + creditos + " Creditos.";

                                    // NOTIFICACIÓN:
                                    // ---> Avisamos a los demás de que has comprado (aprobado) una asignatura.
                                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha aprobado (ehem, comprado por +precioComprar+ Euros) asignatura. Se le han sumado +creditos+ Creditos.'
                                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha aprobado (ehem, comprado por " + precioComprar + " Euros) " + Asuntos[nC] + ". Se le han sumado " + creditos + " Creditos.";
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                                    Thread.Sleep(200);
                                    server.Send(msg);

                                    // !!!!!!!!!!
                                    // ACTUALIZAR PROPIETARIOS:
                                    // Hay que enviar: Owners (y que todos los demás actualizen su DGV).
                                    // !!!!!!!!!!

                                    // Actualizar el DataGrid:
                                    ActualizaGridMaterias();
                                    break;

                                case DialogResult.No:
                                    // ¡No hace nada!
                                    break;
                            }
                        }
                    }

                    // LO MISMO PARA USER 3:

                    else if (idUser == 3) // La ficha que ha caido en esa casilla es del jugador 1:
                    {
                        if (precioComprar <= dinero1) // El usuario tiene suficiente dinero para comprar la casilla:
                        {
                            // Preguntamos al jugador si quiere comprar (aprobar) la asignatura:
                            DialogResult dr = MessageBox.Show("Do you want to buy " + Asuntos[nC] + "? [Precio: " + Precios[nC] + "] [Créditos: " + Creditos[nC] + "]", "Matrícula EETAC", MessageBoxButtons.YesNo);
                            switch (dr)
                            {
                                case DialogResult.Yes:

                                    // Compramos la asignatura:
                                    dinero3 = dinero3 - precioComprar; // Se le quita el dinero al usuario.
                                    money3.Text = Convert.ToString(dinero3); // Actualizamos el dinero que tiene este usuario.
                                    creditos3 = creditos3 + creditos; // Se le suman los creditos al usuario.
                                    credits3.Text = Convert.ToString(creditos3); // Actualizamos los creditos que tiene este usuario.
                                    Owners[nC] = nombre3; // La casilla pasa a tener propietario.

                                    // Avisamos a los demás clientes de cual es el nuevo propietario de la asignatura:
                                    // Formato: '61/user-idGame/user|idPosOwners'
                                    int idPosOwners = nC;
                                    string aviso = "61/" + user + "-" + idGame + "/" + user + "|" + idPosOwners;
                                    byte[] mstge = System.Text.Encoding.ASCII.GetBytes(aviso);
                                    Thread.Sleep(200);
                                    server.Send(mstge);

                                    // Mensaje para actualizar el dinero:
                                    // Formato: '58/user-idGame/fitxa|dinero'
                                    string missatge = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero3;
                                    byte[] msge = System.Text.Encoding.ASCII.GetBytes(missatge);
                                    Thread.Sleep(200);
                                    server.Send(msge);

                                    // Mensaje para actualizar los creditos:
                                    // Formato: '59/user-idGame/fitxa|creditos'
                                    string MNSJ = "59/" + user + "-" + idGame + "/" + idUser + "|" + creditos3;
                                    byte[] mnsj = System.Text.Encoding.ASCII.GetBytes(MNSJ);
                                    Thread.Sleep(200);
                                    server.Send(mnsj);

                                    // Nos avisamos a nosotros mismos para confirmar:
                                    notificacion.Text = "[Casilla " + Asuntos[nC] + "]---> Has aprobado (ehem, comprado por " + precioComprar + " Euros) " + Asuntos[nC] + ". Se te han sumado " + creditos + " Creditos.";

                                    // NOTIFICACIÓN:
                                    // ---> Avisamos a los demás de que has comprado (aprobado) una asignatura.
                                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha aprobado (ehem, comprado por +precioComprar+ Euros) asignatura. Se le han sumado +creditos+ Creditos.'
                                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha aprobado (ehem, comprado por " + precioComprar + " Euros) " + Asuntos[nC] + ". Se le han sumado " + creditos + " Creditos.";
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                                    Thread.Sleep(200);
                                    server.Send(msg);

                                    // !!!!!!!!!!
                                    // ACTUALIZAR PROPIETARIOS:
                                    // Hay que enviar: Owners (y que todos los demás actualizen su DGV).
                                    // !!!!!!!!!!

                                    // Actualizar el DataGrid:
                                    ActualizaGridMaterias();
                                    break;

                                case DialogResult.No:
                                    // ¡No hace nada!
                                    break;
                            }
                        }
                    }

                    // LO MISMO PARA USER 4:

                    else if (idUser == 4) // La ficha que ha caido en esa casilla es del jugador 1:
                    {
                        if (precioComprar <= dinero4) // El usuario tiene suficiente dinero para comprar la casilla:
                        {
                            // Preguntamos al jugador si quiere comprar (aprobar) la asignatura:
                            DialogResult dr = MessageBox.Show("Do you want to buy " + Asuntos[nC] + "? [Precio: " + Precios[nC] + "] [Créditos: " + Creditos[nC] + "]", "Matrícula EETAC", MessageBoxButtons.YesNo);
                            switch (dr)
                            {
                                case DialogResult.Yes:

                                    // Compramos la asignatura:
                                    dinero4 = dinero4 - precioComprar; // Se le quita el dinero al usuario.
                                    money4.Text = Convert.ToString(dinero4); // Actualizamos el dinero que tiene este usuario.
                                    creditos4 = creditos4 + creditos; // Se le suman los creditos al usuario.
                                    credits4.Text = Convert.ToString(creditos4); // Actualizamos los creditos que tiene este usuario.
                                    Owners[nC] = nombre4; // La casilla pasa a tener propietario.

                                    // Avisamos a los demás clientes de cual es el nuevo propietario de la asignatura:
                                    // Formato: '61/user-idGame/user|idPosOwners'
                                    int idPosOwners = nC;
                                    string aviso = "61/" + user + "-" + idGame + "/" + user + "|" + idPosOwners;
                                    byte[] mstge = System.Text.Encoding.ASCII.GetBytes(aviso);
                                    Thread.Sleep(200);
                                    server.Send(mstge);

                                    // Mensaje para actualizar el dinero:
                                    // Formato: '58/user-idGame/fitxa|dinero'
                                    string missatge = "58/" + user + "-" + idGame + "/" + idUser + "|" + dinero4;
                                    byte[] msge = System.Text.Encoding.ASCII.GetBytes(missatge);
                                    Thread.Sleep(200);
                                    server.Send(msge);

                                    // Mensaje para actualizar los creditos:
                                    // Formato: '59/user-idGame/fitxa|creditos'
                                    string MNSJ = "59/" + user + "-" + idGame + "/" + idUser + "|" + creditos4;
                                    byte[] mnsj = System.Text.Encoding.ASCII.GetBytes(MNSJ);
                                    Thread.Sleep(200);
                                    server.Send(mnsj);

                                    // Nos avisamos a nosotros mismos para confirmar:
                                    notificacion.Text = "[Casilla " + Asuntos[nC] + "]---> Has aprobado (ehem, comprado por " + precioComprar + " Euros) " + Asuntos[nC] + ". Se te han sumado " + creditos + " Creditos.";

                                    // NOTIFICACIÓN:
                                    // ---> Avisamos a los demás de que has comprado (aprobado) una asignatura.
                                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha aprobado (ehem, comprado por +precioComprar+ Euros) asignatura. Se le han sumado +creditos+ Creditos.'
                                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha aprobado (ehem, comprado por " + precioComprar + " Euros) " + Asuntos[nC] + ". Se le han sumado " + creditos + " Creditos.";
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                                    Thread.Sleep(200);
                                    server.Send(msg);

                                    // !!!!!!!!!!
                                    // ACTUALIZAR PROPIETARIOS:
                                    // Hay que enviar: Owners (y que todos los demás actualizen su DGV).
                                    // !!!!!!!!!!

                                    // Actualizar el DataGrid:
                                    ActualizaGridMaterias();
                                    break;

                                case DialogResult.No:
                                    // ¡No hace nada!
                                    break;
                            }
                        }
                    }
                }
            }
        }

        // * * * * * * * * * * * * * * * * * * FUNCIÓN PARA MOVER UNA FICHA * * * * * * * * * * * * * * * * * * * * * * 

        public void moverFicha(int desplazamiento)
        {

            int numMov = desplazamiento; // AQUÍ PONEMOS CUANTAS CASILLAS SE DESPLAZA.
            string PosX = ""; // Por ejemplo, 'j1c38_X'.
            string PosY = ""; // Por ejemplo, 'j1c38_Y'.

            if (playerID == 1)
            {
                casilla1 = casilla1 + numMov;
                if (casilla1 >= 40) // CUANDO LLEGAS O PASAS POR LA SALIDA.
                {
                    casilla1 = casilla1 - 40;
                    dinero1 = dinero1 + 500;
                    money1.Text = Convert.ToString(dinero1);
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás del paso por casilla.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500 Euros.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha pasado por meta. Gana 500 Euros.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                else if (casilla1 == 30) // SI CAES EN EL SEGURATA.
                {
                    // Te manda a la cárcel:
                    casilla1 = 10;
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás de que has sido enviado a la cárcel.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Era el noveno en la mesa de la cafeteria, y el segurata lo ha hecho marchar a la carcel.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Era el noveno en la mesa de la cafeteria, y el segurata lo ha hecho marchar a la carcel.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                PosX = $"j{playerID}c{casilla1}_X";
                PosY = $"j{playerID}c{casilla1}_Y";
            }

            else if (playerID == 2)
            {
                casilla2 = casilla2 + numMov;
                if (casilla2 >= 40) // CUANDO LLEGAS A LA SALIDA.
                {
                    casilla2 = casilla2 - 40;
                    // Bonificamos al jugador por el paso por meta:
                    dinero2 = dinero2 + 500;
                    money2.Text = Convert.ToString(dinero2);
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás del paso por casilla.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500 Euros.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha pasado por meta. Gana 500 Euros.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                else if (casilla2 == 30) // SI CAES EN EL SEGURATA.
                {
                    // Te manda a la cárcel:
                    casilla2 = 10;
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás de que has sido enviado a la cárcel.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Era el noveno en la mesa de la cafeteria, y el segurata lo ha hecho marchar a la carcel.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Era el noveno en la mesa de la cafeteria, y el segurata lo ha hecho marchar a la carcel.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                PosX = $"j{playerID}c{casilla2}_X";
                PosY = $"j{playerID}c{casilla2}_Y";
            }

            else if (playerID == 3)
            {
                casilla3 = casilla3 + numMov;
                if (casilla3 >= 40) // CUANDO LLEGAS A LA SALIDA.
                {
                    casilla3 = casilla3 - 40;
                    // Bonificamos al jugador por el paso por meta:
                    dinero3 = dinero3 + 500;
                    money3.Text = Convert.ToString(dinero3);
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás del paso por casilla.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500 Euros.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha pasado por meta. Gana 500 Euros.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                else if (casilla3 == 30) // SI CAES EN EL SEGURATA.
                {
                    // Te manda a la cárcel:
                    casilla3 = 10;
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás de que has sido enviado a la cárcel.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Era el noveno en la mesa de la cafeteria, y el segurata lo ha hecho marchar a la carcel.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Era el noveno en la mesa de la cafeteria, y el segurata lo ha hecho marchar a la carcel.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                PosX = $"j{playerID}c{casilla3}_X";
                PosY = $"j{playerID}c{casilla3}_Y";
            }

            else if (playerID == 4)
            {
                casilla4 = casilla4 + numMov;
                if (casilla4 >= 40) // CUANDO LLEGAS A LA SALIDA.
                {
                    casilla4 = casilla4 - 40;
                    // Bonificamos al jugador por el paso por meta:
                    dinero4 = dinero4 + 500;
                    money4.Text = Convert.ToString(dinero4);
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás del paso por casilla.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Ha pasado por meta. Gana 500 Euros.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Ha pasado por meta. Gana 500 Euros.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                else if (casilla4 == 30) // SI CAES EN EL SEGURATA.
                {
                    // Te manda a la cárcel:
                    casilla4 = 10;
                    // NOTIFICACIÓN:
                    // ---> Avisamos a los demás de que has sido enviado a la cárcel.
                    // Formato: '52/Marc-1/[JUGADOR 1: Marc] -> Era el noveno en la mesa de la cafeteria, y el segurata lo ha hecho marchar a la carcel.'
                    string mensaje = "52/" + user + "-" + idGame + "/" + "[JUGADOR " + playerID + ": " + user + "] -> Era el noveno en la mesa de la cafeteria, y el segurata lo ha hecho marchar a la carcel.";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    Thread.Sleep(200);
                    server.Send(msg);
                }
                PosX = $"j{playerID}c{casilla4}_X";
                PosY = $"j{playerID}c{casilla4}_Y";
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // DEBEMOS ENVIAR LA NUEVA POSICION DE LA FICHA A LOS DEMÁS:
            // 'PosX' es un string con formato 'j1c38_X'.
            // 'PosY' es un string con formato 'j1c38_Y'.
            // Formato del mensaje: '54/Marc-1/numFicha|PosX|PosY'.
            string aviso = "54/" + user + "-" + idGame + "/" + playerID + "|" + PosX + "|" + PosY;
            byte[] msge = System.Text.Encoding.ASCII.GetBytes(aviso);
            Thread.Sleep(200);
            server.Send(msge);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            int posX = getCoordinate(PosX);
            int posY = getCoordinate(PosY);

            if (playerID == 1)
            {
                fitxa1.Location = new Point(posX, posY);
                // FUNCIÓN QUE HACE LO QUE CORRESPONDE PARA CADA CASILLA:
                CasillaNueva(casilla1, Convert.ToInt32(playerID));
            }
            else if (playerID == 2)
            {
                fitxa2.Location = new Point(posX, posY);
                // FUNCIÓN QUE HACE LO QUE CORRESPONDE PARA CADA CASILLA:
                CasillaNueva(casilla2, Convert.ToInt32(playerID));
            }
            else if (playerID == 3)
            {
                fitxa3.Location = new Point(posX, posY);
                // FUNCIÓN QUE HACE LO QUE CORRESPONDE PARA CADA CASILLA:
                CasillaNueva(casilla3, Convert.ToInt32(playerID));
            }
            else if (playerID == 4)
            {
                fitxa4.Location = new Point(posX, posY);
                // FUNCIÓN QUE HACE LO QUE CORRESPONDE PARA CADA CASILLA:
                CasillaNueva(casilla4, Convert.ToInt32(playerID));
            }
        }

        // * * * * * * * * * * * * * * * * * * * PULSAMOS EN EL DADO PARA TIRAR LOS DADOS: * * * * * * * * * * * * * * * * * * * 

        private void dado_Click(object sender, EventArgs e)
        {
            Random myObject = new Random();

            int Num = myObject.Next(1, 6);
            if (Num == 1)
            {
                dado.BackgroundImage = Properties.Resources.Dado_1;
                moverFicha(1);
            }
            else if (Num == 2)
            {
                dado.BackgroundImage = Properties.Resources.Dado_2;
                moverFicha(2);
            }
            else if (Num == 3)
            {
                dado.BackgroundImage = Properties.Resources.Dado_3;
                moverFicha(3);
            }
            else if (Num == 4)
            {
                dado.BackgroundImage = Properties.Resources.Dado_4;
                moverFicha(4);
            }
            else if (Num == 5)
            {
                dado.BackgroundImage = Properties.Resources.Dado_5;
                moverFicha(5);
            }
            else
            { // (Num == 6)
                dado.BackgroundImage = Properties.Resources.Dado_6;
                moverFicha(6);
            }

            // Desactivamos el dado (solo se puede usar una vez) ...
            dado.Enabled = false;

        }

        private void cerrarPartida_Click(object sender, EventArgs e)
        {
            // SOLO EL JUGADOR 1 DE CADA PARTIDA VA A ENVIAR LA INFORMACIÓN DE LA PARTIDA:
            if (playerID == 1)
            {
                // Debemos obtener la fecha actual de la partida:
                string Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                // Se envia algo como: '99/nombreGanador-FechaPartida,':
                string GuardarPartida = "99/" + nP1 + "-" + Fecha + ",";
                byte[] guardarPartida = System.Text.Encoding.ASCII.GetBytes(GuardarPartida);
                Thread.Sleep(200);
                server.Send(guardarPartida);
            }

            // GANADOR + FECHA -> IDPARTIDA
            string winner = nP1;
            string data = DateTime.Now.ToString("dd/MM/yyyy");

            // NOM -> IDJUGADOR
            string name = user;
            

            // CREDITOS TUYOS -> PARTICIPACION
            double CreditosMios = 0;
            if (playerID == 1)
            {
                CreditosMios = creditos1;
            }
            if (playerID == 2)
            {
                CreditosMios = creditos2;
            }
            if (playerID == 3)
            {
                CreditosMios = creditos3;
            }
            if (playerID == 4)
            {
                CreditosMios = creditos4;
            }
            
            int misCreditos = Convert.ToInt32(Math.Round(CreditosMios));

            // Formato: '97/ganador-fecha-username-creditos,'.
            string guardarParticipacion = "97/" + winner + "-" + data + "-" + name + "-" + misCreditos + ",";
            byte[] Participacion = System.Text.Encoding.ASCII.GetBytes(guardarParticipacion);
            Thread.Sleep(200);
            server.Send(Participacion);

            time.Stop();
            tiempoTurno.Stop();
            Close();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }
}
