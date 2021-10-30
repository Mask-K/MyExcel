namespace Menu
{
    partial class Table
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Table));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonWho = new System.Windows.Forms.Button();
            this.buttonConditions = new System.Windows.Forms.Button();
            this.buttonWarn = new System.Windows.Forms.Button();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonAddCol = new System.Windows.Forms.Button();
            this.buttonDelCol = new System.Windows.Forms.Button();
            this.buttonDelRow = new System.Windows.Forms.Button();
            this.textBoxFunctions = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(0, 69);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 29;
            this.dgv.Size = new System.Drawing.Size(1470, 437);
            this.dgv.TabIndex = 0;
            this.dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_CellBeginEdit);
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1470, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShowShortcutKeys = false;
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsm";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XLSM Files (*.xlsm) |*.xlsm";
            // 
            // buttonWho
            // 
            this.buttonWho.Location = new System.Drawing.Point(1386, 24);
            this.buttonWho.Name = "buttonWho";
            this.buttonWho.Size = new System.Drawing.Size(84, 29);
            this.buttonWho.TabIndex = 2;
            this.buttonWho.Text = "Автор";
            this.buttonWho.UseVisualStyleBackColor = true;
            this.buttonWho.Click += new System.EventHandler(this.buttonWho_Click);
            // 
            // buttonConditions
            // 
            this.buttonConditions.Location = new System.Drawing.Point(1228, 24);
            this.buttonConditions.Name = "buttonConditions";
            this.buttonConditions.Size = new System.Drawing.Size(152, 29);
            this.buttonConditions.TabIndex = 3;
            this.buttonConditions.Text = "Умови варіанту";
            this.buttonConditions.UseVisualStyleBackColor = true;
            this.buttonConditions.Click += new System.EventHandler(this.buttonConditions_Click);
            // 
            // buttonWarn
            // 
            this.buttonWarn.Location = new System.Drawing.Point(1094, 24);
            this.buttonWarn.Name = "buttonWarn";
            this.buttonWarn.Size = new System.Drawing.Size(128, 29);
            this.buttonWarn.TabIndex = 13;
            this.buttonWarn.Text = "Застереження";
            this.buttonWarn.UseVisualStyleBackColor = true;
            this.buttonWarn.Click += new System.EventHandler(this.buttonWarn_Click);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(230, 24);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(118, 29);
            this.buttonAddRow.TabIndex = 14;
            this.buttonAddRow.Text = "Додати рядок";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonAddCol
            // 
            this.buttonAddCol.Location = new System.Drawing.Point(354, 24);
            this.buttonAddCol.Name = "buttonAddCol";
            this.buttonAddCol.Size = new System.Drawing.Size(138, 29);
            this.buttonAddCol.TabIndex = 15;
            this.buttonAddCol.Text = "Додати стовпчик";
            this.buttonAddCol.UseVisualStyleBackColor = true;
            this.buttonAddCol.Click += new System.EventHandler(this.buttonAddCol_Click);
            // 
            // buttonDelCol
            // 
            this.buttonDelCol.Location = new System.Drawing.Point(642, 24);
            this.buttonDelCol.Name = "buttonDelCol";
            this.buttonDelCol.Size = new System.Drawing.Size(153, 29);
            this.buttonDelCol.TabIndex = 17;
            this.buttonDelCol.Text = "Видалити стовпчик";
            this.buttonDelCol.UseVisualStyleBackColor = true;
            this.buttonDelCol.Click += new System.EventHandler(this.buttonDelCol_Click);
            // 
            // buttonDelRow
            // 
            this.buttonDelRow.Location = new System.Drawing.Point(498, 24);
            this.buttonDelRow.Name = "buttonDelRow";
            this.buttonDelRow.Size = new System.Drawing.Size(138, 29);
            this.buttonDelRow.TabIndex = 18;
            this.buttonDelRow.Text = "Видалити рядок";
            this.buttonDelRow.UseVisualStyleBackColor = true;
            this.buttonDelRow.Click += new System.EventHandler(this.buttonDelRow_Click);
            // 
            // textBoxFunctions
            // 
            this.textBoxFunctions.Location = new System.Drawing.Point(12, 26);
            this.textBoxFunctions.Name = "textBoxFunctions";
            this.textBoxFunctions.Size = new System.Drawing.Size(174, 27);
            this.textBoxFunctions.TabIndex = 21;
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 507);
            this.Controls.Add(this.textBoxFunctions);
            this.Controls.Add(this.buttonDelRow);
            this.Controls.Add(this.buttonDelCol);
            this.Controls.Add(this.buttonAddCol);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.buttonWarn);
            this.Controls.Add(this.buttonConditions);
            this.Controls.Add(this.buttonWho);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Table";
            this.Text = "Excel";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonWho;
        private System.Windows.Forms.Button buttonConditions;
        private System.Windows.Forms.Button buttonWarn;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonAddCol;
        private System.Windows.Forms.Button buttonDelCol;
        private System.Windows.Forms.Button buttonDelRow;
        private System.Windows.Forms.TextBox textBoxFunctions;
    }
}