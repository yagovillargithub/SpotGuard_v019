using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using XBeeLibrary.Core.IO;
using XBeeLibrary.Xamarin;

namespace SpotV019.Elementos
{
    public class Intermitente
    {
 
        private string id;
        private static string BLE_MAC_ADDR = "13:A2:00:41:EC:BB:77";
        private static string BLE_PASSWORD = "12345";
        private bool estado;
        private XBeeBLEDevice xBee = null;
      
       
        public Intermitente(string name)
        {
            xBee = new XBeeBLEDevice(BLE_MAC_ADDR, BLE_PASSWORD);
            id = name;

            xBee.Open(); // Configuracion inicial
            xBee.SetPANID(new byte[] { (byte)0xFF, (byte)0xFF }); //Por defecto FFFF
            xBee.ApplyChanges();
            xBee.WriteChanges();
            xBee.SendSerialData(Encoding.UTF8.GetBytes("Primera conexión al dispositivo"));
            xBee.Close();
        }

        public void AplicarPatron(string patron)
        {
            switch (patron)
            {
                case "Giro":
                    xBee.Open();
                    for (int i = 0; i < 15; i++)
                    {
                        Thread.Sleep(500);
                        xBee.SetIOConfiguration(IOLine.DIO0_AD1, IOMode.DIGITAL_OUT_HIGH);
                        Thread.Sleep(500);
                        xBee.SetIOConfiguration(IOLine.DIO0_AD1, IOMode.DISABLED);
                    }
                    
                    xBee.Close();
                    break;

                case "Fijo":
                    xBee.Open();
                    xBee.SetIOConfiguration(IOLine.DIO0_AD1, IOMode.DIGITAL_OUT_HIGH);
                    Thread.Sleep(5000);
                    xBee.SetIOConfiguration(IOLine.DIO0_AD1, IOMode.DISABLED);
                    xBee.Close();

                    break;

                case "Warning":
                    xBee.Open();
                    for (int i = 0; i < 180; i++)
                    {
                        Thread.Sleep(80);
                        xBee.SetIOConfiguration(IOLine.DIO0_AD1, IOMode.DIGITAL_OUT_HIGH);
                        Thread.Sleep(80);
                        xBee.SetIOConfiguration(IOLine.DIO0_AD1, IOMode.DISABLED);
                    }
                    xBee.Close();
                    break;
                default:
                if (xBee.IsOpen)
                xBee.Close();
                break;

            }
        }
    }
}