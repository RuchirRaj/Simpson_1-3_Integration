using Ruchir.CP_Assignment.raminrahimzada;

namespace Ruchir.CP_Assignment
{
    /// <summary>
    ///     Contains our sample function (cos(x) in our case)
    /// </summary>
    public class CosFunction : IFunction
    {
        private decimal _end;
        private decimal _start;

        public CosFunction()
        {
        }

        public CosFunction(ulong iterations, decimal end, decimal start)
        {
            Iterations = iterations;
            _end = end;
            _start = start;
            stepSize = (_end - _start) / Iterations;
        }

        public decimal stepSize { get; private set; }

        public ulong Iterations { get; private set; }
        public string Description => "cos(x) (x in radians)";


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
            return DecimalMath.Cos(x);
        }
    }
}