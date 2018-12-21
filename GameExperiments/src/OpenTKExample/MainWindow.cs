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
  using System.Diagnostics;
  using System.IO;
  using System.Threading;

  using OpenTK;
  using OpenTK.Audio;
  using OpenTK.Audio.OpenAL;
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

    static readonly string filename1 = Path.Combine("Sounds", "shoot-1.wav");
    static readonly string filename2 = Path.Combine("Sounds", "shoot-2.wav");
    static readonly string filename3 = Path.Combine("Sounds", "shoot-3.wav");
    static readonly string filename4 = Path.Combine("Sounds", "shoot-4.wav");
    static readonly string filename5 = Path.Combine("Sounds", "shoot-5.wav");
    static readonly string filename6 = Path.Combine("Sounds", "shoot-6.wav");

    // Loads a wave/riff audio file.
    public static byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
    {
      if (stream == null)
        throw new ArgumentNullException("stream");

      using (BinaryReader reader = new BinaryReader(stream))
      {
        // RIFF header
        string signature = new string(reader.ReadChars(4));
        if (signature != "RIFF")
          throw new NotSupportedException("Specified stream is not a wave file.");

        int riff_chunck_size = reader.ReadInt32();

        string format = new string(reader.ReadChars(4));
        if (format != "WAVE")
          throw new NotSupportedException("Specified stream is not a wave file.");

        // WAVE header
        string format_signature = new string(reader.ReadChars(4));
        if (format_signature != "fmt ")
          throw new NotSupportedException("Specified wave file is not supported.");

        int format_chunk_size = reader.ReadInt32();
        int audio_format = reader.ReadInt16();
        int num_channels = reader.ReadInt16();
        int sample_rate = reader.ReadInt32();
        int byte_rate = reader.ReadInt32();
        int block_align = reader.ReadInt16();
        int bits_per_sample = reader.ReadInt16();

        string data_signature = new string(reader.ReadChars(4));
        if (data_signature != "data")
          throw new NotSupportedException("Specified wave file is not supported.");

        int data_chunk_size = reader.ReadInt32();

        channels = num_channels;
        bits = bits_per_sample;
        rate = sample_rate;

        return reader.ReadBytes((int)reader.BaseStream.Length);
      }
    }

    public static ALFormat GetSoundFormat(int channels, int bits)
    {
      switch (channels)
      {
        case 1: return bits == 8 ? ALFormat.Mono8 : ALFormat.Mono16;
        case 2: return bits == 8 ? ALFormat.Stereo8 : ALFormat.Stereo16;
        default: throw new NotSupportedException("The specified sound format is not supported.");
      }
    }

    private int source1, source2, source3, source4, source5, source6, buffer1, buffer2, buffer3, buffer4, buffer5, buffer6;

    private AudioContext context;

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

      // See https://github.com/mono/opentk/blob/master/Source/Examples/OpenAL/1.1/Playback.cs 
      // See https://forums.tigsource.com/index.php?topic=32474.0
      this.context = new AudioContext();

      this.buffer1 = AL.GenBuffer();
      this.source1 = AL.GenSource();
      int state;

      int channels, bits_per_sample, sample_rate;
      byte[] sound_data = LoadWave(File.Open(filename1, FileMode.Open), out channels, out bits_per_sample, out sample_rate);
      AL.BufferData(this.buffer1, GetSoundFormat(channels, bits_per_sample), sound_data, sound_data.Length, sample_rate);

      AL.Source(this.source1, ALSourcei.Buffer, this.buffer1);


      this.buffer2 = AL.GenBuffer();
      this.source2 = AL.GenSource();

      sound_data = LoadWave(File.Open(filename2, FileMode.Open), out channels, out bits_per_sample, out sample_rate);
      AL.BufferData(this.buffer2, GetSoundFormat(channels, bits_per_sample), sound_data, sound_data.Length, sample_rate);

      AL.Source(this.source2, ALSourcei.Buffer, this.buffer2);



      this.buffer3 = AL.GenBuffer();
      this.source3 = AL.GenSource();

      sound_data = LoadWave(File.Open(filename3, FileMode.Open), out channels, out bits_per_sample, out sample_rate);
      AL.BufferData(this.buffer3, GetSoundFormat(channels, bits_per_sample), sound_data, sound_data.Length, sample_rate);

      AL.Source(this.source3, ALSourcei.Buffer, this.buffer3);



      this.buffer4 = AL.GenBuffer();
      this.source4 = AL.GenSource();

      sound_data = LoadWave(File.Open(filename4, FileMode.Open), out channels, out bits_per_sample, out sample_rate);
      AL.BufferData(this.buffer4, GetSoundFormat(channels, bits_per_sample), sound_data, sound_data.Length, sample_rate);

      AL.Source(this.source4, ALSourcei.Buffer, this.buffer4);



      this.buffer5 = AL.GenBuffer();
      this.source5= AL.GenSource();

      sound_data = LoadWave(File.Open(filename5, FileMode.Open), out channels, out bits_per_sample, out sample_rate);
      AL.BufferData(this.buffer5, GetSoundFormat(channels, bits_per_sample), sound_data, sound_data.Length, sample_rate);

      AL.Source(this.source5, ALSourcei.Buffer, this.buffer5);




      this.buffer6 = AL.GenBuffer();
      this.source6 = AL.GenSource();

      sound_data = LoadWave(File.Open(filename6, FileMode.Open), out channels, out bits_per_sample, out sample_rate);
      AL.BufferData(this.buffer6, GetSoundFormat(channels, bits_per_sample), sound_data, sound_data.Length, sample_rate);

      AL.Source(this.source6, ALSourcei.Buffer, this.buffer6);


      AL.SourcePlay(this.source1);

      Trace.Write("Playing");

      // Query the source to find out when it stops playing.
      do
      {
        Thread.Sleep(250);
        Trace.Write(".");
        AL.GetSource(this.source1, ALGetSourcei.SourceState, out state);
      }
      while ((ALSourceState)state == ALSourceState.Playing);

      Trace.WriteLine("");

      AL.SourceStop(this.source1);
    }

    /// <summary>
    ///   The exit method.
    /// </summary>
    public override void Exit()
    {
      AL.DeleteSource(source1);
      AL.DeleteBuffer(buffer1);
      AL.DeleteSource(source2);
      AL.DeleteBuffer(buffer2);
      AL.DeleteSource(source3);
      AL.DeleteBuffer(buffer3);
      AL.DeleteSource(source4);
      AL.DeleteBuffer(buffer4);
      AL.DeleteSource(source5);
      AL.DeleteBuffer(buffer5);
      AL.DeleteSource(source6);
      AL.DeleteBuffer(buffer6);

      this.context.Dispose();

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

    private int psource;

    private int csource = 1;

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
      if (keyState[Key.P])
      {
        int state;
        AL.GetSource(psource, ALGetSourcei.SourceState, out state);
        if ((ALSourceState)state != ALSourceState.Playing)
        {
          //AL.SourceStop(psource);

          // Switch shoot sound being used
          this.csource++;
          if (this.csource > 6) this.csource = 1;
          if (this.csource == 1) this.psource = this.source1;
          if (this.csource == 2) this.psource = this.source2;
          if (this.csource == 3) this.psource = this.source3;
          if (this.csource == 4) this.psource = this.source4;
          if (this.csource == 5) this.psource = this.source5;
          if (this.csource == 6) this.psource = this.source6;
          AL.SourcePlay(psource);
        }
        
      }
      if (keyState[Key.S])
      {
        AL.SourceStop(psource);
      }
      if (keyState[Key.H])
      {
        AL.SourcePause(psource);
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