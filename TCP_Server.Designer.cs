namespace WindowsFormsApp1
{
    partial class TCP_Server
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
            this.TrashBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TrashBox
            // 
            this.TrashBox.Location = new System.Drawing.Point(15, 18);
            this.TrashBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TrashBox.Multiline = true;
            this.TrashBox.Name = "TrashBox";
            this.TrashBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TrashBox.Size = new System.Drawing.Size(346, 387);
            this.TrashBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 417);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(345, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Перезапуск сервера";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TCP_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TrashBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TCP_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP_Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TCP_Server_FormClosing);
            this.Shown += new System.EventHandler(this.TCP_Server_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TrashBox;
        private System.Windows.Forms.Button button1;
    }
}