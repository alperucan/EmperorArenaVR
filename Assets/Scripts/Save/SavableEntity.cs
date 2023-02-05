using System;
using UnityEngine;
using System.Collections.Generic;

public class SavableEntity : MonoBehaviour
{
    [SerializeField] private  string id;
    public string Id => id;

    public object SaveData()
    {
        var data = new Dictionary<string, object>();
        foreach (var savable in GetComponents<ISavable>())
        {
            data[savable.GetType().ToString()] = savable.SaveData();
        }

        return data;
    }

    public void LoadData(object data)
    {
        var dict = data as Dictionary<string, object>;
        foreach (var savable in GetComponents<ISavable>())
        {
            if (dict.TryGetValue(savable.GetType().ToString(), out object value))
            {
                savable.LoadData(value);
            }
        }
    }
    private void Reset()
    {
        id = Guid.NewGuid().ToString();
    }
}
