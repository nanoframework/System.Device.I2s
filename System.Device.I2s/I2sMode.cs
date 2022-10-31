//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System.Device.I2s
{
    /// <summary>
    /// Defines how data is synchronized between devices on a I2s bus.
    /// </summary>
    [Flags]
    public enum I2sMode
    {
        /// <summary>
        /// Master mode
        /// </summary>
        Master = 1 << 0,

        /// <summary>
        /// Slave mode
        /// </summary>
        Slave = 1 << 1,

        /// <summary>
        /// TX mode
        /// </summary>
        Tx = 1 << 2,

        /// <summary>
        /// RX mode
        /// </summary>
        Rx = 1 << 3,

        /// <summary>
        /// Output I2S data to built-in DAC, no matter the data format is 16bit or 32 bit, the DAC module will only take the
        /// 8bits from MSB
        /// </summary>
        DacBuiltIn = 1 << 4,

        /// <summary>
        /// Input I2S data from built-in ADC, each data can be 12-bit width at most
        /// </summary>
        AdcBuiltIn = 1 << 5,

        /// <summary>
        /// PDM mode
        /// </summary>
        Pdm = 1 << 6
    }
}