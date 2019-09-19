using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Optimizing the Unity by not instantiating objects but teleporting it.
/// </summary>
public class Pool : Singleton<Pool>
{
    [SerializeField]
    private List<Transform> children;

    /// <summary>
    /// Getting the component from the pool.
    /// </summary>
    /// <returns>component T</returns>
    public T GetObjectFromPool<T>() where T : MonoBehaviour
    {
        foreach (Transform child in children)
        {
            T _component = child.GetComponent<T>();

            if (_component != null)
            {

                child.transform.parent = null;
                children.Remove(child.transform);
                return _component;
            }
        }
        return default(T);
    }

    /// <summary>
    /// Return Object to the pool
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_component"></param>
    public void ReturnObjectToPool<T>(T _component) where T : MonoBehaviour
    {
        _component.gameObject.SetActive(false);
        children.Add(_component.transform);
    }
}
