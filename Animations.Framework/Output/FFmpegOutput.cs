using System.Diagnostics;
using Animations.Framework.Drawing;

namespace Animations.Framework.Output
{
    public sealed class FFMpegOutput : IVideoOutput
    {
        public FFMpegOutput(string destinationFilePath, AnimationProperties properties)
        {
            _process = new Process();
            _process.StartInfo.FileName = "ffmpeg";
            const string argumentsFormat =
                "-y -f rawvideo -pix_fmt bgra -s:v {0}x{1} -r {2:F2} -i pipe:0 -dst_range 0 -pix_fmt yuv422p -crf 0 \"{3}\"";
            _process.StartInfo.Arguments = string.Format(argumentsFormat, properties.Width, properties.Height,
                properties.Fps, destinationFilePath);
            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardInput = true;
            _process.Start();
        }
        
        public void Dispose()
        {
            _process.StandardInput.Close();
            _process.WaitForExit();
        }

        public void Write(Frame frame)
        {
            _process.StandardInput.BaseStream.Write(frame.Bytes, 0, frame.Bytes.Length);
        }

        private readonly Process _process;
    }
}