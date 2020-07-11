using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseCursor : MonoBehaviour
{
    public BoxCollider2D collider;

    private RectTransform rectTransform;

    private float BoundaryMinX;
    private float BoundaryMaxX;
    private float BoundaryMinY;
    private float BoundaryMaxY;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        rectTransform = GetComponent<RectTransform>();

        BoundaryMinX = collider.offset.x - (collider.size.x / 2f);
        BoundaryMaxX = collider.offset.x + (collider.size.x / 2f);
        
        BoundaryMinY = collider.offset.y - (collider.size.y / 2f);
        BoundaryMaxY = collider.offset.y + (collider.size.y / 2f);
    }

    void Update()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        Vector3 pos = rectTransform.anchoredPosition;
        pos.x += mouseX * 6;
        pos.y += mouseY * 6;
        rectTransform.anchoredPosition = pos;

        rectTransform.anchoredPosition = new Vector3(Mathf.Clamp(rectTransform.anchoredPosition.x, BoundaryMinX, BoundaryMaxX), Mathf.Clamp(rectTransform.anchoredPosition.y, BoundaryMinY, BoundaryMaxY), 0);
    }
}
