namespace Framework.Agenda.Exceptions
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
