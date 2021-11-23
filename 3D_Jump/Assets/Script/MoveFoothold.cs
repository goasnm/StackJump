using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoothold : MonoBehaviour
{
    public static MoveFoothold instance;
    public float speed = 10;
    private int footholdCount = 0;
    private bool isMove;
    private Vector3 stopRotation = new Vector3(0,0,0);
    private ColliderFoothold colliderFoothold;
    private Direction direction;

    private void Awake()
    {
        instance = this;
        colliderFoothold = transform.Find("MoveFoothold1").GetComponent<ColliderFoothold>();
        colliderFoothold.Init(this);
    }
    public enum Direction
    {
        none, left,rigth
    };
    public void Init(Vector3 initRotation, float speed)
    {
        transform.Rotate(initRotation);

        this.speed = speed;
        isMove = true;
        //delayDestroy_ = StartCoroutine(delayDestroy(5));

        if (initRotation.y < 0) direction = Direction.left;
        else direction = Direction.rigth;
    }

    Coroutine delayDestroy_;
    private IEnumerator delayDestroy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveDirection());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPlayerEnter(Collision collision)
    {
        isMove = false;
        bool isFoot = false;
        Direction playerDirection = Direction.none;

        if (delayDestroy_ != null)
        {
            StopCoroutine(delayDestroy_);
        }

        if (transform.position.y + .11f < collision.transform.position.y && footholdCount < 1)
        {
            footholdCount++;
            isFoot = true;
        }
        else 
        {
            if (transform.position.x > collision.transform.position.x)
            {
                playerDirection = Direction.left;
            }
            else 
            {
                playerDirection = Direction.rigth;
            }
        }

        if (isFoot)
        {
            MoveFoothooldSpawner.instance.spawnUp();

            GameManger.instance.AddPoint();

            if (transform.rotation.eulerAngles.y > 359 || transform.rotation.eulerAngles.y < 2)
            {
                GameManger.instance.Combo();
            }
            else
            {
                GameManger.instance.ComboFail();
            }
        }
        else if (!isFoot)
        {
            PlayerController.instance.Fall(playerDirection);
        }

    }

    IEnumerator MoveDirection()
    {
        while(isMove)
        {
            transform.Rotate(new Vector3(0, speed * 10 * Time.deltaTime, 0));
            yield return null;

            if (direction == Direction.rigth)
            {
                if (transform.rotation.eulerAngles.y > 30) break;
            }
            else
            {
                if (0 < transform.rotation.eulerAngles.y && transform.rotation.eulerAngles.y < 30) break;
            }
        }
    }
}
