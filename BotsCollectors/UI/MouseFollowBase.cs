using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowBase : MonoBehaviour
{
    private Vector3 _minCanmeraScale;
    private Vector3 _maxCanmeraScale;

    private void Awake()
    {
        gameObject.SetActive(false);

        _maxCanmeraScale = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane));
        _minCanmeraScale = Camera.main.ViewportToWorldPoint(new Vector3(0f, -1f, Camera.main.nearClipPlane));
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePosition.x <= _maxCanmeraScale.x && mousePosition.y <= _maxCanmeraScale.y &&
                mousePosition.x >= _minCanmeraScale.x && mousePosition.x >= _minCanmeraScale.y)
            {
                transform.position = mousePosition;

            }

            if (Input.GetMouseButtonDown(0))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
