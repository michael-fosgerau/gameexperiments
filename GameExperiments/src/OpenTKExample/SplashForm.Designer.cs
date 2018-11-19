namespace GameExperiments.OpenTKExample
{
	partial class SplashForm
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
			if (disposing && (this.components != null))
			{
				this.components.Dispose();
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbFullscreen = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.edWidth = new System.Windows.Forms.TextBox();
			this.edHeight = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.edFps = new System.Windows.Forms.TextBox();
			this.cbVsync = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(34, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(502, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "About to launch the OpenTKExample UI with these attributes:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(35, 200);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(361, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Once started, press ESC to close the demo.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(71, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Screen mode";
			// 
			// cbFullscreen
			// 
			this.cbFullscreen.AutoSize = true;
			this.cbFullscreen.Checked = true;
			this.cbFullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbFullscreen.Location = new System.Drawing.Point(74, 125);
			this.cbFullscreen.Name = "cbFullscreen";
			this.cbFullscreen.Size = new System.Drawing.Size(74, 17);
			this.cbFullscreen.TabIndex = 3;
			this.cbFullscreen.Text = "Fullscreen";
			this.cbFullscreen.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(196, 105);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 16);
			this.label4.TabIndex = 4;
			this.label4.Text = "Resolution";
			// 
			// edWidth
			// 
			this.edWidth.Location = new System.Drawing.Point(199, 123);
			this.edWidth.Name = "edWidth";
			this.edWidth.Size = new System.Drawing.Size(67, 20);
			this.edWidth.TabIndex = 5;
			this.edWidth.Text = "1024";
			this.edWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// edHeight
			// 
			this.edHeight.Location = new System.Drawing.Point(290, 123);
			this.edHeight.Name = "edHeight";
			this.edHeight.Size = new System.Drawing.Size(67, 20);
			this.edHeight.TabIndex = 6;
			this.edHeight.Text = "768";
			this.edHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(273, 126);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "x";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(504, 200);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(504, 229);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "Exit";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(392, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Max FPS";
			// 
			// edFps
			// 
			this.edFps.Location = new System.Drawing.Point(395, 123);
			this.edFps.Name = "edFps";
			this.edFps.Size = new System.Drawing.Size(67, 20);
			this.edFps.TabIndex = 11;
			this.edFps.Text = "60";
			this.edFps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbVsync
			// 
			this.cbVsync.AutoSize = true;
			this.cbVsync.Checked = true;
			this.cbVsync.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbVsync.Location = new System.Drawing.Point(74, 148);
			this.cbVsync.Name = "cbVsync";
			this.cbVsync.Size = new System.Drawing.Size(57, 17);
			this.cbVsync.TabIndex = 12;
			this.cbVsync.Text = "VSync";
			this.cbVsync.UseVisualStyleBackColor = true;
			this.cbVsync.CheckedChanged += new System.EventHandler(this.cbVsync_CheckedChanged);
			// 
			// SplashForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(638, 271);
			this.Controls.Add(this.cbVsync);
			this.Controls.Add(this.edFps);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.edHeight);
			this.Controls.Add(this.edWidth);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbFullscreen);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "SplashForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OpenTKExample demo";
			this.Shown += new System.EventHandler(this.SplashForm_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox cbFullscreen;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox edWidth;
		private System.Windows.Forms.TextBox edHeight;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox edFps;
		private System.Windows.Forms.CheckBox cbVsync;
	}
}