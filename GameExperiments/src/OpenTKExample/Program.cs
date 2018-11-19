// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Hinnerup Net">
//   Copyright 2018
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowsFormsApp1
{
	using System;
	using System.Windows.Forms;

	/// <summary>
	///     The program.
	/// </summary>
	public static class Program
	{
		/// <summary>
		///    The main method.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			var res = DialogResult.None;
			while (res != DialogResult.OK)
			{
				var sf = new SplashForm();
				res = sf.ShowDialog();
			}
		}
	}
}
