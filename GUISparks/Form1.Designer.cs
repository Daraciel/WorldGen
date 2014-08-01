namespace GUISparks
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nudTierra = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSparks = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAlto = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAncho = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSemilla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTierra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSparks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.nudTierra);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudSparks);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudAlto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudAncho);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbSemilla);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 600);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudTierra
            // 
            this.nudTierra.Location = new System.Drawing.Point(114, 126);
            this.nudTierra.Name = "nudTierra";
            this.nudTierra.Size = new System.Drawing.Size(80, 20);
            this.nudTierra.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Probailidad de Tierra";
            // 
            // nudSparks
            // 
            this.nudSparks.Location = new System.Drawing.Point(114, 100);
            this.nudSparks.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudSparks.Name = "nudSparks";
            this.nudSparks.Size = new System.Drawing.Size(80, 20);
            this.nudSparks.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cantidad de Sparks";
            // 
            // nudAlto
            // 
            this.nudAlto.Location = new System.Drawing.Point(52, 74);
            this.nudAlto.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudAlto.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudAlto.Name = "nudAlto";
            this.nudAlto.Size = new System.Drawing.Size(142, 20);
            this.nudAlto.TabIndex = 5;
            this.nudAlto.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alto";
            // 
            // nudAncho
            // 
            this.nudAncho.Location = new System.Drawing.Point(52, 48);
            this.nudAncho.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudAncho.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudAncho.Name = "nudAncho";
            this.nudAncho.Size = new System.Drawing.Size(142, 20);
            this.nudAncho.TabIndex = 3;
            this.nudAncho.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ancho";
            // 
            // tbSemilla
            // 
            this.tbSemilla.Location = new System.Drawing.Point(52, 22);
            this.tbSemilla.Name = "tbSemilla";
            this.tbSemilla.Size = new System.Drawing.Size(142, 20);
            this.tbSemilla.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semilla";
            // 
            // pbMapa
            // 
            this.pbMapa.Location = new System.Drawing.Point(218, 12);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(800, 600);
            this.pbMapa.TabIndex = 1;
            this.pbMapa.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 624);
            this.Controls.Add(this.pbMapa);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTierra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSparks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudTierra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSparks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAlto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAncho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSemilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.Button button1;
    }
}

