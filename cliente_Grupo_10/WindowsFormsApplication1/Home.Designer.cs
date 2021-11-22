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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Desconectar = new System.Windows.Forms.Button();
            this.enviar = new System.Windows.Forms.Button();
            this.Petición_Marc = new System.Windows.Forms.RadioButton();
            this.Petición_Alba = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.Petición_Eloi = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fechaPartida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openGame = new System.Windows.Forms.Button();
            this.gridListaConectados = new System.Windows.Forms.DataGridView();
            this.dameLista = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // Desconectar
            // 
            this.Desconectar.BackColor = System.Drawing.Color.DarkRed;
            this.Desconectar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desconectar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Desconectar.Location = new System.Drawing.Point(16, 15);
            this.Desconectar.Margin = new System.Windows.Forms.Padding(4);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(573, 27);
            this.Desconectar.TabIndex = 8;
            this.Desconectar.Text = "Desconectar / Cerrar";
            this.Desconectar.UseVisualStyleBackColor = false;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // enviar
            // 
            this.enviar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enviar.Location = new System.Drawing.Point(8, 252);
            this.enviar.Margin = new System.Windows.Forms.Padding(4);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(557, 28);
            this.enviar.TabIndex = 5;
            this.enviar.Text = "Enviar Petición";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Petición_Marc
            // 
            this.Petición_Marc.AutoSize = true;
            this.Petición_Marc.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Petición_Marc.Location = new System.Drawing.Point(44, 78);
            this.Petición_Marc.Margin = new System.Windows.Forms.Padding(4);
            this.Petición_Marc.Name = "Petición_Marc";
            this.Petición_Marc.Size = new System.Drawing.Size(253, 21);
            this.Petición_Marc.TabIndex = 8;
            this.Petición_Marc.TabStop = true;
            this.Petición_Marc.Text = "¿Número de Partidas jugadas?";
            this.Petición_Marc.UseVisualStyleBackColor = true;
            // 
            // Petición_Alba
            // 
            this.Petición_Alba.AutoSize = true;
            this.Petición_Alba.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Petición_Alba.Location = new System.Drawing.Point(44, 107);
            this.Petición_Alba.Margin = new System.Windows.Forms.Padding(4);
            this.Petición_Alba.Name = "Petición_Alba";
            this.Petición_Alba.Size = new System.Drawing.Size(429, 21);
            this.Petición_Alba.TabIndex = 7;
            this.Petición_Alba.TabStop = true;
            this.Petición_Alba.Text = "¿Número de créditos después de una partida ganada?";
            this.Petición_Alba.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Consultas:";
            // 
            // Petición_Eloi
            // 
            this.Petición_Eloi.AutoSize = true;
            this.Petición_Eloi.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Petición_Eloi.Location = new System.Drawing.Point(44, 137);
            this.Petición_Eloi.Margin = new System.Windows.Forms.Padding(4);
            this.Petición_Eloi.Name = "Petición_Eloi";
            this.Petición_Eloi.Size = new System.Drawing.Size(221, 21);
            this.Petición_Eloi.TabIndex = 17;
            this.Petición_Eloi.TabStop = true;
            this.Petición_Eloi.Text = "¿Contra quién he ganado?";
            this.Petición_Eloi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Navy;
            this.groupBox1.Controls.Add(this.fechaPartida);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Petición_Eloi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Petición_Alba);
            this.groupBox1.Controls.Add(this.Petición_Marc);
            this.groupBox1.Controls.Add(this.enviar);
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(16, 49);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(573, 290);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticiones, Grupo 10";
            // 
            // fechaPartida
            // 
            this.fechaPartida.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.fechaPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fechaPartida.Location = new System.Drawing.Point(137, 200);
            this.fechaPartida.Margin = new System.Windows.Forms.Padding(4);
            this.fechaPartida.Name = "fechaPartida";
            this.fechaPartida.Size = new System.Drawing.Size(260, 23);
            this.fechaPartida.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 182);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Fecha de la partida:";
            // 
            // openGame
            // 
            this.openGame.BackColor = System.Drawing.Color.LawnGreen;
            this.openGame.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openGame.Location = new System.Drawing.Point(597, 313);
            this.openGame.Margin = new System.Windows.Forms.Padding(4);
            this.openGame.Name = "openGame";
            this.openGame.Size = new System.Drawing.Size(309, 27);
            this.openGame.TabIndex = 30;
            this.openGame.Text = "Open Game";
            this.openGame.UseVisualStyleBackColor = false;
            this.openGame.Click += new System.EventHandler(this.openGame_Click);
            // 
            // gridListaConectados
            // 
            this.gridListaConectados.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridListaConectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridListaConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListaConectados.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridListaConectados.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridListaConectados.GridColor = System.Drawing.Color.LightGray;
            this.gridListaConectados.Location = new System.Drawing.Point(597, 49);
            this.gridListaConectados.Margin = new System.Windows.Forms.Padding(4);
            this.gridListaConectados.Name = "gridListaConectados";
            this.gridListaConectados.RowHeadersVisible = false;
            this.gridListaConectados.RowHeadersWidth = 51;
            this.gridListaConectados.Size = new System.Drawing.Size(311, 256);
            this.gridListaConectados.TabIndex = 30;
            // 
            // dameLista
            // 
            this.dameLista.BackColor = System.Drawing.Color.Olive;
            this.dameLista.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dameLista.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.dameLista.Location = new System.Drawing.Point(597, 15);
            this.dameLista.Margin = new System.Windows.Forms.Padding(4);
            this.dameLista.Name = "dameLista";
            this.dameLista.Size = new System.Drawing.Size(311, 27);
            this.dameLista.TabIndex = 31;
            this.dameLista.Text = "Dame Lista de Conectados";
            this.dameLista.UseVisualStyleBackColor = false;
            this.dameLista.Click += new System.EventHandler(this.dameLista_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(923, 352);
            this.Controls.Add(this.gridListaConectados);
            this.Controls.Add(this.dameLista);
            this.Controls.Add(this.openGame);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Home";
            this.Text = "Formulario del Cliente, Grupo 10";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridListaConectados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.RadioButton Petición_Marc;
        private System.Windows.Forms.RadioButton Petición_Alba;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Petición_Eloi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fechaPartida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button openGame;
        private System.Windows.Forms.DataGridView gridListaConectados;
        private System.Windows.Forms.Button dameLista;
    }
}

