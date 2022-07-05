namespace User.Models
{
    public class ApiResult<T> where  T: class,new()
    {
        public string Message { get; set; }
        public T Result { get; set; }

    }
}
