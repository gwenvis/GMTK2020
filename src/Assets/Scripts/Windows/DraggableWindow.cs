using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableWindow : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private BoxCollider2D header;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button maximizeButton; // might be unused as it's kind of useless
    [SerializeField] private Button minimizeButton; // might be unused?

    private Vector2 lastMousePos;
    private RectTransform rectTransform;
    private Vector3 position;

    private bool dragging = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        exitButton.onClick.AddListener(OnExitButtonClicked);
        position = rectTransform.position;
    }

    private void OnDestroy()
    {
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void LateUpdate()
    {
        rectTransform.position = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.z));
    }

    private void OnExitButtonClicked()
    {
        GetComponent<WindowCloseAnimation>().StartClosure(CloseWindow);
    }

    private void CloseWindow()
    {
        Destroy(gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Clicked");

        if(!header) return;

        if(header.OverlapPoint(eventData.position))
        {
            Debug.Log("In header");

            dragging = true;
            lastMousePos = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging)
            return;

        Vector2 mousePos = eventData.position;
        Vector3 vec = mousePos - lastMousePos;

        position += vec;
        lastMousePos = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
    }
}
