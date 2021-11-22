
namespace WindowsFormsApplication1
{
    partial class interfaz_Grafica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(interfaz_Grafica));
            this.testSIA = new System.Windows.Forms.Button();
            this.testComunidad = new System.Windows.Forms.Button();
            this.lanzarDados = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.tiempo = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.Button();
            this.dado = new System.Windows.Forms.Panel();
            this.comunidadPanel = new System.Windows.Forms.Panel();
            this.SIAPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // testSIA
            // 
            this.testSIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(247)))), ((int)(((byte)(0)))));
            this.testSIA.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSIA.Location = new System.Drawing.Point(545, 110);
            this.testSIA.Name = "testSIA";
            this.testSIA.Size = new System.Drawing.Size(198, 22);
            this.testSIA.TabIndex = 31;
            this.testSIA.Text = "Test SIA";
            this.testSIA.UseVisualStyleBackColor = false;
            this.testSIA.Click += new System.EventHandler(this.testSIA_Click);
            // 
            // testComunidad
            // 
            this.testComunidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.testComunidad.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testComunidad.Location = new System.Drawing.Point(545, 82);
            this.testComunidad.Name = "testComunidad";
            this.testComunidad.Size = new System.Drawing.Size(198, 22);
            this.testComunidad.TabIndex = 32;
            this.testComunidad.Text = "Test Comunidad";
            this.testComunidad.UseVisualStyleBackColor = false;
            this.testComunidad.Click += new System.EventHandler(this.testComunidad_Click);
            // 
            // lanzarDados
            // 
            this.lanzarDados.BackColor = System.Drawing.Color.LightGray;
            this.lanzarDados.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanzarDados.Location = new System.Drawing.Point(545, 138);
            this.lanzarDados.Name = "lanzarDados";
            this.lanzarDados.Size = new System.Drawing.Size(198, 22);
            this.lanzarDados.TabIndex = 33;
            this.lanzarDados.Text = "Lanzar el Dado";
            this.lanzarDados.UseVisualStyleBackColor = false;
            this.lanzarDados.Click += new System.EventHandler(this.lanzarDados_Click);
            // 
            // time
            // 
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // tiempo
            // 
            this.tiempo.BackColor = System.Drawing.Color.Transparent;
            this.tiempo.Font = new System.Drawing.Font("Built Titling Rg", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo.ForeColor = System.Drawing.Color.LightGray;
            this.tiempo.Location = new System.Drawing.Point(606, 432);
            this.tiempo.Name = "tiempo";
            this.tiempo.Size = new System.Drawing.Size(79, 23);
            this.tiempo.TabIndex = 34;
            this.tiempo.Text = "00:00:00";
            this.tiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.DarkRed;
            this.salir.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir.ForeColor = System.Drawing.Color.LightGray;
            this.salir.Location = new System.Drawing.Point(545, 166);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(198, 22);
            this.salir.TabIndex = 35;
            this.salir.Text = "Salir de la Partida";
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // dado
            // 
            this.dado.BackColor = System.Drawing.Color.Transparent;
            this.dado.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Dado_1;
            this.dado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dado.Location = new System.Drawing.Point(239, 101);
            this.dado.Name = "dado";
            this.dado.Size = new System.Drawing.Size(50, 50);
            this.dado.TabIndex = 36;
            // 
            // comunidadPanel
            // 
            this.comunidadPanel.BackColor = System.Drawing.Color.Transparent;
            this.comunidadPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.comunidadPanel.Location = new System.Drawing.Point(143, 166);
            this.comunidadPanel.Name = "comunidadPanel";
            this.comunidadPanel.Size = new System.Drawing.Size(112, 154);
            this.comunidadPanel.TabIndex = 37;
            // 
            // SIAPanel
            // 
            this.SIAPanel.BackColor = System.Drawing.Color.Transparent;
            this.SIAPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SIAPanel.Location = new System.Drawing.Point(263, 166);
            this.SIAPanel.Name = "SIAPanel";
            this.SIAPanel.Size = new System.Drawing.Size(113, 154);
            this.SIAPanel.TabIndex = 38;
            // 
            // interfaz_Grafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(772, 486);
            this.Controls.Add(this.SIAPanel);
            this.Controls.Add(this.comunidadPanel);
            this.Controls.Add(this.dado);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.tiempo);
            this.Controls.Add(this.lanzarDados);
            this.Controls.Add(this.testComunidad);
            this.Controls.Add(this.testSIA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "interfaz_Grafica";
            this.Text = "interfaz_Grafica";
            this.Load += new System.EventHandler(this.interfaz_Grafica_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testSIA;
        private System.Windows.Forms.Button testComunidad;
        private System.Windows.Forms.Button lanzarDados;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.Label tiempo;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Panel dado;
        private System.Windows.Forms.Panel comunidadPanel;
        private System.Windows.Forms.Panel SIAPanel;
    }
}