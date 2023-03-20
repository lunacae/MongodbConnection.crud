namespace Hub2b.MagazineLuiza.Auth.Client.Exceptions
{
    public class MongodbException : System.Exception
    {
        public MongodbException()
        {
        }

        public MongodbException(string message)
            : base(message)
        {
        }
    }
}
