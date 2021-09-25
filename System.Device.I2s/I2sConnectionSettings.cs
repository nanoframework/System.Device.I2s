//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace System.Device.I2s
{
    /// <summary>
    /// The connection settings of a device on a I2Sbus.
    /// </summary>
    public sealed class I2sConnectionSettings
    {
        private int _busId = 1;

        private int _sampleRate = 44_100;

        private I2sMode _i2sMode = I2sMode.Pdm;

        private I2sBitsPerSample _i2sBitsPerSample = I2sBitsPerSample.Bit16;

        private I2sChannelFormat _i2sChannelFormat = I2sChannelFormat.RightLeft;

        private I2sCommunicationFormat _i2sConnectionFormat = I2sCommunicationFormat.StandardI2s;

        /// <summary>
        /// Initializes new instance of I2sConnectionSettings.
        /// </summary>

        private I2sConnectionSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="I2sConnectionSettings"/> class.
        /// </summary>
        /// <param name="busId">The bus ID the device is connected to.</param>
        public I2sConnectionSettings(int busId)
        {
            BusId = busId;
        }

        internal I2sConnectionSettings(I2sConnectionSettings other)
        {
            BusId = other.BusId;
            Mode = other.Mode;
            SampleRate = other.SampleRate;
            CommunicationFormat = other.CommunicationFormat;
            ChannelFormat = other.ChannelFormat;
            BitsPerSample = other.BitsPerSample;
        }

        /// <summary>
        /// The bus ID the device is connected to.
        /// </summary>
        public int BusId
        {
            get => _busId;

            set
            {
                _busId = value;
            }
        }

        /// <summary>
        /// The I2Smode being used.
        /// </summary>
        public I2sMode Mode
        {
            get => _i2sMode;

            set
            {
                _i2sMode = value;
            }
        }

        /// <summary>
        /// Bits per sample
        /// </summary>
        public I2sBitsPerSample BitsPerSample
        {
            get => _i2sBitsPerSample;

            set
            {
                _i2sBitsPerSample = value;
            }
        }

        /// <summary>
        /// I2S Channel Format
        /// </summary>
        public I2sChannelFormat ChannelFormat
        {
            get => _i2sChannelFormat;

            set
            {
                _i2sChannelFormat = value;
            }
        }

        /// <summary>
        /// Specifies communication format on the I2Sbus.
        /// </summary>
        public I2sCommunicationFormat CommunicationFormat
        {
            get => _i2sConnectionFormat;

            set
            {
                _i2sConnectionFormat = value;
            }
        }

        /// <summary>
        /// Sample Rate.
        /// </summary>
        public int SampleRate
        {
            get => _sampleRate;

            set
            {
                _sampleRate = value;
            }
        }
    }
}