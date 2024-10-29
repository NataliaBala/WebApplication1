namespace WebApplication1.Models;

public class Calculator
{
    public Operator? op { get; set; }
    public double? A { get; set; }
    public double? B { get; set; }

    public String Op
    {
        get
        {
            switch (op)
            {
                case Operator.Add:
                    return "+";
                case Operator.Sub:
                    return "-";
                case Operator.Mult:
                    return "*";
                case Operator.Div:
                    return "/";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return Op != null && A != null && B != null;
    }

    public double Calculate() {
        switch (op)
        {
            case Operator.Add:
                return (double) (A + B);
            case Operator.Sub:
                return (double) (A - B);
            case Operator.Mult:
                return (double) (A * B);
            case Operator.Div:
                return (double) (A / B);
            default: return double.NaN;
        }
    }
    public enum Operator
    {
        Add, Sub, Mult, Div
    }
}