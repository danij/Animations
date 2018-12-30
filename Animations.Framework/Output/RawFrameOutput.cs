using System.IO;
using Animations.Framework.Drawing;

namespace Animations.Framework.Output
{
    public class RawFrameOutput : IVideoOutput
    {
        public RawFrameOutput(string destinationFileFormat)
        {
            _destinationFileFormat = destinationFileFormat;
        }

        public void Dispose()
        {
        }

        public void Write(Frame frame)
        {
            File.WriteAllBytes(string.Format(_destinationFileFormat, _frameNumber++), frame.Bytes);
        }
        
        private int _frameNumber;
        private readonly string _destinationFileFormat;
    }
}