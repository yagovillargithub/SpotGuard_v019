using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SpotV019.Elementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpotV019.Actuadores
{
    public class Activador
    {
        private Indicador indicador;
        private Intermitente izquierdo;
        private Intermitente derecho;
        private Intermitente central;

        public Activador()
        {
            indicador = new Indicador();
            izquierdo = new Intermitente("I");
            derecho = new Intermitente("D");
            central = new Intermitente("C");
        }

        public void IniciarCarrera()
        {
            double[] data = new Double[6];
            Console.WriteLine("Carrera");
            
            while (true)
            {
                data = indicador.getSensorsValue();
                if (data[1] > 1.5) //Dcha
                {
                    derecho.AplicarPatron("Giro");
                }
                else if (data[1] < 1.5) //Izda
                {
                    izquierdo.AplicarPatron("Giro");
                }
                if (data[4] > 3.5) //Fren
                {
                    central.AplicarPatron("Warning");
                }
            }
        }
    }
}