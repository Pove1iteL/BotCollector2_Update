using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBase : MonoBehaviour
{
    private const string LayerPlaceable = "Placeable";

    [SerializeField] private Flag _flagPrefab;

    private BaseControllerFlag _currentflagHandler;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hitInfo.collider.gameObject.layer.Equals(LayerMask.NameToLayer(LayerPlaceable)))
                {
                    if (_currentflagHandler == null)
                        return;

                    if (_currentflagHandler.IsFlagPlaced == false && _currentflagHandler.IsHaveFlag)
                    {
                        PlaceFlag(hitInfo);
                    }
                    else
                    {
                        ReplaceFlag(hitInfo);
                    }

                    _currentflagHandler = null;
                }
                else if (hitInfo.collider.TryGetComponent(out BaseControllerFlag flagHandler))
                {
                    _currentflagHandler = flagHandler;
                }
            }
        }
    }

    private void ReplaceFlag(RaycastHit hitInfo)
    {
        _currentflagHandler.Flag.transform.position = hitInfo.point;
    }

    private void PlaceFlag(RaycastHit hitInfo)
    {
        Flag flag = Instantiate(_flagPrefab, hitInfo.point, Quaternion.identity);
        _currentflagHandler.SetFlag(flag);
    }
}
