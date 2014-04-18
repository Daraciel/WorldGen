namespace WorldGen
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            this.button1 = new System.Windows.Forms.Button();
            this.nudW = new System.Windows.Forms.NumericUpDown();
            this.nudH = new System.Windows.Forms.NumericUpDown();
            this.tbS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLat = new System.Windows.Forms.TextBox();
            this.tbLong = new System.Windows.Forms.TextBox();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSchema = new System.Windows.Forms.ComboBox();
            this.tbScale = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1204, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "GO!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudW
            // 
            this.nudW.Location = new System.Drawing.Point(279, 13);
            this.nudW.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nudW.Name = "nudW";
            this.nudW.Size = new System.Drawing.Size(62, 20);
            this.nudW.TabIndex = 2;
            this.nudW.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // nudH
            // 
            this.nudH.Location = new System.Drawing.Point(399, 13);
            this.nudH.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nudH.Name = "nudH";
            this.nudH.Size = new System.Drawing.Size(62, 20);
            this.nudH.TabIndex = 3;
            this.nudH.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // tbS
            // 
            this.tbS.Location = new System.Drawing.Point(86, 12);
            this.tbS.Name = "tbS";
            this.tbS.Size = new System.Drawing.Size(123, 20);
            this.tbS.TabIndex = 1;
            this.tbS.Text = "0.123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Semilla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ancho:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Alto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Latitud:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(632, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Longitud:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(786, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Escala:";
            // 
            // tbLat
            // 
            this.tbLat.Location = new System.Drawing.Point(542, 12);
            this.tbLat.Name = "tbLat";
            this.tbLat.Size = new System.Drawing.Size(62, 20);
            this.tbLat.TabIndex = 4;
            this.tbLat.Text = "0,0";
            this.tbLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLat_KeyPress);
            // 
            // tbLong
            // 
            this.tbLong.Location = new System.Drawing.Point(689, 12);
            this.tbLong.Name = "tbLong";
            this.tbLong.Size = new System.Drawing.Size(62, 20);
            this.tbLong.TabIndex = 5;
            this.tbLong.Text = "0,0";
            this.tbLong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLong_KeyPress);
            // 
            // pbMapa
            // 
            this.pbMapa.Location = new System.Drawing.Point(12, 51);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(1267, 574);
            this.pbMapa.TabIndex = 13;
            this.pbMapa.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(935, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Esquema de color:";
            // 
            // cbSchema
            // 
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Location = new System.Drawing.Point(1036, 12);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(138, 21);
            this.cbSchema.TabIndex = 15;
            // 
            // tbScale
            // 
            this.tbScale.Location = new System.Drawing.Point(834, 13);
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(62, 20);
            this.tbScale.TabIndex = 16;
            this.tbScale.Text = "1,0";
            this.tbScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbScale_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 637);
            this.Controls.Add(this.tbScale);
            this.Controls.Add(this.cbSchema);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbMapa);
            this.Controls.Add(this.tbLong);
            this.Controls.Add(this.tbLat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbS);
            this.Controls.Add(this.nudH);
            this.Controls.Add(this.nudW);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudW;
        private System.Windows.Forms.NumericUpDown nudH;
        private System.Windows.Forms.TextBox tbS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLat;
        private System.Windows.Forms.TextBox tbLong;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSchema;
        private System.Windows.Forms.TextBox tbScale;
    }
}

