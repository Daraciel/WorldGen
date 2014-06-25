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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoMapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarMapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarMapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trbLat = new System.Windows.Forms.TrackBar();
            this.trbLong = new System.Windows.Forms.TrackBar();
            this.gbEtiquetado = new System.Windows.Forms.GroupBox();
            this.cbMasa = new System.Windows.Forms.CheckBox();
            this.cbForma = new System.Windows.Forms.CheckBox();
            this.gbVisu = new System.Windows.Forms.GroupBox();
            this.pMapa = new System.Windows.Forms.Panel();
            this.rbMapaColor = new System.Windows.Forms.RadioButton();
            this.rbMapaBN = new System.Windows.Forms.RadioButton();
            this.pAccidentes = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.rbShowShape = new System.Windows.Forms.RadioButton();
            this.rbShowRect = new System.Windows.Forms.RadioButton();
            this.cbShowNames = new System.Windows.Forms.CheckBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.cbContinentes = new System.Windows.Forms.CheckBox();
            this.cbIslas = new System.Windows.Forms.CheckBox();
            this.cbIslotes = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).BeginInit();
            this.menuSalvar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.msMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLong)).BeginInit();
            this.gbEtiquetado.SuspendLayout();
            this.gbVisu.SuspendLayout();
            this.pMapa.SuspendLayout();
            this.pAccidentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "GO!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudW
            // 
            this.nudW.Location = new System.Drawing.Point(84, 62);
            this.nudW.Maximum = new decimal(new int[] {
            8192,
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
            this.nudH.Location = new System.Drawing.Point(204, 62);
            this.nudH.Maximum = new decimal(new int[] {
            8192,
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
            this.tbS.Location = new System.Drawing.Point(86, 30);
            this.tbS.Name = "tbS";
            this.tbS.Size = new System.Drawing.Size(180, 20);
            this.tbS.TabIndex = 1;
            this.tbS.Text = "0.123";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Semilla:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ancho:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Alto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Latitud:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Longitud:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Escala:";
            // 
            // tbLat
            // 
            this.tbLat.Location = new System.Drawing.Point(86, 88);
            this.tbLat.Name = "tbLat";
            this.tbLat.Size = new System.Drawing.Size(62, 20);
            this.tbLat.TabIndex = 4;
            this.tbLat.Text = "0,0";
            this.tbLat.TextChanged += new System.EventHandler(this.tbLat_TextChanged);
            this.tbLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLat_KeyPress);
            // 
            // tbLong
            // 
            this.tbLong.Location = new System.Drawing.Point(86, 159);
            this.tbLong.Name = "tbLong";
            this.tbLong.Size = new System.Drawing.Size(62, 20);
            this.tbLong.TabIndex = 5;
            this.tbLong.Text = "0,0";
            this.tbLong.TextChanged += new System.EventHandler(this.tbLong_TextChanged);
            this.tbLong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLong_KeyPress);
            // 
            // pbMapa
            // 
            this.pbMapa.ContextMenuStrip = this.menuSalvar;
            this.pbMapa.Location = new System.Drawing.Point(282, 30);
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
            this.label7.Location = new System.Drawing.Point(29, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Esquema de color:";
            // 
            // cbSchema
            // 
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Location = new System.Drawing.Point(130, 258);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(128, 21);
            this.cbSchema.TabIndex = 7;
            // 
            // tbScale
            // 
            this.tbScale.Location = new System.Drawing.Point(77, 232);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 652);
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
            this.cbProyecciones.Location = new System.Drawing.Point(98, 288);
            this.cbProyecciones.Name = "cbProyecciones";
            this.cbProyecciones.Size = new System.Drawing.Size(160, 21);
            this.cbProyecciones.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Proyección:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Etiquetar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tvAccidentes
            // 
            this.tvAccidentes.Location = new System.Drawing.Point(1088, 64);
            this.tvAccidentes.Name = "tvAccidentes";
            this.tvAccidentes.Size = new System.Drawing.Size(191, 566);
            this.tvAccidentes.TabIndex = 20;
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1291, 24);
            this.msMenu.TabIndex = 21;
            this.msMenu.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoMapaToolStripMenuItem,
            this.guardarMapaToolStripMenuItem,
            this.cargarMapaToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoMapaToolStripMenuItem
            // 
            this.nuevoMapaToolStripMenuItem.Name = "nuevoMapaToolStripMenuItem";
            this.nuevoMapaToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.nuevoMapaToolStripMenuItem.Text = "Nuevo Mapa";
            // 
            // guardarMapaToolStripMenuItem
            // 
            this.guardarMapaToolStripMenuItem.Name = "guardarMapaToolStripMenuItem";
            this.guardarMapaToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.guardarMapaToolStripMenuItem.Text = "Guardar Mapa";
            this.guardarMapaToolStripMenuItem.Click += new System.EventHandler(this.guardarMapaToolStripMenuItem_Click);
            // 
            // cargarMapaToolStripMenuItem
            // 
            this.cargarMapaToolStripMenuItem.Name = "cargarMapaToolStripMenuItem";
            this.cargarMapaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cargarMapaToolStripMenuItem.Text = "Cargar Mapa";
            this.cargarMapaToolStripMenuItem.Click += new System.EventHandler(this.cargarMapaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // trbLat
            // 
            this.trbLat.Location = new System.Drawing.Point(32, 114);
            this.trbLat.Maximum = 90;
            this.trbLat.Minimum = -90;
            this.trbLat.Name = "trbLat";
            this.trbLat.Size = new System.Drawing.Size(226, 45);
            this.trbLat.TabIndex = 22;
            this.trbLat.ValueChanged += new System.EventHandler(this.trbLat_ValueChanged);
            // 
            // trbLong
            // 
            this.trbLong.Location = new System.Drawing.Point(32, 186);
            this.trbLong.Maximum = 360;
            this.trbLong.Minimum = -360;
            this.trbLong.Name = "trbLong";
            this.trbLong.Size = new System.Drawing.Size(226, 45);
            this.trbLong.TabIndex = 23;
            this.trbLong.ValueChanged += new System.EventHandler(this.trbLong_ValueChanged);
            // 
            // gbEtiquetado
            // 
            this.gbEtiquetado.Controls.Add(this.cbForma);
            this.gbEtiquetado.Controls.Add(this.cbMasa);
            this.gbEtiquetado.Controls.Add(this.button2);
            this.gbEtiquetado.Location = new System.Drawing.Point(13, 344);
            this.gbEtiquetado.Name = "gbEtiquetado";
            this.gbEtiquetado.Size = new System.Drawing.Size(253, 98);
            this.gbEtiquetado.TabIndex = 24;
            this.gbEtiquetado.TabStop = false;
            this.gbEtiquetado.Text = "Etiquetado";
            // 
            // cbMasa
            // 
            this.cbMasa.AutoSize = true;
            this.cbMasa.Location = new System.Drawing.Point(7, 20);
            this.cbMasa.Name = "cbMasa";
            this.cbMasa.Size = new System.Drawing.Size(191, 17);
            this.cbMasa.TabIndex = 0;
            this.cbMasa.Text = "Acc. de masa (Islas, continentes...)";
            this.cbMasa.UseVisualStyleBackColor = true;
            // 
            // cbForma
            // 
            this.cbForma.AutoSize = true;
            this.cbForma.Enabled = false;
            this.cbForma.Location = new System.Drawing.Point(7, 44);
            this.cbForma.Name = "cbForma";
            this.cbForma.Size = new System.Drawing.Size(196, 17);
            this.cbForma.TabIndex = 1;
            this.cbForma.Text = "Acc. de forma (Peninsulas, cabos...)";
            this.cbForma.UseVisualStyleBackColor = true;
            // 
            // gbVisu
            // 
            this.gbVisu.Controls.Add(this.btnMostrar);
            this.gbVisu.Controls.Add(this.pAccidentes);
            this.gbVisu.Controls.Add(this.pMapa);
            this.gbVisu.Location = new System.Drawing.Point(13, 448);
            this.gbVisu.Name = "gbVisu";
            this.gbVisu.Size = new System.Drawing.Size(253, 201);
            this.gbVisu.TabIndex = 25;
            this.gbVisu.TabStop = false;
            this.gbVisu.Text = "Visualización";
            // 
            // pMapa
            // 
            this.pMapa.Controls.Add(this.rbMapaColor);
            this.pMapa.Controls.Add(this.rbMapaBN);
            this.pMapa.Location = new System.Drawing.Point(0, 19);
            this.pMapa.Name = "pMapa";
            this.pMapa.Size = new System.Drawing.Size(253, 27);
            this.pMapa.TabIndex = 2;
            // 
            // rbMapaColor
            // 
            this.rbMapaColor.AutoSize = true;
            this.rbMapaColor.Location = new System.Drawing.Point(7, 3);
            this.rbMapaColor.Name = "rbMapaColor";
            this.rbMapaColor.Size = new System.Drawing.Size(87, 17);
            this.rbMapaColor.TabIndex = 2;
            this.rbMapaColor.TabStop = true;
            this.rbMapaColor.Text = "Mapa a color";
            this.rbMapaColor.UseVisualStyleBackColor = true;
            // 
            // rbMapaBN
            // 
            this.rbMapaBN.AutoSize = true;
            this.rbMapaBN.Location = new System.Drawing.Point(100, 3);
            this.rbMapaBN.Name = "rbMapaBN";
            this.rbMapaBN.Size = new System.Drawing.Size(128, 17);
            this.rbMapaBN.TabIndex = 3;
            this.rbMapaBN.TabStop = true;
            this.rbMapaBN.Text = "Mapa Blanco y Negro";
            this.rbMapaBN.UseVisualStyleBackColor = true;
            // 
            // pAccidentes
            // 
            this.pAccidentes.Controls.Add(this.cbIslotes);
            this.pAccidentes.Controls.Add(this.cbIslas);
            this.pAccidentes.Controls.Add(this.cbContinentes);
            this.pAccidentes.Controls.Add(this.cbShowNames);
            this.pAccidentes.Controls.Add(this.rbShowRect);
            this.pAccidentes.Controls.Add(this.rbShowShape);
            this.pAccidentes.Controls.Add(this.label9);
            this.pAccidentes.Location = new System.Drawing.Point(0, 47);
            this.pAccidentes.Name = "pAccidentes";
            this.pAccidentes.Size = new System.Drawing.Size(253, 119);
            this.pAccidentes.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Opciones de Accidentes:";
            // 
            // rbShowShape
            // 
            this.rbShowShape.AutoSize = true;
            this.rbShowShape.Location = new System.Drawing.Point(7, 18);
            this.rbShowShape.Name = "rbShowShape";
            this.rbShowShape.Size = new System.Drawing.Size(110, 17);
            this.rbShowShape.TabIndex = 1;
            this.rbShowShape.TabStop = true;
            this.rbShowShape.Text = "Mostrar contornos";
            this.rbShowShape.UseVisualStyleBackColor = true;
            // 
            // rbShowRect
            // 
            this.rbShowRect.AutoSize = true;
            this.rbShowRect.Location = new System.Drawing.Point(118, 18);
            this.rbShowRect.Name = "rbShowRect";
            this.rbShowRect.Size = new System.Drawing.Size(110, 17);
            this.rbShowRect.TabIndex = 2;
            this.rbShowRect.TabStop = true;
            this.rbShowRect.Text = "Mostrar Recuadro";
            this.rbShowRect.UseVisualStyleBackColor = true;
            // 
            // cbShowNames
            // 
            this.cbShowNames.AutoSize = true;
            this.cbShowNames.Location = new System.Drawing.Point(7, 99);
            this.cbShowNames.Name = "cbShowNames";
            this.cbShowNames.Size = new System.Drawing.Size(106, 17);
            this.cbShowNames.TabIndex = 3;
            this.cbShowNames.Text = "Mostrar Nombres";
            this.cbShowNames.UseVisualStyleBackColor = true;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(6, 172);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 4;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // cbContinentes
            // 
            this.cbContinentes.AutoSize = true;
            this.cbContinentes.Location = new System.Drawing.Point(7, 41);
            this.cbContinentes.Name = "cbContinentes";
            this.cbContinentes.Size = new System.Drawing.Size(120, 17);
            this.cbContinentes.TabIndex = 4;
            this.cbContinentes.Text = "Mostrar Continentes";
            this.cbContinentes.UseVisualStyleBackColor = true;
            // 
            // cbIslas
            // 
            this.cbIslas.AutoSize = true;
            this.cbIslas.Location = new System.Drawing.Point(133, 41);
            this.cbIslas.Name = "cbIslas";
            this.cbIslas.Size = new System.Drawing.Size(85, 17);
            this.cbIslas.TabIndex = 5;
            this.cbIslas.Text = "Mostrar Islas";
            this.cbIslas.UseVisualStyleBackColor = true;
            // 
            // cbIslotes
            // 
            this.cbIslotes.AutoSize = true;
            this.cbIslotes.Location = new System.Drawing.Point(7, 64);
            this.cbIslotes.Name = "cbIslotes";
            this.cbIslotes.Size = new System.Drawing.Size(94, 17);
            this.cbIslotes.TabIndex = 6;
            this.cbIslotes.Text = "Mostrar Islotes";
            this.cbIslotes.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 674);
            this.Controls.Add(this.gbVisu);
            this.Controls.Add(this.gbEtiquetado);
            this.Controls.Add(this.trbLong);
            this.Controls.Add(this.trbLat);
            this.Controls.Add(this.tvAccidentes);
            this.Controls.Add(this.cbProyecciones);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.msMenu);
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
            this.MainMenuStrip = this.msMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMapa)).EndInit();
            this.menuSalvar.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLong)).EndInit();
            this.gbEtiquetado.ResumeLayout(false);
            this.gbEtiquetado.PerformLayout();
            this.gbVisu.ResumeLayout(false);
            this.pMapa.ResumeLayout(false);
            this.pMapa.PerformLayout();
            this.pAccidentes.ResumeLayout(false);
            this.pAccidentes.PerformLayout();
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
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoMapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarMapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarMapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.TrackBar trbLat;
        private System.Windows.Forms.TrackBar trbLong;
        private System.Windows.Forms.GroupBox gbEtiquetado;
        private System.Windows.Forms.CheckBox cbForma;
        private System.Windows.Forms.CheckBox cbMasa;
        private System.Windows.Forms.GroupBox gbVisu;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Panel pAccidentes;
        private System.Windows.Forms.CheckBox cbShowNames;
        private System.Windows.Forms.RadioButton rbShowRect;
        private System.Windows.Forms.RadioButton rbShowShape;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pMapa;
        private System.Windows.Forms.RadioButton rbMapaColor;
        private System.Windows.Forms.RadioButton rbMapaBN;
        private System.Windows.Forms.CheckBox cbIslotes;
        private System.Windows.Forms.CheckBox cbIslas;
        private System.Windows.Forms.CheckBox cbContinentes;
    }
}

