namespace Ruchir.Simpson_Integration
{
    /// <summary>
    ///     Contains our sample function (1/(1+x^2) in our case)
    /// </summary>
    public class CustomFunction1 : IFunction
    {
        private decimal _end;
        private decimal _start;

        /// <summary>
        ///     Empty constructor is needed for reflection part
        /// </summary>
        public CustomFunction1()
        {
        }

        public CustomFunction1(ulong iterations, decimal end, decimal start)
        {
            Iterations = iterations;
            _end = end;
            _start = start;
            stepSize = (_end - _start) / Iterations;
        }

        public decimal stepSize { get; private set; }

        public ulong Iterations { get; private set; }
        public string Description => "1/(1+x^2)";


        public decimal GetValue(ulong i)
        {
            return Value(_start + i * stepSize);
        }

        public void Init(ulong iterations, decimal end, decimal start)
        {
            Iterations = iterations;
            _end = end;
            _start = start;
            stepSize = (_end - _start) / Iterations;
        }

        private decimal Value(decimal x)
        {
            return 1 / (x * x + 1);
        }
    }
}