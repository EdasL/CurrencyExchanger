using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CurrencyExchange
{
    public class Exchange
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Exchange <currency pair> <ammount to exchange>");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            else if (!(RegexLib.IsCurrencyValid(args[0]) && RegexLib.IsNumberValid(args[1])))
            {
                Console.WriteLine("<currency pair> for example: EUR/DKK, <ammount to exchange> : number, you used: {0} {1}", args[0], args[1]);
                Console.ReadKey();
                System.Environment.Exit(1);
            }
       

            //Given data
            string[] lines = { "EUR 743.94", "USD 663.11", "GBP 852.85", "SEK 76.1", "NOK 78.4", "CHF 683.58", "JPY 5.9740" }; 

            List<Exchanger> exchangers = new List<Exchanger>();
            foreach(string line in lines)
            {
                string[] currency = line.Split(' ');
                Exchanger exchanger = new Exchanger(currency[0], Convert.ToDouble(currency[1]));
                exchangers.Add(exchanger);
            }
            exchangers.Add(new Exchanger("DKK", 100));
            
            //request[0]- FROM, request[1]- TO
            string[] request = args[0].Split('/');
            var result = ExchangeCurrencies(exchangers, request, Convert.ToDouble(args[1]));
            if (result != -1)
            {
                Console.Write("Succes: {0}", result);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Error: currency pair should containt one of the following currencies - EUR, USD, GBP, SEK, NOK, CHF, JPY, DKK, you used: {0}", args[1]);
                Console.ReadKey();
            }
            
        }
        public static double ExchangeCurrencies(List<Exchanger> exchangers, string[] request, double ammount )
        {
            if (exchangers.Exists(x => x.Currency == request[0]) && exchangers.Exists(x => x.Currency == request[1]))
            {
                Exchanger to = exchangers.Find(x => x.Currency == request[0]);
                Exchanger from = exchangers.Find(x => x.Currency == request[1]);
                return from.Exchange(to.ChangingCourseDKK, ammount);
            }
            else
            {
                return -1;
            }
        }
    }
}
