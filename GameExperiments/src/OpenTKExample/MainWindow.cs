// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Hinnerup Net A/S">
//   GPL-3.0
// </copyright>
// <summary>
//   Defines the MainWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GameExperiments.OpenTKExample
{
	using System;
	using System.IO;

	using OpenTK;
	using OpenTK.Graphics;
	using OpenTK.Graphics.OpenGL4;
	using OpenTK.Input;

	/// <summary>
	///     The main window.
	/// </summary>
	public sealed class MainWindow : GameWindow
	{
		/// <summary>
		///   The window title.
		/// </summary>
		private const string WindowTitle = "OpenGL";

		/// <summary>
		///   The program id.
		/// </summary>
		private int program;

		/// <summary>
		///   The time ticker.
		/// </summary>
		private double time;

		/// <summary>
		///   The vertex array.
		/// </summary>
		private int vertexArray;

		/// <summary>
		///   Initializes a new instance of the <see cref="MainWindow"/> class.
		/// </summary>
		/// <param name="width">The window width.</param>
		/// <param name="height">The window height.</param>
		/// <param name="fullscreen">True if fullscreen mode should be used.</param>
		public MainWindow(int width, int height, bool fullscreen)
			: base(
				width, // initial width
				height, // initial height
				GraphicsMode.Default,
				WindowTitle, // initial title
				fullscreen ? GameWindowFlags.Fullscreen : GameWindowFlags.Default,
				DisplayDevice.Default,
				4, // OpenGL major version
				0, // OpenGL minor version
				GraphicsContextFlags.ForwardCompatible)
		{
			this.Title += ": OpenGL Version: " + GL.GetString(StringName.Version);
		}

		/// <summary>
		///   The exit method.
		/// </summary>
		public override void Exit()
		{
			GL.DeleteVertexArrays(1, ref this.vertexArray);
			GL.DeleteProgram(this.program);
			
			////base.Exit();
			this.Close();
		}

		/// <summary>
		///   The on load.
		/// </summary>
		/// <param name="e">The OnLoad event e.</param>
		protected override void OnLoad(EventArgs e)
		{
			this.CursorVisible = true;
			this.program = this.CompileShaders();
			GL.GenVertexArrays(1, out this.vertexArray);
			GL.BindVertexArray(this.vertexArray);
			this.Closed += this.OnClosed;
		}

		/// <summary>
		///   The on render frame.
		/// </summary>
		/// <param name="e">The OnRenderFrame event e.</param>
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			this.time += e.Time;
			this.Title = $"{WindowTitle}: (Vsync: {this.VSync}) FPS: {1f / e.Time:0}";
			Color4 backColor;
			backColor.A = 1.0f;
			backColor.R = 0.1f;
			backColor.G = 0.1f;
			backColor.B = 0.3f;
			GL.ClearColor(backColor);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.UseProgram(this.program);

			// add shader attributes here
			Vector4 position;
			position.X = (float)Math.Sin(this.time) * 0.5f;
			position.Y = (float)Math.Cos(this.time) * 0.5f;
			position.Z = 0.0f;
			position.W = 1.0f;
			GL.VertexAttrib4(1, position);
			GL.VertexAttrib1(0, this.time);

			GL.DrawArrays(PrimitiveType.Points, 0, 1);
			GL.PointSize(20);
			this.SwapBuffers();
		}

		/// <summary>
		///   The on resize.
		/// </summary>
		/// <param name="e">The OnResize event e.</param>
		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0, 0, this.Width, this.Height);
		}

		/// <summary>
		///   The on update frame.
		/// </summary>
		/// <param name="e">The OnUpdateFrame event e.</param>
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			this.HandleKeyboard();
		}

		/// <summary>
		///   The compile shaders.
		/// </summary>
		/// <returns>Returns an int reference number to the created openGL program (shader).</returns>
		private int CompileShaders()
		{
			var vertexShader = GL.CreateShader(ShaderType.VertexShader);
			GL.ShaderSource(vertexShader, File.ReadAllText(@"Components\Shaders\vertexShader.vert"));
			GL.CompileShader(vertexShader);

			var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
			GL.ShaderSource(fragmentShader, File.ReadAllText(@"Components\Shaders\fragmentShader.frag"));
			GL.CompileShader(fragmentShader);

			var shaderProgram = GL.CreateProgram();
			GL.AttachShader(shaderProgram, vertexShader);
			GL.AttachShader(shaderProgram, fragmentShader);
			GL.LinkProgram(shaderProgram);

			GL.DetachShader(shaderProgram, vertexShader);
			GL.DetachShader(shaderProgram, fragmentShader);
			GL.DeleteShader(vertexShader);
			GL.DeleteShader(fragmentShader);
			return shaderProgram;
		}

		/// <summary>
		///   The handle keyboard method.
		/// </summary>
		private void HandleKeyboard()
		{
			var keyState = Keyboard.GetState();

			if (keyState.IsKeyDown(Key.Escape))
			{
				this.Exit();
			}
		}

		/// <summary>
		///   The on closed event handler. Calling this method exits the form.
		/// </summary>
		/// <param name="sender">The sender object instance.</param>
		/// <param name="eventArgs">The OnClosed event arguments.</param>
		private void OnClosed(object sender, EventArgs eventArgs)
		{
			this.Exit();
		}
	}
}