using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskbarButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _program;

    public void OnClick()
    {
        if (Input.GetMouseButton(0))
        {
            _program.SetActive(false);
        }
        else
        {
            _program.SetActive(true);
        }
    }
}
