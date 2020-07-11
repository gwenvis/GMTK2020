using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorWindow : MonoBehaviour
{
    public void OnWindowClose()
    {
        ErrorEvents.Instance.ClosedWindow();
    }
}
