namespace BookApp.Model

{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
       public int AuthorId { get; set; }
        public Author? Author { get; set; }
       // public ICollection<Favorite> Favorites { get; set; }
    //    public ICollection<Author> Authors { get; set; }
    }
}
