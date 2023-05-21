namespace Lab4.Common;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class StrategyTypeAttribute : Attribute
{
    public Type Type { get; set; }

    public StrategyTypeAttribute(Type type)
    {
        Type = type;
    }
}