namespace Ruchir.Simpson_Integration
{
    /// <summary>
    ///     Contains our sample function ((1/x) in our case)
    /// </summary>
    public class CustomFunction2 : IFunction
    {
        private decimal _end;
        private decimal _start;

        public CustomFunction2(ulong iterations, decimal end, decimal start)
        {
            Iterations = iterations;
            _end = end;
            _start = start;
            stepSize = (_end - _start) / Iterations;
        }

        public CustomFunction2()
        {
        }

        public decimal stepSize { get; private set; }

        public ulong Iterations { get; private set; }
        public string Description => "1/x";


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
            return 1 / x;
        }
    }
}