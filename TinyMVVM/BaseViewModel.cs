#nullable enable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TinyMVVM
{
    public abstract class BaseViewModel : BindableBase
    {
        private string _title = string.Empty;

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public virtual string Title
        {
            get => _title;
            set => Set<string>(ref _title, value);
        }

        /// <summary>
        /// Subscribes to ObservableCollection and updates non observable collection
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="addToTarget"></param>
        /// <param name="removeFromTarget"></param>
        /// <param name="cleanUpFunction"></param>
        public void Subscribe<TSource, TTarget>(ObservableCollection<TSource> source, IList<TTarget> target,
            Func<TSource, TTarget> addToTarget, Func<TSource, TTarget>? removeFromTarget = null, Action? cleanUpFunction = null)
        {
            //allow both to be the same
            removeFromTarget ??= addToTarget;

            source.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (TSource item in e.NewItems)
                            target.Add(addToTarget(item));
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (TSource item in e.OldItems)
                            target.Remove(removeFromTarget(item));
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        foreach (TSource item in e.OldItems)
                            target.Remove(removeFromTarget(item));
                        foreach (TSource item in e.NewItems)
                            target.Add(addToTarget(item));
                        break;
                    default: return;
                }
                cleanUpFunction?.Invoke();
            };
        }

        /// <summary>
        /// No need for converters if type matches
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="cleanUpFunction"></param>
        public void Subscribe<T>(ObservableCollection<T> source, IList<T> target, Action? cleanUpFunction = null) => Subscribe(source, target, s => s, null, cleanUpFunction);
    }
}
#nullable restore
