namespace TinyMVVM;

// ReSharper disable once TypeParameterCanBeVariant
public interface IListItemViewModel<TParent, TChild> where TParent : ListingViewModel<TChild> where TChild : class
{
    /// <summary>
    /// The Parent View Model of Type <see cref="ListingViewModel{T}"/>
    /// </summary>
    public TParent Parent { get; }

    /// <summary>
    /// Indicates if this Item is selected
    /// </summary>
    public bool IsSelected { get; }
}
