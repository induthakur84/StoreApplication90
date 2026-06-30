using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entites
{
    public  class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //many to many relationship

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
