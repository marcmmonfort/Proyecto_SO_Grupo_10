
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
            this.components = new System.ComponentModel.Container();
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
            this.nom = new System.Windows.Forms.Label();
            this.tempsMin = new System.Windows.Forms.Label();
            this.tempsSec = new System.Windows.Forms.Label();
            this.textMin = new System.Windows.Forms.Label();
            this.textSec = new System.Windows.Forms.Label();
            this.tempsPartida = new System.Windows.Forms.Timer(this.components);
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
            this.enviar.Location = new System.Drawing.Point(151, 201);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(110, 23);
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
            this.cerrar.Size = new System.Drawing.Size(108, 23);
            this.cerrar.TabIndex = 38;
            this.cerrar.Text = "Cerrar Juego";
            this.cerrar.UseVisualStyleBackColor = false;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // nom
            // 
            this.nom.BackColor = System.Drawing.Color.Transparent;
            this.nom.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nom.ForeColor = System.Drawing.Color.White;
            this.nom.Location = new System.Drawing.Point(45, 99);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(137, 17);
            this.nom.TabIndex = 63;
            this.nom.Text = "nombre";
            this.nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tempsMin
            // 
            this.tempsMin.BackColor = System.Drawing.Color.Transparent;
            this.tempsMin.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempsMin.ForeColor = System.Drawing.Color.White;
            this.tempsMin.Location = new System.Drawing.Point(377, 99);
            this.tempsMin.Name = "tempsMin";
            this.tempsMin.Size = new System.Drawing.Size(33, 18);
            this.tempsMin.TabIndex = 64;
            this.tempsMin.Text = "0";
            this.tempsMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tempsSec
            // 
            this.tempsSec.BackColor = System.Drawing.Color.Transparent;
            this.tempsSec.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempsSec.ForeColor = System.Drawing.Color.White;
            this.tempsSec.Location = new System.Drawing.Point(377, 113);
            this.tempsSec.Name = "tempsSec";
            this.tempsSec.Size = new System.Drawing.Size(33, 24);
            this.tempsSec.TabIndex = 65;
            this.tempsSec.Text = "0";
            this.tempsSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textMin
            // 
            this.textMin.BackColor = System.Drawing.Color.Transparent;
            this.textMin.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMin.ForeColor = System.Drawing.Color.White;
            this.textMin.Location = new System.Drawing.Point(405, 99);
            this.textMin.Name = "textMin";
            this.textMin.Size = new System.Drawing.Size(80, 18);
            this.textMin.TabIndex = 66;
            this.textMin.Text = "minutes";
            this.textMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textSec
            // 
            this.textSec.BackColor = System.Drawing.Color.Transparent;
            this.textSec.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSec.ForeColor = System.Drawing.Color.White;
            this.textSec.Location = new System.Drawing.Point(405, 116);
            this.textSec.Name = "textSec";
            this.textSec.Size = new System.Drawing.Size(80, 18);
            this.textSec.TabIndex = 67;
            this.textSec.Text = "seconds";
            this.textSec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tempsPartida
            // 
            this.tempsPartida.Tick += new System.EventHandler(this.tempsPartida_Tick);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Inicio_Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(524, 236);
            this.Controls.Add(this.textSec);
            this.Controls.Add(this.textMin);
            this.Controls.Add(this.tempsSec);
            this.Controls.Add(this.tempsMin);
            this.Controls.Add(this.nom);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inicio_FormClosing);
            this.Load += new System.EventHandler(this.Inicio_Load_1);
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
        private System.Windows.Forms.Label nom;
        private System.Windows.Forms.Label tempsMin;
        private System.Windows.Forms.Label tempsSec;
        private System.Windows.Forms.Label textMin;
        private System.Windows.Forms.Label textSec;
        private System.Windows.Forms.Timer tempsPartida;
    }
}