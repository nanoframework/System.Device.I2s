using System;
using System.Text;

namespace AudioPlayer
{
    public class WavFileHeader
    {
        private readonly byte[] _header;

        public WavFileHeader(byte[] header)
        {
            if (header == null || header.Length != 44)
                throw new ArgumentException("Only WAV file headers with 44 bytes are supported.");

            _header = header;
        }

        public WavFileHeader()
        {
            _header = new byte[44];
            RiffChunkId = "RIFF";
            WaveFormat = "WAVE";
            FormatChunkId = "fmt ";
            DataChunkId = "data";
        }

        public string RiffChunkId
        {
            get => Encoding.UTF8.GetString(_header, 0, 4);
            set
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                if (bytes.Length != 4) throw new ArgumentException("RiffChunkId must be 4 bytes long");

                Array.Copy(bytes, 0, _header, 0, 4);
            }
        }

        public int FileSize
        {
            get => BitConverter.ToInt32(_header, 4);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 4, 4);
            }
        }

        public string WaveFormat
        {
            get => Encoding.UTF8.GetString(_header, 8, 4);
            set
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                if (bytes.Length != 4) throw new ArgumentException("WaveFormat must be 4 bytes long");

                Array.Copy(bytes, 0, _header, 8, 4);
            }
        }

        public string FormatChunkId
        {
            get => Encoding.UTF8.GetString(_header, 12, 4);
            set
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                if (bytes.Length != 4) throw new ArgumentException("FormatChunkId must be 4 bytes long");

                Array.Copy(bytes, 0, _header, 12, 4);
            }
        }

        public int FormatChunkSize
        {
            get => BitConverter.ToInt32(_header, 16);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 16, 4);
            }
        }

        public short AudioFormat
        {
            get => BitConverter.ToInt16(_header, 20);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 20, 2);
            }
        }

        public short NumberOfChannels
        {
            get => BitConverter.ToInt16(_header, 22);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 22, 2);
            }
        }

        public int SampleRate
        {
            get => BitConverter.ToInt32(_header, 24);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 24, 4);
            }
        }

        public int BytesPerSecond
        {
            get => BitConverter.ToInt32(_header, 28);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 28, 4);
            }
        }

        public short FrameSize
        {
            get => BitConverter.ToInt16(_header, 32);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 32, 2);
            }
        }

        public short BitsPerSample
        {
            get => BitConverter.ToInt16(_header, 34);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 32, 2);
            }
        }

        public string DataChunkId
        {
            get => Encoding.UTF8.GetString(_header, 36, 4);
            set
            {
                var bytes = Encoding.UTF8.GetBytes(value);
                if (bytes.Length != 4) throw new ArgumentException("DataChunkId must be 4 bytes long");
                Array.Copy(bytes, 0, _header, 36, 4);
            }
        }

        public int DataChunkSize
        {
            get => BitConverter.ToInt32(_header, 40);
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, _header, 40, 4);
            }
        }
    }
}