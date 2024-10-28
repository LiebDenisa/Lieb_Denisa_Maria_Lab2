namespace Lieb_Denisa_Maria_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();


    }
}
