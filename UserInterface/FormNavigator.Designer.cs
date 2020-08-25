namespace UserInterface
{
    public partial class FormNavigator
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
            this.labelNameOfEvent = new System.Windows.Forms.Label();
            this.gMapControlNavigator = new GMap.NET.WindowsForms.GMapControl();
            this.labelStartAdress = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNameOfEvent
            // 
            this.labelNameOfEvent.AutoSize = true;
            this.labelNameOfEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameOfEvent.Location = new System.Drawing.Point(322, 72);
            this.labelNameOfEvent.Name = "labelNameOfEvent";
            this.labelNameOfEvent.Size = new System.Drawing.Size(158, 29);
            this.labelNameOfEvent.TabIndex = 0;
            this.labelNameOfEvent.Text = "nameOfEvent";
            // 
            // gMapControlNavigator
            // 
            this.gMapControlNavigator.Bearing = 0F;
            this.gMapControlNavigator.CanDragMap = true;
            this.gMapControlNavigator.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControlNavigator.GrayScaleMode = false;
            this.gMapControlNavigator.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControlNavigator.LevelsKeepInMemmory = 5;
            this.gMapControlNavigator.Location = new System.Drawing.Point(69, 119);
            this.gMapControlNavigator.MarkersEnabled = true;
            this.gMapControlNavigator.MaxZoom = 18;
            this.gMapControlNavigator.MinZoom = 2;
            this.gMapControlNavigator.MouseWheelZoomEnabled = true;
            this.gMapControlNavigator.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControlNavigator.Name = "gMapControlNavigator";
            this.gMapControlNavigator.NegativeMode = false;
            this.gMapControlNavigator.PolygonsEnabled = true;
            this.gMapControlNavigator.RetryLoadTile = 0;
            this.gMapControlNavigator.RoutesEnabled = true;
            this.gMapControlNavigator.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControlNavigator.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControlNavigator.ShowTileGridLines = false;
            this.gMapControlNavigator.Size = new System.Drawing.Size(683, 340);
            this.gMapControlNavigator.TabIndex = 1;
            this.gMapControlNavigator.Zoom = 16D;
            this.gMapControlNavigator.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControlNavigator_MouseDoubleClick);
            // 
            // labelStartAdress
            // 
            this.labelStartAdress.AutoSize = true;
            this.labelStartAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartAdress.Location = new System.Drawing.Point(203, 462);
            this.labelStartAdress.Name = "labelStartAdress";
            this.labelStartAdress.Size = new System.Drawing.Size(377, 20);
            this.labelStartAdress.TabIndex = 4;
            this.labelStartAdress.Text = "Double Click on your Start Point to get Directions";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UserInterface.Properties.Resources.Navigator_logo;
            this.pictureBox1.Location = new System.Drawing.Point(207, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 491);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelStartAdress);
            this.Controls.Add(this.gMapControlNavigator);
            this.Controls.Add(this.labelNameOfEvent);
            this.Name = "FormNavigator";
            this.Text = "Navigator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNameOfEvent;
        private GMap.NET.WindowsForms.GMapControl gMapControlNavigator;
        private System.Windows.Forms.Label labelStartAdress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}