using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darksouls_3_Calculator
{
        public class Weapon
        {
            public string Category { get; set; }
            public string Name { get; set; }
            public int BaseDamage { get; set; }
            public double StrengthScaling { get; set; }
            public double DexterityScaling { get; set; }
            public double IntelligenceScaling { get; set; }
            public double FaithScaling { get; set; }
            public string ImagePath { get; set; }
    }
    
}
