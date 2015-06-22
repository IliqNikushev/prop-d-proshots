using System;
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
                        this.items = Database.Where<ReceiptItem>("|T|.receipt_id = {0}", this.ID);
                else if(this.items.Count == 0 && this.ID != 0)
                    this.items = Database.Where<ReceiptItem>("|T|.receipt_id = {0}", this.ID);
                return this.items;
            }
        }
        public DateTime PurchasedOn { get; private set; }
        public Visitor PurchasedBy { get; private set; }
        public ShopWorkplace Shop { get { return this.Items.Count > 0 ? this.Items[0].Item.Shop : null; } }
        public bool Postponed { get; private set; }
        public decimal Price { get { return this.Items.Sum(x => x.TotalPrice); } }

        public void Postpone()
        {
            this.Postponed = true;
        }

        public void UnPostpone()
        {
            this.Postponed = false;
        }

        public Receipt(int id, Visitor visitor, DateTime purchasedOn, bool postponed)
            : base(id)
        {
            this.PurchasedBy = visitor;
            this.Postponed = postponed;
            this.PurchasedOn = purchasedOn;
        }

        public Receipt(Visitor visitor, List<ReceiptItem> items)
            : this(0, visitor, DateTime.Now, false)
        {
            this.items = items;
        }

        public void Clear()
        {
            if (this.ID == 0) return;

            Database.Delete<ReceiptItem>("|T|.receipt_id = {0}", this.ID);
            Database.Delete(this, "|T|.id = {0}", this.ID);
        }

        public override Record Create()
        {
            Receipt result = this;
            if (this.ID == 0)
                result = Database.Insert(this, "purchasedBy, purchasedOn, postponed", this.PurchasedBy.ID, this.PurchasedOn, this.Postponed) as Receipt;
            else
                result = Database.Update(this, "postponed = {0}".Arg(this.Postponed), "|T|.id = {0}".Arg(this.ID)) as Receipt;

            Database.Delete<ReceiptItem>("|T|.receipt_id = {0}", result.ID);

            foreach (var item in this.items)
                new ReceiptItem(item.Item, result, item.Times, item.PricePerItem, item.TotalPrice).Create();

            return result;
        }
    }
}
