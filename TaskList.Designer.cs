namespace DCRTasksTool
{
    partial class TaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskList));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ShowPending = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Event = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Included = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Enabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pending = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Executed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonExecute = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelLB = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ShowPending,
            this.Event,
            this.Included,
            this.Enabled,
            this.Pending,
            this.Executed});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 96);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(694, 255);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ShowPending
            // 
            this.ShowPending.Text = "";
            this.ShowPending.Width = 20;
            // 
            // Event
            // 
            this.Event.Text = "Events";
            this.Event.Width = 295;
            // 
            // Included
            // 
            this.Included.Text = "Included";
            this.Included.Width = 80;
            // 
            // Enabled
            // 
            this.Enabled.Text = "Enabled";
            this.Enabled.Width = 82;
            // 
            // Pending
            // 
            this.Pending.Text = "Pending";
            this.Pending.Width = 89;
            // 
            // Executed
            // 
            this.Executed.Text = "Executed";
            this.Executed.Width = 108;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(631, 384);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(75, 23);
            this.buttonExecute.TabIndex = 1;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(469, 384);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.labelLB);
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 87);
            this.panel2.TabIndex = 7;
            // 
            // labelLB
            // 
            this.labelLB.AutoSize = true;
            this.labelLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLB.Location = new System.Drawing.Point(32, 26);
            this.labelLB.Name = "labelLB";
            this.labelLB.Size = new System.Drawing.Size(298, 44);
            this.labelLB.TabIndex = 0;
            this.labelLB.Text = "DCR TASK LIST";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(550, 384);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 8;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 447);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaskList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskList";
            this.Shown += new System.EventHandler(this.TaskList_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.ColumnHeader Event;
        private System.Windows.Forms.ColumnHeader Included;
        private System.Windows.Forms.ColumnHeader Enabled;
        private System.Windows.Forms.ColumnHeader Pending;
        private System.Windows.Forms.ColumnHeader Executed;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelLB;
        private System.Windows.Forms.ColumnHeader ShowPending;
        private System.Windows.Forms.Button buttonRefresh;
    }
}