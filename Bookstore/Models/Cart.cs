using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public virtual void AddItem(Book bk, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartLineItem 
                {
                    Book = bk,
                    Quantity = qty

                }); 
            }
            else
            {
                line.Quantity += qty;
            }

        }

        public virtual void RemoveItem(Book bk)
        {
            Items.RemoveAll(b => b.Book.BookId == bk.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }

        public virtual double CalculateTotal()
        {
            double sum = Items.Sum(b => b.Quantity * b.Book.Price);
            return sum;
        }
    }

   

    public class CartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
