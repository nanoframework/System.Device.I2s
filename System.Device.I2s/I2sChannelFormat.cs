//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System.Device.I2s
{
    /// <summary>
    ///     Defines channels on a I2s bus.
    /// </summary>
    public enum I2sChannelFormat
    {
        /// <summary>
        ///     I2S_CHANNEL_FMT_RIGHT_LEFT
        /// </summary>
        RightLeft = 0x00,

        /// <summary>
        ///     I2S_CHANNEL_FMT_ALL_RIGHT
        /// </summary>
        AllRight,

        /// <summary>
        ///     I2S_CHANNEL_FMT_ALL_LEFT
        /// </summary>
        AllLeft,

        /// <summary>
        ///     I2S_CHANNEL_FMT_ONLY_RIGHT
        /// </summary>
        OnlyRight,

        /// <summary>
        ///     I2S_CHANNEL_FMT_ONLY_LEFT
        /// </summary>
        OnlyLeft
    }
}