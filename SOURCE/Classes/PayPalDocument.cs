using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    using Exceptions;
    /// <summary>
    /// Document received from PayPal to inform about transactions ( deposits )
    /// </summary>
    public class PayPalDocument : Record
    {
        const string DATE_FORMAT = "YYYY/MM/dd/HH:mm:SS";

        public int ID{get;private set;}
        public DateTime Date{get;private set;}
        public string Raw { get; private set; }
        public List<Deposit> Deposits { get { return Database.Where<Deposit>("Deposits.paypal_document_id = {0}", this.ID); } }

        public PayPalDocument(int ID, DateTime date, string raw)
        {
            this.ID = ID;
            this.Date = date;
            this.Raw = raw;
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        /*
        public static PayPalDocument Parse(string text)
        {
            return Parse(text.Split('\n'));
        }

        public static PayPalDocument Parse(string[] lines)
        {
            if (lines.Length < 5) throw new InvalidPayPalLogFileException();

            ushort numberOfDeposits = 0;
            if (ushort.TryParse(lines[3], out numberOfDeposits))
                if (numberOfDeposits - 4 != 4)
                    throw new InvalidPayPalLogFileException();

            decimal bankAccountNumber = -1;
            if (!decimal.TryParse(lines[0], out bankAccountNumber))
                throw new InvalidPayPalLogFileException();

            DateTime dateStart = new DateTime(2, 2, 2);
            if (!DateTime.TryParseExact(lines[1], DATE_FORMAT, null, System.Globalization.DateTimeStyles.None, out dateStart))
                throw new InvalidPayPalLogFileException();

            DateTime dateEnd = new DateTime(2, 2, 2);
            if (!DateTime.TryParseExact(lines[2], DATE_FORMAT, null, System.Globalization.DateTimeStyles.None, out dateEnd))
                throw new InvalidPayPalLogFileException();

            Deposit[] deposits = new Deposit[numberOfDeposits];

            for (int i = 0; i < numberOfDeposits; i++)
            {
                decimal amount = -1;
                string[] lineParams = lines[i].Split(' ');

                if (lineParams.Length != 2)
                    throw new InvalidPayPalLogFileException();

                string id = lineParams[1];
                if (!decimal.TryParse(lineParams[1], out amount))
                    throw new InvalidPayPalLogFileException();

                deposits[i] = new Deposit(id, amount);
            }

            return new PayPalDocument(bankAccountNumber, dateStart, dateEnd, deposits);
        }*/
    }
}
