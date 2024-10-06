using MediatR;

namespace Library.Application.Book.Command.CreateBook
{
    public record CreateBookCommand(
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
    string Location
    ): IRequest<int>;
}
