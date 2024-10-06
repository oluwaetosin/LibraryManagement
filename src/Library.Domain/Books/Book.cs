using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Books
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Author { get; set; }

        [MaxLength(20)]
        public string ISBN { get; set; }

        [MaxLength(255)]
        public string Publisher { get; set; }

        public int PublicationYear { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(50)]
        public string Language { get; set; }

        [MaxLength(50)]
        public string Edition { get; set; }

        public int Pages { get; set; }

        public int CopiesAvailable { get; set; }
        public int Copies { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }
       
        
    }
}
