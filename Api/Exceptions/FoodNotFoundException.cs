using System.Globalization;

namespace Api.Exceptions;

public class FoodNotFoundException : Exception
{
    public FoodNotFoundException()
    {
    }

    public FoodNotFoundException(string message) : base(message)
    {
    }

    public FoodNotFoundException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}