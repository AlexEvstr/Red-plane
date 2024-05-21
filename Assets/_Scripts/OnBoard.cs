using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBoard : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _onboard;
    [SerializeField] private GameObject _onBoard_0;
    [SerializeField] private GameObject _onBoard_1;
    [SerializeField] private GameObject _onBoard_2;
    [SerializeField] private GameObject _onBoard_3;

    private void Start()
    {
        string enter = PlayerPrefs.GetString("enter", "");
        if (enter == "")
        {
            _menu.SetActive(false);
            _onboard.SetActive(true);
        }
        else
        {
            _menu.SetActive(true);
            _onboard.SetActive(false);
        }
    }

    public void Open1()
    {
        _onBoard_0.SetActive(false);
        _onBoard_1.SetActive(true);
    }

    public void Open2()
    {
        _onBoard_1.SetActive(false);
        _onBoard_2.SetActive(true);
    }

    public void Open3()
    {
        _onBoard_2.SetActive(false);
        _onBoard_3.SetActive(true);
    }

    public void OpenMenu()
    {
        _onboard.SetActive(false);
        _menu.SetActive(true);
        PlayerPrefs.SetString("enter", "was");
    }
}
