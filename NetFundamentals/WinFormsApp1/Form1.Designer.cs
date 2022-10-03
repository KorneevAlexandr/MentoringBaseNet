namespace WinFormsApp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameBtn = new System.Windows.Forms.Button();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.AccessibleName = "";
            this.NameTextBox.Location = new System.Drawing.Point(93, 73);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(231, 27);
            this.NameTextBox.TabIndex = 1;
            // 
            // NameBtn
            // 
            this.NameBtn.Location = new System.Drawing.Point(153, 150);
            this.NameBtn.Name = "NameBtn";
            this.NameBtn.Size = new System.Drawing.Size(94, 29);
            this.NameBtn.TabIndex = 2;
            this.NameBtn.Text = "Accept";
            this.NameBtn.UseVisualStyleBackColor = true;
            this.NameBtn.Click += new System.EventHandler(this.NameBtn_Click);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AccessibleName = "";
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(86, 230);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(0, 20);
            this.ResultLabel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 450);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.NameBtn);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox NameTextBox;
        private Button NameBtn;
        private Label ResultLabel;
    }
}