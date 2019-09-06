using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (i.Metadata.Symbol.Equals(operation))
                {
                    return i.Value.Operate(left, right).ToString();
                }
            }
            return "Operation Not Found!";
        }

        public async Task<string> AvailableOperationsAsync()
        {
            StringBuilder result = new StringBuilder();

            // C# 8.0 feature: Indices and ranges
            /*dummyArrayToShowIndicesAndRangesFeatures = _operations.ToArray()[0..^0]; 
            Would give the same as the next statement. ^ symbol give you the index starting from the end, so ^0 is the same as _operations.Length. 
            Take in account that the start index is included in the range but not the last. */
            var dummyArrayToShowIndicesAndRangesFeatures = _operations.ToArray()[..];

            result.AppendLine("List of all operators listed with PrittyToString:");

            // C# 8.0 feature: Asynchronous streams
            await foreach (var prittyToString in GetAsyncStream(dummyArrayToShowIndicesAndRangesFeatures))
            {
                result.AppendLine(prittyToString);
            };

            return result.ToString();
        }

        private static async IAsyncEnumerable<string> GetAsyncStream(Lazy<IOperation, IOperationData>[] operations)
        {
            foreach (Lazy<IOperation, IOperationData> l in operations)
            {
                await Task.Delay(100);
                yield return l.Value.PrittyToString();
            }
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
