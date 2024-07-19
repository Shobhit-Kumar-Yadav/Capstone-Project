namespace BookApp.Model

{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        //public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        //public string? ModifiedBy { get; set; }
        //public DateTime? ModifiedDate { get; set; }




        //public int BookId { get; set; }
        public  ICollection<Book>? Books{ get; set; }
    }
}
