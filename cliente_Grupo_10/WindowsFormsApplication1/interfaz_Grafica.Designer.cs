
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
            this.userName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.temps = new System.Windows.Forms.Label();
            this.message4 = new System.Windows.Forms.Label();
            this.message3 = new System.Windows.Forms.Label();
            this.message2 = new System.Windows.Forms.Label();
            this.message1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.escrito = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testSIA
            // 
            this.testSIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(247)))), ((int)(((byte)(0)))));
            this.testSIA.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSIA.Location = new System.Drawing.Point(650, 159);
            this.testSIA.Name = "testSIA";
            this.testSIA.Size = new System.Drawing.Size(252, 23);
            this.testSIA.TabIndex = 31;
            this.testSIA.Text = "Test SIA";
            this.testSIA.UseVisualStyleBackColor = false;
            this.testSIA.Click += new System.EventHandler(this.testSIA_Click);
            // 
            // testComunidad
            // 
            this.testComunidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.testComunidad.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testComunidad.Location = new System.Drawing.Point(650, 101);
            this.testComunidad.Name = "testComunidad";
            this.testComunidad.Size = new System.Drawing.Size(252, 23);
            this.testComunidad.TabIndex = 32;
            this.testComunidad.Text = "Test Comunidad";
            this.testComunidad.UseVisualStyleBackColor = false;
            this.testComunidad.Click += new System.EventHandler(this.testComunidad_Click);
            // 
            // lanzarDados
            // 
            this.lanzarDados.BackColor = System.Drawing.Color.LightGray;
            this.lanzarDados.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lanzarDados.Location = new System.Drawing.Point(650, 130);
            this.lanzarDados.Name = "lanzarDados";
            this.lanzarDados.Size = new System.Drawing.Size(252, 23);
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
            this.tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo.ForeColor = System.Drawing.Color.LightGray;
            this.tiempo.Location = new System.Drawing.Point(998, 748);
            this.tiempo.Name = "tiempo";
            this.tiempo.Size = new System.Drawing.Size(230, 71);
            this.tiempo.TabIndex = 34;
            this.tiempo.Text = "00:00:00";
            this.tiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.DarkRed;
            this.salir.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir.ForeColor = System.Drawing.Color.LightGray;
            this.salir.Location = new System.Drawing.Point(650, 188);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(252, 23);
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
            this.dado.Location = new System.Drawing.Point(284, 123);
            this.dado.Name = "dado";
            this.dado.Size = new System.Drawing.Size(68, 70);
            this.dado.TabIndex = 36;
            // 
            // comunidadPanel
            // 
            this.comunidadPanel.BackColor = System.Drawing.Color.Transparent;
            this.comunidadPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.comunidadPanel.Location = new System.Drawing.Point(173, 220);
            this.comunidadPanel.Name = "comunidadPanel";
            this.comunidadPanel.Size = new System.Drawing.Size(134, 201);
            this.comunidadPanel.TabIndex = 37;
            // 
            // SIAPanel
            // 
            this.SIAPanel.BackColor = System.Drawing.Color.Transparent;
            this.SIAPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SIAPanel.Location = new System.Drawing.Point(320, 220);
            this.SIAPanel.Name = "SIAPanel";
            this.SIAPanel.Size = new System.Drawing.Size(132, 201);
            this.SIAPanel.TabIndex = 38;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.BackColor = System.Drawing.Color.Transparent;
            this.userName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.LightGray;
            this.userName.Location = new System.Drawing.Point(783, 536);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(35, 14);
            this.userName.TabIndex = 39;
            this.userName.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Courier New", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(247)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(722, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "Logged as:";
            // 
            // temps
            // 
            this.temps.AutoSize = true;
            this.temps.BackColor = System.Drawing.Color.Transparent;
            this.temps.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temps.ForeColor = System.Drawing.Color.LightGray;
            this.temps.Location = new System.Drawing.Point(745, 577);
            this.temps.Name = "temps";
            this.temps.Size = new System.Drawing.Size(63, 14);
            this.temps.TabIndex = 41;
            this.temps.Text = "00:00:00";
            this.temps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // message4
            // 
            this.message4.BackColor = System.Drawing.Color.Transparent;
            this.message4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message4.ForeColor = System.Drawing.Color.Yellow;
            this.message4.Location = new System.Drawing.Point(650, 416);
            this.message4.Name = "message4";
            this.message4.Size = new System.Drawing.Size(252, 18);
            this.message4.TabIndex = 42;
            this.message4.Text = "- - - - - - - - - -";
            // 
            // message3
            // 
            this.message3.BackColor = System.Drawing.Color.Transparent;
            this.message3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message3.ForeColor = System.Drawing.Color.Yellow;
            this.message3.Location = new System.Drawing.Point(650, 398);
            this.message3.Name = "message3";
            this.message3.Size = new System.Drawing.Size(252, 18);
            this.message3.TabIndex = 43;
            this.message3.Text = "ENJOY THE GAME!";
            // 
            // message2
            // 
            this.message2.BackColor = System.Drawing.Color.Transparent;
            this.message2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message2.ForeColor = System.Drawing.Color.Yellow;
            this.message2.Location = new System.Drawing.Point(650, 380);
            this.message2.Name = "message2";
            this.message2.Size = new System.Drawing.Size(252, 18);
            this.message2.TabIndex = 44;
            this.message2.Text = "Created by: Alba, Eloi and Marc.";
            // 
            // message1
            // 
            this.message1.BackColor = System.Drawing.Color.Transparent;
            this.message1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message1.ForeColor = System.Drawing.Color.Yellow;
            this.message1.Location = new System.Drawing.Point(650, 362);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(252, 18);
            this.message1.TabIndex = 45;
            this.message1.Text = "Welcome to Monopoly EETAC!";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightGray;
            this.label6.Location = new System.Drawing.Point(744, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 46;
            this.label6.Text = "C H A T";
            // 
            // escrito
            // 
            this.escrito.Location = new System.Drawing.Point(653, 464);
            this.escrito.Name = "escrito";
            this.escrito.Size = new System.Drawing.Size(249, 20);
            this.escrito.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(711, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 14);
            this.label2.TabIndex = 48;
            this.label2.Text = "Mensaje a enviar:";
            // 
            // sendMessage
            // 
            this.sendMessage.BackColor = System.Drawing.Color.Black;
            this.sendMessage.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendMessage.ForeColor = System.Drawing.Color.Yellow;
            this.sendMessage.Location = new System.Drawing.Point(714, 490);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(120, 23);
            this.sendMessage.TabIndex = 49;
            this.sendMessage.Text = "Enviar";
            this.sendMessage.UseVisualStyleBackColor = false;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // interfaz_Grafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(931, 641);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.escrito);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.message1);
            this.Controls.Add(this.message2);
            this.Controls.Add(this.message3);
            this.Controls.Add(this.message4);
            this.Controls.Add(this.temps);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userName);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label temps;
        private System.Windows.Forms.Label message4;
        private System.Windows.Forms.Label message3;
        private System.Windows.Forms.Label message2;
        private System.Windows.Forms.Label message1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox escrito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendMessage;
    }
}