namespace btnObj
{
    partial class PebbleTap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PebbleTap));
            this.label1 = new System.Windows.Forms.Label();
            this.menStr = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.midToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mp3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thmW = new System.Windows.Forms.ToolStripMenuItem();
            this.thmD = new System.Windows.Forms.ToolStripMenuItem();
            this.tblL = new System.Windows.Forms.TableLayoutPanel();
            this.btnplaystop = new System.Windows.Forms.Button();
            this.lab = new System.Windows.Forms.Label();
            this.btnstrt = new System.Windows.Forms.Button();
            this.tealb = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblt = new System.Windows.Forms.Label();
            this.btnfin = new System.Windows.Forms.Button();
            this.btnimprt = new System.Windows.Forms.Button();
            this.StepTimer = new System.Windows.Forms.Timer(this.components);
            this.ato = new System.Windows.Forms.Button();
            this.lblfilnm = new System.Windows.Forms.Label();
            this.btndgv = new System.Windows.Forms.Button();
            this.menStr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 533);
            this.label1.TabIndex = 1;
            this.label1.Text = "A1\r\nA#1\r\nB1\r\nC1\r\nC#1\r\nC2\r\nD1\r\nD♭\r\nE1\r\nF1\r\nF#1\r\nG1\r\nG#1";
            // 
            // menStr
            // 
            this.menStr.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menStr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.themeToolStripMenuItem});
            this.menStr.Location = new System.Drawing.Point(0, 0);
            this.menStr.Name = "menStr";
            this.menStr.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menStr.Size = new System.Drawing.Size(1115, 26);
            this.menStr.TabIndex = 15;
            this.menStr.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.midToolStripMenuItem,
            this.wavToolStripMenuItem,
            this.mp3ToolStripMenuItem});
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // midToolStripMenuItem
            // 
            this.midToolStripMenuItem.Name = "midToolStripMenuItem";
            this.midToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.midToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.midToolStripMenuItem.Text = "mid";
            this.midToolStripMenuItem.Click += new System.EventHandler(this.midToolStripMenuItem_Click);
            // 
            // wavToolStripMenuItem
            // 
            this.wavToolStripMenuItem.Name = "wavToolStripMenuItem";
            this.wavToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.wavToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.wavToolStripMenuItem.Text = "wav";
            this.wavToolStripMenuItem.Click += new System.EventHandler(this.wavToolStripMenuItem_Click);
            // 
            // mp3ToolStripMenuItem
            // 
            this.mp3ToolStripMenuItem.Name = "mp3ToolStripMenuItem";
            this.mp3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.mp3ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.mp3ToolStripMenuItem.Text = "mp3";
            this.mp3ToolStripMenuItem.Click += new System.EventHandler(this.mp3ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thmW,
            this.thmD});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // thmW
            // 
            this.thmW.Name = "thmW";
            this.thmW.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.thmW.Size = new System.Drawing.Size(169, 22);
            this.thmW.Text = "Light";
            this.thmW.Click += new System.EventHandler(this.thmW_Click);
            // 
            // thmD
            // 
            this.thmD.Name = "thmD";
            this.thmD.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.thmD.Size = new System.Drawing.Size(169, 22);
            this.thmD.Text = "Dark";
            this.thmD.Click += new System.EventHandler(this.thmD_Click);
            // 
            // tblL
            // 
            this.tblL.AllowDrop = true;
            this.tblL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblL.AutoScroll = true;
            this.tblL.ColumnCount = 2;
            this.tblL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblL.Location = new System.Drawing.Point(85, 97);
            this.tblL.Name = "tblL";
            this.tblL.RowCount = 2;
            this.tblL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblL.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblL.Size = new System.Drawing.Size(1030, 550);
            this.tblL.TabIndex = 5;
            // 
            // btnplaystop
            // 
            this.btnplaystop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnplaystop.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnplaystop.Location = new System.Drawing.Point(85, 659);
            this.btnplaystop.Name = "btnplaystop";
            this.btnplaystop.Size = new System.Drawing.Size(100, 40);
            this.btnplaystop.TabIndex = 9;
            this.btnplaystop.Text = "Play";
            this.btnplaystop.UseVisualStyleBackColor = true;
            this.btnplaystop.Click += new System.EventHandler(this.btnplaystop_Click);
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lab.Location = new System.Drawing.Point(614, 39);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(101, 18);
            this.lab.TabIndex = 16;
            this.lab.Text = "Album Name :";
            // 
            // btnstrt
            // 
            this.btnstrt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnstrt.Font = new System.Drawing.Font("Bookman Old Style", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstrt.Location = new System.Drawing.Point(874, 34);
            this.btnstrt.Margin = new System.Windows.Forms.Padding(2);
            this.btnstrt.Name = "btnstrt";
            this.btnstrt.Size = new System.Drawing.Size(53, 30);
            this.btnstrt.TabIndex = 2;
            this.btnstrt.Text = "Start";
            this.btnstrt.UseVisualStyleBackColor = true;
            this.btnstrt.Click += new System.EventHandler(this.btnstrt_Click);
            // 
            // tealb
            // 
            this.tealb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tealb.Location = new System.Drawing.Point(719, 37);
            this.tealb.Name = "tealb";
            this.tealb.Size = new System.Drawing.Size(144, 24);
            this.tealb.TabIndex = 17;
            // 
            // dgv
            // 
            this.dgv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgv.Location = new System.Drawing.Point(105, 73);
            this.dgv.Margin = new System.Windows.Forms.Padding(2);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(786, 557);
            this.dgv.TabIndex = 18;
            this.dgv.Visible = false;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(614, 662);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Minimum = 40;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(194, 45);
            this.trackBar1.TabIndex = 19;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 120;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblt
            // 
            this.lblt.AutoSize = true;
            this.lblt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblt.Location = new System.Drawing.Point(820, 666);
            this.lblt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblt.Name = "lblt";
            this.lblt.Size = new System.Drawing.Size(92, 24);
            this.lblt.TabIndex = 20;
            this.lblt.Text = "120 BPM";
            // 
            // btnfin
            // 
            this.btnfin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfin.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfin.Location = new System.Drawing.Point(190, 659);
            this.btnfin.Name = "btnfin";
            this.btnfin.Size = new System.Drawing.Size(100, 40);
            this.btnfin.TabIndex = 21;
            this.btnfin.Text = "Finish";
            this.btnfin.UseVisualStyleBackColor = true;
            this.btnfin.Click += new System.EventHandler(this.btnfin_Click);
            // 
            // btnimprt
            // 
            this.btnimprt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnimprt.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimprt.Location = new System.Drawing.Point(296, 659);
            this.btnimprt.Name = "btnimprt";
            this.btnimprt.Size = new System.Drawing.Size(100, 40);
            this.btnimprt.TabIndex = 24;
            this.btnimprt.Text = "Import";
            this.btnimprt.UseVisualStyleBackColor = true;
            this.btnimprt.Click += new System.EventHandler(this.btnimprt_Click);
            // 
            // StepTimer
            // 
            this.StepTimer.Interval = 120;
            this.StepTimer.Tick += new System.EventHandler(this.StepTimer_Tick);
            // 
            // ato
            // 
            this.ato.Location = new System.Drawing.Point(0, 0);
            this.ato.Name = "ato";
            this.ato.Size = new System.Drawing.Size(75, 23);
            this.ato.TabIndex = 0;
            // 
            // lblfilnm
            // 
            this.lblfilnm.AutoSize = true;
            this.lblfilnm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfilnm.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblfilnm.Location = new System.Drawing.Point(32, 41);
            this.lblfilnm.Name = "lblfilnm";
            this.lblfilnm.Size = new System.Drawing.Size(0, 25);
            this.lblfilnm.TabIndex = 26;
            // 
            // btndgv
            // 
            this.btndgv.Location = new System.Drawing.Point(0, 0);
            this.btndgv.Name = "btndgv";
            this.btndgv.Size = new System.Drawing.Size(75, 23);
            this.btndgv.TabIndex = 0;
            // 
            // PebbleTap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1132, 597);
            this.Controls.Add(this.lblfilnm);
            this.Controls.Add(this.btnimprt);
            this.Controls.Add(this.btnfin);
            this.Controls.Add(this.lblt);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.btnstrt);
            this.Controls.Add(this.btnplaystop);
            this.Controls.Add(this.tblL);
            this.Controls.Add(this.tealb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menStr);
            this.Controls.Add(this.dgv);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menStr;
            this.Name = "PebbleTap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PebbleTap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menStr.ResumeLayout(false);
            this.menStr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menStr;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem midToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wavToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mp3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thmW;
        private System.Windows.Forms.ToolStripMenuItem thmD;
        private System.Windows.Forms.TableLayoutPanel tblL;
        private System.Windows.Forms.Button btnplaystop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Button btnstrt;
        private System.Windows.Forms.TextBox tealb;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblt;
        private System.Windows.Forms.Button btnfin;
        private System.Windows.Forms.Button btnimprt;
        private System.Windows.Forms.Timer StepTimer;
        private System.Windows.Forms.Button ato;
        private System.Windows.Forms.Label lblfilnm;
        private System.Windows.Forms.Button btndgv;
       // private System.Windows.Forms.Timer stepTimer;
    }
}

