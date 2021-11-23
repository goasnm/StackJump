using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFoothold : MonoBehaviour
{
    MoveFoothold parentMoveFoothold;

    public void Init(MoveFoothold moveFoothold)
    {
        parentMoveFoothold = moveFoothold;
    }

    private void OnCollisionEnter(Collision collision)
    {
        parentMoveFoothold.OnPlayerEnter(collision);
    }    
}
