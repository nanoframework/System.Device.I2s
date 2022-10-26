//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Device.I2s;
using System.Diagnostics;using System.IO;
using System.Threading;
using AudioPlayer;
using nanoFramework.Hardware.Esp32;

Debug.WriteLine("Hello from I2S!");

Configuration.SetPinFunction(0, DeviceFunction.I2S1_WS);
Configuration.SetPinFunction(34, DeviceFunction.I2S1_MDATA_IN);

I2sDevice i2s = new(new I2sConnectionSettings(1)
{
    BitsPerSample = I2sBitsPerSample.Bit8,
    ChannelFormat = I2sChannelFormat.OnlyLeft,
    Mode = I2sMode.Master | I2sMode.Rx | I2sMode.Pdm,
    CommunicationFormat = I2sCommunicationFormat.I2S,
    SampleRate = 8_000
});

// should be one second of sound data:
SpanByte buff = new byte[8000];
i2s.Read(buff);
i2s.Dispose();

var header = new WavFileHeader
{
    AudioFormat = 1,
    SampleRate = 8000,
    BitsPerSample = 8,
    BytesPerSampleFrame = 1,
    BytesPerSecond = 8000,
    DataChunkSize = 8000,
    FormatChunkSize = 16,
    NumberOfChannels = 1,
    FileSize = 36 + 8000
};

var outputFile = new FileStream("D:\\output.wav", FileMode.CreateNew, FileAccess.ReadWrite);
var headerData = header.GetHeaderData();
outputFile.Write(headerData, 0, headerData.Length);

var buffer = buff.ToArray();
outputFile.Write(buffer, 0, buffer.Length);

outputFile.Flush();
outputFile.Close();
outputFile.Dispose();

Thread.Sleep(Timeout.Infinite);