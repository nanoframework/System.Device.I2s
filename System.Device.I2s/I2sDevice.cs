//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Device.I2s
{
    /// <summary>
    /// The communications channel to a device on an I2s bus.
    /// </summary>
    public class I2sDevice : IDisposable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _disposed;

        private readonly I2sConnectionSettings _connectionSettings;

        /// <summary>
        /// Create an I2s Device
        /// </summary>
        /// <param name="settings">Connection settings</param>
        public I2sDevice(I2sConnectionSettings settings)
        {
            _connectionSettings = settings;

            // call native init to allow HAL/PAL inits related with I2s hardware
            NativeInit();
        }

        /// <summary>
        /// The connection settings of a device on an I2s bus. The connection settings are immutable after the device is
        /// created
        /// so the object returned will be a clone of the settings object.
        /// </summary>
        public I2sConnectionSettings ConnectionSettings => _connectionSettings;

        /// <summary>
        /// Reads data from the I2s device.
        /// </summary>
        /// <param name="buffer">
        /// The buffer to read the data from the I2s device.
        /// The length of the buffer determines how much data to read from the I2s device.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Read(SpanByte buffer);

        /// <summary>
        /// Writes data to the I2s device.
        /// </summary>
        /// <param name="buffer">
        /// The buffer that contains the data to be written to the I2s device.
        /// The data should not include the I2s device address.
        /// </param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Write(SpanByte buffer);

        /// <summary>
        /// Creates a communications channel to a device on an I2s bus running on the current platform
        /// </summary>
        /// <param name="settings">The connection settings of a device on an I2s bus.</param>
        /// <returns>A communications channel to a device on an I2s bus</returns>
        public static I2sDevice Create(I2sConnectionSettings settings)
        {
            return new I2sDevice(settings);
        }

        #region IDisposable Support

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                NativeDispose();

                _disposed = true;
            }
        }

#pragma warning disable 1591
        ~I2sDevice()
        {
            Dispose(false);
        }

        /// <summary>
        /// <inheritdoc cref="IDisposable.Dispose" />
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                Dispose(true);

                GC.SuppressFinalize(this);
            }
        }

        #endregion

        #region external calls to native implementations

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeInit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeDispose();

        #endregion
    }
}