namespace _22Percent_BE.Data.Entities
{
    public class RelationshipWithUser:BaseModel
    {
        public User User { set; get; }
        public string CreateUser { set; get; }
    }
}
