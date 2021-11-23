using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    new Rigidbody rigidbody;
    public float jumpForce = 500;
    public float maxJumpForce = 550;
    public float fallForce = 500;
    public int jumpCount = 0;
    private Vector3 initPos;
    public bool isClick = true;
    public GameObject ComboEffect;
    private bool isFoothold = true;
    public Animator animator;


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        instance = this;
        initPos = transform.position;
    }

    public void InitPlayer()
    {
        transform.position = initPos;
        rigidbody.velocity = Vector3.zero;
        transform.Rotate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        Die();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal.y > .5)
        {
            isFoothold = true;
            jumpCount = 0;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        isFoothold = false;
    }

    private void Die()
    {
        if (transform.position.y < 0 || transform.position.x < -5 || transform.position.x > 5)
        {
            GameManger.instance.Init();
        }
    }

    private void PlayerJump()
    {
        if (isClick && UIManager.instance.isStart && isFoothold)
        {
            if (Input.GetMouseButtonDown(0) && jumpCount < 1)
            {
                jumpCount++;
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(.0f, jumpForce, .0f);
            }
            else if (Input.GetMouseButtonUp(0) && rigidbody.velocity.y > 0)
            {
                rigidbody.velocity = rigidbody.velocity * .5f;
            }
        }
        animator.SetBool("isFoothold", isFoothold);
    }

    public void Fall(MoveFoothold.Direction direction)
    {
        if (direction == MoveFoothold.Direction.rigth)
        {
            rigidbody.AddForce(new Vector3(fallForce, fallForce, 0));
            isClick = false;
        }
        else
        {
            rigidbody.AddForce(new Vector3(-fallForce, fallForce, 0));
            isClick = false;
        }
    }

    public void showComboEffect()
    {
        GameObject newComboEffect = Instantiate(ComboEffect);
        newComboEffect.transform.position = transform.position;
        Destroy(newComboEffect, 0.5f);
    }
}
