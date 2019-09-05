using System;
using System.ComponentModel.Composition;
using Calculator.Core;

namespace Operation.Sum
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '+')]
    public class AddOperation : IOperation
    {
        public int Operate(int left, int right)
        {
            return left + right;
        }
    }
}
