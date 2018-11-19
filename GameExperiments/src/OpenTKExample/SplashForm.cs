// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Hinnerup Net">
//   GPL-3.0
// </copyright>
// <summary>
//   Defines the SplashForm where UI options can be set.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameExperiments.OpenTKExample
{
	using System;
	using System.Windows.Forms;

	using OpenTK;

	public partial class SplashForm : Form
	{
		public SplashForm()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var width = int.Parse(this.edWidth.Text);
			var height = int.Parse(this.edHeight.Text);
			var maxFps = int.Parse(this.edFps.Text);
			var fullscreen = this.cbFullscreen.Checked;
			var vsync = this.cbVsync.Checked;
			using (var mw = new MainWindow(width, height, fullscreen))
			{
				mw.VSync = vsync ? VSyncMode.On : VSyncMode.Off;
				mw.Run(maxFps);
			}
		}

		private void SplashForm_Shown(object sender, EventArgs e)
		{
			var myScreen = Screen.FromControl(this);
			var area = myScreen.Bounds;
			this.edWidth.Text = area.Width.ToString();
			this.edHeight.Text = area.Height.ToString();
		}

		private void cbVsync_CheckedChanged(object sender, EventArgs e)
		{
			this.edFps.Enabled = this.cbVsync.Checked;
		}
	}
}
