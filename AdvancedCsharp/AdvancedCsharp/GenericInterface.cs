using System;
using System.Collections.Generic;

public interface IRepository<T>
{
    void Add(T item);
    IEnumerable<T> GetAll();
}

public class Repository<T> : IRepository<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }
}

class ProgramGenericInterface
{
    static void Main()
    {
        IRepository<string> stringRepo = new Repository<string>();
        stringRepo.Add("Item 1");
        stringRepo.Add("Item 2");

        foreach (var item in stringRepo.GetAll())
        {
            Console.WriteLine(item);
        }
    }
}