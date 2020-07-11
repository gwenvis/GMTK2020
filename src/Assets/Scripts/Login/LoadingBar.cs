using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadingBar : MonoBehaviour
{

    [SerializeField] private float itemWidth;
    [SerializeField] private float startX;
    [SerializeField] private float endX;
    [SerializeField] private float speed = 3;
    private float posY;

    public UnityEvent callback;
    [SerializeField] private float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y;
        MoveBar();
    }

    private void Update()
    {
        if (maxTime <= 0) return;
        maxTime -= Time.deltaTime;
        if (maxTime <= 0)
        {
            callback.Invoke();
        }
    }

    private void MoveBar()
    {
        if (transform.localPosition.x >= endX)
            transform.localPosition = new Vector2(startX, posY);

        transform.position = new Vector2(transform.position.x + itemWidth, posY);
        Invoke("MoveBar", speed);
    }
}
