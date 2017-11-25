using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication.ViewModel;

namespace WpfAppLab5
{
    public class MainViewModel
    {
        public ObservableCollection<Device> Devices { get; set; }
        public Device SelectedDevice { get; set; }
        
        public ICommand DisableDevice { get; set; }
        public ICommand EnableDevice { get; set; }

        public MainViewModel()
        {
            Devices = new ObservableCollection<Device>();

            DisableDevice = new Command(arg => DisableDeviceMethod());
            EnableDevice = new Command(arg => EnableDeviceMethod());

            AddAllDevices();
        }
        
        private void AddAllDevices()
        {
            int exceptionNumbers = 0;
            using (var searcher = new ManagementObjectSearcher("Select * from Win32_PnPEntity"))
            {
                ManagementObjectCollection objectCollection = searcher.Get();

                foreach (ManagementObject managementObject in objectCollection)
                {
                    ManagementBaseObject driverInformation = null;
                    foreach (var item in managementObject.GetRelated("Win32_SystemDriver"))
                        driverInformation = item;

                    try
                    {
                        object[] hardwareIdObjects = ((object[])managementObject["HardWareID"]);

                        Devices.Add(new Device
                        {
                            ClassGuid = managementObject["ClassGuid"].ToString(),
                            HardWareID = hardwareIdObjects[0].ToString(),
                            DeviceID = managementObject["DeviceID"].ToString(),
                            Manufacturer = managementObject["Manufacturer"].ToString(),
                            Name = managementObject["Name"].ToString(),
                            Description = driverInformation["Description"].ToString(),
                            PathName = driverInformation["PathName"].ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        //у некоторый устройств невозможно получить параметры
                        exceptionNumbers++;
                    }
                }
            }

            MessageBox.Show(String.Format("У {0} устройств не получилось достать некоторые параметры.", exceptionNumbers));

        }

        private void DisableDeviceMethod()
        {
            using (var searcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
            {
                ManagementObjectCollection objectCollection = searcher.Get();

                foreach (ManagementObject managementObject in objectCollection)
                {
                    if (managementObject["DeviceID"].ToString() == SelectedDevice.DeviceID)
                    {
                        object[] myarr = { new bool() };
                        try
                        {
                            managementObject.InvokeMethod("Disable", myarr);
                            MessageBox.Show("Устройство успешно отключено.", "Confirmation", MessageBoxButton.OK);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Не удалось отключить устройство.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        break;
                    }
                }
            }

        }

        private void EnableDeviceMethod()
        {
            using (var searcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
            {
                ManagementObjectCollection objectCollection = searcher.Get();

                foreach (ManagementObject managementObject in objectCollection)
                {
                    if (managementObject["DeviceID"].ToString() == SelectedDevice.DeviceID)
                    {
                        object[] myarr = { new bool() };
                        try
                        {
                            managementObject.InvokeMethod("Enable", myarr);
                            MessageBox.Show("Устройство успешно включено.", "Confirmation", MessageBoxButton.OK);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Не удалось включить устройство.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        break;
                    }
                }
            }
        }
    }
}
