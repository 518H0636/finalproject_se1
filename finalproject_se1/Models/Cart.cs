using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finalproject_se1.Models
{
    public class CartItem
    {
        public tblGood product { get; set; }
        public int quantity { get; set; }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        { 
            get { return items; } 
        }
        public int TotalQ()
        { 
            return items.Sum(s=>s.quantity);
        }
        public void Add(tblGood _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.product.goodID == _pro.goodID);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    product = _pro,
                    quantity = _quantity
                });
            }
            else
            {
                item.quantity += _quantity;
            }
        }
        public void UpdateQ(String id,int quantity)
        {
            var item = items.Find(s => s.product.goodID == id);
            if (item != null)
            {
                item.quantity = quantity;
            }
        }
        public double totalM()
        { 
            var total=items.Sum(s => s.product.unitSold*s.quantity);
            return (double)total;
        }
        public void ClearC()
        { items.Clear(); }
        public void RemoveC(String id) 
        { 
            items.RemoveAll(s=>s.product.goodID == id);
        }
    }
}
