﻿using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using TinyMVVM.Command;

namespace TinyMVVM;

/// <summary>
/// A ViewModel Base for ViewModels bearing Lists
/// like in a TabControl -> TabItems Context
/// </summary>
public abstract class ListingViewModel<T> : BaseViewModel where T : class
{
    /// <summary>
    /// The Items of T as Observable Collection
    /// </summary>
    public ObservableCollection<T> Items { get; set; } = new ObservableCollection<T>();

    private int _selectedIndex = -1;
    /// <summary>
    /// Gets or Sets the selectedIndex
    /// </summary>
    public virtual int SelectedIndex
    {
        get => _selectedIndex;
        set => Set(ref _selectedIndex, value, OnSelectedIndexChanged);
    }

    /// <summary>
    /// Gets the SelectedItem
    /// </summary>
    public T SelectedItem => Items.ElementAtOrDefault(SelectedIndex);

    /// <summary>
    /// DeleteCommand
    /// </summary>
    public ICommand DeleteItemCommand { get; set; }

    /// <summary>
    /// ctor
    /// </summary>
    protected ListingViewModel()
    {
        var type = GetType();
        var method = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .FirstOrDefault(s => Attribute.IsDefined(s, typeof(DeleteCommandAttribute)));
        if (method != null)
            DeleteItemCommand = new RelayCommand<T>((Action<T>)Delegate.CreateDelegate(typeof(Action<T>), this, method));
    }

    /// <summary>
    /// Fires when SelectedIndex changes
    /// </summary>
    public event EventHandler SelectedIndexChanged;

    /// <summary>
    /// Selected index changed handler
    /// </summary>
    protected virtual void OnSelectedIndexChanged()
    {
        SelectedIndexChanged?.Invoke(this, new EventArgs());
        OnPropertyChanged(nameof(SelectedItem));
    }
}
