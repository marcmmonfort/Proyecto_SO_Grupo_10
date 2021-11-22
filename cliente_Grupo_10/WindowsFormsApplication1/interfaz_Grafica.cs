using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            Comunidad frm = new Comunidad();
            frm.Show();
        }

        private void testSIA_Click(object sender, EventArgs e)
        {
            SIA frm = new SIA();
            frm.Show();
        }
    }
}
