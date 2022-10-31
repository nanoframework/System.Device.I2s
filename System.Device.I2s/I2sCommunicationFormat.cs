//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System.Device.I2s
{
    /// <summary>
    /// Defines channels on a I2s bus.
    /// </summary>
    public enum I2sCommunicationFormat
    {
        /// <summary>
        /// I2S communication I2S Philips standard, data launch at second BCK
        /// </summary>
        I2S = 0x01,

        /// <summary>
        /// I2S communication MSB alignment standard, data launch at first BCK
        /// </summary>
        Msb = 0x03,

        /// <summary>
        /// PCM Short standard, also known as DSP mode. The period of synchronization signal (WS) is 1 bck cycle.
        /// </summary>
        PcmShort = 0x04,

        /// <summary>
        /// PCM Long standard. The period of synchronization signal (WS) is channel_bit * bck cycles.
        /// </summary>
        PcmLong = 0x0C,

        /// <summary>
        /// Standard max
        /// </summary>
        Max
    }
}