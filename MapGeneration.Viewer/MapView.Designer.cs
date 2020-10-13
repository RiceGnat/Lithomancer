namespace Lithomancer.MapGeneration.Viewer
{
	partial class MapView
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
			this.showEdges = new System.Windows.Forms.CheckBox();
			this.wallDensity = new System.Windows.Forms.TrackBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.rockDensity = new System.Windows.Forms.TrackBar();
			this.factorySeed = new System.Windows.Forms.TextBox();
			this.mapSeed = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.wallDensity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rockDensity)).BeginInit();
			this.SuspendLayout();
			// 
			// showEdges
			// 
			this.showEdges.AutoSize = true;
			this.showEdges.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.showEdges.Location = new System.Drawing.Point(9, 232);
			this.showEdges.Name = "showEdges";
			this.showEdges.Size = new System.Drawing.Size(15, 14);
			this.showEdges.TabIndex = 0;
			this.showEdges.UseVisualStyleBackColor = true;
			// 
			// wallDensity
			// 
			this.wallDensity.Location = new System.Drawing.Point(0, 12);
			this.wallDensity.Minimum = 1;
			this.wallDensity.Name = "wallDensity";
			this.wallDensity.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.wallDensity.Size = new System.Drawing.Size(45, 104);
			this.wallDensity.TabIndex = 1;
			this.wallDensity.Value = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(32, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(389, 366);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// rockDensity
			// 
			this.rockDensity.Location = new System.Drawing.Point(0, 122);
			this.rockDensity.Minimum = 1;
			this.rockDensity.Name = "rockDensity";
			this.rockDensity.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.rockDensity.Size = new System.Drawing.Size(45, 104);
			this.rockDensity.TabIndex = 3;
			this.rockDensity.Value = 1;
			// 
			// factorySeed
			// 
			this.factorySeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.factorySeed.Location = new System.Drawing.Point(32, 372);
			this.factorySeed.Name = "factorySeed";
			this.factorySeed.Size = new System.Drawing.Size(100, 20);
			this.factorySeed.TabIndex = 4;
			// 
			// mapSeed
			// 
			this.mapSeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.mapSeed.Location = new System.Drawing.Point(138, 372);
			this.mapSeed.Name = "mapSeed";
			this.mapSeed.Size = new System.Drawing.Size(100, 20);
			this.mapSeed.TabIndex = 5;
			// 
			// CaveView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 398);
			this.Controls.Add(this.mapSeed);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.factorySeed);
			this.Controls.Add(this.rockDensity);
			this.Controls.Add(this.wallDensity);
			this.Controls.Add(this.showEdges);
			this.Name = "CaveView";
			this.Text = "Cave";
			((System.ComponentModel.ISupportInitialize)(this.wallDensity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rockDensity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox showEdges;
		private System.Windows.Forms.TrackBar wallDensity;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TrackBar rockDensity;
		private System.Windows.Forms.TextBox factorySeed;
		private System.Windows.Forms.TextBox mapSeed;
	}
}