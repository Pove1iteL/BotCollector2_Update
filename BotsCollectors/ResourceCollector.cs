using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceCollector : MonoBehaviour
{
    public event UnityAction<int> CollectResource;
    public bool IsDetected { get; private set; }
    public int QuantityResources => _quantityResources;

    private int _quantityResources = 0;

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

    public void CollectBase()
    {
        IsDetected = true;
    }
}