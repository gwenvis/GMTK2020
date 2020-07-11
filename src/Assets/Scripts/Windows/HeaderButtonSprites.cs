using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HeaderButtonSprites : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite DepressedButtonSprite;
    [SerializeField] private Sprite PressedButtonSprite;

    private Image button;

    public void OnPointerDown(PointerEventData eventData)
    {
        button.sprite = PressedButtonSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.sprite = DepressedButtonSprite;
    }

    protected void Awake()
    {
        button = GetComponent<Image>();
    }
}
