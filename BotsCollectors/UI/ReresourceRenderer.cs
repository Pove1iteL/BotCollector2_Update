using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ReresourceRenderer : MonoBehaviour
{
    [SerializeField] private DetectorBases _detectorBases;

    private Text _resourceQuantityText;

    private void OnEnable()
    {
        if (_detectorBases.Bases != null)
        {
            foreach (var baseResource in _detectorBases.Bases)
            {
                baseResource.CollectResource += RendereResourceCount;
            }
        }
    }

    private void OnDisable()
    {
        if (_detectorBases.Bases != null)
        {
            foreach (var baseResource in _detectorBases.Bases)
            {
                baseResource.CollectResource -= RendereResourceCount;
            }
        }
    }

    private void Awake()
    {
        _detectorBases.DetectBase();
        _resourceQuantityText = GetComponent<Text>();
    }

    public void RendereResourceCount(int count)
    {
        _resourceQuantityText.text = count.ToString();
    }
}
