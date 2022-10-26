//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.Diagnostics;
using System.Threading;
using AudioPlayer;
using nanoFramework.Hardware.Esp32;
using nanoFramework.System.IO.FileSystem;

// Beware: if you stop debugging while the file is open,
// re-plugin the USB cable to the MCU will re-start the application
// therefore might re-open the wav file again and also "lock" it again.
// thus we explicitly wait until Debugger is attached, so that we can "reset"
while (!Debugger.IsAttached)
{
    Thread.Sleep(500);
}

// SD Card:
uint cs = 5;
Configuration.SetPinFunction(23, DeviceFunction.SPI1_MOSI);
Configuration.SetPinFunction(18, DeviceFunction.SPI1_CLOCK);
Configuration.SetPinFunction(19, DeviceFunction.SPI1_MISO);

var sdCard = new SDCard(new SDCard.SDCardSpiParameters { spiBus = 1, chipSelectPin = cs });
sdCard.Mount();

// download the following file and copy it to an microSD card on the root (or adapt the audioFile correspondingly)
// convert it first to a wav file. Or use the one from the repository.
// Tested with 16 bits, 16 kHz, Mono with a MAX98357A breakout board.
// source: https://www.videvo.net/royalty-free-music-track/variation/232917/
var audioFile = "D:\\Variation-CLJ013901.wav";
var player = new I2sWavPlayer(I2sWavPlayer.Bus.One, audioFile);
player.Play();
player.Dispose();

sdCard.Unmount();
sdCard.Dispose();