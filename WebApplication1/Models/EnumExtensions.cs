using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication1.Models;

public static class EnumExtentions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            .GetName();
    }
    
}