//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System.Device.I2s
{
    /// <summary>
    ///     Defines channels on a I2s bus.
    /// </summary>
    public enum I2sCommunicationFormat
    {
        /// <summary>
        ///     I2S communication I2S Philips standard, data launch at second BCK
        /// </summary>
        I2S,

        /// <summary>
        ///     I2S communication MSB alignment standard, data launch at first BCK
        /// </summary>
        Msb,

        /// <summary>
        ///     PCM Short standard, also known as DSP mode. The period of synchronization signal (WS) is 1 bck cycle.
        /// </summary>
        PcmShort,

        /// <summary>
        ///     PCM Long standard. The period of synchronization signal (WS) is channel_bit * bck cycles.
        /// </summary>
        PcmLong,

        /// <summary>
        ///     Standard max
        /// </summary>
        Max
    }
}