namespace Library.Contracts.Books
{
    public record BorrowBookRequest(int BookId);

    public record ReturnBookRequest(int BookId);
}
