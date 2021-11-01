using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary.Model
{
   public class Book
    {

public Book(string id, string title, int quantity, string category)
        {
            Id = id;
            Title = title;
            Quantity = quantity;
            Category = category;
        }


        public Book(string title, int quantity, string category)
        {
            Title = title;
            Quantity = quantity;
            Category = category;
        }

        public string Id { get => Id; set => Id = value; }
        public string Title { get => Title; set => Title = value; }
        public int Quantity { get => Quantity; set => Quantity = value; }
        public string Category { get => Category; set => Category = value; }
    }
}
