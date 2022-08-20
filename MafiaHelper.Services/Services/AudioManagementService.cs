using MafiaHelper.Services.Services;
using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MafiaHelper.Services
{
    public static class AudioManagementService
    {
        public static void Mute()
        {
            try
            {

                var audioDevices = GetAllActiveSoundDevices();

                //Loop through all devices
                foreach (var device in audioDevices)
                {
                    try
                    {
                        //Mute it
                        device.AudioEndpointVolume.Mute = true;
                    }
                    catch (Exception ex)
                    {
                        //Do something with exception when an audio endpoint could not be muted
                        LoggService.Log(ex, $"deviceName: {device.FriendlyName} deviceID: {device.ID}");
                    }
                }
            }
            catch (Exception ex)
            {
                //When something happend that prevent us to iterate through the devices
                LoggService.Log(ex);
            }
        }

        public static void UnMute()
        {
            try
            {
                var audioDevices = GetAllActiveSoundDevices();

                //Loop through all devices
                foreach (MMDevice device in audioDevices)
                {
                    try
                    {
                      
                        //UnMute it
                        device.AudioEndpointVolume.Mute = false;
                    }
                    catch (Exception ex)
                    {
                        //When something with exception when an audio endpoint could not be muted
                        LoggService.Log(ex, $"deviceName: {device.FriendlyName} deviceID: {device.ID}");
                    }
                }
            }
            catch (Exception ex)
            {
                //When something happend that prevent us to iterate through the devices
                LoggService.Log(ex);
            }
        }

        private static MMDeviceCollection GetAllActiveSoundDevices()
        {
            //Instantiate an Enumerator to find audio devices
            var deviceEnumerator = new MMDeviceEnumerator();

            //Get all the devices, no matter what condition or status
            var audioDevices = deviceEnumerator.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.All, NAudio.CoreAudioApi.DeviceState.Active);

            return audioDevices;
        }
    }
}
