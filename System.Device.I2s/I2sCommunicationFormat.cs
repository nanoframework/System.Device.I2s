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
        StandardI2s,

        /// <summary>
        /// Standard I2S with LSB
        /// </summary>
        StandardI2sLsb,

        /// <summary>
        /// Standard I2S with MSB
        /// </summary>
        StandardI2sMsb,

        /// <summary>
        /// Standard I2S with PCM
        /// </summary>
        StandardI2sPcm,

        /// <summary>
        /// PCM Short standard, also known as DSP mode. The period of synchronization signal (WS) is 1 bck cycle.
        /// </summary>
        PcmShort,

        /// <summary>
        /// PCM Long standard. The period of synchronization signal (WS) is channel_bit*bck cycles.
        /// </summary>
        PcmLong,
    }
}
