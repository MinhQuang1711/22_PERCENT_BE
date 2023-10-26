namespace _22Percent_BE.Data.Entities
{
    public class BaseModel
    {
        public string Id { set; get; }

        public BaseModel() {
            Id = Guid.NewGuid().ToString();
        }
    }
}
