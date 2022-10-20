using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using nanoFramework.System.IO.FileSystem;

namespace AudioPlayer
{
    public class AudioFilesSource
    {
        private readonly SDCard mycard;

        public AudioFilesSource(uint spiBus, uint chipSelectPin)
        {
            // Initialise an instance of SDCard using constructor specific to your board/adapter
            // Boards with SDCard on SPI bus, SPI 1 default , no card detect
            mycard = new SDCard(new SDCard.SDCardSpiParameters { spiBus = spiBus, chipSelectPin = chipSelectPin });
            Debug.WriteLine("SDcard inited");

            // Enable Storage events if you have Card detect on adapter 
            StorageEventManager.RemovableDeviceInserted += StorageEventManager_RemovableDeviceInserted;
            StorageEventManager.RemovableDeviceRemoved += StorageEventManager_RemovableDeviceRemoved;
        }

        public void UnMountIfMounted()
        {
            if (mycard.IsMounted) mycard.Unmount();
        }

        public bool Mount()
        {
            try
            {
                mycard.Mount();
                Debug.WriteLine("Card Mounted");

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Card failed to mount : {ex.Message}");
                Debug.WriteLine($"IsMounted {mycard.IsMounted}");
            }

            return false;
        }

        public ArrayList ScanForAudioFiles()
        {
            if (!mycard.IsMounted)
                // Try to mount card
                Mount();

            var files = Directory.GetFiles("D:\\");
            var hits = new ArrayList();

            foreach (var file in files)
                if (file.EndsWith(".wav"))
                    hits.Add(file);

            return hits;
        }

        private void StorageEventManager_RemovableDeviceRemoved(object sender, RemovableDeviceEventArgs e)
        {
            Debug.WriteLine($"Card removed - Event:{e.Event} Path:{e.Path}");
        }

        private void StorageEventManager_RemovableDeviceInserted(object sender, RemovableDeviceEventArgs e)
        {
            Debug.WriteLine($"Card inserted - Event:{e.Event} Path:{e.Path}");

            // Card just inserted lets try to mount it
            Mount();
        }
    }
}