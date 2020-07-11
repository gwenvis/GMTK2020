using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseCursor : MonoBehaviour
{
    RectTransform rectTransform;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        rectTransform = GetComponent<RectTransform>();
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
    }
}
