namespace Task2
{
    public class HelloFormatter : IHelloFormatter
    {
        public string Hello(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("User name can not be null or empty");
            }

            return $"{DateTime.Now.ToShortTimeString()} Hello, {userName}!";
        }
    }
}