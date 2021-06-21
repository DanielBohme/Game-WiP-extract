using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T prefab;

    private Queue<T> objects = new Queue<T>();
    public static GenericObjectPool<T> Instance { get; private set; }

    public interface IInstance<T>
    {
        T Instance { get; set; }
    }

    private void Awake()
    {
        Instance = this;
    }

    protected virtual void OnEnable()
    {
    }

    public T Get()
    {
        if (objects.Count == 0)
        {
            AddObjects(1);
        }

        return objects.Dequeue();
    }

    protected void AddObjects(int count)
    {
        var newObject = GameObject.Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objects.Enqueue(newObject);
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }
}
