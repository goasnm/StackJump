using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoothooldSpawner : MonoBehaviour
{
    public float speed;
    public MoveFoothold moveFoothold;
    public static MoveFoothooldSpawner instance;
    public GameObject target;
    public Vector3 initRoation = new Vector3(0, 0, 0);
    //public Transform[] spawnerPos;
    private Vector3 InitPos;
    private List<MoveFoothold> FootholdList = new List<MoveFoothold>();


    private void Awake()
    {
        InitPos = new Vector3(0, 0.3f, 10);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Init()
    {
        transform.position = InitPos;
        DestroyAllFoothold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSpawn()
    {
        spawnFoothold();
    }

    public void spawnFoothold()
    {
        int pos = Random.Range(0, 2);
        if (pos == 0)
        {
            speed = Random.Range(2f, 3f);
            initRoation = new Vector3(0, -30, 0);
        }
        else
        {
            speed = Random.Range(-2f, -3f);
            initRoation = new Vector3(0, 30, 0);
        }
        MoveFoothold newFoothold = Instantiate(moveFoothold);
        newFoothold.transform.position = transform.position;


        newFoothold.Init(initRoation, speed);
        FootholdList.Add(newFoothold);

        
    }




    public void spawnUp()
    {
        transform.position = new Vector3(transform.position.x,
            transform.position.y + 0.3f, transform.position.z);
        spawnFoothold();
    }

    public void DestroyAllFoothold()
    {
        foreach (var iter in FootholdList)
        {
            Destroy(iter.gameObject);
        }
        FootholdList.Clear();
    }

}
