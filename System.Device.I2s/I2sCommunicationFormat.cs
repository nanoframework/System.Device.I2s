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
        StandardI2s = 0X01,
        
        /// <summary>
        /// I2S format LSB, (I2S_COMM_FORMAT_I2S |I2S_COMM_FORMAT_I2S_LSB) correspond to I2S_MSB
        /// </summary>
        Lsb = 0X02,

        /// <summary>
        /// I2S communication MSB alignment standard, data launch at first BCK
        /// </summary>
        Msb = 0X03,

        /// <summary>
        /// PCM Short standard, also known as DSP mode. The period of synchronization signal (WS) is 1 bck cycle.
        /// </summary>
        PcmShort = 0X04,

        /// <summary>
        /// PCM Long standard. The period of synchronization signal (WS) is channel_bit*bck cycles.
        /// </summary>
        PcmLong = 0X0C,

        /// <summary>
        /// standard max
        /// </summary>
        StandMax,                
    }
}
