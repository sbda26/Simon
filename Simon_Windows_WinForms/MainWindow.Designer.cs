namespace Simon_Windows_WinForms
{
    partial class frmMain
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
            this.btnTop = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBottom = new System.Windows.Forms.Button();
            this.lblProgram = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTop
            // 
            this.btnTop.Location = new System.Drawing.Point(267, 52);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(75, 23);
            this.btnTop.TabIndex = 0;
            this.btnTop.Tag = "X";
            this.btnTop.UseVisualStyleBackColor = true;
            this.btnTop.Click += new System.EventHandler(this.ButtonClickedByUser);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(198, 81);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Tag = "X";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.ButtonClickedByUser);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(341, 81);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 2;
            this.btnRight.Tag = "X";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.ButtonClickedByUser);
            // 
            // btnBottom
            // 
            this.btnBottom.Location = new System.Drawing.Point(267, 110);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(75, 23);
            this.btnBottom.TabIndex = 3;
            this.btnBottom.Tag = "X";
            this.btnBottom.UseVisualStyleBackColor = true;
            this.btnBottom.Click += new System.EventHandler(this.ButtonClickedByUser);
            // 
            // lblProgram
            // 
            this.lblProgram.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgram.ForeColor = System.Drawing.Color.White;
            this.lblProgram.Location = new System.Drawing.Point(365, 162);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Size = new System.Drawing.Size(166, 28);
            this.lblProgram.TabIndex = 6;
            this.lblProgram.Text = "Dave\'s Simon";
            this.lblProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(456, 70);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(27, 34);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 51);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Click Here To Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(583, 213);
            this.ControlBox = false;
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblProgram);
            this.Controls.Add(this.btnBottom);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStart;
    }
}

