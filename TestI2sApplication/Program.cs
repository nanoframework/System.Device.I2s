using nanoFramework.Hardware.Esp32;
using System;
using System.Device.I2s;
using System.Diagnostics;
using System.Threading;


Debug.WriteLine("Hello from I2S!");

Configuration.SetPinFunction(0, DeviceFunction.I2S1_WS);
Configuration.SetPinFunction(34, DeviceFunction.I2S1_MDATA_IN);

I2sDevice i2s = new(new I2sConnectionSettings(1) { 
    BitsPerSample = I2sBitsPerSample.Bit16, 
    ChannelFormat = I2sChannelFormat.AllRight, 
    Mode = I2sMode.Master | I2sMode.Rx | I2sMode.Pdm, 
    CommunicationFormat = I2sCommunicationFormat.I2S, 
    SampleRate = 44_100 });

SpanByte buff = new byte[1024];
i2s.Read(buff);

Thread.Sleep(Timeout.Infinite);

