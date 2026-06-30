namespace Order.Domain.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserProfile UserProfile { get; set; }


        //here we are creating relationoship between user and orders

        //where the user can have multiple orders
        // but each order is associated with only one user


        public ICollection<OrderModel> OrderModels { get; set; } = new List<OrderModel>();
    }
}
