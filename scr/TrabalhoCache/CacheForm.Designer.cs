namespace TrabalhoCache
{
    partial class CacheForm
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

         private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CacheForm));
            this.lblImputFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.bntShowFileDialog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTimeMP = new System.Windows.Forms.TextBox();
            this.txtTimeCache = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWrittenPolicy = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxWrittenPolicy = new System.Windows.Forms.ComboBox();
            this.txtLinhasConjunto = new System.Windows.Forms.TextBox();
            this.lblSizeLine = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLineSize = new System.Windows.Forms.TextBox();
            this.txtNumeroLinhas = new System.Windows.Forms.TextBox();
            this.lblLineNumbers = new System.Windows.Forms.Label();
            this.bntReport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblImputFile
            // 
            this.lblImputFile.AutoSize = true;
            this.lblImputFile.Location = new System.Drawing.Point(12, 24);
            this.lblImputFile.Name = "lblImputFile";
            this.lblImputFile.Size = new System.Drawing.Size(100, 13);
            this.lblImputFile.TabIndex = 0;
            this.lblImputFile.Text = "Arquivo de entrada:";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(118, 21);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(243, 20);
            this.txtFilePath.TabIndex = 1;
            this.txtFilePath.Text = " ";
            // 
            // bntShowFileDialog
            // 
            this.bntShowFileDialog.Location = new System.Drawing.Point(369, 20);
            this.bntShowFileDialog.Name = "bntShowFileDialog";
            this.bntShowFileDialog.Size = new System.Drawing.Size(38, 20);
            this.bntShowFileDialog.TabIndex = 2;
            this.bntShowFileDialog.Text = "...";
            this.bntShowFileDialog.UseVisualStyleBackColor = true;
            this.bntShowFileDialog.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(15, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramêtros de entrada";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtTimeMP, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtTimeCache, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblWrittenPolicy, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxWrittenPolicy, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLinhasConjunto, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSizeLine, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtLineSize, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNumeroLinhas, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLineNumbers, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 159);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txtTimeMP
            // 
            this.txtTimeMP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeMP.Location = new System.Drawing.Point(163, 134);
            this.txtTimeMP.Name = "txtTimeMP";
            this.txtTimeMP.Size = new System.Drawing.Size(201, 20);
            this.txtTimeMP.TabIndex = 11;
            // 
            // txtTimeCache
            // 
            this.txtTimeCache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeCache.Location = new System.Drawing.Point(163, 108);
            this.txtTimeCache.Name = "txtTimeCache";
            this.txtTimeCache.Size = new System.Drawing.Size(201, 20);
            this.txtTimeCache.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tempo de acesso MP:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWrittenPolicy
            // 
            this.lblWrittenPolicy.AutoSize = true;
            this.lblWrittenPolicy.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWrittenPolicy.Location = new System.Drawing.Point(3, 0);
            this.lblWrittenPolicy.Name = "lblWrittenPolicy";
            this.lblWrittenPolicy.Size = new System.Drawing.Size(93, 27);
            this.lblWrittenPolicy.TabIndex = 0;
            this.lblWrittenPolicy.Text = "Politica de escrita:";
            this.lblWrittenPolicy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tempo de acesso cache:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxWrittenPolicy
            // 
            this.cbxWrittenPolicy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxWrittenPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWrittenPolicy.FormattingEnabled = true;
            this.cbxWrittenPolicy.Location = new System.Drawing.Point(163, 3);
            this.cbxWrittenPolicy.Name = "cbxWrittenPolicy";
            this.cbxWrittenPolicy.Size = new System.Drawing.Size(201, 21);
            this.cbxWrittenPolicy.TabIndex = 1;
            // 
            // txtLinhasConjunto
            // 
            this.txtLinhasConjunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLinhasConjunto.Location = new System.Drawing.Point(163, 82);
            this.txtLinhasConjunto.Name = "txtLinhasConjunto";
            this.txtLinhasConjunto.Size = new System.Drawing.Size(201, 20);
            this.txtLinhasConjunto.TabIndex = 7;
            this.txtLinhasConjunto.Tag = "NeedBePower2";
            // 
            // lblSizeLine
            // 
            this.lblSizeLine.AutoSize = true;
            this.lblSizeLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSizeLine.Location = new System.Drawing.Point(3, 27);
            this.lblSizeLine.Name = "lblSizeLine";
            this.lblSizeLine.Size = new System.Drawing.Size(95, 26);
            this.lblSizeLine.TabIndex = 2;
            this.lblSizeLine.Text = "Tamanho da linha:";
            this.lblSizeLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Numero de linhas por conjunto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLineSize
            // 
            this.txtLineSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLineSize.Location = new System.Drawing.Point(163, 30);
            this.txtLineSize.Name = "txtLineSize";
            this.txtLineSize.Size = new System.Drawing.Size(201, 20);
            this.txtLineSize.TabIndex = 3;
            this.txtLineSize.Tag = "NeedBePower2";
            // 
            // txtNumeroLinhas
            // 
            this.txtNumeroLinhas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroLinhas.Location = new System.Drawing.Point(163, 56);
            this.txtNumeroLinhas.Name = "txtNumeroLinhas";
            this.txtNumeroLinhas.Size = new System.Drawing.Size(201, 20);
            this.txtNumeroLinhas.TabIndex = 5;
            this.txtNumeroLinhas.Tag = "NeedBePower2";
            // 
            // lblLineNumbers
            // 
            this.lblLineNumbers.AutoSize = true;
            this.lblLineNumbers.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLineNumbers.Location = new System.Drawing.Point(3, 53);
            this.lblLineNumbers.Name = "lblLineNumbers";
            this.lblLineNumbers.Size = new System.Drawing.Size(92, 26);
            this.lblLineNumbers.TabIndex = 4;
            this.lblLineNumbers.Text = "Numero de linhas:";
            this.lblLineNumbers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bntReport
            // 
            this.bntReport.Location = new System.Drawing.Point(317, 255);
            this.bntReport.Name = "bntReport";
            this.bntReport.Size = new System.Drawing.Size(91, 31);
            this.bntReport.TabIndex = 4;
            this.bntReport.Text = "Gerar relatório";
            this.bntReport.UseVisualStyleBackColor = true;
            this.bntReport.Click += new System.EventHandler(this.bntReport_Click);
            // 
            // CacheForm
            // 
            this.AcceptButton = this.bntReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 298);
            this.Controls.Add(this.bntReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bntShowFileDialog);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblImputFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CacheForm";
            this.Text = "Simulador de memória cache";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblImputFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button bntShowFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblWrittenPolicy;
        private System.Windows.Forms.Label lblSizeLine;
        private System.Windows.Forms.ComboBox cbxWrittenPolicy;
        private System.Windows.Forms.TextBox txtLineSize;
        private System.Windows.Forms.TextBox txtLinhasConjunto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumeroLinhas;
        private System.Windows.Forms.Label lblLineNumbers;
        private System.Windows.Forms.Button bntReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtTimeMP;
        private System.Windows.Forms.TextBox txtTimeCache;
    }
}