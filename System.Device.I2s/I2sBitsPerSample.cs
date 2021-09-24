//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System.Device.I2s
{
    /// <summary>
    /// Defines how bit per sample is synchronized between devices on a I2s bus.
    /// </summary>
    public enum I2sBitsPerSample
    {
        /// <summary>
        /// I2S bits per sample: 8-bits
        /// </summary>
        BIT8 = 8,

        /// <summary>
        /// I2S bits per sample: 16-bits
        /// </summary>
        BIT16 = 16,

        /// <summary>
        /// I2S bits per sample: 24-bits
        /// </summary>
        BIT24 = 24,

        /// <summary>
        /// I2S bits per sample: 32-bits
        /// </summary>
        BIT32 = 32

    }
}