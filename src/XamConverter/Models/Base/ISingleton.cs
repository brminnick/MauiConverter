namespace XamConverter;

interface ISingleton<T>
{
    abstract static T Instance { get; }
}
