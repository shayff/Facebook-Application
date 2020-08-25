namespace UserInterface
{
    public partial class FormExit
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
            this.buttonYseExit = new System.Windows.Forms.Button();
            this.buttonNoExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonYseExit
            // 
            this.buttonYseExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonYseExit.Location = new System.Drawing.Point(80, 215);
            this.buttonYseExit.Name = "buttonYseExit";
            this.buttonYseExit.Size = new System.Drawing.Size(257, 75);
            this.buttonYseExit.TabIndex = 0;
            this.buttonYseExit.Text = "YES";
            this.buttonYseExit.UseVisualStyleBackColor = true;
            this.buttonYseExit.Click += new System.EventHandler(this.buttonYseExit_Click);
            // 
            // buttonNoExit
            // 
            this.buttonNoExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonNoExit.Location = new System.Drawing.Point(475, 215);
            this.buttonNoExit.Name = "buttonNoExit";
            this.buttonNoExit.Size = new System.Drawing.Size(258, 75);
            this.buttonNoExit.TabIndex = 1;
            this.buttonNoExit.Text = "No";
            this.buttonNoExit.UseVisualStyleBackColor = true;
            this.buttonNoExit.Click += new System.EventHandler(this.buttonNoExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("David", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(664, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sure you want to Exit?";
            // 
            // FormExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(790, 342);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNoExit);
            this.Controls.Add(this.buttonYseExit);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormExit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonYseExit;
        private System.Windows.Forms.Button buttonNoExit;
        private System.Windows.Forms.Label label1;
    }
}