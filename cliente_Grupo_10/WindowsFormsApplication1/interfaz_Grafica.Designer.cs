
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.tiempo = new System.Windows.Forms.Label();
            this.salir = new System.Windows.Forms.Button();
            this.dado = new System.Windows.Forms.Panel();
            this.comunidadPanel = new System.Windows.Forms.Panel();
            this.SIAPanel = new System.Windows.Forms.Panel();
            this.userName = new System.Windows.Forms.Label();
            this.temps = new System.Windows.Forms.Label();
            this.message4 = new System.Windows.Forms.Label();
            this.message3 = new System.Windows.Forms.Label();
            this.message2 = new System.Windows.Forms.Label();
            this.message1 = new System.Windows.Forms.Label();
            this.escrito = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sendMessage = new System.Windows.Forms.Button();
            this.creditsText = new System.Windows.Forms.Label();
            this.moneyText = new System.Windows.Forms.Label();
            this.fitxa1 = new System.Windows.Forms.Panel();
            this.fitxa2 = new System.Windows.Forms.Panel();
            this.fitxa3 = new System.Windows.Forms.Panel();
            this.fitxa4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.user1 = new System.Windows.Forms.Label();
            this.user2 = new System.Windows.Forms.Label();
            this.user3 = new System.Windows.Forms.Label();
            this.user4 = new System.Windows.Forms.Label();
            this.flecha1 = new System.Windows.Forms.Panel();
            this.flecha2 = new System.Windows.Forms.Panel();
            this.flecha3 = new System.Windows.Forms.Panel();
            this.flecha4 = new System.Windows.Forms.Panel();
            this.turno1 = new System.Windows.Forms.Label();
            this.turno2 = new System.Windows.Forms.Label();
            this.turno3 = new System.Windows.Forms.Label();
            this.turno4 = new System.Windows.Forms.Label();
            this.money1 = new System.Windows.Forms.Label();
            this.money2 = new System.Windows.Forms.Label();
            this.money3 = new System.Windows.Forms.Label();
            this.money4 = new System.Windows.Forms.Label();
            this.credits1 = new System.Windows.Forms.Label();
            this.credits2 = new System.Windows.Forms.Label();
            this.credits3 = new System.Windows.Forms.Label();
            this.credits4 = new System.Windows.Forms.Label();
            this.propietariosAsignaturas = new System.Windows.Forms.DataGridView();
            this.notificacion = new System.Windows.Forms.TextBox();
            this.tiempoTurno = new System.Windows.Forms.Timer(this.components);
            this.idUsuari = new System.Windows.Forms.Label();
            this.cerrarPartida = new System.Windows.Forms.Button();
            this.creditosFinales1 = new System.Windows.Forms.Label();
            this.creditosFinales3 = new System.Windows.Forms.Label();
            this.creditosFinales2 = new System.Windows.Forms.Label();
            this.nombreFinal2 = new System.Windows.Forms.Label();
            this.nombreFinal3 = new System.Windows.Forms.Label();
            this.nombreFinal1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.propietariosAsignaturas)).BeginInit();
            this.SuspendLayout();
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
            this.salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.salir.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir.ForeColor = System.Drawing.Color.LightGray;
            this.salir.Location = new System.Drawing.Point(674, 305);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(67, 22);
            this.salir.TabIndex = 35;
            this.salir.Text = "Salir";
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // dado
            // 
            this.dado.BackColor = System.Drawing.Color.Transparent;
            this.dado.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Tirar_Dados;
            this.dado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dado.Location = new System.Drawing.Point(284, 123);
            this.dado.Name = "dado";
            this.dado.Size = new System.Drawing.Size(68, 70);
            this.dado.TabIndex = 36;
            this.dado.Click += new System.EventHandler(this.dado_Click);
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
            this.SIAPanel.Location = new System.Drawing.Point(318, 220);
            this.SIAPanel.Name = "SIAPanel";
            this.SIAPanel.Size = new System.Drawing.Size(135, 201);
            this.SIAPanel.TabIndex = 38;
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.Transparent;
            this.userName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.LightGray;
            this.userName.Location = new System.Drawing.Point(673, 278);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(76, 15);
            this.userName.TabIndex = 39;
            this.userName.Text = "User";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // temps
            // 
            this.temps.AutoSize = true;
            this.temps.BackColor = System.Drawing.Color.Transparent;
            this.temps.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temps.ForeColor = System.Drawing.Color.LightGray;
            this.temps.Location = new System.Drawing.Point(741, 576);
            this.temps.Name = "temps";
            this.temps.Size = new System.Drawing.Size(72, 16);
            this.temps.TabIndex = 41;
            this.temps.Text = "00:00:00";
            this.temps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // message4
            // 
            this.message4.BackColor = System.Drawing.Color.Transparent;
            this.message4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.message4.Location = new System.Drawing.Point(656, 465);
            this.message4.Name = "message4";
            this.message4.Size = new System.Drawing.Size(240, 18);
            this.message4.TabIndex = 42;
            this.message4.Text = "- - - - - - - - - - - - - - - - -";
            // 
            // message3
            // 
            this.message3.BackColor = System.Drawing.Color.Transparent;
            this.message3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.message3.Location = new System.Drawing.Point(656, 436);
            this.message3.Name = "message3";
            this.message3.Size = new System.Drawing.Size(240, 18);
            this.message3.TabIndex = 43;
            this.message3.Text = "ENJOY THE GAME!";
            // 
            // message2
            // 
            this.message2.BackColor = System.Drawing.Color.Transparent;
            this.message2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.message2.Location = new System.Drawing.Point(656, 407);
            this.message2.Name = "message2";
            this.message2.Size = new System.Drawing.Size(240, 18);
            this.message2.TabIndex = 44;
            this.message2.Text = "Created by Alba, Eloi and Marc.";
            // 
            // message1
            // 
            this.message1.BackColor = System.Drawing.Color.Transparent;
            this.message1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.message1.Location = new System.Drawing.Point(656, 379);
            this.message1.Name = "message1";
            this.message1.Size = new System.Drawing.Size(240, 18);
            this.message1.TabIndex = 45;
            this.message1.Text = "Welcome to Monopoly EETAC!";
            // 
            // escrito
            // 
            this.escrito.BackColor = System.Drawing.Color.Yellow;
            this.escrito.Location = new System.Drawing.Point(653, 512);
            this.escrito.Name = "escrito";
            this.escrito.Size = new System.Drawing.Size(197, 20);
            this.escrito.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(713, 495);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 14);
            this.label2.TabIndex = 48;
            this.label2.Text = "Mensaje a enviar:";
            // 
            // sendMessage
            // 
            this.sendMessage.BackColor = System.Drawing.Color.DarkRed;
            this.sendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendMessage.Font = new System.Drawing.Font("Courier New", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendMessage.ForeColor = System.Drawing.Color.Yellow;
            this.sendMessage.Location = new System.Drawing.Point(856, 512);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(46, 20);
            this.sendMessage.TabIndex = 49;
            this.sendMessage.Text = "Send";
            this.sendMessage.UseVisualStyleBackColor = false;
            this.sendMessage.Click += new System.EventHandler(this.sendMessage_Click);
            // 
            // creditsText
            // 
            this.creditsText.BackColor = System.Drawing.Color.Transparent;
            this.creditsText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditsText.ForeColor = System.Drawing.Color.Yellow;
            this.creditsText.Location = new System.Drawing.Point(740, 213);
            this.creditsText.Name = "creditsText";
            this.creditsText.Size = new System.Drawing.Size(41, 22);
            this.creditsText.TabIndex = 50;
            this.creditsText.Text = "000.0";
            this.creditsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // moneyText
            // 
            this.moneyText.BackColor = System.Drawing.Color.Transparent;
            this.moneyText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moneyText.ForeColor = System.Drawing.Color.Aqua;
            this.moneyText.Location = new System.Drawing.Point(726, 242);
            this.moneyText.Name = "moneyText";
            this.moneyText.Size = new System.Drawing.Size(55, 22);
            this.moneyText.TabIndex = 51;
            this.moneyText.Text = "00000";
            this.moneyText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fitxa1
            // 
            this.fitxa1.BackColor = System.Drawing.Color.Transparent;
            this.fitxa1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Ficha1;
            this.fitxa1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fitxa1.Location = new System.Drawing.Point(531, 546);
            this.fitxa1.Name = "fitxa1";
            this.fitxa1.Size = new System.Drawing.Size(20, 20);
            this.fitxa1.TabIndex = 57;
            // 
            // fitxa2
            // 
            this.fitxa2.BackColor = System.Drawing.Color.Transparent;
            this.fitxa2.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Ficha2;
            this.fitxa2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fitxa2.Location = new System.Drawing.Point(551, 546);
            this.fitxa2.Name = "fitxa2";
            this.fitxa2.Size = new System.Drawing.Size(20, 20);
            this.fitxa2.TabIndex = 58;
            // 
            // fitxa3
            // 
            this.fitxa3.BackColor = System.Drawing.Color.Transparent;
            this.fitxa3.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Ficha3;
            this.fitxa3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fitxa3.Location = new System.Drawing.Point(531, 566);
            this.fitxa3.Name = "fitxa3";
            this.fitxa3.Size = new System.Drawing.Size(20, 20);
            this.fitxa3.TabIndex = 58;
            // 
            // fitxa4
            // 
            this.fitxa4.BackColor = System.Drawing.Color.Transparent;
            this.fitxa4.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Ficha4;
            this.fitxa4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fitxa4.Location = new System.Drawing.Point(551, 566);
            this.fitxa4.Name = "fitxa4";
            this.fitxa4.Size = new System.Drawing.Size(20, 20);
            this.fitxa4.TabIndex = 60;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Ficha1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(690, 123);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            this.panel1.TabIndex = 58;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Ficha2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(690, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 59;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Ficha3;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(690, 163);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 20);
            this.panel3.TabIndex = 60;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Ficha4;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(690, 183);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 20);
            this.panel4.TabIndex = 61;
            // 
            // user1
            // 
            this.user1.BackColor = System.Drawing.Color.Transparent;
            this.user1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user1.ForeColor = System.Drawing.Color.LightGray;
            this.user1.Location = new System.Drawing.Point(716, 126);
            this.user1.Name = "user1";
            this.user1.Size = new System.Drawing.Size(65, 15);
            this.user1.TabIndex = 62;
            this.user1.Text = "User";
            this.user1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // user2
            // 
            this.user2.BackColor = System.Drawing.Color.Transparent;
            this.user2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user2.ForeColor = System.Drawing.Color.LightGray;
            this.user2.Location = new System.Drawing.Point(716, 146);
            this.user2.Name = "user2";
            this.user2.Size = new System.Drawing.Size(65, 15);
            this.user2.TabIndex = 63;
            this.user2.Text = "User";
            this.user2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // user3
            // 
            this.user3.BackColor = System.Drawing.Color.Transparent;
            this.user3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user3.ForeColor = System.Drawing.Color.LightGray;
            this.user3.Location = new System.Drawing.Point(716, 166);
            this.user3.Name = "user3";
            this.user3.Size = new System.Drawing.Size(65, 15);
            this.user3.TabIndex = 64;
            this.user3.Text = "User";
            this.user3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // user4
            // 
            this.user4.BackColor = System.Drawing.Color.Transparent;
            this.user4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user4.ForeColor = System.Drawing.Color.LightGray;
            this.user4.Location = new System.Drawing.Point(716, 186);
            this.user4.Name = "user4";
            this.user4.Size = new System.Drawing.Size(65, 15);
            this.user4.TabIndex = 65;
            this.user4.Text = "User";
            this.user4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flecha1
            // 
            this.flecha1.BackColor = System.Drawing.Color.Transparent;
            this.flecha1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Flecha_Definitiva;
            this.flecha1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flecha1.Location = new System.Drawing.Point(666, 123);
            this.flecha1.Name = "flecha1";
            this.flecha1.Size = new System.Drawing.Size(20, 20);
            this.flecha1.TabIndex = 59;
            // 
            // flecha2
            // 
            this.flecha2.BackColor = System.Drawing.Color.Transparent;
            this.flecha2.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Flecha_Definitiva;
            this.flecha2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flecha2.Location = new System.Drawing.Point(666, 143);
            this.flecha2.Name = "flecha2";
            this.flecha2.Size = new System.Drawing.Size(20, 20);
            this.flecha2.TabIndex = 60;
            // 
            // flecha3
            // 
            this.flecha3.BackColor = System.Drawing.Color.Transparent;
            this.flecha3.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Flecha_Definitiva;
            this.flecha3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flecha3.Location = new System.Drawing.Point(666, 163);
            this.flecha3.Name = "flecha3";
            this.flecha3.Size = new System.Drawing.Size(20, 20);
            this.flecha3.TabIndex = 61;
            // 
            // flecha4
            // 
            this.flecha4.BackColor = System.Drawing.Color.Transparent;
            this.flecha4.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Flecha_Definitiva;
            this.flecha4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flecha4.Location = new System.Drawing.Point(666, 183);
            this.flecha4.Name = "flecha4";
            this.flecha4.Size = new System.Drawing.Size(20, 20);
            this.flecha4.TabIndex = 62;
            // 
            // turno1
            // 
            this.turno1.BackColor = System.Drawing.Color.Transparent;
            this.turno1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turno1.ForeColor = System.Drawing.Color.LightGray;
            this.turno1.Location = new System.Drawing.Point(642, 126);
            this.turno1.Name = "turno1";
            this.turno1.Size = new System.Drawing.Size(22, 15);
            this.turno1.TabIndex = 66;
            this.turno1.Text = "20";
            this.turno1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // turno2
            // 
            this.turno2.BackColor = System.Drawing.Color.Transparent;
            this.turno2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turno2.ForeColor = System.Drawing.Color.LightGray;
            this.turno2.Location = new System.Drawing.Point(642, 146);
            this.turno2.Name = "turno2";
            this.turno2.Size = new System.Drawing.Size(22, 15);
            this.turno2.TabIndex = 67;
            this.turno2.Text = "20";
            this.turno2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // turno3
            // 
            this.turno3.BackColor = System.Drawing.Color.Transparent;
            this.turno3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turno3.ForeColor = System.Drawing.Color.LightGray;
            this.turno3.Location = new System.Drawing.Point(642, 166);
            this.turno3.Name = "turno3";
            this.turno3.Size = new System.Drawing.Size(22, 15);
            this.turno3.TabIndex = 68;
            this.turno3.Text = "20";
            this.turno3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // turno4
            // 
            this.turno4.BackColor = System.Drawing.Color.Transparent;
            this.turno4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turno4.ForeColor = System.Drawing.Color.LightGray;
            this.turno4.Location = new System.Drawing.Point(642, 186);
            this.turno4.Name = "turno4";
            this.turno4.Size = new System.Drawing.Size(22, 15);
            this.turno4.TabIndex = 69;
            this.turno4.Text = "20";
            this.turno4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // money1
            // 
            this.money1.BackColor = System.Drawing.Color.Transparent;
            this.money1.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Bold);
            this.money1.ForeColor = System.Drawing.Color.Aqua;
            this.money1.Location = new System.Drawing.Point(785, 126);
            this.money1.Name = "money1";
            this.money1.Size = new System.Drawing.Size(45, 17);
            this.money1.TabIndex = 70;
            this.money1.Text = "00000";
            this.money1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // money2
            // 
            this.money2.BackColor = System.Drawing.Color.Transparent;
            this.money2.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Bold);
            this.money2.ForeColor = System.Drawing.Color.Aqua;
            this.money2.Location = new System.Drawing.Point(785, 146);
            this.money2.Name = "money2";
            this.money2.Size = new System.Drawing.Size(45, 17);
            this.money2.TabIndex = 71;
            this.money2.Text = "00000";
            this.money2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // money3
            // 
            this.money3.BackColor = System.Drawing.Color.Transparent;
            this.money3.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Bold);
            this.money3.ForeColor = System.Drawing.Color.Aqua;
            this.money3.Location = new System.Drawing.Point(785, 166);
            this.money3.Name = "money3";
            this.money3.Size = new System.Drawing.Size(45, 17);
            this.money3.TabIndex = 72;
            this.money3.Text = "00000";
            this.money3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // money4
            // 
            this.money4.BackColor = System.Drawing.Color.Transparent;
            this.money4.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Bold);
            this.money4.ForeColor = System.Drawing.Color.Aqua;
            this.money4.Location = new System.Drawing.Point(785, 186);
            this.money4.Name = "money4";
            this.money4.Size = new System.Drawing.Size(45, 17);
            this.money4.TabIndex = 73;
            this.money4.Text = "00000";
            this.money4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // credits1
            // 
            this.credits1.BackColor = System.Drawing.Color.Transparent;
            this.credits1.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Bold);
            this.credits1.ForeColor = System.Drawing.Color.Yellow;
            this.credits1.Location = new System.Drawing.Point(851, 126);
            this.credits1.Name = "credits1";
            this.credits1.Size = new System.Drawing.Size(45, 17);
            this.credits1.TabIndex = 74;
            this.credits1.Text = "000.0";
            this.credits1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // credits2
            // 
            this.credits2.BackColor = System.Drawing.Color.Transparent;
            this.credits2.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Bold);
            this.credits2.ForeColor = System.Drawing.Color.Yellow;
            this.credits2.Location = new System.Drawing.Point(851, 146);
            this.credits2.Name = "credits2";
            this.credits2.Size = new System.Drawing.Size(45, 17);
            this.credits2.TabIndex = 75;
            this.credits2.Text = "000.0";
            this.credits2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // credits3
            // 
            this.credits3.BackColor = System.Drawing.Color.Transparent;
            this.credits3.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Bold);
            this.credits3.ForeColor = System.Drawing.Color.Yellow;
            this.credits3.Location = new System.Drawing.Point(851, 166);
            this.credits3.Name = "credits3";
            this.credits3.Size = new System.Drawing.Size(45, 17);
            this.credits3.TabIndex = 76;
            this.credits3.Text = "000.0";
            this.credits3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // credits4
            // 
            this.credits4.BackColor = System.Drawing.Color.Transparent;
            this.credits4.Font = new System.Drawing.Font("Courier New", 7F, System.Drawing.FontStyle.Bold);
            this.credits4.ForeColor = System.Drawing.Color.Yellow;
            this.credits4.Location = new System.Drawing.Point(851, 186);
            this.credits4.Name = "credits4";
            this.credits4.Size = new System.Drawing.Size(45, 17);
            this.credits4.TabIndex = 77;
            this.credits4.Text = "000.0";
            this.credits4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // propietariosAsignaturas
            // 
            this.propietariosAsignaturas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(75)))));
            this.propietariosAsignaturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.propietariosAsignaturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.propietariosAsignaturas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(29)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(29)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.propietariosAsignaturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.propietariosAsignaturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle40.NullValue = null;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.propietariosAsignaturas.DefaultCellStyle = dataGridViewCellStyle40;
            this.propietariosAsignaturas.GridColor = System.Drawing.Color.DarkRed;
            this.propietariosAsignaturas.Location = new System.Drawing.Point(787, 242);
            this.propietariosAsignaturas.Name = "propietariosAsignaturas";
            this.propietariosAsignaturas.RowHeadersVisible = false;
            this.propietariosAsignaturas.RowHeadersWidth = 51;
            this.propietariosAsignaturas.Size = new System.Drawing.Size(121, 81);
            this.propietariosAsignaturas.TabIndex = 78;
            // 
            // notificacion
            // 
            this.notificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(17)))), ((int)(((byte)(67)))));
            this.notificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notificacion.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificacion.ForeColor = System.Drawing.Color.White;
            this.notificacion.Location = new System.Drawing.Point(173, 432);
            this.notificacion.Multiline = true;
            this.notificacion.Name = "notificacion";
            this.notificacion.Size = new System.Drawing.Size(280, 51);
            this.notificacion.TabIndex = 79;
            // 
            // tiempoTurno
            // 
            this.tiempoTurno.Tick += new System.EventHandler(this.tiempoTurno_Tick);
            // 
            // idUsuari
            // 
            this.idUsuari.BackColor = System.Drawing.Color.Transparent;
            this.idUsuari.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idUsuari.ForeColor = System.Drawing.Color.LightGray;
            this.idUsuari.Location = new System.Drawing.Point(755, 278);
            this.idUsuari.Name = "idUsuari";
            this.idUsuari.Size = new System.Drawing.Size(20, 15);
            this.idUsuari.TabIndex = 80;
            this.idUsuari.Text = "1";
            this.idUsuari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cerrarPartida
            // 
            this.cerrarPartida.BackColor = System.Drawing.Color.DarkRed;
            this.cerrarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cerrarPartida.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarPartida.ForeColor = System.Drawing.Color.LightGray;
            this.cerrarPartida.Location = new System.Drawing.Point(362, 59);
            this.cerrarPartida.Name = "cerrarPartida";
            this.cerrarPartida.Size = new System.Drawing.Size(211, 22);
            this.cerrarPartida.TabIndex = 81;
            this.cerrarPartida.Text = "Cerrar Partida";
            this.cerrarPartida.UseVisualStyleBackColor = false;
            this.cerrarPartida.Click += new System.EventHandler(this.cerrarPartida_Click);
            // 
            // creditosFinales1
            // 
            this.creditosFinales1.BackColor = System.Drawing.Color.Black;
            this.creditosFinales1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditosFinales1.ForeColor = System.Drawing.Color.Yellow;
            this.creditosFinales1.Location = new System.Drawing.Point(397, 292);
            this.creditosFinales1.Name = "creditosFinales1";
            this.creditosFinales1.Size = new System.Drawing.Size(140, 21);
            this.creditosFinales1.TabIndex = 82;
            this.creditosFinales1.Text = "000.0";
            this.creditosFinales1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // creditosFinales3
            // 
            this.creditosFinales3.BackColor = System.Drawing.Color.Black;
            this.creditosFinales3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditosFinales3.ForeColor = System.Drawing.Color.Yellow;
            this.creditosFinales3.Location = new System.Drawing.Point(537, 365);
            this.creditosFinales3.Name = "creditosFinales3";
            this.creditosFinales3.Size = new System.Drawing.Size(131, 21);
            this.creditosFinales3.TabIndex = 84;
            this.creditosFinales3.Text = "000.0";
            this.creditosFinales3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // creditosFinales2
            // 
            this.creditosFinales2.BackColor = System.Drawing.Color.Black;
            this.creditosFinales2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditosFinales2.ForeColor = System.Drawing.Color.Yellow;
            this.creditosFinales2.Location = new System.Drawing.Point(264, 329);
            this.creditosFinales2.Name = "creditosFinales2";
            this.creditosFinales2.Size = new System.Drawing.Size(133, 21);
            this.creditosFinales2.TabIndex = 88;
            this.creditosFinales2.Text = "000.0";
            this.creditosFinales2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombreFinal2
            // 
            this.nombreFinal2.BackColor = System.Drawing.Color.Transparent;
            this.nombreFinal2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreFinal2.ForeColor = System.Drawing.Color.Black;
            this.nombreFinal2.Location = new System.Drawing.Point(274, 364);
            this.nombreFinal2.Name = "nombreFinal2";
            this.nombreFinal2.Size = new System.Drawing.Size(115, 21);
            this.nombreFinal2.TabIndex = 89;
            this.nombreFinal2.Text = "USER";
            this.nombreFinal2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombreFinal3
            // 
            this.nombreFinal3.BackColor = System.Drawing.Color.Transparent;
            this.nombreFinal3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreFinal3.ForeColor = System.Drawing.Color.Black;
            this.nombreFinal3.Location = new System.Drawing.Point(544, 403);
            this.nombreFinal3.Name = "nombreFinal3";
            this.nombreFinal3.Size = new System.Drawing.Size(115, 21);
            this.nombreFinal3.TabIndex = 90;
            this.nombreFinal3.Text = "USER";
            this.nombreFinal3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nombreFinal1
            // 
            this.nombreFinal1.BackColor = System.Drawing.Color.Transparent;
            this.nombreFinal1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreFinal1.ForeColor = System.Drawing.Color.Black;
            this.nombreFinal1.Location = new System.Drawing.Point(410, 327);
            this.nombreFinal1.Name = "nombreFinal1";
            this.nombreFinal1.Size = new System.Drawing.Size(115, 21);
            this.nombreFinal1.TabIndex = 91;
            this.nombreFinal1.Text = "USER";
            this.nombreFinal1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // interfaz_Grafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Tablero_Completo_V6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(931, 641);
            this.Controls.Add(this.nombreFinal1);
            this.Controls.Add(this.nombreFinal3);
            this.Controls.Add(this.nombreFinal2);
            this.Controls.Add(this.creditosFinales2);
            this.Controls.Add(this.creditosFinales3);
            this.Controls.Add(this.creditosFinales1);
            this.Controls.Add(this.cerrarPartida);
            this.Controls.Add(this.idUsuari);
            this.Controls.Add(this.notificacion);
            this.Controls.Add(this.propietariosAsignaturas);
            this.Controls.Add(this.credits4);
            this.Controls.Add(this.credits3);
            this.Controls.Add(this.credits2);
            this.Controls.Add(this.credits1);
            this.Controls.Add(this.money4);
            this.Controls.Add(this.money3);
            this.Controls.Add(this.money2);
            this.Controls.Add(this.money1);
            this.Controls.Add(this.turno4);
            this.Controls.Add(this.turno3);
            this.Controls.Add(this.turno2);
            this.Controls.Add(this.turno1);
            this.Controls.Add(this.flecha4);
            this.Controls.Add(this.flecha3);
            this.Controls.Add(this.flecha2);
            this.Controls.Add(this.flecha1);
            this.Controls.Add(this.user4);
            this.Controls.Add(this.user3);
            this.Controls.Add(this.user2);
            this.Controls.Add(this.user1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fitxa4);
            this.Controls.Add(this.fitxa3);
            this.Controls.Add(this.fitxa2);
            this.Controls.Add(this.fitxa1);
            this.Controls.Add(this.moneyText);
            this.Controls.Add(this.creditsText);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.escrito);
            this.Controls.Add(this.message1);
            this.Controls.Add(this.message2);
            this.Controls.Add(this.message3);
            this.Controls.Add(this.message4);
            this.Controls.Add(this.temps);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.SIAPanel);
            this.Controls.Add(this.comunidadPanel);
            this.Controls.Add(this.dado);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.tiempo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "interfaz_Grafica";
            this.Text = "interfaz_Grafica";
            this.Load += new System.EventHandler(this.interfaz_Grafica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.propietariosAsignaturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.Label tiempo;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Panel dado;
        private System.Windows.Forms.Panel comunidadPanel;
        private System.Windows.Forms.Panel SIAPanel;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label temps;
        private System.Windows.Forms.Label message4;
        private System.Windows.Forms.Label message3;
        private System.Windows.Forms.Label message2;
        private System.Windows.Forms.Label message1;
        private System.Windows.Forms.TextBox escrito;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.Label creditsText;
        private System.Windows.Forms.Label moneyText;
        private System.Windows.Forms.Panel fitxa1;
        private System.Windows.Forms.Panel fitxa2;
        private System.Windows.Forms.Panel fitxa3;
        private System.Windows.Forms.Panel fitxa4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label user1;
        private System.Windows.Forms.Label user2;
        private System.Windows.Forms.Label user3;
        private System.Windows.Forms.Label user4;
        private System.Windows.Forms.Panel flecha1;
        private System.Windows.Forms.Panel flecha2;
        private System.Windows.Forms.Panel flecha3;
        private System.Windows.Forms.Panel flecha4;
        private System.Windows.Forms.Label turno1;
        private System.Windows.Forms.Label turno2;
        private System.Windows.Forms.Label turno3;
        private System.Windows.Forms.Label turno4;
        private System.Windows.Forms.Label money1;
        private System.Windows.Forms.Label money2;
        private System.Windows.Forms.Label money3;
        private System.Windows.Forms.Label money4;
        private System.Windows.Forms.Label credits1;
        private System.Windows.Forms.Label credits2;
        private System.Windows.Forms.Label credits3;
        private System.Windows.Forms.Label credits4;
        private System.Windows.Forms.DataGridView propietariosAsignaturas;
        private System.Windows.Forms.TextBox notificacion;
        private System.Windows.Forms.Timer tiempoTurno;
        private System.Windows.Forms.Label idUsuari;
        private System.Windows.Forms.Button cerrarPartida;
        private System.Windows.Forms.Label creditosFinales1;
        private System.Windows.Forms.Label creditosFinales3;
        private System.Windows.Forms.Label creditosFinales2;
        private System.Windows.Forms.Label nombreFinal2;
        private System.Windows.Forms.Label nombreFinal3;
        private System.Windows.Forms.Label nombreFinal1;
    }
}