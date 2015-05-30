﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Receipt : Record
    {
        private List<ReceiptItem> items;
        public List<ReceiptItem> Items
        {
            get
            {
                if (this.items == null)
                    if (this.ID == 0) 
                        this.items = new List<ReceiptItem>(); 
                    else
                        this.items = Database.Where<ReceiptItem>("ReceiptItems.receipt_id = {0}", this.ID);
                return this.items;
            }
        }
        public DateTime PurchasedOn { get; private set; }
        public Visitor PurchasedBy { get; private set; }
        public ShopJob Shop { get { return this.items.Count > 0 ? this.items[0].Item.Shop : null; } }

        public Receipt(int id, Visitor visitor, DateTime purchasedOn)
            : base(id)
        {
            this.PurchasedBy = visitor;
            
            this.PurchasedOn = purchasedOn;
        }

        public override Record Create()
        {
            throw new NotImplementedException();
        }
    }
}
