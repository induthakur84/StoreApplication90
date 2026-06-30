namespace Order.Domain.Entites
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }


        public decimal price{ get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
