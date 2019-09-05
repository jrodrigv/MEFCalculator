using System.ComponentModel.Composition;
using Calculator.Core;

namespace Operation.Multiply
{

    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '*')]
    public class MultiplyOperation : IOperation
    {
        public int Operate(int left, int right)
        {
            return left * right;
        }
    }
}