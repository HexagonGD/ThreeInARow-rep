using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<T> : ScriptableObject where T : Component
{
    [SerializeField] private List<T> _prefabs;

    public T Create(int index)
    {
        return Instantiate(_prefabs[index]);
    }

    public T CreateRandom()
    {
        var index = Random.Range(0, _prefabs.Count);
        return Create(index);
    }
}
