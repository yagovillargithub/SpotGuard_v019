using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SpotV019.Sensores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotV019.Actuadores
{
    public class Indicador
    {
        Giroscopio gyro_snr;
        Acelerometro acmtr_snr;
        public Indicador()
        {
            gyro_snr = new Giroscopio();
            gyro_snr.ToggleGyroscope();
            acmtr_snr = new Acelerometro();
            acmtr_snr.ToggleAccelerometer();
        }

        public void printSensorsStatus()
        {
            if (gyro_snr.getData()[0] != 0 || gyro_snr.getData()[1] != 0 || gyro_snr.getData()[2] != 0)
            {
                System.Console.WriteLine("[Gyroscopio]: X:" + gyro_snr.getData()[0] + " Y: " + gyro_snr.getData()[1] + " Z: " + gyro_snr.getData()[2]);
            }

            if (acmtr_snr.getData()[0] != 0 || acmtr_snr.getData()[1] != 0 || acmtr_snr.getData()[2] != 0)
            {
                System.Console.WriteLine("[Acelerometro]: X:" + acmtr_snr.getData()[0] + " Y: " + acmtr_snr.getData()[1] + " Z: " + acmtr_snr.getData()[2]);
            }
        }

        public string GetSensorsStatus()
        {
            return "[Gyroscopio]: X:" + gyro_snr.getData()[0] + " Y: " + gyro_snr.getData()[1] + " Z: " + gyro_snr.getData()[2] + "\n" + "[Acelerometro]: X:" + acmtr_snr.getData()[0] + " Y: " + acmtr_snr.getData()[1] + " Z: " + acmtr_snr.getData()[2];
        }

        public double[] getSensorsValue()
        {
            double[] values = new double[6];
            values[0] = gyro_snr.getData()[0];
            values[1] = gyro_snr.getData()[1];
            values[2] = gyro_snr.getData()[2];
            values[3] = acmtr_snr.getData()[3];
            values[4] = acmtr_snr.getData()[4];
            values[5] = acmtr_snr.getData()[5];

            return values;
        }

    }
}