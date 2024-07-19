namespace BookApp.Model

{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfileImageUrl { get; set; }
     //   public ICollection<Favorite> Favorites { get; set; }
    }
}
