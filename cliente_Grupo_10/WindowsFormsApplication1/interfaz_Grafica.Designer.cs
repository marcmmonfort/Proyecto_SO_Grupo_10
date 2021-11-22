
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(interfaz_Grafica));
            this.testSIA = new System.Windows.Forms.Button();
            this.testComunidad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testSIA
            // 
            this.testSIA.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.testSIA.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSIA.Location = new System.Drawing.Point(148, 367);
            this.testSIA.Name = "testSIA";
            this.testSIA.Size = new System.Drawing.Size(215, 22);
            this.testSIA.TabIndex = 31;
            this.testSIA.Text = "Test SIA";
            this.testSIA.UseVisualStyleBackColor = false;
            this.testSIA.Click += new System.EventHandler(this.testSIA_Click);
            // 
            // testComunidad
            // 
            this.testComunidad.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.testComunidad.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testComunidad.Location = new System.Drawing.Point(148, 339);
            this.testComunidad.Name = "testComunidad";
            this.testComunidad.Size = new System.Drawing.Size(215, 22);
            this.testComunidad.TabIndex = 32;
            this.testComunidad.Text = "Test Comunidad";
            this.testComunidad.UseVisualStyleBackColor = false;
            this.testComunidad.Click += new System.EventHandler(this.testComunidad_Click);
            // 
            // interfaz_Grafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(502, 486);
            this.Controls.Add(this.testComunidad);
            this.Controls.Add(this.testSIA);
            this.Name = "interfaz_Grafica";
            this.Text = "interfaz_Grafica";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testSIA;
        private System.Windows.Forms.Button testComunidad;
    }
}