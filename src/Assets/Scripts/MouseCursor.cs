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

        if (!collider)
            return;

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
        pos.x += mouseX * 2;
        pos.y += mouseY * 2;


        if(collider)
            rectTransform.anchoredPosition = new Vector3(Mathf.RoundToInt(Mathf.Clamp(pos.x, BoundaryMinX, BoundaryMaxX)),
                                                     Mathf.RoundToInt(Mathf.Clamp(pos.y, BoundaryMinY, BoundaryMaxY)),
                                                     0);
        else
            rectTransform.anchoredPosition = new Vector3(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y), Mathf.Round(pos.z));

    }
}
