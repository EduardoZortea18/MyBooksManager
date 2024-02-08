using BooksManager.Domain.Entities;

namespace MyBooksManager.Domain.Entities
{
    public class Loan : BaseEntity
    {
        public int BookId { get; private set; }
        public int UserId { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ExpectedReturnDate { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public Book Book { get; private set; }
        public User User { get; private set; }

        public Loan(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
            LoanDate = DateTime.UtcNow;
            ExpectedReturnDate = DateTime.UtcNow.AddDays(7);
        }

        public void ConfirmReturn()
        {
            ReturnDate = DateTime.UtcNow;
        }
    }
}
