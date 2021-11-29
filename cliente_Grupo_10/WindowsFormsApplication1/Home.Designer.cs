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
            this.Petición_Alba = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.Petición_Eloi = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fechaPartida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gridListaConectados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Desconectar = new System.Windows.Forms.Button();
            this.crearPartida = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.estadoInvitados = new System.Windows.Forms.DataGridView();
            this.tiempo = new System.Windows.Forms.Label();
            this.cuentaAtras = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaConectados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estadoInvitados)).BeginInit();
            this.SuspendLayout();
            // 
            // enviar
            // 
            this.enviar.BackColor = System.Drawing.Color.LightGray;
            this.enviar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enviar.Location = new System.Drawing.Point(6, 260);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(339, 23);
            this.enviar.TabIndex = 5;
            this.enviar.Text = "Enviar Petición";
            this.enviar.UseVisualStyleBackColor = false;
            this.enviar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Petición_Marc
            // 
            this.Petición_Marc.AutoSize = true;
            this.Petición_Marc.ForeColor = System.Drawing.Color.LightGray;
            this.Petición_Marc.Location = new System.Drawing.Point(12, 96);
            this.Petición_Marc.Name = "Petición_Marc";
            this.Petición_Marc.Size = new System.Drawing.Size(221, 18);
            this.Petición_Marc.TabIndex = 8;
            this.Petición_Marc.TabStop = true;
            this.Petición_Marc.Text = "¿Número de Partidas jugadas?";
            this.Petición_Marc.UseVisualStyleBackColor = true;
            // 
            // Petición_Alba
            // 
            this.Petición_Alba.AutoSize = true;
            this.Petición_Alba.ForeColor = System.Drawing.Color.LightGray;
            this.Petición_Alba.Location = new System.Drawing.Point(12, 122);
            this.Petición_Alba.Name = "Petición_Alba";
            this.Petición_Alba.Size = new System.Drawing.Size(326, 18);
            this.Petición_Alba.TabIndex = 7;
            this.Petición_Alba.TabStop = true;
            this.Petición_Alba.Text = "¿Número de créditos después de una partida?";
            this.Petición_Alba.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.label3.Location = new System.Drawing.Point(24, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Consultas:";
            // 
            // Petición_Eloi
            // 
            this.Petición_Eloi.AutoSize = true;
            this.Petición_Eloi.ForeColor = System.Drawing.Color.LightGray;
            this.Petición_Eloi.Location = new System.Drawing.Point(12, 147);
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
            this.groupBox1.Controls.Add(this.fechaPartida);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Petición_Eloi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Petición_Alba);
            this.groupBox1.Controls.Add(this.Petición_Marc);
            this.groupBox1.Controls.Add(this.enviar);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 289);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticiones, Grupo 10";
            // 
            // fechaPartida
            // 
            this.fechaPartida.BackColor = System.Drawing.Color.LightGray;
            this.fechaPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fechaPartida.Location = new System.Drawing.Point(77, 207);
            this.fechaPartida.Name = "fechaPartida";
            this.fechaPartida.Size = new System.Drawing.Size(196, 20);
            this.fechaPartida.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(105, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Fecha de la partida:";
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
            this.gridListaConectados.Location = new System.Drawing.Point(369, 31);
            this.gridListaConectados.Name = "gridListaConectados";
            this.gridListaConectados.RowHeadersVisible = false;
            this.gridListaConectados.RowHeadersWidth = 51;
            this.gridListaConectados.Size = new System.Drawing.Size(175, 95);
            this.gridListaConectados.TabIndex = 30;
            this.gridListaConectados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridListaConectados_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.label1.Location = new System.Drawing.Point(384, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "Usuarios Conectados:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Desconectar
            // 
            this.Desconectar.BackColor = System.Drawing.Color.DarkRed;
            this.Desconectar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desconectar.ForeColor = System.Drawing.Color.LightGray;
            this.Desconectar.Location = new System.Drawing.Point(12, 307);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(351, 22);
            this.Desconectar.TabIndex = 30;
            this.Desconectar.Text = "Desconectar / Cerrar";
            this.Desconectar.UseVisualStyleBackColor = false;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click_1);
            // 
            // crearPartida
            // 
            this.crearPartida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(29)))), ((int)(((byte)(60)))));
            this.crearPartida.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearPartida.ForeColor = System.Drawing.Color.LightGray;
            this.crearPartida.Location = new System.Drawing.Point(369, 134);
            this.crearPartida.Name = "crearPartida";
            this.crearPartida.Size = new System.Drawing.Size(175, 22);
            this.crearPartida.TabIndex = 31;
            this.crearPartida.Text = "Iniciar Partida";
            this.crearPartida.UseVisualStyleBackColor = false;
            this.crearPartida.Click += new System.EventHandler(this.crearPartida_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(210)))), ((int)(((byte)(5)))));
            this.label4.Location = new System.Drawing.Point(369, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 14);
            this.label4.TabIndex = 32;
            this.label4.Text = "Estado de los Invitados:";
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
            this.estadoInvitados.Location = new System.Drawing.Point(369, 206);
            this.estadoInvitados.Name = "estadoInvitados";
            this.estadoInvitados.RowHeadersVisible = false;
            this.estadoInvitados.RowHeadersWidth = 51;
            this.estadoInvitados.Size = new System.Drawing.Size(175, 123);
            this.estadoInvitados.TabIndex = 33;
            // 
            // tiempo
            // 
            this.tiempo.BackColor = System.Drawing.Color.Transparent;
            this.tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempo.ForeColor = System.Drawing.Color.LightGray;
            this.tiempo.Location = new System.Drawing.Point(418, 159);
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
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(19)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(554, 341);
            this.Controls.Add(this.tiempo);
            this.Controls.Add(this.estadoInvitados);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.crearPartida);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridListaConectados);
            this.Controls.Add(this.groupBox1);
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
        private System.Windows.Forms.RadioButton Petición_Alba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Petición_Eloi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fechaPartida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridListaConectados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button crearPartida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView estadoInvitados;
        private System.Windows.Forms.Label tiempo;
        private System.Windows.Forms.Timer cuentaAtras;
    }
}

