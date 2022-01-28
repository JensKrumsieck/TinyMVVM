namespace TinyMVVM.Utility;

/// <summary>
/// small singleton implementation
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Singleton<T> where T : new()
{
    private static readonly Lazy<T> Lazy = new Lazy<T>(() => new T());

    /// <summary>
    /// The instance!
    /// </summary>
    public static T Instance => Lazy.Value;
}
