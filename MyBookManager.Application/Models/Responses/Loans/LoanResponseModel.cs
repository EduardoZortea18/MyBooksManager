namespace MyBooksManager.Application.Models.Responses.Loans
{
    public class LoanResponseModel
    {
        public int BookId { get; private set; }
        public int UserId { get; private set; }
        public DateTime LoanDate { get; private set; }
        public DateTime? ExpectedReturnDate { get; private set; }
        public DateTime? ReturnDate { get; private set; }

        public LoanResponseModel()
        {
        }

        public LoanResponseModel(int bookId, int userId, DateTime loanDate, DateTime expectedReturnDate, DateTime returnDate)
        {
            BookId = bookId;
            UserId = userId;
            LoanDate = loanDate;
            ExpectedReturnDate = expectedReturnDate;
            ReturnDate = returnDate;
        }
    }
}
