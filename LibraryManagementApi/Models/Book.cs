using System.Reflection.PortableExecutable;

namespace LibraryManagementApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int year { get; set; }
        public float Price { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
