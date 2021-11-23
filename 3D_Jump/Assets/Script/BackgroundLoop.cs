using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    //    private float top;

    //    // Start is called before the first frame update
    //    private void Awake()
    //    {
    //        //BoxCollider BackgroundCollider = GetComponent<BoxCollider>();
    //        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
    //        top = boxCollider2D.size.x;
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        if (transform.position.x <= -top)
    //        {
    //            Reposition();
    //        }
    //    }

    //    private void Reposition()
    //    {
    //        //Vector3 offset = new Vector3(0, top * 2f, 0);
    //        //transform.position = transform.position + offset;

    //        Vector2 offset = new Vector2(top * 2f, 0f);
    //        transform.position = (Vector2)transform.position + offset;

    //    }

    private float down;

    private void Awake()
    {
        //BoxCollider2D ������Ʈ�� Size�ʵ��� x���� ���� ���̷� ���
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        down = backgroundCollider.size.y;
    }

    private void Update()
    {
        // ���� ��ġ�� �������� �������� width �̻� �̵������� ��ġ�� ����
        if (transform.localPosition.y <= -down)
        {
            Reposition();
        }
    }

    // ��ġ�� �����ϴ� �޼���
    private void Reposition()
    {
        //���� ��ġ���� ���������� ���� ���� *2��ŭ �̵�
        Vector3 offset = new Vector3(0, down * 2f,0);
        transform.localPosition = (Vector3)transform.localPosition + offset;
    }
}

