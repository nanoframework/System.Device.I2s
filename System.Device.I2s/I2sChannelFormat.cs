//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System.Device.I2s
{
    /// <summary>
    /// Defines channels on a I2s bus.
    /// </summary>
    public enum I2sChannelFormat
    {
        /// <summary>
        /// I2S_CHANNEL_FMT_RIGHT_LEFT
        /// </summary>
        I2S_CHANNEL_FMT_RIGHT_LEFT = 0x00,

        /// <summary>
        /// I2S_CHANNEL_FMT_ALL_RIGHT
        /// </summary>
        I2S_CHANNEL_FMT_ALL_RIGHT,

        /// <summary>
        /// I2S_CHANNEL_FMT_ALL_LEFT
        /// </summary>
        I2S_CHANNEL_FMT_ALL_LEFT,

        /// <summary>
        /// I2S_CHANNEL_FMT_ONLY_RIGHT
        /// </summary>
        I2S_CHANNEL_FMT_ONLY_RIGHT,

        /// <summary>
        /// I2S_CHANNEL_FMT_ONLY_LEFT
        /// </summary>
        I2S_CHANNEL_FMT_ONLY_LEFT,
    }
}