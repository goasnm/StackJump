using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public Text textStart;
    public Text textPoint;
    public bool isStart = false;

    private void Awake()
    {
        instance = this;
    }

    public void OnclickStart()
    {
        PlayerController.instance.isClick = true;
        isStart = true;
        MoveFoothooldSpawner.instance.startSpawn();
        textStart.gameObject.SetActive(false);
        GameManger.instance.point = 0;
        textPoint.text = "0";
    }

    public void OnclickRestart()
    {
        isStart = false;
        textStart.gameObject.SetActive(true);

        // ÄÞº¸ ÃÊ±âÈ­
        GameManger.instance.ComboFail();
    }

    public void SetPoint(int point)
    {
        textPoint.text = string.Format("{0:n0}", point);
    }
}
