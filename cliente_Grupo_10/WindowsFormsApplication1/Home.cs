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

        // Booleans:
        bool Loged = false;
        bool Connect = false;
        bool Conect_Click = false;


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
                    case 1: //respuesta a peticion 1
                        
                        MessageBox.Show(user + " tiene " + mensaje + " puntos después de ganar el día " + fechaPartida.Text);
                        break;

                    case 2: //respuesta a peticion 2
                        
                        MessageBox.Show(user + " ha jugado " + mensaje + " partidas.");
                        break;

                    case 3: //respuesta a peticion 3
                        
                        MessageBox.Show(user + " ha ganado a: " + mensaje);
                        break;

                    case 5: //respuesta a peticion 5
                        
                        MessageBox.Show(user + " tiene " + mensaje + " puntos después de ganar el día " + fechaPartida.Text);
                        break;

                    case 6: // notificacion

                        DelegadoParaEscribir delegado = new DelegadoParaEscribir(PonListaConectados);
                        gridListaConectados.Invoke(delegado, new object[] {mensaje});
                        break;

                }
            }

        }


        public void PonListaConectados(string mensaje)
        {
            gridListaConectados.Rows.Clear();
            gridListaConectados.ColumnCount = 1;
            gridListaConectados.ColumnHeadersVisible = true;
            MessageBox.Show(mensaje);
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

        private void Desconectar_Click(object sender, EventArgs e)
        {
            atender.Abort();
            string mensaje = "0/"+ user; 
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
                    // CANVI ***********************************************************************************************
                    /**
                                        byte[] msg2 = new byte[80];
                                        server.Receive(msg2);
                                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                                        MessageBox.Show(user + " tiene " + mensaje + " puntos después de ganar el día " + fechaPartida.Text);
                    **/
                    // CANVI ***********************************************************************************************
                }

            }
            // ---> PETICIÓN DE MARC A LA BASE DE DATOS (Radio Button): - - - - - - - - - -
            else if (Petición_Marc.Checked)
            {
                string mensaje = "2/" + user;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                // CANVI ***********************************************************************************************
                /**
                                    byte[] msg2 = new byte[80];
                                    server.Receive(msg2);
                                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                                    MessageBox.Show(user + " ha jugado " + mensaje + " partidas.");
                **/
                // CANVI ***********************************************************************************************
            }

            // ---> PETICIÓN DE ELOI A LA BASE DE DATOS (Radio Button): - - - - - - - - - -

            else if (Petición_Eloi.Checked)
            {
                // NO ESTÀ FET.
                string mensaje = "3/" + user;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                // CANVI ***********************************************************************************************
                /**
                                byte[] msg2 = new byte[80];
                                server.Receive(msg2);
                                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                                MessageBox.Show(user + " ha ganado a: " + mensaje);
                **/
                // CANVI ***********************************************************************************************
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void openGame_Click(object sender, EventArgs e)
        {
            interfaz_Grafica frm = new interfaz_Grafica();
            frm.Show();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void dameLista_Click(object sender, EventArgs e)
        {
            string mensaje = "6/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            byte[] msg2 = new byte[100];
            server.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];

            // Creamos la dataGridView. En cada línea añade el nombre de los usuarios conectados
            gridListaConectados.Rows.Clear();
            gridListaConectados.ColumnCount = 1;
            gridListaConectados.ColumnHeadersVisible = true;
            MessageBox.Show(mensaje);
            if (mensaje != null)
            {
                char delimeter = '/';
                string[] split = mensaje.Split(delimeter);
                int i = 1;
                while (i < split.Length)
                {
                    gridListaConectados.Rows.Add(split[i]);
                    i = i + 1;
                }
                gridListaConectados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }
}
