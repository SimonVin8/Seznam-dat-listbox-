using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seznam_dat__listbox_.Models
{
    public class car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model} ({Power}HP)";
        }
    }
}
