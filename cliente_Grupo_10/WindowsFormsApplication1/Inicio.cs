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

namespace WindowsFormsApplication1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        // - - - - - - - - - - - - - - - - - - - - PARÁMETROS - - - - - - - - - - - - - - - - - - - -

        // 1. Identificación del usuario que está usando el programa de cliente.
        string user;
        string password;

        // 2. Servidor:
        Socket server;

        // 3. Para saber si ya hemos conectado con el servidor...
        bool initialConnection = false;

        // 4. Bind del Servidor (para no tener que cambiarlo cada vez tanto en Register como en LogIn:
        int bind = 50080;

        // - - - - - - - - - - - - - - - - - - - - CLICK AL BOTÓN 'ENVIAR' - - - - - - - - - - - - - - - - - - - -
        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        

        private void enviar_Click(object sender, EventArgs e)
        {
            if (Login.Checked)
            {
                if (initialConnection == false)
                {
                    IPAddress direc = IPAddress.Parse("147.83.117.22");
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
                    if (mensaje == "0")
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
                        initialConnection = false; // Dejamos como Falso para si luego queremos volver a conectar.

                        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

                    }
                    else if (mensaje == "-1")
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
                    IPAddress direc = IPAddress.Parse("147.83.117.22");
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

                    if (mensaje == "0")
                    {
                        MessageBox.Show("[!] Registrado Satisfactoriamente. [!]");
                        userRegister.Text = "";
                        contraRegister.Text = "";
                    }
                    else if (mensaje == "1")
                    {
                        MessageBox.Show("[!] Ya existe este usuario. [!]");
                    }
                    else if (mensaje == "-1")
                    {
                        MessageBox.Show("[!] ERROR en el Registro. [!]");
                    }
                    else
                        MessageBox.Show("[!] Error no identificado [!]");
                }
            }
        }

       

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

}
