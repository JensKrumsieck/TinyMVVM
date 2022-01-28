using System.Collections.ObjectModel;

namespace TinyMVVM.Utility;

public static class CollectionUtil
{
    public static void ClearAndNotify<T>(this ObservableCollection<T> input)
    {
        var items = input.ToList();
        foreach (var item in items) input.Remove(item);
    }
}
