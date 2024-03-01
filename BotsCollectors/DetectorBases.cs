using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBases : MonoBehaviour
{
    [SerializeField] private Transform _basePoint;
    [SerializeField] private BaseBuilerSystem _baseCreator;
    [SerializeField] private LayerMask _baseLayerMask;

    public List<ResourceCollector> Bases => _bases;

    private List<ResourceCollector> _bases = new List<ResourceCollector>();
    private float _radius = 100f;

    private void OnEnable()
    {
        _baseCreator.NewBaseBuilded += DetectBase;
    }

    private void OnDisable()
    {
        _baseCreator.NewBaseBuilded -= DetectBase;
    }

    public void DetectBase()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_basePoint.position, _radius, _baseLayerMask);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out ResourceCollector resourceCollection))
            {
                if (_bases.Contains(resourceCollection) == false)
                {
                    if (resourceCollection.IsDetected == false)
                    {
                        resourceCollection.CollectBase();
                        _bases.Add(resourceCollection);
                    }
                }
            }
        }
    }
}
