﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfIdojarasBongeszo
{
    public class Idojaras
    {
        public int Ev { get; set; }
        public int Honap { get; set; }
        public int Nap { get; set; }
        public int Ora { get; set; }
        public double Homerseklet { get; set; }
        public double Szelsebesseg { get; set; }
        public double Paratartalom { get; set; }

        public Idojaras(string sor,char hatarolo)
        {
            var adatok = sor.Split(hatarolo);
            Ev=Convert.ToInt32(adatok[0]);
            Honap=Convert.ToInt32(adatok[1]);
            Nap=Convert.ToInt32(adatok[2]);
            Ora=Convert.ToInt32(adatok[3]);
            Homerseklet=Convert.ToDouble(adatok[4]);
            Szelsebesseg=Convert.ToDouble(adatok[5]);
            Paratartalom=Convert.ToDouble(adatok[6]);
            
        }
    }
}
