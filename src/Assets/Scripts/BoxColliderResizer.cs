using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BoxColliderResizer : MonoBehaviour
{
    private RectTransform rectTransform;
    private BoxCollider2D boxCollider;

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        boxCollider = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();

        Debug.Log(rectTransform.sizeDelta);

        boxCollider.size = rectTransform.sizeDelta;
        boxCollider.offset = new Vector2(0, boxCollider.size.y / 2 * -1);
    }
}
