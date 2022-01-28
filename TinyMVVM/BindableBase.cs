namespace TinyMVVM;

public abstract class BindableBase : INotifyPropertyChanged
{
    /// <summary>
    /// Sets referenced storage to value if value is not already set to storage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="storage"></param>
    /// <param name="value"></param>
    /// <param name="propertyName"></param>
    /// <returns>True if value changed, false if existing value matches value parameter</returns>
    protected virtual bool Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        //already set
        if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
        storage = value;
        OnPropertyChanged(propertyName);

        return true;
    }

    /// <summary>
    /// Sets referenced storage to value if value is not already set to storage and fires
    /// onChanged Action
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="storage"></param>
    /// <param name="value"></param>
    /// <param name="onChanged"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    protected virtual bool Set<T>(ref T storage, T value, Action onChanged,
        [CallerMemberName] string propertyName = null)
    {
        if (!Set(ref storage, value, propertyName)) return false;
        onChanged?.Invoke();
        return true;

    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
