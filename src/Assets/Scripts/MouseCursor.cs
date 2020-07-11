using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseCursor : MonoBehaviour
{

    float timeOfTravel = 5;
    float currentTime = 0; 
    float normalizedValue;
    Vector3 newPos;
    RectTransform rectTransform;

    float x;
    float y;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            x = Random.Range(0, 10);
            y = Random.Range(0, 10);

            newPos = new Vector3(x, y, 0);

            StartCoroutine(LerpObject());
        }
    }

    IEnumerator LerpObject()
    {
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;

            rectTransform.anchoredPosition = Vector3.Lerp(transform.position, newPos, normalizedValue);
            yield return null;
        }
    }
}
