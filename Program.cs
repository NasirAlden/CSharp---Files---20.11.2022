using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;


namespace workingWithFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");

            string path = "newFile.txt";
            string str = "**";

            //justWrite(path , str);

            //Console.WriteLine("please enter 10 sentence");
            for (int i = 0; i < 10; i++)
            {
                //str = Console.ReadLine();
                //justAppend(path, str);
            }

            //justRead(path);

            //randomIt(path);
            string pathBanks = "snifim.txt";
            int numberOfBanks = justReadBanks(pathBanks);
            Console.WriteLine(numberOfBanks);

            Bank[] arrBank = new Bank[numberOfBanks - 1];
            StreamReader sr = new StreamReader(pathBanks);
            string line = sr.ReadLine();
            for (int i = 0; i < numberOfBanks - 1; i++)
            {
                line = sr.ReadLine();

                arrBank[i] = justReadBanksInfo(line);
            }

            string reversed;
            int countMizrachi = 0;
            for (int i = 0; i < arrBank.Length; i++)
            {


                if (arrBank[i].bankName.Contains("הפועלים") && arrBank[i].phone.Contains("8"))
                {

                    Console.WriteLine( arrBank[i].bankName + " " + arrBank[i].phone);
                }


                if (arrBank[i].city.Equals("ירושלים") || arrBank[i].city.Equals("תל אביב -יפו"))
                {

                    Console.WriteLine("" + arrBank[i].bankBranch + " " + arrBank[i].city);
                }

                //if (arrBank[i].bankName.Contains("מזרחי"))
                //{
                //    countMizrachi++;
                //    Console.WriteLine(countMizrachi + " " + arrBank[i].bankName);
                //}
            }


            Console.ReadLine();


        } // Main End.




        static void justWrite(string path, string str)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(str);
            sw.Close();
        }

        static void justAppend(string path, string str)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(str);
            sw.Close();
        }

        static void justRead(string path)
        {
            StreamReader sr = new StreamReader(path);
            int count = 1;
            while (sr.ReadLine() is string s)
            {
                Console.WriteLine($"Line {count++} is : {s}");
            }
            sr.Close();
        }

        static int justReadBanks(string path)
        {
            StreamReader sr = new StreamReader(path);
            int count = 0;
            while (sr.ReadLine() is string s)
            {
                count++;
            }
            sr.Close();
            return count;
        }

        static Bank justReadBanksInfo(string fileLine)
        {
            Bank bank = new Bank("1000");
            string[] strLineWithEmpty = fileLine.Split(',');
            if (strLineWithEmpty[1].Contains("הפועלים"))
            {
                bank = new Hapoalim(strLineWithEmpty[0]);
            }
            else if (strLineWithEmpty[1].Contains("מזרחי"))
            {
                bank = new Mizrahi(strLineWithEmpty[0]);
            }
            else if (strLineWithEmpty[1].Contains("לאומי"))
            {
                bank = new Liumi(strLineWithEmpty[0]);
            }
            else if (strLineWithEmpty[1].Contains("דיסקונט"))
            {
                bank = new Discount(strLineWithEmpty[0]);
            }
            else {
                bank = new Bank(strLineWithEmpty[0]);
            }

            bank.bankName = string.Copy(strLineWithEmpty[1]);
            bank.bankBranch = strLineWithEmpty[2];
            bank.address = strLineWithEmpty[4];
            bank.city = strLineWithEmpty[5];
            bank.phone = strLineWithEmpty[8];


            return bank;
        }

        static void randomIt(string path)
        {
            Random random = new Random();
            int numberOfRows = random.Next(50, 101);
            int numberOfStars;
            StreamWriter sw = new StreamWriter(path, true);
            for (int i = 0; i < numberOfRows; i++)
            {
                numberOfStars = random.Next(3, 10);
                for (int j = 0; j < numberOfStars; j++)
                {
                    sw.Write("*");
                }
                sw.WriteLine("");
            }
            sw.Close();

        }
    }
}