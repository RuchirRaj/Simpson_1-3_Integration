namespace Ruchir.CP_Assignment
{
    /// <summary>
    ///     All custom function must implement this
    /// </summary>
    public interface IFunction
    {
        public decimal stepSize { get; }
        public ulong Iterations { get; }

        public string Description { get; }

        public decimal GetValue(ulong iteration);

        public void Init(ulong iterations, decimal end, decimal start);
    }
}