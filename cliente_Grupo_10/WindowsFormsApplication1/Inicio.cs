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
using WindowsFormsApplication1;
using System.Windows;

namespace WindowsFormsApplication1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        // - - - - - - - - - - - - - - - - - - - - PARÁMETROS - - - - - - - - - - - - - - - - - - - -

        // >>> [1]. Identificación del usuario que está usando el programa de cliente.
        string user;
        string password;

        // >>> [2]. Servidor:
        Socket server;

        // >>> [3]. Para saber si ya hemos conectado con el servidor...
        bool initialConnection = false;

        // >>> [4]. Bind del Servidor:
        // ---> Entorno de producción:
        int bind = 50080;
        // ---> Entorno de desarroyo:
        // int bind = 9011;

        // >>> [5]. IP del Servidor:
        // ---> Entorno de producción:
        string DirIP = "147.83.117.22";
        // ---> Entorno de desarroyo:
        // string DirIP = "192.168.56.102";

        // - - - - - - - - - - - - - - - - - - - - - CARGA DEL FORMULARIO - - - - - - - - - - - - - - - - - - - - -

        private void Inicio_Load_1(object sender, EventArgs e)
        {
            textMin.Visible = false;
            textSec.Visible = false;
            tempsMin.Visible = false;
            tempsSec.Visible = false;
            nom.Visible = false;
            this.BackgroundImage = Properties.Resources.Inicio_Fondo;
            // Timer para contar cuanto tiempo se juega a la partida:
            tempsPartida.Interval = 1000;
            tempsSec.Text = "0";
            tempsMin.Text = "0";

            // MÉTODO PARA QUE SE ABRA EL FORMULARIO EN EL CENTRO DE CUALQUIER PANTALLA.
            // (Sea cual sea el tamaño de la pantalla).
            int screenH = Screen.PrimaryScreen.Bounds.Height;
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int formH = 275;
            int formW = 540;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point ((screenW/2-formW/2), (screenH/2 - formH/2));

            // BLOQUEA EL MOVIMIENTO DEL FORMULARIO.
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        // - - - - - - - - - - - - - - - - - - - - CLICK AL BOTÓN 'ENVIAR' - - - - - - - - - - - - - - - - - - - -

        private void enviar_Click(object sender, EventArgs e)
        {
            if (Login.Checked)
            {
                if (initialConnection == false)
                {
                    IPAddress direc = IPAddress.Parse(DirIP);
                    IPEndPoint ipep = new IPEndPoint(direc, bind);

                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);

                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show("[!] No se ha podido conectar con el servidor! [!]");
                        return;
                    }

                    initialConnection = true;
                }

                if (((userLogin.Text == "") && (contraLogin.Text == "")) || ((userLogin.Text == "") || (contraLogin.Text == "")))
                {
                    MessageBox.Show("[!] Debes llenar ambos campos para poder hacer el Login. [!]");
                }
                else
                {
                    string mensaje = "4/" + userLogin.Text + "/" + contraLogin.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    
                    byte[] msg2 = new byte[80];

                    server.Receive(msg2);
                    string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                    int codigo = Convert.ToInt32(trozos[0]);
                    mensaje = trozos[1].Split('\0')[0];
                    if (mensaje == "0\n")
                    {
                        MessageBox.Show("[!] Logueado Satisfactoriamente. Se ha conecado con el Servidor y la BBDD. [!]");
                        // Guarda el nombre del usuario y la contraseña en esta simulación.
                        user = userLogin.Text;
                        password = contraLogin.Text;
                        userLogin.Text = "";
                        contraLogin.Text = "";

                        // Vamos directamente al Menú del juego:

                        Home form = new Home();
                        // Pasamos la conexión, el usuario y la contraseña al menú principal.
                        form.SetConnection(server);
                        form.SetUserAndPassword(user, password);
                        form.Show();
                        tempsPartida.Start(); // Se empieza a contar el tiempo de juego.

                        // DEJAMOS EL FORMULARIO PREPARADO PARA LA DESPEDIDA:

                        Register.Visible = false;
                        Login.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        enviar.Visible = false;
                        userRegister.Visible = false;
                        userLogin.Visible = false;
                        contraLogin.Visible = false;
                        contraRegister.Visible = false;
                        int width = 231;
                        int height = 23;
                        cerrar.Size = new Size(width, height);
                        cerrar.Location = new Point(149, 200);
                        this.BackgroundImage = Properties.Resources.Despedida_3;
                        textMin.Visible = true;
                        textSec.Visible = true;
                        tempsMin.Visible = true;
                        tempsSec.Visible = true;
                        nom.Visible = true;
                        nom.Text = user;

                        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

                    }
                    else if (mensaje == "-1\n")
                    {
                        MessageBox.Show("[!] ERROR en el Logueo. [!]");
                    }
                }
            }

            // ---> PETICIÓN DE REGISTRARSE EN LA BASE DE DATOS (Radio Button): - - - - - - - - - -

            else if (Register.Checked)
            {
                if (initialConnection == false)
                {
                    IPAddress direc = IPAddress.Parse(DirIP);
                    IPEndPoint ipep = new IPEndPoint(direc, bind);

                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    try
                    {
                        server.Connect(ipep);
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show("[!] No se ha podido conectar con el servidor! [!]");
                        return;
                    }

                    initialConnection = true;
                }

                if (((userRegister.Text == "") && (contraRegister.Text == "")) || ((userRegister.Text == "") || (contraRegister.Text == "")))
                {
                    MessageBox.Show("[!] Debes llenar ambos campos para poder hacer el Registro. [!]");
                }
                else
                {
                    string mensaje = "5/" + userRegister.Text + "/" + contraRegister.Text;
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');
                    mensaje = trozos[1].Split('\0')[0];

                    if (mensaje == "0\n")
                    {
                        MessageBox.Show("[!] Registrado Satisfactoriamente. [!]");
                        userRegister.Text = "";
                        contraRegister.Text = "";
                    }
                    else if (mensaje == "1\n")
                    {
                        MessageBox.Show("[!] Ya existe este usuario. [!]");
                    }
                    else if (mensaje == "-1\n")
                    {
                        MessageBox.Show("[!] ERROR en el Registro. [!]");
                    }
                    else
                        MessageBox.Show("[!] Error no identificado [!]");
                }
            }
        }

        // - - - - - - - - - - - - - - SE CIERRA DESDE EL FORM HOME - - - - - - - - - - - - - - - - 

        // CERRAR POR BOTÓN.
        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            tempsPartida.Stop();
        }
        // PARA CERRAR DESDE HOME.
        public void CloseInicio()
        {
            this.Close();
            tempsPartida.Stop();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        // CERRAR POR PESTAÑA 'X'.
        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            // No se debe hacer nada en especial, y ya la función cierra sola el formulario.
        }

        private void tempsPartida_Tick(object sender, EventArgs e)
        {
            int minutes = Convert.ToInt32(tempsMin.Text);
            int seconds = Convert.ToInt32(tempsSec.Text);
            seconds = seconds + 1;
            if (seconds == 60)
            {
                seconds = 0;
                minutes = minutes + 1;
            }
            tempsMin.Text = Convert.ToString(minutes);
            tempsSec.Text = Convert.ToString(seconds);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

}
