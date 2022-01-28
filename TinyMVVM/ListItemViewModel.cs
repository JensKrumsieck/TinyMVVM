namespace TinyMVVM;

/// <summary>
/// Represents a ListItem
/// To be used with <see cref="ListingViewModel{T}"/>
/// </summary>
public class ListItemViewModel<TParent, TChild> : BaseViewModel, IListItemViewModel<TParent, TChild> where TParent : ListingViewModel<TChild> where TChild : class
{

    /// <summary>
    /// The Parent View Model of Type <see cref="ListingViewModel{T}"/>
    /// </summary>
    public TParent Parent { get; }

    /// <summary>
    /// Indicates if this Item is selected
    /// </summary>
    public bool IsSelected => Parent?.SelectedItem == this;

    public ListItemViewModel(TParent parent)
    {
        Parent = parent;
        Parent.SelectedIndexChanged += (s, e) => OnPropertyChanged(nameof(IsSelected));
    }
}
