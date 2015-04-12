﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class OfflineDatabase : Database
    {
        [TestMethod]
        public override void Connect()
        {
           // throw new NotImplementedException();
        }

        [TestMethod]
        public override void ConnectFailedNotExistingDatabase()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void ConnectFailedWrongProvider()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void GetSingleItem()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void GetMultipleItems()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void UpdateSingleItem()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void UpdateMultipleItems()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void OnPowerFailure()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void OnConnectionFailure()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void HandleValidPayPalDocument()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void HandleInvalidPayPalDocument()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void HandlePayPalDocumentPowerFailure()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public override void HandlePayPalDocumentConnectionFailure()
        {
            throw new NotImplementedException();
        }
    }
}
