using System;
using System.IO;

namespace AudioPlayer
{
    public class SinusGenerator
    {
        private const int FormatChunkSize = 16;
        private const short FormatType = 1;
        private const int HeaderSize = 8;
        private const double Tau = 2 * Math.PI;
        private const int WaveSize = 4;
        private readonly short _bitsPerSample;
        private readonly int _bytesPerSecond;
        private readonly short _frameSize;

        private readonly short _tracks;

        public SinusGenerator(int sampleRate = 16000, short bitsPerSample = 8, short tracks = 1)
        {
            SampleRate = sampleRate;
            _bitsPerSample = bitsPerSample;
            _tracks = tracks;
            _frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            _bytesPerSecond = SampleRate * _frameSize;
        }

        public int SampleRate { get; }

        public int CalculateFileSize(int msDuration)
        {
            var samples = (int)((double)SampleRate * msDuration / 1000);
            var dataChunkSize = samples * _frameSize;
            var fileSize = WaveSize + HeaderSize + FormatChunkSize + HeaderSize + dataChunkSize;

            return fileSize;
        }

        public void WriteBeep(Stream target, ushort frequency, int msDuration, ushort volume = 16383)
        {
            var writer = new BinaryWriter(target);

            var samples = (int)((double)SampleRate * msDuration / 1000);
            var dataChunkSize = samples * _frameSize;
            var fileSize = CalculateFileSize(msDuration);

            writer.Write(0x46464952); // "RIFF"
            writer.Write(fileSize);
            writer.Write(0x45564157); // "WAVE"
            writer.Write(0x20746D66); // "fmt "
            writer.Write(FormatChunkSize);
            writer.Write(FormatType);
            writer.Write(_tracks);
            writer.Write(SampleRate);
            writer.Write(_bytesPerSecond);
            writer.Write(_frameSize);
            writer.Write(_bitsPerSample);
            writer.Write(0x61746164); // "data"
            writer.Write(dataChunkSize);
            {
                var theta = frequency * Tau / SampleRate;

                // 'volume' is UInt16 (0 .. Uint16.MaxValue / 65 535)
                // 'amp' is Int16.MaxValue (0 .. 32 767)
                // amp = volume / 2
                double amp = volume >> 2;
                for (var step = 0; step < samples; step++)
                {
                    var s = (short)(amp * Math.Sin(theta * step));
                    writer.Write(s);
                }
            }

            writer.Flush();
        }
    }
}