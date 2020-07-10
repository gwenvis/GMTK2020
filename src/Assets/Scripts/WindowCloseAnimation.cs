using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCloseAnimation : MonoBehaviour
{
    [SerializeField] private float closeSpeed = 2f;

    private Action callback;
    private bool animating;

    private RectTransform t;

    private void Start()
    {
        t = GetComponent<RectTransform>();
    }

    public void StartClosure(Action callback)
    {
        this.callback = callback;

        animating = true;
    }

    private void Update()
    {
        if (!animating)
            return;

        float currentScale = t.localScale.x;
        float newScale = Mathf.MoveTowards(currentScale, 0, closeSpeed * Time.deltaTime);
        t.localScale = new Vector3(newScale, newScale, 1);

        if(Mathf.Approximately(newScale, 0))
        {
            callback();
        }
    }
}
