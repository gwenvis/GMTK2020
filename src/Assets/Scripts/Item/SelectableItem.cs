using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SelectableItem : MonoBehaviour, IPointerClickHandler
{
    private const float DOUBLE_CLICK_TIME = 0.35f;
    private static SelectableItem selectedItem;

    private bool clicked;
    private float clickedTime;

    public virtual void Select()
    {           
        selectedItem?.DeSelect();
        selectedItem = this;
    }

    public virtual void DoubleClicked() 
    {
        if (selectedItem != this)
            Select();    
    }

    public virtual void DeSelect()
    {
        selectedItem = null;
    }

    protected void Update()
    {
        if (clicked && Time.time > clickedTime + DOUBLE_CLICK_TIME)
            clicked = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clicked && Time.time < clickedTime + DOUBLE_CLICK_TIME)
        {
            DoubleClicked();
            clicked = false;
        }
        else
        {
            clicked = true;
            clickedTime = Time.time;
            Select();
        }
    }
}
