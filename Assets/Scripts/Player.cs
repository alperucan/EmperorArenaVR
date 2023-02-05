using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : Singleton<Player>,ISavable
{

    [SerializeField]public Inventory Inventory { get; private set; }
    [SerializeField]public Equipment Equipment { get; private set; }
    [SerializeField]public Stats Stats { get; private set; }
    [SerializeField] public Skills Skills { get; private set; }

    public void Awake()
    {
        Inventory = GetComponent<Inventory>();
        Equipment = GetComponent<Equipment>();
        Stats = GetComponent<Stats>();
        Skills = GetComponent<Skills>();
    }

    public object SaveData()
    {
        return new PlayerData()
        {
            //x = transform.position.x,
            //y = transform.position.y,
            //z = transform.position.z, 
            position = transform.position,
            rotation = transform.rotation
        };
    }

    public void LoadData(object data)
    {
        PlayerData playerData = (PlayerData)data;
       
        transform.position = playerData.position;
        transform.rotation = playerData.rotation;
    }
}
