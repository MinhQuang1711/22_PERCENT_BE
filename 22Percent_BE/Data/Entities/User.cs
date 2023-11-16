namespace _22Percent_BE.Data.Entities
{
    public class User:BaseModel
    {
        public string CreateUser { get; set; }
        public string Password { get; set; }
        public User() { }
    }
}
