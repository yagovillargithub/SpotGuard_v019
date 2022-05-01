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
    public class Acelerometro
    {


        private double[] acl_XYZ;
        private double[] acl_init;
        private Boolean initialiced;



        SensorSpeed speed = SensorSpeed.Fastest;

        public Acelerometro()
        {
            acl_XYZ = new double[3];
            acl_init = new double[3];

            for (int i = 0; i < 3; i++)
            {
                acl_XYZ[i] = 0;
                acl_init[i] = 0;
            }

            initialiced = false;

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;


        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            if (initialiced)
            {
                acl_XYZ[0] = Convert.ToDouble(data.Acceleration.X) - acl_init[0];
                acl_XYZ[1] = Convert.ToDouble(data.Acceleration.Z) - acl_init[1];
                acl_XYZ[2] = Convert.ToDouble(data.Acceleration.Y) - acl_init[2];

            }
            else
            {
                acl_init[0] = Convert.ToDouble(data.Acceleration.X);
                acl_init[1] = Convert.ToDouble(data.Acceleration.Z);
                acl_init[2] = Convert.ToDouble(data.Acceleration.Y);
                initialiced = true;
            }
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {

            }
            catch (Exception ex)
            {

            }
        }

        public double[] getData()
        {
            return acl_XYZ;
        }
    }
}