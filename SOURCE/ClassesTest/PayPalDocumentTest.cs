using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class PayPalDocumentTest
    {
        [TestMethod]
        public void ValidDocument()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidNumberOfLines()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void AccountNumberNotExist()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void AccountNumberTooBig()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void AccountNumberTooSmall()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void DateTimeFormat()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidStartDate()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidStartDateTime()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidEndDate()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidEndDateTime()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidNumberOfDeposits()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidDepositNoSpace()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidDepositWithLetters()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidTooManyDeposits()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidDepositTooBig()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.InvalidPayPalLogFileException))]
        public void InvalidDepositTooSmall()
        {
        }

        [TestMethod]
        public void OnPowerFailure()
        {
        }

        [TestMethod]
        public void OnConnectionFailure()
        {
        }
    }
}
