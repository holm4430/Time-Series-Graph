namespace WebDL
{
    partial class Form2
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
            this.cb20daySMA = new System.Windows.Forms.CheckBox();
            this.cb50daySMA = new System.Windows.Forms.CheckBox();
            this.cb200daySMA = new System.Windows.Forms.CheckBox();
            this.cbBoll = new System.Windows.Forms.CheckBox();
            this.cb50dayEMA = new System.Windows.Forms.CheckBox();
            this.cbMACD = new System.Windows.Forms.CheckBox();
            this.labelpercent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb20daySMA
            // 
            this.cb20daySMA.AutoSize = true;
            this.cb20daySMA.Location = new System.Drawing.Point(73, 6);
            this.cb20daySMA.Name = "cb20daySMA";
            this.cb20daySMA.Size = new System.Drawing.Size(86, 17);
            this.cb20daySMA.TabIndex = 0;
            this.cb20daySMA.Text = "20 Day SMA";
            this.cb20daySMA.UseVisualStyleBackColor = true;
            this.cb20daySMA.CheckedChanged += new System.EventHandler(this.cb20daySMA_CheckedChanged);
            // 
            // cb50daySMA
            // 
            this.cb50daySMA.AutoSize = true;
            this.cb50daySMA.Location = new System.Drawing.Point(165, 6);
            this.cb50daySMA.Name = "cb50daySMA";
            this.cb50daySMA.Size = new System.Drawing.Size(86, 17);
            this.cb50daySMA.TabIndex = 1;
            this.cb50daySMA.Text = "50 Day SMA";
            this.cb50daySMA.UseVisualStyleBackColor = true;
            this.cb50daySMA.CheckedChanged += new System.EventHandler(this.cb50daySMA_CheckedChanged);
            // 
            // cb200daySMA
            // 
            this.cb200daySMA.AutoSize = true;
            this.cb200daySMA.Location = new System.Drawing.Point(257, 6);
            this.cb200daySMA.Name = "cb200daySMA";
            this.cb200daySMA.Size = new System.Drawing.Size(92, 17);
            this.cb200daySMA.TabIndex = 2;
            this.cb200daySMA.Text = "200 Day SMA";
            this.cb200daySMA.UseVisualStyleBackColor = true;
            this.cb200daySMA.CheckedChanged += new System.EventHandler(this.cb200daySMA_CheckedChanged);
            // 
            // cbBoll
            // 
            this.cbBoll.AutoSize = true;
            this.cbBoll.Location = new System.Drawing.Point(544, 6);
            this.cbBoll.Name = "cbBoll";
            this.cbBoll.Size = new System.Drawing.Size(99, 17);
            this.cbBoll.TabIndex = 3;
            this.cbBoll.Text = "Bollinger Bands";
            this.cbBoll.UseVisualStyleBackColor = true;
            this.cbBoll.CheckedChanged += new System.EventHandler(this.cbBoll_CheckedChanged);
            // 
            // cb50dayEMA
            // 
            this.cb50dayEMA.AutoSize = true;
            this.cb50dayEMA.Location = new System.Drawing.Point(355, 6);
            this.cb50dayEMA.Name = "cb50dayEMA";
            this.cb50dayEMA.Size = new System.Drawing.Size(86, 17);
            this.cb50dayEMA.TabIndex = 4;
            this.cb50dayEMA.Text = "50 Day EMA";
            this.cb50dayEMA.UseVisualStyleBackColor = true;
            this.cb50dayEMA.CheckedChanged += new System.EventHandler(this.cb50dayEMA_CheckedChanged);
            // 
            // cbMACD
            // 
            this.cbMACD.AutoSize = true;
            this.cbMACD.Location = new System.Drawing.Point(447, 6);
            this.cbMACD.Name = "cbMACD";
            this.cbMACD.Size = new System.Drawing.Size(57, 17);
            this.cbMACD.TabIndex = 5;
            this.cbMACD.Text = "MACD";
            this.cbMACD.UseVisualStyleBackColor = true;
            this.cbMACD.CheckedChanged += new System.EventHandler(this.cbMACD_CheckedChanged);
            // 
            // labelpercent
            // 
            this.labelpercent.AutoSize = true;
            this.labelpercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelpercent.Location = new System.Drawing.Point(650, 10);
            this.labelpercent.Name = "labelpercent";
            this.labelpercent.Size = new System.Drawing.Size(0, 13);
            this.labelpercent.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(644, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(678, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelpercent);
            this.Controls.Add(this.cbMACD);
            this.Controls.Add(this.cb50dayEMA);
            this.Controls.Add(this.cbBoll);
            this.Controls.Add(this.cb200daySMA);
            this.Controls.Add(this.cb50daySMA);
            this.Controls.Add(this.cb20daySMA);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb20daySMA;
        private System.Windows.Forms.CheckBox cb50daySMA;
        private System.Windows.Forms.CheckBox cb200daySMA;
        private System.Windows.Forms.CheckBox cbBoll;
        private System.Windows.Forms.CheckBox cb50dayEMA;
        private System.Windows.Forms.CheckBox cbMACD;
        private System.Windows.Forms.Label labelpercent;
        private System.Windows.Forms.Label label1;
        

        
    }
}