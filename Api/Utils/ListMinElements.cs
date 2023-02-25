using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Api.Utils;

public class ListMinElements : ValidationAttribute
{
    private readonly int _minCount;

    public ListMinElements(int minCount)
    {
        _minCount = minCount;
    }

    public override bool IsValid(object? value)
    {
        if (value is IList list) return list.Count > _minCount;
        return false;
    }
}