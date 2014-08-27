namespace GCGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbSemilla = new System.Windows.Forms.TextBox();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudAncho = new System.Windows.Forms.NumericUpDown();
            this.nudAlto = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudIteraciones = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAgua = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGO = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteraciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgua)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGO);
            this.groupBox1.Controls.Add(this.nudAgua);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudIteraciones);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudAlto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudAncho);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbSemilla);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 341);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semilla:";
            // 
            // tbSemilla
            // 
            this.tbSemilla.Location = new System.Drawing.Point(77, 19);
            this.tbSemilla.Name = "tbSemilla";
            this.tbSemilla.Size = new System.Drawing.Size(136, 20);
            this.tbSemilla.TabIndex = 1;
            // 
            // pbMapa
            // 
            this.pbMapa.Location = new System.Drawing.Point(249, 13);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(800, 600);
            this.pbMapa.TabIndex = 1;
            this.pbMapa.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ancho:";
            // 
            // nudAncho
            // 
            this.nudAncho.Location = new System.Drawing.Point(77, 71);
            this.nudAncho.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.nudAncho.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudAncho.Name = "nudAncho";
            this.nudAncho.Size = new System.Drawing.Size(68, 20);
            this.nudAncho.TabIndex = 3;
            this.nudAncho.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // nudAlto
            // 
            this.nudAlto.Location = new System.Drawing.Point(77, 97);
            this.nudAlto.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.nudAlto.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.nudAlto.Name = "nudAlto";
            this.nudAlto.Size = new System.Drawing.Size(68, 20);
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
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alto:";
            // 
            // nudIteraciones
            // 
            this.nudIteraciones.Location = new System.Drawing.Point(77, 45);
            this.nudIteraciones.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudIteraciones.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudIteraciones.Name = "nudIteraciones";
            this.nudIteraciones.Size = new System.Drawing.Size(136, 20);
            this.nudIteraciones.TabIndex = 7;
            this.nudIteraciones.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIteraciones.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Iteraciones:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // nudAgua
            // 
            this.nudAgua.Location = new System.Drawing.Point(77, 123);
            this.nudAgua.Name = "nudAgua";
            this.nudAgua.Size = new System.Drawing.Size(68, 20);
            this.nudAgua.TabIndex = 9;
            this.nudAgua.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "% de Agua:";
            // 
            // btnGO
            // 
            this.btnGO.Location = new System.Drawing.Point(70, 166);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(75, 23);
            this.btnGO.TabIndex = 10;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 620);
            this.Controls.Add(this.pbMapa);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "GreatCirclesGUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIteraciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAgua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudAlto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAncho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSemilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.NumericUpDown nudIteraciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.NumericUpDown nudAgua;
        private System.Windows.Forms.Label label5;
    }
}

