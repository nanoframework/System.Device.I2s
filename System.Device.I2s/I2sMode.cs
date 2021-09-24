//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System.Device.I2s
{
    /// <summary>
    /// Defines how data is synchronized between devices on a I2s bus.
    /// </summary>
    public enum I2sMode
    {
        /// <summary>
        /// Master mode
        /// </summary>
        MASTER = 1,

        /// <summary>
        /// Slave mode
        /// </summary>
        SLAVE = 2,

        /// <summary>
        /// TX mode
        /// </summary>
        TX = 4,

        /// <summary>
        /// RX mode
        /// </summary>
        RX = 8,

        /// <summary>
        /// Output I2S data to built-in DAC, no matter the data format is 16bit or 32 bit, the DAC module will only take the 8bits from MSB
        /// </summary>
        DAC_BUILT_IN = 16,

        /// <summary>
        /// Input I2S data from built-in ADC, each data can be 12-bit width at most
        /// </summary>
        ADC_BUILT_IN = 32,

        /// <summary>
        /// PDM mode
        /// </summary>
        PDM = 64

    }
}