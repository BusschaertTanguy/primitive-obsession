namespace Domain.Common.Guards;

internal static class Guards
{
    public static void NotEmpty(object? value, string property)
    {
        if (value == null) throw new ArgumentNullException(property);
    }

    public static void NotEmpty(Guid value, string property)
    {
        if (value == Guid.Empty) throw new ArgumentNullException(property);
    }

    public static void NotEmpty(string value, string property)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(property);
    }

    public static void GreaterThanZero(int value, string property)
    {
        if (value <= 0) throw new InvalidOperationException($"{property} has to be greater then 0.");
    }
    
    public static void GreaterThanZero(decimal value, string property)
    {
        if (value <= 0) throw new InvalidOperationException($"{property} has to be greater then 0.");
    }
    
    public static void OtherThanZero(int value, string property)
    {
        if (value == 0) throw new InvalidOperationException($"{property} has to be greater then 0.");
    }
}