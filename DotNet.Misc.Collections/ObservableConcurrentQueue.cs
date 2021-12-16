using System.Collections.Specialized;

namespace System.Collections.Concurrent;

public class ObservableConcurrentQueue<T> : ConcurrentQueue<T>, INotifyCollectionChanged
{
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public event NotifyCollectionChangedEventHandler? ItemEnqueued;

    public event NotifyCollectionChangedEventHandler? ItemDequeued;

    public new void Enqueue(T item)
    {
        base.Enqueue(item);
        OnItemEnqueued(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
    }

    public new bool TryDequeue(out T? result)
    {
        var flag = base.TryDequeue(out result);

        OnItemDequeued(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, result));
        return flag;
    }

    internal void OnItemEnqueued(NotifyCollectionChangedEventArgs e)
    {
        OnCollectionChanged(e);
        if (ItemEnqueued is null)
            return;

        ItemEnqueued(this, e);
    }

    internal void OnItemDequeued(NotifyCollectionChangedEventArgs e)
    {
        OnCollectionChanged(e);
        if (ItemDequeued is null)
            return;

        ItemDequeued(this, e);
    }

    internal void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        if (CollectionChanged is null)
            return;

        CollectionChanged(this, e);
    }
}
