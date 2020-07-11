using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorEvents : SingletonBehaviour<ErrorEvents>
{

    [SerializeField] private GameObject errorPrefab;

    private int currentErrors = 0;
    private int maxRandomErrors = 5;

    [Header("Multiple errors")]
    private float startXOffset = -200;
    private float startYOffset = 300;
    private float windowsOffset = 20;
    private float delay = 0.2f;

    public void StartErrorEvent()
    {
        CreateWindow();
    }

    public void ClosedWindow()
    {
        if (currentErrors < 0)
            return;

        currentErrors++;
        if (currentErrors < maxRandomErrors)
            RandomPlacement();
        else
            StartCoroutine(StackPlacement(10));
    }

    /// <summary>
    /// Create a new error window.
    /// </summary>
    /// <returns></returns>
    private GameObject CreateWindow()
    {
        SoundManager.Instance.PlaySound("Error");
        GameObject errorWindow = Instantiate(errorPrefab, transform);
        return errorWindow;
    }

    /// <summary>
    /// Place an error window at a random position on the screen.
    /// </summary>
    public void RandomPlacement()
    {
        GameObject errorWindow = CreateWindow();
        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);
        errorWindow.transform.position = new Vector2(randomX, randomY);
    }

    /// <summary>
    /// Placing multiple errors ontop of eachother.
    /// </summary>
    private IEnumerator StackPlacement(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(delay);
            GameObject errorWindow = CreateWindow();
            errorWindow.transform.position = new Vector2(-startXOffset + (windowsOffset * i), startYOffset - (windowsOffset * i));
        }

        currentErrors = -1;
    }
}
