using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backPos : MonoBehaviour
{
    private Vector3 InitPos;
    public static backPos instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        InitPos = transform.position;
    }

    public void InitBackPos()
    {
        transform.position = InitPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
