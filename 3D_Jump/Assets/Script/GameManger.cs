using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;

    public int point;

    private void Awake()
    {
        instance = this;
    }
    public void AddPoint()
    {
        point++;

        if (comboCount >= 2)
        {
            point = point + 1;
        }

        UIManager.instance.SetPoint(point);
    }

    // Start is called before the first frame update
    public void Init()
    {
        MoveFoothooldSpawner.instance.Init();

        PlayerController.instance.InitPlayer();

        UIManager.instance.OnclickRestart();

        UIManager.instance.SetPoint(point);

        backPos.instance.InitBackPos();

    }

    private int comboCount;

    public void Combo()
    {
        comboCount++;

        if (comboCount >= 2)
        {
            PlayerController.instance.showComboEffect();
        }
    }

    public void ComboFail()
    {
        comboCount = 0;
    }
}
