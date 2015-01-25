namespace WebDL
{
    partial class Form1
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.btnGraph = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.Ticker = new System.Windows.Forms.Label();
            this.lstDataType = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(11, 5);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(130, 28);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Location = new System.Drawing.Point(12, 98);
            this.dgData.Name = "dgData";
            this.dgData.Size = new System.Drawing.Size(761, 218);
            this.dgData.TabIndex = 1;
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(635, 12);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(137, 23);
            this.btnGraph.TabIndex = 3;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(181, 65);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(132, 20);
            this.dtpStart.TabIndex = 4;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(333, 65);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(132, 20);
            this.dtpEnd.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(162, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 23);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "End Date:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 65);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(141, 20);
            this.tbName.TabIndex = 8;
            // 
            // Ticker
            // 
            this.Ticker.AutoSize = true;
            this.Ticker.Location = new System.Drawing.Point(15, 45);
            this.Ticker.Name = "Ticker";
            this.Ticker.Size = new System.Drawing.Size(40, 13);
            this.Ticker.TabIndex = 9;
            this.Ticker.Text = "Ticker:";
            // 
            // lstDataType
            // 
            this.lstDataType.FormattingEnabled = true;
            this.lstDataType.Location = new System.Drawing.Point(582, 42);
            this.lstDataType.Name = "lstDataType";
            this.lstDataType.Size = new System.Drawing.Size(121, 43);
            this.lstDataType.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(484, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Time Series Type:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 332);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDataType);
            this.Controls.Add(this.Ticker);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.dgData);
            this.Controls.Add(this.btnDownload);
            this.MaximumSize = new System.Drawing.Size(800, 900);
            this.MinimumSize = new System.Drawing.Size(800, 371);
            this.Name = "Form1";
            this.Text = "Equity Data";
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridView dgData;
   
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label Ticker;
        private System.Windows.Forms.ListBox lstDataType;
        private System.Windows.Forms.Label label1;

    }
}

