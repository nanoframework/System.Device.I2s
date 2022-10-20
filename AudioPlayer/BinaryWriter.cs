using System;
using System.IO;

namespace AudioPlayer
{
    public class BinaryWriter
    {
        private readonly MemoryStream _stream;

        public BinaryWriter(MemoryStream stream)
        {
            _stream = stream;
        }

        public void Write(int i)
        {
            var currentLocation = _stream.Position;

            var bytes = BitConverter.GetBytes(i);
            _stream.Write(bytes, 0, 4);
        }

        public void Write(byte b)
        {
            _stream.WriteByte(b);
        }

        public void Flush()
        {
            _stream.Flush();
        }
    }
}