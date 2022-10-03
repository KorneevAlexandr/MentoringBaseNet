namespace Task2
{
    public class HelloFormatter
    {
        private readonly string _userName;

        public HelloFormatter(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("User name can not be null or empty");
            }

            _userName = userName;
        }

        public string Hello()
        {
            return $"{DateTime.Now.ToShortTimeString()} Hello, {_userName}!";
        }
    }
}