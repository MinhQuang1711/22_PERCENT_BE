namespace _22Percent_BE.Data.Entities
{
    public class BaseModel
    {
        public string id { set; get; }

        public BaseModel() {
            id = Guid.NewGuid().ToString();
        }
    }
}
