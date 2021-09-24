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
        STAND_I2S = 0X01,

        /// <summary>
        /// I2S communication MSB alignment standard, data launch at first BCK
        /// </summary>
        STAND_MSB = 0X03,

        /// <summary>
        /// PCM Short standard, also known as DSP mode. The period of synchronization signal (WS) is 1 bck cycle.
        /// </summary>
        STAND_PCM_SHORT = 0X04,

        /// <summary>
        /// PCM Long standard. The period of synchronization signal (WS) is channel_bit*bck cycles.
        /// </summary>
        STAND_PCM_LONG = 0X0C,

        /// <summary>
        /// standard max
        /// </summary>
        STAND_MAX,

        /// <summary>
        /// I2S communication format I2S, correspond to STAND_I2S
        /// </summary>
        I2S = 0X01,
        
        /// <summary>
        /// I2S format MSB, (I2S_COMM_FORMAT_I2S |I2S_COMM_FORMAT_I2S_MSB) correspond to
        /// </summary>
        I2S_MSB = 0X01,
        
        /// <summary>
        /// I2S format LSB, (I2S_COMM_FORMAT_I2S |I2S_COMM_FORMAT_I2S_LSB) correspond to I2S_MSB
        /// </summary>
        I2S_LSB = 0X02,

        /// <summary>
        /// I2S communication format PCM, correspond to PCM_SHORT
        /// </summary>
        PCM = 0X04,

        /// <summary>
        /// I2S communication format PCM, correspond to STAND_PCM_SHORT
        /// </summary>
        PCM_SHORT = 0X04,

        /// <summary>
        /// I2S communication format PCM, correspond to STAND_PCM_SHORT
        /// </summary>
        PCM_LONG = 0X08
    }
}