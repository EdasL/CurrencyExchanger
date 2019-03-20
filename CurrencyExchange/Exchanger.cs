using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    public class Exchanger
    {
        public string Currency { get; set; }
        public double ChangingCourseDKK { get; set; }

        public Exchanger(string type, double course)
        {
            this.Currency = type;
            this.ChangingCourseDKK = course;
        }

        public double Exchange(double rate, double ammount)
        {
            //rate - FROM, ChangingCourseDKK - TO
            return (rate / ChangingCourseDKK) * ammount;
        }
    }
}
