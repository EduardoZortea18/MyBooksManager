namespace MyBooksManager.Application.Models.Responses.Users
{
    public record UserResponseModel
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public UserResponseModel(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
