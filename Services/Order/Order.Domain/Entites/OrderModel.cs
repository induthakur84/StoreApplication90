namespace Order.Domain.Entites
{
    public  class OrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //fk
        public int UserId { get; set; }



        //navigation property to the user entity

        public User User { get; set; }

    }
}
