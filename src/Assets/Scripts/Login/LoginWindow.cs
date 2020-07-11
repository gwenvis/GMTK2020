using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginWindow : MonoBehaviour
{

    [SerializeField] private InputField username;
    [SerializeField] private InputField password;

    [SerializeField] private GameObject login;
    [SerializeField] private GameObject loadingBar;

    public void OnConfirm()
    {
        if (username.text != "" && password.text != "")
        {
            login.SetActive(false);
            loadingBar.SetActive(true);
        }
    }

    public void SwitchScene()
    {
        Application.LoadLevel(1);
    }
}
