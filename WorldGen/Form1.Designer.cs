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
            this.components = new System.ComponentModel.Container();
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
            this.menuSalvar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nSGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSchema = new System.Windows.Forms.ComboBox();
            this.tbScale = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.cbProyecciones = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tvAccidentes = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.nudW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.menuSalvar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "GO!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudW
            // 
            this.nudW.Location = new System.Drawing.Point(84, 44);
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
            this.nudH.Location = new System.Drawing.Point(204, 44);
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
            this.label2.Location = new System.Drawing.Point(37, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ancho:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Alto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Latitud:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Longitud:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Escala:";
            // 
            // tbLat
            // 
            this.tbLat.Location = new System.Drawing.Point(85, 82);
            this.tbLat.Name = "tbLat";
            this.tbLat.Size = new System.Drawing.Size(62, 20);
            this.tbLat.TabIndex = 4;
            this.tbLat.Text = "0,0";
            this.tbLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLat_KeyPress);
            // 
            // tbLong
            // 
            this.tbLong.Location = new System.Drawing.Point(214, 82);
            this.tbLong.Name = "tbLong";
            this.tbLong.Size = new System.Drawing.Size(62, 20);
            this.tbLong.TabIndex = 5;
            this.tbLong.Text = "0,0";
            this.tbLong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLong_KeyPress);
            // 
            // pbMapa
            // 
            this.pbMapa.ContextMenuStrip = this.menuSalvar;
            this.pbMapa.Location = new System.Drawing.Point(282, 12);
            this.pbMapa.Name = "pbMapa";
            this.pbMapa.Size = new System.Drawing.Size(800, 600);
            this.pbMapa.TabIndex = 13;
            this.pbMapa.TabStop = false;
            // 
            // menuSalvar
            // 
            this.menuSalvar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nSGuardar});
            this.menuSalvar.Name = "menuSalvar";
            this.menuSalvar.Size = new System.Drawing.Size(162, 26);
            // 
            // nSGuardar
            // 
            this.nSGuardar.Name = "nSGuardar";
            this.nSGuardar.Size = new System.Drawing.Size(161, 22);
            this.nSGuardar.Text = "Guardar Como...";
            this.nSGuardar.Click += new System.EventHandler(this.nSGuardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Esquema de color:";
            // 
            // cbSchema
            // 
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Location = new System.Drawing.Point(138, 144);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(138, 21);
            this.cbSchema.TabIndex = 7;
            // 
            // tbScale
            // 
            this.tbScale.Location = new System.Drawing.Point(85, 118);
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(62, 20);
            this.tbScale.TabIndex = 6;
            this.tbScale.Text = "1,0";
            this.tbScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbScale_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslEstado,
            this.ProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 636);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1291, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslEstado
            // 
            this.tslEstado.Name = "tslEstado";
            this.tslEstado.Size = new System.Drawing.Size(49, 17);
            this.tslEstado.Text = "Iniciado";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // cbProyecciones
            // 
            this.cbProyecciones.FormattingEnabled = true;
            this.cbProyecciones.Location = new System.Drawing.Point(106, 174);
            this.cbProyecciones.Name = "cbProyecciones";
            this.cbProyecciones.Size = new System.Drawing.Size(138, 21);
            this.cbProyecciones.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Proyección:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Etiquetar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tvAccidentes
            // 
            this.tvAccidentes.Location = new System.Drawing.Point(1088, 46);
            this.tvAccidentes.Name = "tvAccidentes";
            this.tvAccidentes.Size = new System.Drawing.Size(191, 566);
            this.tvAccidentes.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 658);
            this.Controls.Add(this.tvAccidentes);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbProyecciones);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.statusStrip1);
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
            this.menuSalvar.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslEstado;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ComboBox cbProyecciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip menuSalvar;
        private System.Windows.Forms.ToolStripMenuItem nSGuardar;
        private System.Windows.Forms.TreeView tvAccidentes;
    }
}

