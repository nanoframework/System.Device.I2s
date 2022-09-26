using System;
using System.Device.I2s;
using System.Diagnostics;
using System.Threading;
using nanoFramework.Hardware.Esp32;

Debug.WriteLine("Hello from nanoFramework!");
Configuration.SetPinFunction(4, DeviceFunction.I2S1_BCK);
Configuration.SetPinFunction(18, DeviceFunction.I2S1_DATA_OUT);
Configuration.SetPinFunction(19, DeviceFunction.I2S1_WS);
Configuration.SetPinFunction(21, DeviceFunction.I2S1_MCK);

var i2s = new I2sDevice(new I2sConnectionSettings(1)
{
    Mode = I2sMode.Master | I2sMode.Tx | I2sMode.Pdm,
    CommunicationFormat = I2sCommunicationFormat.StandardI2s,

    SampleRate = 44_100,
    BitsPerSample = I2sBitsPerSample.Bit16,
    ChannelFormat = I2sChannelFormat.AllRight
});

var buff = new byte[882];
var rnd = new Random(42);
rnd.NextBytes(buff);

SpanByte span = buff;

while (true)
{
    i2s.Write(span);
    Thread.Sleep(10);
}
