﻿using MediatR;

namespace MyBooksManager.Application.Commands.Books.CreateBook
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int PublicationDate { get; set; }
    }
}
