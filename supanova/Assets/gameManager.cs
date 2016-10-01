using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour

{
    public float shipSpeed = .2f;
    public GameObject ship;
    public GameObject sun;
    public GameObject largeRock;
    public GameObject smallRock;
   // public GameObject[] rocks;
    public GameObject bigBoost;
    public GameObject smallBoost;
    public Transform spawnPoint;
    public float sunSpeed;
    public float boostSpeed;
    public float rockSpeed;
    public float gameClock;
    public float spawnRate;


	// Use this for initialization
	void Start ()
    {
        spawnRate = .3f;
        gameClock = 0;

	}
	
	// Update is called once per frame
	void Update ()
    {
        spawnRate -= Time.smoothDeltaTime;
        gameClock = gameClock + Time.smoothDeltaTime;
        if (spawnRate <= 0)
        {
            spawnRate = .3f;
            asteroidSpawn();
            boostSpawn();
        }

        
	}

    public void boostSpawn()
    {
        int boostType = Random.Range(1, 10);
        Vector2 spawnLine = new Vector2(spawnPoint.position.x, Random.Range(-5, 5));

        if (boostType == 1 || boostType == 2 || boostType == 3)
        {
            Instantiate(smallBoost, spawnLine, Quaternion.identity);
        }

        else if (boostType == 4)          
            Instantiate(bigBoost, spawnLine, Quaternion.identity);

    }

    public void asteroidSpawn()
    {
        //float spawnRate = 3f;
        int rockType = Random.Range(1, 6);
        Vector2 spawnLine = new Vector2(spawnPoint.position.x, Random.Range(-5, 5));

        if (rockType == 3 || rockType == 4 || rockType == 5 || rockType == 6)
        {
            Instantiate(smallRock, spawnLine, Quaternion.identity);
        }

        else
            Instantiate(largeRock, spawnLine, Quaternion.identity);



    }
}
