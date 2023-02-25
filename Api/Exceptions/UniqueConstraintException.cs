using System.Globalization;

namespace Api.Exceptions;

public class UniqueConstraintException : Exception
{
    public int Id { get; set; }
    public UniqueConstraintException(int id) : base()
    {
        Id = id;
    }

    public UniqueConstraintException(string message, int id) : base(message)
    {
        Id = id;
    }

    public UniqueConstraintException(string message, int id, params object[] args) 
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
        Id = id;
    }
    
}