namespace DCRTasksTool
{
    partial class Choice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Choice));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonID = new System.Windows.Forms.Button();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelLB = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonID);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Location = new System.Drawing.Point(71, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 173);
            this.panel1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "ID";
            // 
            // buttonID
            // 
            this.buttonID.Location = new System.Drawing.Point(92, 79);
            this.buttonID.Name = "buttonID";
            this.buttonID.Size = new System.Drawing.Size(329, 34);
            this.buttonID.TabIndex = 0;
            this.buttonID.Text = "Get With ID";
            this.buttonID.UseVisualStyleBackColor = true;
            this.buttonID.Click += new System.EventHandler(this.buttonID_Click);
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(92, 37);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(329, 20);
            this.textBoxId.TabIndex = 0;
            this.textBoxId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxId_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.labelLB);
            this.panel2.Location = new System.Drawing.Point(1, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 87);
            this.panel2.TabIndex = 6;
            // 
            // labelLB
            // 
            this.labelLB.AutoSize = true;
            this.labelLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLB.Location = new System.Drawing.Point(60, 22);
            this.labelLB.Name = "labelLB";
            this.labelLB.Size = new System.Drawing.Size(395, 44);
            this.labelLB.TabIndex = 0;
            this.labelLB.Text = "DCR TOOL OPTIONS";
            // 
            // Choice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 328);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Choice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choice";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonID;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelLB;
    }
}