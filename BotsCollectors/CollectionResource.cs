using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectionResource : MonoBehaviour
{
    private int _quantityResources = 0;

    public bool IsCollected { get; private set; }

    public event UnityAction<int> CollectResource;

    public int QuantityResources => _quantityResources;

    public void OnGetResource()
    {
        _quantityResources++;
        CollectResource?.Invoke(_quantityResources);
    }

    public void TakeQuantityResource(int cost)
    {
        _quantityResources -= cost;
        CollectResource?.Invoke(_quantityResources);
    }

    public void Collect()
    {
        IsCollected = true;
    }
}