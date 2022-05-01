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
using Xamarin.Essentials;

namespace SpotV019.Sensores
{
    public class Giroscopio
    {
        private double[] vel_XYZ;

        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.Game;

        public Giroscopio()
        {

            for (int i = 0; i < 3; i++)
            {
                vel_XYZ[i] = 0;
            }
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
        }

        void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;

            vel_XYZ[0] = Convert.ToDouble(data.AngularVelocity.X);
            vel_XYZ[1] = Convert.ToDouble(data.AngularVelocity.X);
            vel_XYZ[2] = Convert.ToDouble(data.AngularVelocity.X);
        }

        public void ToggleGyroscope()
        {
            try
            {
                if (Gyroscope.IsMonitoring)
                    Gyroscope.Stop();
                else
                    Gyroscope.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine("No soportado en el dispositivo");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepcion no controlada");
            }
        }
        public double[] getData()
        {
            double[] data = new double[3];
            data = vel_XYZ;
           
            return data;
        }
    }
}