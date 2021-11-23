using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public static Scrolling instance;
    public float speed = 10f; // �̵� �ӵ�

    private void Awake()
    {
        instance = this;
    }


    private void Update()
        {
            //�ʴ� speed�� �ӵ��� �������� �����̵�
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    
}
