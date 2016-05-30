namespace server
{
    partial class FrmReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxReoprt = new System.Windows.Forms.ComboBox();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "报表筛选";
            // 
            // cbxReoprt
            // 
            this.cbxReoprt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReoprt.FormattingEnabled = true;
            this.cbxReoprt.Items.AddRange(new object[] {
            "正在使用适配器",
            "启用的适配器"});
            this.cbxReoprt.Location = new System.Drawing.Point(129, 23);
            this.cbxReoprt.Name = "cbxReoprt";
            this.cbxReoprt.Size = new System.Drawing.Size(230, 20);
            this.cbxReoprt.TabIndex = 4;
            this.cbxReoprt.SelectedIndexChanged += new System.EventHandler(this.cbxReoprt_SelectedIndexChanged);
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(28, 49);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReport.Size = new System.Drawing.Size(643, 420);
            this.txtReport.TabIndex = 3;
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxReoprt);
            this.Controls.Add(this.txtReport);
            this.Name = "FrmReport";
            this.Text = "FrmReport";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxReoprt;
        private System.Windows.Forms.TextBox txtReport;
    }
}