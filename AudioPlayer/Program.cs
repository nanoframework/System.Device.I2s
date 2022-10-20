using System;
using System.Device.I2s;
using System.IO;
using AudioPlayer;
using nanoFramework.Hardware.Esp32;

// I2S Audio device:
Configuration.SetPinFunction(32, DeviceFunction.I2S1_BCK);
Configuration.SetPinFunction(33, DeviceFunction.I2S1_DATA_OUT);
Configuration.SetPinFunction(25, DeviceFunction.I2S1_WS);
//Configuration.SetPinFunction(15, DeviceFunction.I2S1_MCK);

// SD Card:
uint cs = 5;
Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
Configuration.SetPinFunction(18, DeviceFunction.SPI1_CLOCK);
Configuration.SetPinFunction(19, DeviceFunction.SPI1_MISO);
var audioFilesSource = new AudioFilesSource(1, cs);

uint sampleRate = 16000;
var bufferSize = 10000;

var i2S = new I2sDevice(new I2sConnectionSettings(1)
{
    Mode = I2sMode.Master | I2sMode.Tx,
    CommunicationFormat = I2sCommunicationFormat.StandardI2s,

    SampleRate = (int)sampleRate,
    BitsPerSample = I2sBitsPerSample.Bit16,
    ChannelFormat = I2sChannelFormat.RightLeft,
    BufferSize = bufferSize
});

//var sinus = new SinusGenerator((int)sampleRate, 16);
//using (var memoryStream = new MemoryStream())
//{
//    sinus.WriteBeep(memoryStream, 637, 500);
//    memoryStream.Seek(0, SeekOrigin.Begin);

//    var buffer = new SpanByte(new byte[10000]);
//    var len = memoryStream.Read(buffer);
//    while (len > 0)
//    {
//        i2S.Write(buffer);
//        len = memoryStream.Read(buffer);
//    }
//}

if (audioFilesSource.Mount())
{
    var audioFiles = audioFilesSource.ScanForAudioFiles();
    if (audioFiles.Count == 0) return;

    var audioFile = (string)audioFiles[1];
    using (var file = new FileStream(audioFile, FileMode.Open, FileAccess.Read))
    {
        // skip headers:
        file.Seek(44, SeekOrigin.Begin);

        var buffer = new byte[bufferSize];
        var len = file.Read(buffer, 0, buffer.Length);
        while (len > 0)
        {
            var spanBytes = new SpanByte(buffer, 0, len);
            i2S.Write(spanBytes);
            len = file.Read(buffer, 0, buffer.Length);
        }

        file.Close();
        file.Dispose();
    }
}

