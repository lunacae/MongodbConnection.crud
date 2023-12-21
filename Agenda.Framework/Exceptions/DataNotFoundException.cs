namespace Framework.Agenda.Exceptions
{
    public class DataNotFoundException : System.Exception
    {
        public DataNotFoundException()
        {
        }

        public DataNotFoundException(string message)
            : base(message)
        {
        }
    }
}
