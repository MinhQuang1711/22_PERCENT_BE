namespace _22Percent_BE.Data.Entities
{
    public class User: BaseModel
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string createUser { get; set; }

        public User() { }
        
    }
}
