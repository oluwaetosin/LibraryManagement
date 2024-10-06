namespace Library.Contracts.Books
{

    public record NewBookRequest(
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
