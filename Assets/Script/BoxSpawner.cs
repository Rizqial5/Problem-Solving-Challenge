using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] boxPrefabs;
    public GameObject[] box;
    public double gainScore;

    public GameManager gameManager;
    public float spawnTime = 3.0f;

    //public float spawnRefresher = 10.0f;


    private void Start()
    {
        StartSpawnBox();
    }

    private void Update()
    {
        
    }

    //problem6-----------------------
    private void StartSpawnBox()
    {
        bool isBoxSpawned = false;
        int totalBox = Random.Range(0, 5);

        while (!isBoxSpawned)
        {
            Vector3 BoxPosition = new Vector3(Random.Range(-4f, 4f), Random.Range(-3.5f, 3.5f), 0);
            box = new GameObject[boxPrefabs.Length];
            if ((BoxPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                for (int i = 1; totalBox < boxPrefabs.Length; totalBox += i)
                {
                    Vector3 _boxPosition = new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(-3.0f, 3.0f), 0);
                    box[totalBox] = Instantiate(boxPrefabs[totalBox], _boxPosition, Quaternion.identity) as GameObject;

                }
                isBoxSpawned = true;
            }
        }
    }
    //problem6-----------------------


    //problem8---------------------------------------------------------
    void SpawnBox()
    {
        Vector3 BoxPosition = new Vector3(Random.Range(-4f, 4f), Random.Range(-3.5f, 3.5f), 0);
        int randomBox = Random.Range(0, 6);

        if((BoxPosition - transform.position).magnitude > 1)
        {
            Instantiate(boxPrefabs[randomBox], BoxPosition , Quaternion.identity);
        }
    }
    //problem8---------------------------------------------------------

    //Problem7----------------------------------------
    public void AddScore()
    {
        double value = 0;
        value += gainScore;
        gameManager.ScoreIncrement(value);
    }
    //Problem7----------------------------------------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);//Problem7----------------------------------------
        AddScore();

        Invoke("SpawnBox", spawnTime);//Problem8
       
    }
}
