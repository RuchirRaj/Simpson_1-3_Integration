namespace Ruchir.Simpson_Integration
{
    /// <summary>
    ///     Contains Simpson 1/3 integration rule
    /// </summary>
    public class SimpsonIntegrator
    {
        private readonly IFunction _function;

        public SimpsonIntegrator(IFunction function)
        {
            _function = function;
        }

        /// <summary>
        ///     Get the final integrated value
        /// </summary>
        /// <returns></returns>
        public decimal GetIntegration()
        {
            var firstTerm = _function.GetValue(0) + _function.GetValue(_function.Iterations);
            decimal secondTerm = 0;
            decimal thirdTerm = 0;

            //Using boolean to switch for cases modulus operation is expensive
            var odd = false;

            using (var progress = new ProgressBar())
            {
                for (ulong i = 1; i < _function.Iterations; i++)
                {
                    if (odd)
                        thirdTerm += _function.GetValue(i);
                    else
                        secondTerm += _function.GetValue(i);
                    odd = !odd;
                    progress.Report((double) i / _function.Iterations);
                }
            }

            var final = (firstTerm + secondTerm * 4 + thirdTerm * 2) * _function.stepSize / 3;
            return final;
        }
    }
}