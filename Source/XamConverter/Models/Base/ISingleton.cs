namespace XamConverter.Models.Base;

interface ISingleton<T>
{
    abstract static T Instance { get; }
}
