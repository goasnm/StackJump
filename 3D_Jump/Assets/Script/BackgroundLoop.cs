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
        //BoxCollider2D 컴포넌트의 Size필드의 x값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        down = backgroundCollider.size.y;
    }

    private void Update()
    {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을때 위치를 리셋
        if (transform.localPosition.y <= -down)
        {
            Reposition();
        }
    }

    // 위치를 리셋하는 메서드
    private void Reposition()
    {
        //현재 위치에서 오른쪽으로 가로 길이 *2만큼 이동
        Vector3 offset = new Vector3(0, down * 2f,0);
        transform.localPosition = (Vector3)transform.localPosition + offset;
    }
}

