using System.Reflection;
using Lab4.Input;
using Lab4.Output;

namespace Lab4.Common;

internal static class StrategyTypeExtension
{
    public static IInputStrategy? CreateInputStrategy(this InputStrategyType type, object?[]? arguments)
    {
        try
        {
            return type.CreateStrategy<IInputStrategy, InputStrategyType>(arguments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static IOutputStrategy? CreateOutputStrategy(this OutputStrategyType type, object?[]? arguments)
    {
        try
        {
            return type.CreateStrategy<IOutputStrategy, OutputStrategyType>(arguments);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static TStrategy? CreateStrategy<TStrategy, TType>(this TType type, object?[]? arguments) where TType : Enum
    {
        FieldInfo? fieldInfo = typeof(TType).GetField(Enum.GetName(typeof(TType), type)!);

        if (fieldInfo is null)
        {
            return default;
        }

        StrategyTypeAttribute? attribute = (StrategyTypeAttribute?)
            Attribute.GetCustomAttribute(fieldInfo, typeof(StrategyTypeAttribute));

        if (attribute is null)
        {
            return default;
        }

        return (TStrategy?) Activator.CreateInstance(attribute.Type, arguments);
    }
}