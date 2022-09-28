using System;
using System.IO;

namespace AudioPlayer
{
    public class BinaryWriter
    {
        private readonly Stream _stream;

        public BinaryWriter(Stream stream)
        {
            _stream = stream;
        }

        public void Write(int i)
        {
            var currentLocation = _stream.Position;

            var bytes = BitConverter.GetBytes(i);
            _stream.Write(bytes, 0, 4);

            if (_stream.Position != currentLocation + 4)
            {
                // something went wrong ?
            }
        }

        public void Flush()
        {
            _stream.Flush();
        }
    }
}