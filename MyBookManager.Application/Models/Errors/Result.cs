namespace MyBooksManager.Application.Models.Errors
{
    public class Result<T> where T : class
    {
        public T Data { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool HasError { get; private set; }
        public Result(T data, string errorMessage, bool hasError = false)
        {
            Data = data;
            ErrorMessage = errorMessage;
            HasError = hasError;
        }
    }
}
