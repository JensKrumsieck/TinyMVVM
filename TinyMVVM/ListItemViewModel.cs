namespace TinyMVVM
{
    /// <summary>
    /// Represents a ListItem
    /// To be used with <see cref="ListingViewModel{T}"/>
    /// </summary>
    public class ListItemViewModel<T> : BaseViewModel where T : class
    {

        /// <summary>
        /// The Parent View Model of Type <see cref="ListingViewModel{T}"/>
        /// </summary>
        public ListingViewModel<T> Parent { get; }

        /// <summary>
        /// Indicates if this Item is selected
        /// </summary>
        public bool IsSelected => Parent?.SelectedItem == this;

        public ListItemViewModel(ListingViewModel<T> parent)
        {
            Parent = parent;
            Parent.SelectedIndexChanged += (s, e) => OnPropertyChanged(nameof(IsSelected));
        }
    }
}
