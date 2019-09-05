namespace Calculator.Core
{
    public interface IOperation
    {
        int Operate(int left, int right);

        // C# 8.0 feature: Default interface members and Enhancement of interpolated verbatim strings
        public string PrittyToString() => @$"Operator: {GetType().Name}";
    }
}