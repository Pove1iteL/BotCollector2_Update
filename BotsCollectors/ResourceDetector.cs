using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDetector : MonoBehaviour
{
    [SerializeField] private float _detectionDelay = 1f;
    [SerializeField] private LayerMask _resourceLayerMask;

    private int _limitResource = 100;
    private float _radius = 100;

    private List<Resource> _resources = new List<Resource>();

    private void Start()
    {
        StartCoroutine(FindResource());
    }

    public bool TryGetResource(out Resource resource)
    {
        if (_resources.Count == 0)
        {
            resource = null;
            return false;
        }

        var res = _resources[0];
        _resources.Remove(res);

        resource = res;

        return true;
    }

    private IEnumerator FindResource()
    {
        WaitForSeconds waiter = new WaitForSeconds(_detectionDelay);

        while (_resources.Count <= _limitResource)
        {
            DetectResources();
            yield return waiter;
        }
    }

    private void DetectResources()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _resourceLayerMask);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out Resource res))
            {
                if (_resources.Contains(res) == false)
                {
                    if (res.IsCollected == false)
                    {
                        res.Collect();
                        _resources.Add(res);
                    }
                }
            }
        }
    }
}