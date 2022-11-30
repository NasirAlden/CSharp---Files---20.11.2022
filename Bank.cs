using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace workingWithFiles
{
    public class Bank
    {

        //שם בנק, מספר סניף, קוד בנק, רחוב,עיר, טלפון.

        public Bank(string _bankCode)
        {

            bankCode = _bankCode;
        }

        public string bankName { get; set; }
        public string bankBranch { get; set; }

        public readonly string bankCode;
        public string address { get; set; }
        public string city { get; set; }
        public string phone { get; set; }


        

    }

    public class Hapoalim : Bank
    {
        public int workersInSnif;

        public Hapoalim(string bnkCode) : base(bnkCode)
        {

        }
    }

    public class Mizrahi : Bank
    {
        public int clubMembersCount;

        public Mizrahi(string bnkCode) : base(bnkCode)
        {

        }
    }


    public class Liumi : Bank
    {
        public string GiftForNewCustpres;

        public Liumi(string bnkCode) : base(bnkCode)
        {

        }
    }

    public class Discount : Bank
    {
        public bool IsTeacher;

        public Discount(string bnkCode) : base(bnkCode)
        {

        }
    }

}