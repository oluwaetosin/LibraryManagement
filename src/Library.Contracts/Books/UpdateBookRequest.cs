using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Contracts.Books
{
    public record UpdateBookRequest(
        int BookId,
       string Title,
       string Author,
       string ISBN,
       string Publisher,
       int PublicationYear,
       string Category,
       string Language,
       string Edition,
       int Pages,
       int CopiesAvailable,
       string Location,
       int Copies
    );
}
