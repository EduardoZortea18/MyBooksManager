using MediatR;

namespace MyBooksManager.Application.Commands.Loans.CreateLoan
{
    public class CreateLoanCommand : IRequest<int>
    {
        public int BookId { get; private set; }
        public int UserId { get; private set; }

        public CreateLoanCommand(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
        }
    }
}
