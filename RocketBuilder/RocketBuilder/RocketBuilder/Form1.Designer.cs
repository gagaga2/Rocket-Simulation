namespace RocketBuilder
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
            this.tbxPosition = new System.Windows.Forms.TextBox();
            this.tbxHeight = new System.Windows.Forms.TextBox();
            this.lblLaunchDegree = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trbPosition = new System.Windows.Forms.TrackBar();
            this.btn1 = new System.Windows.Forms.Button();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxPosition
            // 
            this.tbxPosition.Location = new System.Drawing.Point(475, 345);
            this.tbxPosition.Name = "tbxPosition";
            this.tbxPosition.Size = new System.Drawing.Size(100, 20);
            this.tbxPosition.TabIndex = 0;
            this.tbxPosition.TextChanged += new System.EventHandler(this.tbxPosition_TextChanged);
            // 
            // tbxHeight
            // 
            this.tbxHeight.Location = new System.Drawing.Point(475, 448);
            this.tbxHeight.Name = "tbxHeight";
            this.tbxHeight.Size = new System.Drawing.Size(100, 20);
            this.tbxHeight.TabIndex = 1;
            this.tbxHeight.TextChanged += new System.EventHandler(this.tbxHeight_TextChanged);
            // 
            // lblLaunchDegree
            // 
            this.lblLaunchDegree.AutoSize = true;
            this.lblLaunchDegree.Location = new System.Drawing.Point(386, 348);
            this.lblLaunchDegree.Name = "lblLaunchDegree";
            this.lblLaunchDegree.Size = new System.Drawing.Size(83, 13);
            this.lblLaunchDegree.TabIndex = 3;
            this.lblLaunchDegree.Text = "Launch Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Launch Height";
            // 
            // trbPosition
            // 
            this.trbPosition.Location = new System.Drawing.Point(475, 368);
            this.trbPosition.Maximum = 360;
            this.trbPosition.Name = "trbPosition";
            this.trbPosition.Size = new System.Drawing.Size(100, 45);
            this.trbPosition.TabIndex = 5;
            this.trbPosition.Scroll += new System.EventHandler(this.trbPosition_Scroll);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(113, 416);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(123, 83);
            this.btn1.TabIndex = 7;
            this.btn1.Text = "button1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // pbxPreview
            // 
            this.pbxPreview.BackColor = System.Drawing.Color.Gray;
            this.pbxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxPreview.Location = new System.Drawing.Point(376, 159);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(199, 180);
            this.pbxPreview.TabIndex = 8;
            this.pbxPreview.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 561);
            this.Controls.Add(this.pbxPreview);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.trbPosition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLaunchDegree);
            this.Controls.Add(this.tbxHeight);
            this.Controls.Add(this.tbxPosition);
            this.Name = "Form1";
            this.Text = "Rocket Builder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPosition;
        private System.Windows.Forms.TextBox tbxHeight;
        private System.Windows.Forms.Label lblLaunchDegree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trbPosition;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.PictureBox pbxPreview;
    }
}

