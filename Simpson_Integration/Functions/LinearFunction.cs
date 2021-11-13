using Ruchir.Simpson_Integration.raminrahimzada;

namespace Ruchir.Simpson_Integration
{
    /// <summary>
    ///     Contains our sample function (x in our case)
    /// </summary>
    public class LinearFunction : IFunction
    {
        private decimal _end;
        private decimal _start;

        public LinearFunction()
        {
        }

        public LinearFunction(ulong iterations, decimal end, decimal start)
        {
            Iterations = iterations;
            _end = end;
            _start = start;
            stepSize = (_end - _start) / Iterations;
        }

        public decimal stepSize { get; private set; }

        public ulong Iterations { get; private set; }
        public string Description => "x";


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
            return x;
        }
    }
}