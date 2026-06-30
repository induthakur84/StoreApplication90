namespace Order.Domain.Entites
{

    //one to one relationship between user and user profile
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Foreign key of user table

        public int UserId { get; set; }

        //navigation property to the user entityu
        public User User { get; set; }
    }
}
