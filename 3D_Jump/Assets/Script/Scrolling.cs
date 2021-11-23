using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public static Scrolling instance;
    public float speed = 10f; // 이동 속도

    private void Awake()
    {
        instance = this;
    }


    private void Update()
        {
            //초당 speed의 속도로 왼쪽으로 평행이동
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    
}
