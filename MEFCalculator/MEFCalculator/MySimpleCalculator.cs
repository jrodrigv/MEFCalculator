using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using Calculator.Core;

namespace MEFCalculator
{

    [Export(typeof(ICalculator))]
    class MySimpleCalculator : ICalculator
    {
        [ImportMany] private IEnumerable<Lazy<IOperation, IOperationData>> _operations;

        public String Calculate(String input)
        {
            int left;
            int right;
            // Finds the operator.
            int fn = FindFirstNonDigit(input);
            if (fn < 0) return "Could not parse command.";

            try
            {
                // Separate out the operands.
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
            }
            catch
            {
                return "Could not parse command.";
            }

            var operation = input[fn];

            foreach (Lazy<IOperation, IOperationData> i in _operations)
            {
                if (i.Metadata.Symbol.Equals(operation)) return i.Value.Operate(left, right).ToString();
            }
            return "Operation Not Found!";
        }

        private int FindFirstNonDigit(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!(char.IsDigit(s[i]))) return i;
            }
            return -1;
        }
    }
}
