namespace ClipperPro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ibImagen = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirImágenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearArchivoDeEjemplosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearArchivosDeEntrenamientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemploToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaciarFicherosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaciarFicheroBahíasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaciarFicheroPenínsulasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaciarFicheroCabosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaciarFicheroCanalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaciarFicheroGolfosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaciarNegativosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaciarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ibCrop = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNada = new System.Windows.Forms.RadioButton();
            this.rbGolfo = new System.Windows.Forms.RadioButton();
            this.rbBahia = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbCan = new System.Windows.Forms.RadioButton();
            this.rbCabo = new System.Windows.Forms.RadioButton();
            this.rbPen = new System.Windows.Forms.RadioButton();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbHelp = new System.Windows.Forms.GroupBox();
            this.lblHelp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ibImagen)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibCrop)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // ibImagen
            // 
            this.ibImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibImagen.Location = new System.Drawing.Point(12, 47);
            this.ibImagen.Name = "ibImagen";
            this.ibImagen.Size = new System.Drawing.Size(800, 600);
            this.ibImagen.TabIndex = 2;
            this.ibImagen.TabStop = false;
            this.ibImagen.Paint += new System.Windows.Forms.PaintEventHandler(this.ibImagen_Paint);
            this.ibImagen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ibImagen_MouseDown);
            this.ibImagen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ibImagen_MouseMove);
            this.ibImagen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ibImagen_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ejemploToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirImágenToolStripMenuItem,
            this.crearToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirImágenToolStripMenuItem
            // 
            this.abrirImágenToolStripMenuItem.Name = "abrirImágenToolStripMenuItem";
            this.abrirImágenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirImágenToolStripMenuItem.Text = "Abrir mapa";
            this.abrirImágenToolStripMenuItem.Click += new System.EventHandler(this.abrirImágenToolStripMenuItem_Click);
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearArchivoDeEjemplosToolStripMenuItem,
            this.crearArchivosDeEntrenamientoToolStripMenuItem});
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.crearToolStripMenuItem.Text = "Crear...";
            // 
            // crearArchivoDeEjemplosToolStripMenuItem
            // 
            this.crearArchivoDeEjemplosToolStripMenuItem.Name = "crearArchivoDeEjemplosToolStripMenuItem";
            this.crearArchivoDeEjemplosToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.crearArchivoDeEjemplosToolStripMenuItem.Text = "Crear archivo de ejemplos";
            this.crearArchivoDeEjemplosToolStripMenuItem.Click += new System.EventHandler(this.crearArchivoDeEjemplosToolStripMenuItem_Click);
            // 
            // crearArchivosDeEntrenamientoToolStripMenuItem
            // 
            this.crearArchivosDeEntrenamientoToolStripMenuItem.Name = "crearArchivosDeEntrenamientoToolStripMenuItem";
            this.crearArchivosDeEntrenamientoToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.crearArchivosDeEntrenamientoToolStripMenuItem.Text = "Crear archivos de entrenamiento";
            this.crearArchivosDeEntrenamientoToolStripMenuItem.Click += new System.EventHandler(this.crearArchivosDeEntrenamientoToolStripMenuItem_Click);
            // 
            // ejemploToolStripMenuItem
            // 
            this.ejemploToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vaciarFicherosToolStripMenuItem});
            this.ejemploToolStripMenuItem.Name = "ejemploToolStripMenuItem";
            this.ejemploToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ejemploToolStripMenuItem.Text = "Ejemplos";
            // 
            // vaciarFicherosToolStripMenuItem
            // 
            this.vaciarFicherosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vaciarFicheroBahíasToolStripMenuItem,
            this.vaciarFicheroPenínsulasToolStripMenuItem,
            this.vaciarFicheroCabosToolStripMenuItem,
            this.vaciarFicheroCanalesToolStripMenuItem,
            this.vaciarFicheroGolfosToolStripMenuItem,
            this.vaciarNegativosToolStripMenuItem,
            this.vaciarTodosToolStripMenuItem});
            this.vaciarFicherosToolStripMenuItem.Name = "vaciarFicherosToolStripMenuItem";
            this.vaciarFicherosToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.vaciarFicherosToolStripMenuItem.Text = "Vaciar Ficheros";
            // 
            // vaciarFicheroBahíasToolStripMenuItem
            // 
            this.vaciarFicheroBahíasToolStripMenuItem.Name = "vaciarFicheroBahíasToolStripMenuItem";
            this.vaciarFicheroBahíasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.vaciarFicheroBahíasToolStripMenuItem.Text = "Vaciar fichero Bahías";
            this.vaciarFicheroBahíasToolStripMenuItem.Click += new System.EventHandler(this.vaciarFicheroBahíasToolStripMenuItem_Click);
            // 
            // vaciarFicheroPenínsulasToolStripMenuItem
            // 
            this.vaciarFicheroPenínsulasToolStripMenuItem.Name = "vaciarFicheroPenínsulasToolStripMenuItem";
            this.vaciarFicheroPenínsulasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.vaciarFicheroPenínsulasToolStripMenuItem.Text = "Vaciar fichero Penínsulas";
            this.vaciarFicheroPenínsulasToolStripMenuItem.Click += new System.EventHandler(this.vaciarFicheroPenínsulasToolStripMenuItem_Click);
            // 
            // vaciarFicheroCabosToolStripMenuItem
            // 
            this.vaciarFicheroCabosToolStripMenuItem.Name = "vaciarFicheroCabosToolStripMenuItem";
            this.vaciarFicheroCabosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.vaciarFicheroCabosToolStripMenuItem.Text = "Vaciar fichero Cabos";
            this.vaciarFicheroCabosToolStripMenuItem.Click += new System.EventHandler(this.vaciarFicheroCabosToolStripMenuItem_Click);
            // 
            // vaciarFicheroCanalesToolStripMenuItem
            // 
            this.vaciarFicheroCanalesToolStripMenuItem.Name = "vaciarFicheroCanalesToolStripMenuItem";
            this.vaciarFicheroCanalesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.vaciarFicheroCanalesToolStripMenuItem.Text = "Vaciar fichero Canales";
            this.vaciarFicheroCanalesToolStripMenuItem.Click += new System.EventHandler(this.vaciarFicheroCanalesToolStripMenuItem_Click);
            // 
            // vaciarFicheroGolfosToolStripMenuItem
            // 
            this.vaciarFicheroGolfosToolStripMenuItem.Name = "vaciarFicheroGolfosToolStripMenuItem";
            this.vaciarFicheroGolfosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.vaciarFicheroGolfosToolStripMenuItem.Text = "Vaciar fichero Golfos";
            this.vaciarFicheroGolfosToolStripMenuItem.Click += new System.EventHandler(this.vaciarFicheroGolfosToolStripMenuItem_Click);
            // 
            // vaciarNegativosToolStripMenuItem
            // 
            this.vaciarNegativosToolStripMenuItem.Name = "vaciarNegativosToolStripMenuItem";
            this.vaciarNegativosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.vaciarNegativosToolStripMenuItem.Text = "Vaciar fichero Negativos";
            this.vaciarNegativosToolStripMenuItem.Click += new System.EventHandler(this.vaciarTodosToolStripMenuItem_Click);
            // 
            // vaciarTodosToolStripMenuItem
            // 
            this.vaciarTodosToolStripMenuItem.Name = "vaciarTodosToolStripMenuItem";
            this.vaciarTodosToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.vaciarTodosToolStripMenuItem.Text = "Vaciar todos";
            this.vaciarTodosToolStripMenuItem.Click += new System.EventHandler(this.vaciarTodosToolStripMenuItem1_Click);
            // 
            // ibCrop
            // 
            this.ibCrop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ibCrop.Location = new System.Drawing.Point(835, 47);
            this.ibCrop.Name = "ibCrop";
            this.ibCrop.Size = new System.Drawing.Size(75, 75);
            this.ibCrop.TabIndex = 2;
            this.ibCrop.TabStop = false;
            this.ibCrop.Paint += new System.Windows.Forms.PaintEventHandler(this.ibCrop_Paint);
            this.ibCrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ibCrop_MouseDown);
            this.ibCrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ibCrop_MouseMove);
            this.ibCrop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ibCrop_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mapa Original";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(832, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Región elegida";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNada);
            this.groupBox1.Controls.Add(this.rbGolfo);
            this.groupBox1.Controls.Add(this.rbBahia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbCan);
            this.groupBox1.Controls.Add(this.rbCabo);
            this.groupBox1.Controls.Add(this.rbPen);
            this.groupBox1.Location = new System.Drawing.Point(835, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 144);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de accidente";
            // 
            // rbNada
            // 
            this.rbNada.AutoSize = true;
            this.rbNada.Checked = true;
            this.rbNada.Location = new System.Drawing.Point(60, 121);
            this.rbNada.Name = "rbNada";
            this.rbNada.Size = new System.Drawing.Size(51, 17);
            this.rbNada.TabIndex = 7;
            this.rbNada.TabStop = true;
            this.rbNada.Text = "Nada";
            this.rbNada.UseVisualStyleBackColor = true;
            this.rbNada.Click += new System.EventHandler(this.rbNada_Click);
            // 
            // rbGolfo
            // 
            this.rbGolfo.AutoSize = true;
            this.rbGolfo.Location = new System.Drawing.Point(85, 97);
            this.rbGolfo.Name = "rbGolfo";
            this.rbGolfo.Size = new System.Drawing.Size(50, 17);
            this.rbGolfo.TabIndex = 6;
            this.rbGolfo.Tag = resources.GetString("rbGolfo.Tag");
            this.rbGolfo.Text = "Golfo";
            this.rbGolfo.UseVisualStyleBackColor = true;
            this.rbGolfo.Click += new System.EventHandler(this.rbGolfo_Click);
            // 
            // rbBahia
            // 
            this.rbBahia.AutoSize = true;
            this.rbBahia.Location = new System.Drawing.Point(85, 73);
            this.rbBahia.Name = "rbBahia";
            this.rbBahia.Size = new System.Drawing.Size(54, 17);
            this.rbBahia.TabIndex = 5;
            this.rbBahia.Tag = resources.GetString("rbBahia.Tag");
            this.rbBahia.Text = "Bahía";
            this.rbBahia.UseVisualStyleBackColor = true;
            this.rbBahia.Click += new System.EventHandler(this.rbBahia_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Agua";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tierra";
            // 
            // rbCan
            // 
            this.rbCan.AutoSize = true;
            this.rbCan.Location = new System.Drawing.Point(85, 50);
            this.rbCan.Name = "rbCan";
            this.rbCan.Size = new System.Drawing.Size(99, 17);
            this.rbCan.TabIndex = 2;
            this.rbCan.Tag = "Canal de agua que conecta dos lagos, mares u océanos , en consecuencia se encuent" +
    "ra entre dos masas de tierra. Los términos estrecho, canal y paso pueden ser sin" +
    "ónimos e intercambiables.";
            this.rbCan.Text = "Estrecho/Canal";
            this.rbCan.UseVisualStyleBackColor = true;
            this.rbCan.Click += new System.EventHandler(this.rbCan_Click);
            // 
            // rbCabo
            // 
            this.rbCabo.AutoSize = true;
            this.rbCabo.Location = new System.Drawing.Point(6, 73);
            this.rbCabo.Name = "rbCabo";
            this.rbCabo.Size = new System.Drawing.Size(50, 17);
            this.rbCabo.TabIndex = 1;
            this.rbCabo.Tag = resources.GetString("rbCabo.Tag");
            this.rbCabo.Text = "Cabo";
            this.rbCabo.UseVisualStyleBackColor = true;
            this.rbCabo.Click += new System.EventHandler(this.rbCabo_Click);
            // 
            // rbPen
            // 
            this.rbPen.AutoSize = true;
            this.rbPen.Location = new System.Drawing.Point(6, 50);
            this.rbPen.Name = "rbPen";
            this.rbPen.Size = new System.Drawing.Size(73, 17);
            this.rbPen.TabIndex = 0;
            this.rbPen.Tag = resources.GetString("rbPen.Tag");
            this.rbPen.Text = "Península";
            this.rbPen.UseVisualStyleBackColor = true;
            this.rbPen.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.rbPen.Click += new System.EventHandler(this.rbPen_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(895, 279);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbHelp
            // 
            this.gbHelp.Controls.Add(this.lblHelp);
            this.gbHelp.Location = new System.Drawing.Point(835, 332);
            this.gbHelp.Name = "gbHelp";
            this.gbHelp.Size = new System.Drawing.Size(200, 315);
            this.gbHelp.TabIndex = 8;
            this.gbHelp.TabStop = false;
            this.gbHelp.Text = "Ayudas";
            // 
            // lblHelp
            // 
            this.lblHelp.Location = new System.Drawing.Point(6, 30);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(188, 271);
            this.lblHelp.TabIndex = 0;
            this.lblHelp.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 659);
            this.Controls.Add(this.gbHelp);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ibCrop);
            this.Controls.Add(this.ibImagen);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ClipperPro";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibImagen)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ibCrop)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbHelp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibImagen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirImágenToolStripMenuItem;
        private Emgu.CV.UI.ImageBox ibCrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbGolfo;
        private System.Windows.Forms.RadioButton rbBahia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbCan;
        private System.Windows.Forms.RadioButton rbCabo;
        private System.Windows.Forms.RadioButton rbPen;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.RadioButton rbNada;
        private System.Windows.Forms.GroupBox gbHelp;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.ToolStripMenuItem ejemploToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaciarFicherosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaciarFicheroBahíasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaciarFicheroPenínsulasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaciarFicheroCabosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaciarFicheroCanalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaciarFicheroGolfosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaciarNegativosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaciarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearArchivoDeEjemplosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearArchivosDeEntrenamientoToolStripMenuItem;
    }
}

