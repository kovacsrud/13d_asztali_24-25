﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKutyakDb.model
{
    public class Rendeles
    {
        public int Id { get; set; }
        public int FajtaId { get; set; }
        public int NevId { get; set; }
        public string FajtaNev { get; set; }
        public string KutyaNev { get; set; }
        public int Eletkor { get; set; }
        public string UtolsoEll { get; set; }
    }
}
