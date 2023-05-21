namespace Lab4.Input;

internal interface IInputStrategy
{
    Task<T[]?> GetData<T>();
}