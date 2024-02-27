using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Reflection.Metadata.Ecma335;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        static int count = 0;
        public static int GetCalledCount()
        {
            return count;
        }
        public static int Add(string input)
        {
            count++;
            int result = 0;
            // Tecknet som separerar siffrorna, komma som standard.
            char delimiter = ',';
            // Sträng för utskrift av negativa siffror.
            string negativeNumbers = "";
            // Startvärde för loopen, beroende på ifall man har // i början eller ej.
            int k = 0;

            if (input.Contains('-'))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '-')
                    {
                        negativeNumbers += input[i].ToString() 
                                        + input[i + 1].ToString() 
                                        + " ";
                    }
                }
                throw new NegativeNumberException("No negatives allowed. \n" +
                                                 $"Negative numbers in input: {negativeNumbers}");
            }
            if (input.Length < 1)
            {
                // Returnerar 0 ifall man får in tom sträng.
                return 0;
            }
            else
            {
                if (input.StartsWith("//"))
                {
                    // Hämtar nytt tecken för separation.
                    delimiter = Convert.ToChar(input.Substring(2, 1));
                    k = 3;
                }
                for (int i = k; i < input.Length; i++)
                {
                    if (char.IsNumber(input[i]))
                    { 
                        result += 
                            CheckAmountOfDigitsAndGetResult
                            (i, input, delimiter);
                    }
                    // Kollar efter "\n" tecken.
                    if (i < input.Length -1 
                        && IsLineBreak(input[i] + input[i + 1].ToString()))
                    {
                        // hoppar två steg om man stöter på "\n"
                        i++;
                    }
                }
            }
            return result;
        }
        public static bool IsLineBreak (string s)
        {
            if (s == "\n")
            {
                return true;
            }
            return false;
        }
        public static int CheckAmountOfDigitsAndGetResult 
                          (int i, string input, char delimiter)
        {
            // Kollar ifall det finns plats kvar i strängen så man inte går out of
            // bounds, samt kollar ifall nästa tecken är en delimiter eller ej.
            if (i < input.Length - 1 && input[i + 1] != delimiter)
            {
                return Int32.Parse(input[i] + input[i + 1].ToString());
            }
            else
            {
                return Int32.Parse(input[i].ToString());
            }
        }
    }
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }
}
