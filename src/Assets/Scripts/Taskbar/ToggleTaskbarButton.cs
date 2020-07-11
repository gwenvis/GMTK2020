using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTaskbarButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _taskBarIcon;

    private void OnEnable()
    {
        _taskBarIcon.SetActive(true);
    }

    private void OnDestroy()
    {
        _taskBarIcon.SetActive(false);
    }
}
