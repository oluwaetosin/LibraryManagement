﻿using ErrorOr;
using MediatR;
using DomainBooks = Library.Domain.Books;

namespace Library.Application.Book.Command.UpdateBook
{
    public record UpdateBookCommand
    (
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
    ) : IRequest<ErrorOr<DomainBooks.Book>>;
}
