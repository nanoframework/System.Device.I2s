using System;
using System.Device.I2s;
using System.Diagnostics;
using System.IO;
using nanoFramework.Hardware.Esp32;

namespace AudioPlayer
{
    public class I2sWavPlayer : IDisposable
    {
        public enum Bus
        {
            One = 1,
            Two = 2
        }

        private readonly I2sDevice _i2S;
        private readonly FileStream _stream;

        public I2sWavPlayer(Bus bus, string audioFile, int bckPin = 32, int dataPin = 33, int wsPin = 25)
        {
            switch (bus)
            {
                case Bus.One:
                    // I2S Audio device:
                    Configuration.SetPinFunction(bckPin, DeviceFunction.I2S1_BCK);
                    Configuration.SetPinFunction(dataPin, DeviceFunction.I2S1_DATA_OUT);
                    Configuration.SetPinFunction(wsPin, DeviceFunction.I2S1_WS);
                    //Configuration.SetPinFunction(5, DeviceFunction.I2S1_MCK);
                    break;
                case Bus.Two:
                    // I2S Audio device:
                    Configuration.SetPinFunction(bckPin, DeviceFunction.I2S2_BCK);
                    Configuration.SetPinFunction(dataPin, DeviceFunction.I2S2_DATA_OUT);
                    Configuration.SetPinFunction(wsPin, DeviceFunction.I2S2_WS);
                    //Configuration.SetPinFunction(5, DeviceFunction.I2S2_MCK);
                    break;
            }

            _stream = new FileStream(audioFile, FileMode.Open, FileAccess.Read);

            var header = new byte[44];
            var len = _stream.Read(header, 0, header.Length);
            if (len != 44) throw new IOException("Not enough bytes in the wav file header.");

            var headerParser = new WavFileHeader(header);

            _i2S = new I2sDevice(new I2sConnectionSettings(1)
            {
                Mode = I2sMode.Master | I2sMode.Tx,
                CommunicationFormat = I2sCommunicationFormat.I2S,

                SampleRate = headerParser.SampleRate,
                BitsPerSample = ToBitsPerSample(headerParser.BitsPerSample),
                ChannelFormat = ToChannelFormat(headerParser.NumberOfChannels),
                BufferSize = 40000
            });
        }

        public void Dispose()
        {
            _i2S.Dispose();

            _stream.Close();
            _stream.Dispose();
        }

        public void Play()
        {
            _stream.Seek(44, SeekOrigin.Begin);

            var buffer = new byte[10000];
            try
            {
                while (true)
                {
                    var len = _stream.Read(buffer, 0, buffer.Length);
                    if (len == 0)
                        // end of file, quit:
                        break;

                    var spanBytes = new SpanByte(buffer, 0, len);
                    _i2S.Write(spanBytes);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception happened, but why? {e.Message}");
            }
        }

        private static I2sChannelFormat ToChannelFormat(short channels)
        {
            return channels switch
            {
                1 => I2sChannelFormat.OnlyLeft,
                2 => I2sChannelFormat.RightLeft,
                _ => throw new ArgumentOutOfRangeException("channels", "Only supports either Mono or Stereo WAV files.")
            };
        }

        private static I2sBitsPerSample ToBitsPerSample(short bitsPerSample)
        {
            return bitsPerSample switch
            {
                8 => I2sBitsPerSample.Bit8,
                16 => I2sBitsPerSample.Bit16,
                24 => I2sBitsPerSample.Bit24,
                32 => I2sBitsPerSample.Bit32,
                _ => throw new ArgumentOutOfRangeException("bitsPerSample",
                    "Only 8, 16, 24 or 32 bits per sample are supported.")
            };
        }
    }
}