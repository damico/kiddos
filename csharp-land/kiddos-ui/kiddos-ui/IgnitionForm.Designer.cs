/*

Copyleft 2015 - Jose Ricardo de Oliveira Damico <jd.comment@gmail.com>

This file is part of Kiddos.

Kiddos is free software: you can redistribute it and/or modify it under the terms 
of the GNU General Public License as published by the Free Software Foundation, 
either version 3 of the License, or any later version.

Kiddos is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; 
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with Kiddos. 
If not, see http://www.gnu.org/licenses/.

*/

namespace kiddos_ui
{

    partial class IgnitionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IgnitionForm));
            this.timesTextBox = new System.Windows.Forms.TextBox();
            this.plantBt = new System.Windows.Forms.Button();
            this.nThreadsTextBox = new System.Windows.Forms.TextBox();
            this.urlsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.udL = new System.Windows.Forms.Label();
            this.rdL = new System.Windows.Forms.Label();
            this.euLL = new System.Windows.Forms.Label();
            this.rdLL = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.clockLabel = new System.Windows.Forms.Label();
            this.urLabel = new System.Windows.Forms.Label();
            this.srLabel = new System.Windows.Forms.Label();
            this.activeThreadsLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.interfacesComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ipSpoofCheckBox = new System.Windows.Forms.CheckBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timesTextBox
            // 
            this.timesTextBox.Location = new System.Drawing.Point(120, 164);
            this.timesTextBox.Name = "timesTextBox";
            this.timesTextBox.Size = new System.Drawing.Size(32, 20);
            this.timesTextBox.TabIndex = 4;
            this.timesTextBox.Text = "100";
            // 
            // plantBt
            // 
            this.plantBt.Location = new System.Drawing.Point(158, 139);
            this.plantBt.Name = "plantBt";
            this.plantBt.Size = new System.Drawing.Size(383, 45);
            this.plantBt.TabIndex = 5;
            this.plantBt.Text = "Plant the Kiddie";
            this.plantBt.UseVisualStyleBackColor = true;
            this.plantBt.Click += new System.EventHandler(this.button1_Click);
            // 
            // nThreadsTextBox
            // 
            this.nThreadsTextBox.Location = new System.Drawing.Point(120, 139);
            this.nThreadsTextBox.Name = "nThreadsTextBox";
            this.nThreadsTextBox.Size = new System.Drawing.Size(32, 20);
            this.nThreadsTextBox.TabIndex = 3;
            this.nThreadsTextBox.Text = "8";
            // 
            // urlsTextBox
            // 
            this.urlsTextBox.Location = new System.Drawing.Point(97, 6);
            this.urlsTextBox.Name = "urlsTextBox";
            this.urlsTextBox.Size = new System.Drawing.Size(444, 20);
            this.urlsTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of Threads:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Times per Thread:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kiddostroller Url:";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(16, 207);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(525, 60);
            this.logTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Log:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.udL);
            this.groupBox1.Controls.Add(this.rdL);
            this.groupBox1.Controls.Add(this.euLL);
            this.groupBox1.Controls.Add(this.rdLL);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.clockLabel);
            this.groupBox1.Controls.Add(this.urLabel);
            this.groupBox1.Controls.Add(this.srLabel);
            this.groupBox1.Controls.Add(this.activeThreadsLabel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(14, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 74);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiddie Status ";

            // 
            // udL
            // 
            this.udL.AutoSize = true;
            this.udL.Location = new System.Drawing.Point(467, 50);
            this.udL.Name = "udL";
            this.udL.Size = new System.Drawing.Size(55, 13);
            this.udL.TabIndex = 19;
            this.udL.Text = "00000000";
            // 
            // rdL
            // 
            this.rdL.AutoSize = true;
            this.rdL.Location = new System.Drawing.Point(467, 35);
            this.rdL.Name = "rdL";
            this.rdL.Size = new System.Drawing.Size(55, 13);
            this.rdL.TabIndex = 18;
            this.rdL.Text = "00000000";
            // 
            // euLL
            // 
            this.euLL.AutoSize = true;
            this.euLL.Location = new System.Drawing.Point(270, 50);
            this.euLL.Name = "euLL";
            this.euLL.Size = new System.Drawing.Size(198, 13);
            this.euLL.TabIndex = 17;
            this.euLL.Text = "Estimated Upload ..................................:";
            // 
            // rdLL
            // 
            this.rdLL.AutoSize = true;
            this.rdLL.Location = new System.Drawing.Point(270, 35);
            this.rdLL.Name = "rdLL";
            this.rdLL.Size = new System.Drawing.Size(197, 13);
            this.rdLL.TabIndex = 16;
            this.rdLL.Text = "Real Download .....................................:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(198, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Time ......................................................:";
            // 
            // clockLabel
            // 
            this.clockLabel.AutoSize = true;
            this.clockLabel.Location = new System.Drawing.Point(467, 20);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.Size = new System.Drawing.Size(49, 13);
            this.clockLabel.TabIndex = 11;
            this.clockLabel.Text = "00:00:00";
            // 
            // urLabel
            // 
            this.urLabel.AutoSize = true;
            this.urLabel.Location = new System.Drawing.Point(192, 50);
            this.urLabel.Name = "urLabel";
            this.urLabel.Size = new System.Drawing.Size(55, 13);
            this.urLabel.TabIndex = 14;
            this.urLabel.Text = "00000000";
            // 
            // srLabel
            // 
            this.srLabel.AutoSize = true;
            this.srLabel.Location = new System.Drawing.Point(192, 35);
            this.srLabel.Name = "srLabel";
            this.srLabel.Size = new System.Drawing.Size(55, 13);
            this.srLabel.TabIndex = 13;
            this.srLabel.Text = "00000000";
            // 
            // activeThreadsLabel
            // 
            this.activeThreadsLabel.AutoSize = true;
            this.activeThreadsLabel.Location = new System.Drawing.Point(192, 20);
            this.activeThreadsLabel.Name = "activeThreadsLabel";
            this.activeThreadsLabel.Size = new System.Drawing.Size(55, 13);
            this.activeThreadsLabel.TabIndex = 12;
            this.activeThreadsLabel.Text = "00000000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Unsuccessfull Requests ...................:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Successfull Requests .......................:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Active Threads .................................:";
            // 
            // interfacesComboBox
            // 
            this.interfacesComboBox.Enabled = false;
            this.interfacesComboBox.FormattingEnabled = true;
            this.interfacesComboBox.Location = new System.Drawing.Point(97, 31);
            this.interfacesComboBox.Name = "interfacesComboBox";
            this.interfacesComboBox.Size = new System.Drawing.Size(317, 21);
            this.interfacesComboBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(9, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Output Interface:";
            // 
            // ipSpoofCheckBox
            // 
            this.ipSpoofCheckBox.AutoSize = true;
            this.ipSpoofCheckBox.Location = new System.Drawing.Point(420, 34);
            this.ipSpoofCheckBox.Name = "ipSpoofCheckBox";
            this.ipSpoofCheckBox.Size = new System.Drawing.Size(128, 17);
            this.ipSpoofCheckBox.TabIndex = 2;
            this.ipSpoofCheckBox.Text = "Ip Spoofing (to target)";
            this.ipSpoofCheckBox.UseVisualStyleBackColor = true;
            this.ipSpoofCheckBox.CheckedChanged += new System.EventHandler(this.ipSpoofCheckBox_CheckedChanged);
            // 
            // idTextBox
            // 
            this.idTextBox.BackColor = System.Drawing.Color.Navy;
            this.idTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.idTextBox.Location = new System.Drawing.Point(326, 188);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(215, 20);
            this.idTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(299, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "ID:";
            // 
            // IgnitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 275);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.ipSpoofCheckBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.interfacesComboBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.urlsTextBox);
            this.Controls.Add(this.nThreadsTextBox);
            this.Controls.Add(this.plantBt);
            this.Controls.Add(this.timesTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IgnitionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KiddieZoo UI - Tester";
            this.Load += new System.EventHandler(this.IgnitionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox timesTextBox;
        private System.Windows.Forms.Button plantBt;
        private System.Windows.Forms.TextBox nThreadsTextBox;
        private System.Windows.Forms.TextBox urlsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label activeThreadsLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label urLabel;
        private System.Windows.Forms.Label srLabel;
        private System.Windows.Forms.Label clockLabel;
        private System.Windows.Forms.Label udL;
        private System.Windows.Forms.Label rdL;
        private System.Windows.Forms.Label euLL;
        private System.Windows.Forms.Label rdLL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox interfacesComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox ipSpoofCheckBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label5;
    }
}

