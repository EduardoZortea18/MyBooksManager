﻿using MyBooksManager.Application.Models.Responses.Loans;

namespace MyBooksManager.Application.Models.Responses.Books
{
    public record BookResponseModel
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string Isbn { get; init; }
        public int PublicationDate { get; init; }
        public List<LoanResponseModel> Loans { get; init; }

        public BookResponseModel(int id, string title, string author, string isbn, int publicationDate, List<LoanResponseModel> loans)
        {
            Id = id;
            Title = title;
            Author = author;
            Isbn = isbn;
            PublicationDate = publicationDate;
            Loans = loans;
        }
    }
}
