using System;
using System.Collections.Generic;

public class ObjectPool<T> where T : IPoolable
{
    private readonly Func<T> createFunc;
    private readonly List<T> available = new List<T>();

    public ObjectPool(Func<T> createFunc)
    {
        this.createFunc = createFunc;
    }

    public T Get()
    {
        T item;
        if (available.Count > 0)
        {
            item = available[available.Count - 1];
            available.RemoveAt(available.Count - 1);
        }
        else
        {
            item = createFunc();
        }

        item.OnGetFromPool();
        return item;
    }

    public void Return(T item)
    {
        item.OnReturnToPool();
        available.Add(item);
    }
}
