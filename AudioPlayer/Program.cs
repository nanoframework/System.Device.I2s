using System;
using System.Device.I2s;
using System.IO;
using System.Threading;
using AudioPlayer;
using nanoFramework.Hardware.Esp32;

Configuration.SetPinFunction(4, DeviceFunction.I2S1_BCK);
Configuration.SetPinFunction(18, DeviceFunction.I2S1_DATA_OUT);
Configuration.SetPinFunction(15, DeviceFunction.I2S1_WS);
//Configuration.SetPinFunction(21, DeviceFunction.I2S1_MCK);

var beepGenerator = new SinusGenerator();

var i2S = new I2sDevice(new I2sConnectionSettings(1)
{
    Mode = I2sMode.Master | I2sMode.Tx | I2sMode.Pdm,
    CommunicationFormat = I2sCommunicationFormat.StandardI2s,

    SampleRate = beepGenerator.SampleRate,
    BitsPerSample = I2sBitsPerSample.Bit8,
    ChannelFormat = I2sChannelFormat.AllRight
});

var buffer = new SpanByte(new byte[200]);

var msDuration = 200;
var inputStream = new MemoryStream();
beepGenerator.WriteBeep(inputStream, 5000, msDuration);
inputStream.Seek(0, SeekOrigin.Begin);

var len = inputStream.Read(buffer);
while (len > 0)
{
    i2S.Write(buffer);
    Thread.Sleep(10);

    len = inputStream.Read(buffer);
}