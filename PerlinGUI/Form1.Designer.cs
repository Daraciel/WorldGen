namespace PerlinGUI
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
            this.tbSemilla = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPersistencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudAmplitud = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudOctavas = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.nudAlto = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAncho = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pbMapa = new System.Windows.Forms.PictureBox();
            this.tvOctavas = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmplitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOctavas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSemilla);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbPersistencia);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudAmplitud);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudOctavas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.nudAlto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudAncho);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 600);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valores del mapa";
            // 
            // tbSemilla
            // 
            this.tbSemilla.Location = new System.Drawing.Point(67, 19);
            this.tbSemilla.Name = "tbSemilla";
            this.tbSemilla.Size = new System.Drawing.Size(127, 20);
            this.tbSemilla.TabIndex = 20;
            this.tbSemilla.Text = "123456789";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Semilla";
            // 
            // tbPersistencia
            // 
            this.tbPersistencia.Location = new System.Drawing.Point(67, 150);
            this.tbPersistencia.Name = "tbPersistencia";
            this.tbPersistencia.Size = new System.Drawing.Size(127, 20);
            this.tbPersistencia.TabIndex = 18;
            this.tbPersistencia.Text = "0,5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Persistencia";
            // 
            // nudAmplitud
            // 
            this.nudAmplitud.DecimalPlaces = 2;
            this.nudAmplitud.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudAmplitud.Location = new System.Drawing.Point(67, 124);
            this.nudAmplitud.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAmplitud.Name = "nudAmplitud";
            this.nudAmplitud.Size = new System.Drawing.Size(127, 20);
            this.nudAmplitud.TabIndex = 14;
            this.nudAmplitud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Amplitud";
            // 
            // nudOctavas
            // 
            this.nudOctavas.Location = new System.Drawing.Point(67, 98);
            this.nudOctavas.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudOctavas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOctavas.Name = "nudOctavas";
            this.nudOctavas.Size = new System.Drawing.Size(127, 20);
            this.nudOctavas.TabIndex = 12;
            this.nudOctavas.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Octavas";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(52, 271);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Generar";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // nudAlto
            // 
            this.nudAlto.Location = new System.Drawing.Point(67, 71);
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
            this.nudAlto.Size = new System.Drawing.Size(127, 20);
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
            this.label3.Location = new System.Drawing.Point(8, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Alto";
            // 
            // nudAncho
            // 
            this.nudAncho.Location = new System.Drawing.Point(67, 45);
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
            this.nudAncho.Size = new System.Drawing.Size(127, 20);
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
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ancho";
            // 
            // pbMapa
            // 
            this.pbMapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMapa.Location = new System.Drawing.Point(218, 12);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(800, 600);
            this.pbMapa.TabIndex = 2;
            this.pbMapa.TabStop = false;
            // 
            // tvOctavas
            // 
            this.tvOctavas.Location = new System.Drawing.Point(1024, 41);
            this.tvOctavas.Name = "tvOctavas";
            this.tvOctavas.Size = new System.Drawing.Size(145, 265);
            this.tvOctavas.TabIndex = 3;
            this.tvOctavas.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvOctavas_NodeMouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 624);
            this.Controls.Add(this.tvOctavas);
            this.Controls.Add(this.pbMapa);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "PerlinGUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmplitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOctavas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.NumericUpDown nudAlto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAncho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbMapa;
        private System.Windows.Forms.TextBox tbSemilla;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPersistencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudAmplitud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudOctavas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvOctavas;
    }
}

