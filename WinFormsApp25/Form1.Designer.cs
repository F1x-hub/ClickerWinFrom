namespace WinFormsApp25
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblCPS = new Label();
            txtSeconds = new TextBox();
            btnStart = new Button();
            lblStatus = new Label();
            btnStop = new Button();
            txtMilliseconds = new TextBox();
            lblMilliseconds = new Label();
            lblSeconds = new Label();
            chkTopMost = new CheckBox();
            btnChangeHotKey = new Button();
            SuspendLayout();
            // 
            // lblCPS
            // 
            lblCPS.AutoSize = true;
            lblCPS.Location = new Point(12, 37);
            lblCPS.Name = "lblCPS";
            lblCPS.Size = new Size(86, 20);
            lblCPS.TabIndex = 0;
            lblCPS.Text = "Set Interval:";
            lblCPS.Click += lblCPS_Click;
            // 
            // txtSeconds
            // 
            txtSeconds.Location = new Point(98, 34);
            txtSeconds.Name = "txtSeconds";
            txtSeconds.PlaceholderText = "Seconds";
            txtSeconds.Size = new Size(60, 27);
            txtSeconds.TabIndex = 1;
            txtSeconds.Text = "0";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 97);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start (F4)";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 74);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(113, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Status: Stopped";
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(186, 97);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop (F4)";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtMilliseconds
            // 
            txtMilliseconds.Location = new Point(186, 34);
            txtMilliseconds.Name = "txtMilliseconds";
            txtMilliseconds.PlaceholderText = "Milliseconds";
            txtMilliseconds.Size = new Size(60, 27);
            txtMilliseconds.TabIndex = 5;
            txtMilliseconds.Text = "100";
            // 
            // lblMilliseconds
            // 
            lblMilliseconds.AutoSize = true;
            lblMilliseconds.Location = new Point(186, 11);
            lblMilliseconds.Name = "lblMilliseconds";
            lblMilliseconds.Size = new Size(91, 20);
            lblMilliseconds.TabIndex = 6;
            lblMilliseconds.Text = "Milliseconds";
            // 
            // lblSeconds
            // 
            lblSeconds.AutoSize = true;
            lblSeconds.Location = new Point(98, 11);
            lblSeconds.Name = "lblSeconds";
            lblSeconds.Size = new Size(64, 20);
            lblSeconds.TabIndex = 7;
            lblSeconds.Text = "Seconds";
            // 
            // chkTopMost
            // 
            chkTopMost.AutoSize = true;
            chkTopMost.Checked = true;
            chkTopMost.CheckState = CheckState.Checked;
            chkTopMost.Location = new Point(12, 132);
            chkTopMost.Name = "chkTopMost";
            chkTopMost.Size = new Size(127, 24);
            chkTopMost.TabIndex = 8;
            chkTopMost.Text = "Always on Top";
            chkTopMost.UseVisualStyleBackColor = true;
            chkTopMost.CheckedChanged += chkTopMost_CheckedChanged;
            // 
            // btnChangeHotKey
            // 
            btnChangeHotKey.Location = new Point(145, 132);
            btnChangeHotKey.Name = "btnChangeHotKey";
            btnChangeHotKey.Size = new Size(135, 29);
            btnChangeHotKey.TabIndex = 9;
            btnChangeHotKey.Text = "Change Hotkey";
            btnChangeHotKey.UseVisualStyleBackColor = true;
            btnChangeHotKey.Click += btnChangeHotKey_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 164);
            Controls.Add(btnChangeHotKey);
            Controls.Add(chkTopMost);
            Controls.Add(lblSeconds);
            Controls.Add(lblMilliseconds);
            Controls.Add(txtMilliseconds);
            Controls.Add(btnStop);
            Controls.Add(lblStatus);
            Controls.Add(btnStart);
            Controls.Add(txtSeconds);
            Controls.Add(lblCPS);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clicker";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            KeyDown += Form1_KeyDownForHotKey;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCPS;
        private TextBox txtSeconds;
        private Button btnStart;
        private Label lblStatus;
        private Button btnStop;
        private TextBox txtMilliseconds;
        private Label lblMilliseconds;
        private Label lblSeconds;
        private CheckBox chkTopMost;
        private Button btnChangeHotKey;
    }
}
