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
            this.lblLaunchDegree = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trbPosition = new System.Windows.Forms.TrackBar();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.lblMass = new System.Windows.Forms.Label();
            this.lblFuel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalMass = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxPosition = new System.Windows.Forms.NumericUpDown();
            this.tbxAltitude = new System.Windows.Forms.NumericUpDown();
            this.tbxFuel = new System.Windows.Forms.NumericUpDown();
            this.tbxHeight = new System.Windows.Forms.NumericUpDown();
            this.tbxWidth = new System.Windows.Forms.NumericUpDown();
            this.tbxEfficiency = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEfficiency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLaunchDegree
            // 
            this.lblLaunchDegree.AutoSize = true;
            this.lblLaunchDegree.Location = new System.Drawing.Point(9, 206);
            this.lblLaunchDegree.Name = "lblLaunchDegree";
            this.lblLaunchDegree.Size = new System.Drawing.Size(83, 13);
            this.lblLaunchDegree.TabIndex = 3;
            this.lblLaunchDegree.Text = "Launch Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Launch Altitude";
            // 
            // trbPosition
            // 
            this.trbPosition.Location = new System.Drawing.Point(111, 226);
            this.trbPosition.Maximum = 360;
            this.trbPosition.Name = "trbPosition";
            this.trbPosition.Size = new System.Drawing.Size(100, 45);
            this.trbPosition.TabIndex = 5;
            this.trbPosition.Scroll += new System.EventHandler(this.trbPosition_Scroll);
            // 
            // pbxPreview
            // 
            this.pbxPreview.BackColor = System.Drawing.Color.DimGray;
            this.pbxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxPreview.Location = new System.Drawing.Point(12, 12);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(270, 180);
            this.pbxPreview.TabIndex = 8;
            this.pbxPreview.TabStop = false;
            // 
            // lblMass
            // 
            this.lblMass.AutoSize = true;
            this.lblMass.Location = new System.Drawing.Point(9, 343);
            this.lblMass.Name = "lblMass";
            this.lblMass.Size = new System.Drawing.Size(59, 13);
            this.lblMass.TabIndex = 13;
            this.lblMass.Text = "Total Mass";
            // 
            // lblFuel
            // 
            this.lblFuel.AutoSize = true;
            this.lblFuel.Location = new System.Drawing.Point(9, 319);
            this.lblFuel.Name = "lblFuel";
            this.lblFuel.Size = new System.Drawing.Size(71, 13);
            this.lblFuel.TabIndex = 15;
            this.lblFuel.Text = "Fuel Capacity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Engine Efficiency";
            // 
            // lblTotalMass
            // 
            this.lblTotalMass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalMass.Location = new System.Drawing.Point(111, 342);
            this.lblTotalMass.Name = "lblTotalMass";
            this.lblTotalMass.Size = new System.Drawing.Size(100, 23);
            this.lblTotalMass.TabIndex = 18;
            this.lblTotalMass.Text = "Fuel + 15%";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(9, 400);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(100, 13);
            this.lblWidth.TabIndex = 19;
            this.lblWidth.Text = "Rocket Base Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(9, 374);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(76, 13);
            this.lblHeight.TabIndex = 20;
            this.lblHeight.Text = "Rocket Height";
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(83, 492);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(128, 68);
            this.btnLaunch.TabIndex = 23;
            this.btnLaunch.Text = "Launch!";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Meters A.S.L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Liter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Kg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Meters";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Meters";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Kn/liter";
            // 
            // tbxPosition
            // 
            this.tbxPosition.Location = new System.Drawing.Point(111, 204);
            this.tbxPosition.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.tbxPosition.Name = "tbxPosition";
            this.tbxPosition.Size = new System.Drawing.Size(100, 20);
            this.tbxPosition.TabIndex = 30;
            this.tbxPosition.ValueChanged += new System.EventHandler(this.tbxPosition_ValueChanged);
            // 
            // tbxAltitude
            // 
            this.tbxAltitude.Location = new System.Drawing.Point(111, 274);
            this.tbxAltitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbxAltitude.Name = "tbxAltitude";
            this.tbxAltitude.Size = new System.Drawing.Size(100, 20);
            this.tbxAltitude.TabIndex = 32;
            this.tbxAltitude.ValueChanged += new System.EventHandler(this.tbxAltitude_ValueChanged);
            // 
            // tbxFuel
            // 
            this.tbxFuel.Location = new System.Drawing.Point(111, 312);
            this.tbxFuel.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.tbxFuel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbxFuel.Name = "tbxFuel";
            this.tbxFuel.Size = new System.Drawing.Size(100, 20);
            this.tbxFuel.TabIndex = 33;
            this.tbxFuel.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tbxFuel.ValueChanged += new System.EventHandler(this.tbxFuel_ValueChanged);
            // 
            // tbxHeight
            // 
            this.tbxHeight.Location = new System.Drawing.Point(111, 374);
            this.tbxHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tbxHeight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.tbxHeight.Name = "tbxHeight";
            this.tbxHeight.Size = new System.Drawing.Size(100, 20);
            this.tbxHeight.TabIndex = 34;
            this.tbxHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.tbxHeight.ValueChanged += new System.EventHandler(this.tbxHeight_ValueChanged);
            // 
            // tbxWidth
            // 
            this.tbxWidth.Location = new System.Drawing.Point(111, 400);
            this.tbxWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tbxWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbxWidth.Name = "tbxWidth";
            this.tbxWidth.Size = new System.Drawing.Size(100, 20);
            this.tbxWidth.TabIndex = 35;
            this.tbxWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbxWidth.ValueChanged += new System.EventHandler(this.tbxWidth_ValueChanged);
            // 
            // tbxEfficiency
            // 
            this.tbxEfficiency.Location = new System.Drawing.Point(111, 425);
            this.tbxEfficiency.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tbxEfficiency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbxEfficiency.Name = "tbxEfficiency";
            this.tbxEfficiency.Size = new System.Drawing.Size(100, 20);
            this.tbxEfficiency.TabIndex = 36;
            this.tbxEfficiency.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tbxEfficiency.ValueChanged += new System.EventHandler(this.tbxEfficiency_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(111, 451);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 37;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 453);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Engine Max Power";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(217, 453);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Kn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 599);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.tbxEfficiency);
            this.Controls.Add(this.tbxWidth);
            this.Controls.Add(this.tbxHeight);
            this.Controls.Add(this.tbxFuel);
            this.Controls.Add(this.tbxAltitude);
            this.Controls.Add(this.tbxPosition);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.lblTotalMass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFuel);
            this.Controls.Add(this.lblMass);
            this.Controls.Add(this.pbxPreview);
            this.Controls.Add(this.trbPosition);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLaunchDegree);
            this.Name = "Form1";
            this.Text = "Rocket Builder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbxEfficiency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblLaunchDegree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trbPosition;
        private System.Windows.Forms.PictureBox pbxPreview;
        private System.Windows.Forms.Label lblMass;
        private System.Windows.Forms.Label lblFuel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalMass;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown tbxPosition;
        private System.Windows.Forms.NumericUpDown tbxAltitude;
        private System.Windows.Forms.NumericUpDown tbxFuel;
        private System.Windows.Forms.NumericUpDown tbxHeight;
        private System.Windows.Forms.NumericUpDown tbxWidth;
        private System.Windows.Forms.NumericUpDown tbxEfficiency;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

