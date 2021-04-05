
namespace Led
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
            System.Windows.Forms.Label labelTemp;
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.labelSetPoint = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.lblDenumireTemp = new System.Windows.Forms.Label();
            this.lblDenSetP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            labelTemp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gold;
            this.button3.Location = new System.Drawing.Point(383, 252);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "SetPlus";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Location = new System.Drawing.Point(272, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "SetMinus";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTemp
            // 
            labelTemp.AutoSize = true;
            labelTemp.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            labelTemp.Location = new System.Drawing.Point(338, 64);
            labelTemp.Name = "labelTemp";
            labelTemp.Size = new System.Drawing.Size(84, 31);
            labelTemp.TabIndex = 8;
            labelTemp.Text = "label1";
            labelTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSetPoint
            // 
            this.labelSetPoint.AutoSize = true;
            this.labelSetPoint.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelSetPoint.Location = new System.Drawing.Point(338, 201);
            this.labelSetPoint.Name = "labelSetPoint";
            this.labelSetPoint.Size = new System.Drawing.Size(84, 31);
            this.labelSetPoint.TabIndex = 9;
            this.labelSetPoint.Text = "label2";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelStatus.Location = new System.Drawing.Point(338, 385);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(84, 31);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "label2";
            // 
            // lblDenumireTemp
            // 
            this.lblDenumireTemp.AutoSize = true;
            this.lblDenumireTemp.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDenumireTemp.Location = new System.Drawing.Point(65, 64);
            this.lblDenumireTemp.Name = "lblDenumireTemp";
            this.lblDenumireTemp.Size = new System.Drawing.Size(181, 31);
            this.lblDenumireTemp.TabIndex = 11;
            this.lblDenumireTemp.Text = "Temperature :";
            this.lblDenumireTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDenSetP
            // 
            this.lblDenSetP.AutoSize = true;
            this.lblDenSetP.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDenSetP.Location = new System.Drawing.Point(65, 201);
            this.lblDenSetP.Name = "lblDenSetP";
            this.lblDenSetP.Size = new System.Drawing.Size(213, 31);
            this.lblDenSetP.TabIndex = 12;
            this.lblDenSetP.Text = "Actual SetPoint :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(65, 385);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "Actual Status :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDenSetP);
            this.Controls.Add(this.lblDenumireTemp);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelSetPoint);
            this.Controls.Add(labelTemp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Name = "Form1";
            this.Text = "TERMOSTAT - Main Control Panel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label labelTemp;
        private System.Windows.Forms.Label labelSetPoint;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label lblDenumireTemp;
        private System.Windows.Forms.Label lblDenSetP;
        private System.Windows.Forms.Label label1;
    }
}



