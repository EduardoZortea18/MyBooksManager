using BooksManager.Infra.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MyBooksManager.Application.Commands.Books.CreateBook;
using MyBooksManager.Application.Validators;
using MyBooksManager.Ioc;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<BooksManagerDbContext>(opts => opts.UseNpgsql(connectionString));

builder.Services.AddControllers()
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateBookCommandValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.ConfigureDependencyInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
