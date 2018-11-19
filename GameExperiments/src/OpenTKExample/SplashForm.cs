// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Hinnerup Net A/S">
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

	/// <summary>
	///   The splash form.
	/// </summary>
	public partial class SplashForm : Form
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="SplashForm"/> class.
		/// </summary>
		public SplashForm()
		{
			this.InitializeComponent();
		}

		/// <summary>
		///   Event handler for button1.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The button client event e.</param>
		private void Button1Click(object sender, EventArgs e)
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

		/// <summary>
		///   Event handler for when SplashForm is shown.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The shown event e.</param>
		private void SplashFormShown(object sender, EventArgs e)
		{
			var myScreen = Screen.FromControl(this);
			var area = myScreen.Bounds;
			this.edWidth.Text = area.Width.ToString();
			this.edHeight.Text = area.Height.ToString();
		}

		/// <summary>
		///   Event handler for when the checkbox for vsync is toggled.
		/// </summary>
		/// <param name="sender">The sender object instance.</param>
		/// <param name="e">The checkbox toggle event e.</param>
		private void CbVsyncCheckedChanged(object sender, EventArgs e)
		{
			this.edFps.Enabled = this.cbVsync.Checked;
		}
	}
}
