namespace WindowsFormsApplication1
{
    partial class Home
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.enviar = new System.Windows.Forms.Button();
            this.Petición_Marc = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.Petición_Eloi = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idUsuario = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gridListaConectados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Desconectar = new System.Windows.Forms.Button();
            this.crearPartida = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.estadoInvitados = new System.Windows.Forms.DataGridView();
            this.tiempo = new System.Windows.Forms.Label();
            this.cuentaAtras = new System.Windows.Forms.Timer(this.components);
            this.InvitarAmigos = new System.Windows.Forms.Button();
            this.notificacionHome = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.eliminarUsuario = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaConectados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadoInvitados)).BeginInit();
            this.SuspendLayout();
            // 
            // enviar
            // 
            this.enviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.enviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.enviar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enviar.Location = new System.Drawing.Point(12, 259);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(384, 23);
            this.enviar.TabIndex = 5;
            this.enviar.Text = "Enviar Petición";
            this.enviar.UseVisualStyleBackColor = false;
            this.enviar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Petición_Marc
            // 
            this.Petición_Marc.AutoSize = true;
            this.Petición_Marc.ForeColor = System.Drawing.Color.LightGray;
            this.Petición_Marc.Location = new System.Drawing.Point(12, 90);
            this.Petición_Marc.Name = "Petición_Marc";
            this.Petición_Marc.Size = new System.Drawing.Size(221, 18);
            this.Petición_Marc.TabIndex = 8;
            this.Petición_Marc.TabStop = true;
            this.Petición_Marc.Text = "¿Cuántas partidas he jugado?";
            this.Petición_Marc.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.label3.Location = new System.Drawing.Point(25, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Consultas:";
            // 
            // Petición_Eloi
            // 
            this.Petición_Eloi.AutoSize = true;
            this.Petición_Eloi.ForeColor = System.Drawing.Color.LightGray;
            this.Petición_Eloi.Location = new System.Drawing.Point(12, 114);
            this.Petición_Eloi.Name = "Petición_Eloi";
            this.Petición_Eloi.Size = new System.Drawing.Size(193, 18);
            this.Petición_Eloi.TabIndex = 17;
            this.Petición_Eloi.TabStop = true;
            this.Petición_Eloi.Text = "¿Contra quién he ganado?";
            this.Petición_Eloi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(29)))), ((int)(((byte)(60)))));
            this.groupBox1.Controls.Add(this.Petición_Eloi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Petición_Marc);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 189);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticiones, Grupo 10";
            // 
            // idUsuario
            // 
            this.idUsuario.BackColor = System.Drawing.Color.Transparent;
            this.idUsuario.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idUsuario.ForeColor = System.Drawing.Color.LightGray;
            this.idUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.idUsuario.Location = new System.Drawing.Point(430, 32);
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.Size = new System.Drawing.Size(253, 19);
            this.idUsuario.TabIndex = 31;
            this.idUsuario.Text = "USER";
            this.idUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.label5.Location = new System.Drawing.Point(430, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "USER";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridListaConectados
            // 
            this.gridListaConectados.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridListaConectados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridListaConectados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridListaConectados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(29)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(29)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaConectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridListaConectados.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridListaConectados.GridColor = System.Drawing.Color.DarkRed;
            this.gridListaConectados.Location = new System.Drawing.Point(433, 85);
            this.gridListaConectados.Name = "gridListaConectados";
            this.gridListaConectados.RowHeadersVisible = false;
            this.gridListaConectados.RowHeadersWidth = 51;
            this.gridListaConectados.Size = new System.Drawing.Size(250, 158);
            this.gridListaConectados.TabIndex = 30;
            this.gridListaConectados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridListaConectados_CellContentClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.label1.Location = new System.Drawing.Point(486, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Usuarios Conectados";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Desconectar
            // 
            this.Desconectar.BackColor = System.Drawing.Color.DarkRed;
            this.Desconectar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Desconectar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desconectar.ForeColor = System.Drawing.Color.LightGray;
            this.Desconectar.Location = new System.Drawing.Point(12, 480);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(184, 23);
            this.Desconectar.TabIndex = 30;
            this.Desconectar.Text = "Desconectar / Cerrar";
            this.Desconectar.UseVisualStyleBackColor = false;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click_1);
            // 
            // crearPartida
            // 
            this.crearPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            this.crearPartida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.crearPartida.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearPartida.ForeColor = System.Drawing.Color.Black;
            this.crearPartida.Location = new System.Drawing.Point(433, 290);
            this.crearPartida.Name = "crearPartida";
            this.crearPartida.Size = new System.Drawing.Size(250, 22);
            this.crearPartida.TabIndex = 31;
            this.crearPartida.Text = "Invitar aleatorios";
            this.crearPartida.UseVisualStyleBackColor = false;
            this.crearPartida.Click += new System.EventHandler(this.crearPartida_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.label4.Location = new System.Drawing.Point(474, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 14);
            this.label4.TabIndex = 32;
            this.label4.Text = "Estado de los Invitados";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // estadoInvitados
            // 
            this.estadoInvitados.BackgroundColor = System.Drawing.Color.LightGray;
            this.estadoInvitados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.estadoInvitados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.estadoInvitados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(29)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(29)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.estadoInvitados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.estadoInvitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.estadoInvitados.DefaultCellStyle = dataGridViewCellStyle4;
            this.estadoInvitados.GridColor = System.Drawing.Color.DarkRed;
            this.estadoInvitados.Location = new System.Drawing.Point(433, 376);
            this.estadoInvitados.Name = "estadoInvitados";
            this.estadoInvitados.RowHeadersVisible = false;
            this.estadoInvitados.RowHeadersWidth = 51;
            this.estadoInvitados.Size = new System.Drawing.Size(250, 127);
            this.estadoInvitados.TabIndex = 33;
            // 
            // tiempo
            // 
            this.tiempo.BackColor = System.Drawing.Color.Transparent;
            this.tiempo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo.ForeColor = System.Drawing.Color.LightGray;
            this.tiempo.Location = new System.Drawing.Point(520, 325);
            this.tiempo.Name = "tiempo";
            this.tiempo.Size = new System.Drawing.Size(79, 23);
            this.tiempo.TabIndex = 35;
            this.tiempo.Text = "30";
            this.tiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cuentaAtras
            // 
            this.cuentaAtras.Tick += new System.EventHandler(this.cuentaAtras_Tick);
            // 
            // InvitarAmigos
            // 
            this.InvitarAmigos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            this.InvitarAmigos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InvitarAmigos.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvitarAmigos.ForeColor = System.Drawing.Color.Black;
            this.InvitarAmigos.Location = new System.Drawing.Point(433, 262);
            this.InvitarAmigos.Name = "InvitarAmigos";
            this.InvitarAmigos.Size = new System.Drawing.Size(250, 22);
            this.InvitarAmigos.TabIndex = 36;
            this.InvitarAmigos.Text = "Invitar amigos";
            this.InvitarAmigos.UseVisualStyleBackColor = false;
            this.InvitarAmigos.Click += new System.EventHandler(this.InvitarAmigos_Click);
            // 
            // notificacionHome
            // 
            this.notificacionHome.BackColor = System.Drawing.Color.Black;
            this.notificacionHome.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificacionHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.notificacionHome.Location = new System.Drawing.Point(14, 312);
            this.notificacionHome.Name = "notificacionHome";
            this.notificacionHome.Size = new System.Drawing.Size(382, 157);
            this.notificacionHome.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.label8.Location = new System.Drawing.Point(120, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 14);
            this.label8.TabIndex = 38;
            this.label8.Text = "Resultado de la Petición";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eliminarUsuario
            // 
            this.eliminarUsuario.BackColor = System.Drawing.Color.Red;
            this.eliminarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eliminarUsuario.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eliminarUsuario.ForeColor = System.Drawing.Color.Black;
            this.eliminarUsuario.Location = new System.Drawing.Point(202, 480);
            this.eliminarUsuario.Name = "eliminarUsuario";
            this.eliminarUsuario.Size = new System.Drawing.Size(194, 23);
            this.eliminarUsuario.TabIndex = 39;
            this.eliminarUsuario.Text = "Eliminar Usuario y Salir";
            this.eliminarUsuario.UseVisualStyleBackColor = false;
            this.eliminarUsuario.Click += new System.EventHandler(this.eliminarUsuario_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Home_V1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(695, 515);
            this.Controls.Add(this.eliminarUsuario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.notificacionHome);
            this.Controls.Add(this.InvitarAmigos);
            this.Controls.Add(this.tiempo);
            this.Controls.Add(this.estadoInvitados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.crearPartida);
            this.Controls.Add(this.idUsuario);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridListaConectados);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.enviar);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.Text = "Formulario del Cliente, Grupo 10";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Home_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaConectados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadoInvitados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.RadioButton Petición_Marc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Petición_Eloi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridListaConectados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button crearPartida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView estadoInvitados;
        private System.Windows.Forms.Label tiempo;
        private System.Windows.Forms.Timer cuentaAtras;
        private System.Windows.Forms.Label idUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button InvitarAmigos;
        private System.Windows.Forms.Label notificacionHome;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button eliminarUsuario;
    }
}

