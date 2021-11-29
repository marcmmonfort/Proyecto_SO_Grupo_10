
namespace WindowsFormsApplication1
{
    partial class Inicio
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
            this.Register = new System.Windows.Forms.RadioButton();
            this.Login = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.userRegister = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contraRegister = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userLogin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.contraLogin = new System.Windows.Forms.TextBox();
            this.enviar = new System.Windows.Forms.Button();
            this.cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Register
            // 
            this.Register.AutoSize = true;
            this.Register.BackColor = System.Drawing.Color.Transparent;
            this.Register.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register.ForeColor = System.Drawing.Color.Yellow;
            this.Register.Location = new System.Drawing.Point(92, 33);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(90, 20);
            this.Register.TabIndex = 27;
            this.Register.TabStop = true;
            this.Register.Text = "REGISTER";
            this.Register.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.BackColor = System.Drawing.Color.Transparent;
            this.Login.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.Color.Yellow;
            this.Login.Location = new System.Drawing.Point(358, 33);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(66, 20);
            this.Login.TabIndex = 28;
            this.Login.TabStop = true;
            this.Login.Text = "LOGIN";
            this.Login.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(62, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Usuario:";
            // 
            // userRegister
            // 
            this.userRegister.BackColor = System.Drawing.Color.Gray;
            this.userRegister.Location = new System.Drawing.Point(65, 86);
            this.userRegister.Name = "userRegister";
            this.userRegister.Size = new System.Drawing.Size(144, 20);
            this.userRegister.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(62, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "Contraseña:";
            // 
            // contraRegister
            // 
            this.contraRegister.BackColor = System.Drawing.Color.Gray;
            this.contraRegister.Location = new System.Drawing.Point(65, 140);
            this.contraRegister.Name = "contraRegister";
            this.contraRegister.PasswordChar = '⌖';
            this.contraRegister.Size = new System.Drawing.Size(144, 20);
            this.contraRegister.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(312, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 33;
            this.label6.Text = "Usuario:";
            // 
            // userLogin
            // 
            this.userLogin.BackColor = System.Drawing.Color.Gray;
            this.userLogin.Location = new System.Drawing.Point(315, 86);
            this.userLogin.Name = "userLogin";
            this.userLogin.Size = new System.Drawing.Size(144, 20);
            this.userLogin.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(312, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = "Contraseña:";
            // 
            // contraLogin
            // 
            this.contraLogin.BackColor = System.Drawing.Color.Gray;
            this.contraLogin.Location = new System.Drawing.Point(315, 140);
            this.contraLogin.Name = "contraLogin";
            this.contraLogin.PasswordChar = '⌖';
            this.contraLogin.Size = new System.Drawing.Size(144, 20);
            this.contraLogin.TabIndex = 36;
            // 
            // enviar
            // 
            this.enviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(45)))), ((int)(((byte)(91)))));
            this.enviar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviar.ForeColor = System.Drawing.Color.GhostWhite;
            this.enviar.Location = new System.Drawing.Point(148, 201);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(113, 23);
            this.enviar.TabIndex = 37;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = false;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // cerrar
            // 
            this.cerrar.BackColor = System.Drawing.Color.DarkRed;
            this.cerrar.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrar.ForeColor = System.Drawing.Color.GhostWhite;
            this.cerrar.Location = new System.Drawing.Point(267, 201);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(117, 23);
            this.cerrar.TabIndex = 38;
            this.cerrar.Text = "Cerrar Juego";
            this.cerrar.UseVisualStyleBackColor = false;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Inicio_Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(524, 236);
            this.Controls.Add(this.cerrar);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.contraLogin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.userLogin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.contraRegister);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userRegister);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Register);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicio_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Register;
        private System.Windows.Forms.RadioButton Login;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contraRegister;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox contraLogin;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.Button cerrar;
    }
}