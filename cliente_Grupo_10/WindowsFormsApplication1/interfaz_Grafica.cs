using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class interfaz_Grafica : Form
    {
        public interfaz_Grafica()
        {
            InitializeComponent();
        }

        private void testComunidad_Click(object sender, EventArgs e)
        {
            // Genera un número aleatorio del 1 al 5 para importar una carta de comunidad diferente.
            Random myObject = new Random();
            int Num = myObject.Next(1, 5);
            if (Num == 1) {
                comunidadPanel.BackgroundImage = Properties.Resources.Comunidad_1;
            }
            else if (Num == 2) {
                comunidadPanel.BackgroundImage = Properties.Resources.Comunidad_2;
            }
            else if (Num == 3) {
                comunidadPanel.BackgroundImage = Properties.Resources.Comunidad_3;
            }
            else if (Num == 4) {
                comunidadPanel.BackgroundImage = Properties.Resources.Comunidad_4;
            }
            else {
                comunidadPanel.BackgroundImage = Properties.Resources.Comunidad_5;
            }
        }

        private void testSIA_Click(object sender, EventArgs e)
        {
            // Genera un número aleatorio del 1 al 2 para importar una carta de comunidad diferente.
            Random myObject = new Random();
            int Num = myObject.Next(1, 2);
            if (Num == 1) {
                SIAPanel.BackgroundImage = Properties.Resources.SIA_1;
            }
            else {
                SIAPanel.BackgroundImage = Properties.Resources.SIA_2;
            }
        }

        private void time_Tick(object sender, EventArgs e)
        {
            tiempo.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void interfaz_Grafica_Load(object sender, EventArgs e)
        {
            // Declaramos que el tiempo varia cada 1 s (1000 ms):
            time.Interval = 1000;
            time.Start();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            time.Stop();
            Close();
        }

        private void lanzarDados_Click(object sender, EventArgs e)
        {
            Random myObject = new Random();
            int Num = myObject.Next(1, 6);
            if (Num == 1) {
                dado.BackgroundImage = Properties.Resources.Dado_1;
            }
            else if (Num == 2) {
                dado.BackgroundImage = Properties.Resources.Dado_2;
            }
            else if (Num == 3) {
                dado.BackgroundImage = Properties.Resources.Dado_3;
            }
            else if (Num == 4) {
                dado.BackgroundImage = Properties.Resources.Dado_4;
            }
            else if (Num == 5) {
                dado.BackgroundImage = Properties.Resources.Dado_5;
            }
            else {
                dado.BackgroundImage = Properties.Resources.Dado_6;
            }
        }
    }
}
