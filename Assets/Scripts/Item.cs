using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Item : MonoBehaviour
{
    [SerializeField] private string definitionKey;
    public InventoryItem InventoryItem { get; private set; }
    public string DefinitionKey => definitionKey;
   
}
