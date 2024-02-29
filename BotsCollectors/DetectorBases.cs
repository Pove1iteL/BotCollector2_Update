using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBases : MonoBehaviour
{
    [SerializeField] private Transform _findingBasePoint;
    [SerializeField] private BuildBaseSystem _buildBase;

    private List<CollectionResource> _bases = new List<CollectionResource>();
    private float _radius = 100f;
    public List<CollectionResource> Bases => _bases;

    private void OnEnable()
    {
        _buildBase.NewBase += DetectBase;
    }

    private void OnDisable()
    {
        _buildBase.NewBase -= DetectBase;
    }

    public void DetectBase()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_findingBasePoint.position, _radius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out CollectionResource resourceCollection))
            {
                if (!_bases.Contains(resourceCollection))
                {
                    if (resourceCollection.IsCollected == false)
                    {
                        resourceCollection.Collect();
                        _bases.Add(resourceCollection);

                        Debug.Log(_bases.Count + " - Количество баз");

                    }
                }
            }
        }
    }
}
