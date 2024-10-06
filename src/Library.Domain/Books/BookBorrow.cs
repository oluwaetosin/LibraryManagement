using Library.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Library.Domain.Books
{
  
        public class BookBorrow
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ID { get; set; }

            [ForeignKey("Book")]
            public int BookID { get; set; }
            public virtual Book Book { get; set; }

            [ForeignKey("User")]
            public int UserID { get; set; }
            public virtual User User { get; set; }

            public DateTime DateBorrowed { get; set; } = DateTime.Now;

            public bool Returned { get; set; }  = false;

            

           
        }
     
 
}
