using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Classes
{
    [TestClass]
    public class OfflineDatabase : Database
    {
        public override void Connect()
        {
           // throw new NotImplementedException();
        }

        public override void ConnectFailedNotExistingDatabase()
        {
            throw new NotImplementedException();
        }

        public override void ConnectFailedWrongProvider()
        {
            throw new NotImplementedException();
        }

        public override void GetSingleItem()
        {
            throw new NotImplementedException();
        }

        public override void GetMultipleItems()
        {
            throw new NotImplementedException();
        }

        public override void UpdateSingleItem()
        {
            throw new NotImplementedException();
        }

        public override void UpdateMultipleItems()
        {
            throw new NotImplementedException();
        }

        public override void OnPowerFailure()
        {
            throw new NotImplementedException();
        }

        public override void OnConnectionFailure()
        {
            throw new NotImplementedException();
        }

        public override void Synchronize()
        {
            throw new NotImplementedException();
        }
    }
}
