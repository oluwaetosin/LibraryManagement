using Library.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Library.Domain.Books
{
  
        public class BookReservation
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int ReservationID { get; set; }

            [ForeignKey("Book")]
            public int BookID { get; set; }
            public virtual Book Book { get; set; }

            [ForeignKey("User")]
            public int UserID { get; set; }
            public virtual User User { get; set; }

            public DateTime ReservationDateTime { get; set; } = DateTime.Now;

            [NotMapped]
            public DateTime ExpirationDateTime => ReservationDateTime.AddHours(24);

            [Required]
            [Column(TypeName = "ENUM('Reserved', 'Expired', 'Cancelled')")]
            public ReservationStatus Status { get; set; } = ReservationStatus.Reserved;

           
        }

        public enum ReservationStatus
        {
            Reserved,
            Expired,
            Cancelled
        }
 
}
