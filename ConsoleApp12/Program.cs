namespace ConsoleApp12
{
    class DiscriminantLessThanZero : Exception
    {
        protected Exception e;
        private string m;

        public DiscriminantLessThanZero() { }

        public DiscriminantLessThanZero(string m) : base(m)
        {

        }
        public DiscriminantLessThanZero(string m, Exception i) : base(m, i)
        {
            m = m;
            i = e;
        }
    }

    class TryException : DiscriminantLessThanZero
    {
        public TryException()
        {
            Random randomA = new Random();
            Random randomB = new Random();
            Random randomC = new Random();

            int a, b, c;

            a = randomA.Next(-30, 30);
            b = randomB.Next(-30, 30);
            c = randomC.Next(-30, 30);

            double D = Math.Pow(b, 2) - 4 * a * c;


            if (D < 0)
            {
                throw new DiscriminantLessThanZero($"Дискриминант меньше нуля", e);
            }

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TryException exception = new TryException();
            }
            catch (DiscriminantLessThanZero exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}