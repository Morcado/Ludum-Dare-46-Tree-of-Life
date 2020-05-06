using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject bush = null;
    [SerializeField] private GameObject seed;
    [SerializeField] private GameObject watercan;
    [SerializeField] private GameObject fertilizer;
    [SerializeField] private GameObject energy;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject fire;
    private float fertilizerSpawnTime = 3.0f;
    private float bushSpawnTime = 2.0f;
    private float fireSpawnTime = 3.0f;
    private List<Vector2> puntos = new List<Vector2>();
    [SerializeField] private GameObject enemies;
    [SerializeField] private GameObject collectibles;

    // Start is called before the first frame update
    void Start() {
        // level 1.
        AddPoints();
    }

    public void SpawnBush(bool left) {
        if (left) {
            Instantiate(bush, new Vector3(0.855f, 1.505f, 0), Quaternion.identity);
        }
        else {
            Instantiate(bush, new Vector3(-0.855f, 1.505f, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update(){
        SpawnLV1();
    }

    void SpawnLV1() {
        int chose;
        if (GameObject.FindWithTag("Bush") != null) {
            bushSpawnTime -= Time.deltaTime;
            if(bushSpawnTime < 0){
                bushSpawnTime = 7f;
                Destroy(GameObject.FindWithTag("Bush"));
            }
            //Instantiate(bush, new Vector3(0.855f, 1.505f, 0), Quaternion.identity);
        }
        if (GameObject.FindWithTag("WaterCan") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            var collectible = Instantiate(watercan, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            collectible.transform.parent = collectibles.transform;
        }

        if (GameObject.FindWithTag("Fertilizer") == null) {
            fertilizerSpawnTime -= Time.deltaTime;
            if(fertilizerSpawnTime < 0) {
                chose = Mathf.RoundToInt(Random.Range(0f, 10f));
                var collectible = Instantiate(fertilizer, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
                collectible.transform.parent = collectibles.transform;
                chose = Mathf.RoundToInt(Random.Range(0f, 10f));
                var collectible2 = Instantiate(fertilizer, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
                collectible2.transform.parent = collectibles.transform;
            }
        }
        if (GameObject.FindWithTag("Seed") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            var collectible = Instantiate(seed, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            collectible.transform.parent = collectibles.transform;
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            var collectible2 = Instantiate(seed, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            collectible2.transform.parent = collectibles.transform;
        }
        if (GameObject.FindWithTag("Energy") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            var collectible = Instantiate(energy, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            collectible.transform.parent = collectibles.transform;
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            var collectible2 = Instantiate(energy, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            collectible2.transform.parent = collectibles.transform;
        }
        if (GameObject.FindWithTag("Skeleton") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            var enemy = Instantiate(skeleton, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            enemy.transform.parent = enemies.transform;
        }
        if (GameObject.FindWithTag("Zombie") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            var enemy = Instantiate(zombie, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            enemy.transform.parent = enemies.transform;
        }
        if (GameObject.FindWithTag("Fire") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            var enemy = Instantiate(fire, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            enemy.transform.parent = enemies.transform;
        }
    }

    void AddPoints() {
        switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name) {
            case "SampleScene": 
                puntos.Add(new Vector2(-8.59f, 1.96f));
                puntos.Add(new Vector2(10.26f, 2.03f));
                puntos.Add(new Vector2(-9.67f, 13.32f));
                puntos.Add(new Vector2(-0.5f, 13.06f));
                puntos.Add(new Vector2(9.56f, 13.17f));
                puntos.Add(new Vector2(9.67f, 9.11f));
                puntos.Add(new Vector2(-0.24f, 8.93f));
                puntos.Add(new Vector2(-10f, 9f));
                puntos.Add(new Vector2(-14.43f, 10.04f));
                puntos.Add(new Vector2(-6.9f, 5.09f));
                puntos.Add(new Vector2(13.48f, 6.13f));
            break;
            case "SecondStage":        
                puntos.Add(new Vector2(-0.01f, 11.93f));
                puntos.Add(new Vector2(-9.23f, 12.98f));
                puntos.Add(new Vector2(-9.02f, 12.95f));
                puntos.Add(new Vector2(10.44f, 8.01f));
                puntos.Add(new Vector2(-9.1f, 7.86f));
                puntos.Add(new Vector2(-14.05f, 9.85f));
                puntos.Add(new Vector2(-12.84f, 4.96f));
                puntos.Add(new Vector2(-5.06f, 5.08f));
                puntos.Add(new Vector2(10.81f, 4.9f));
                puntos.Add(new Vector2(-13.58f, 1.92f));
                puntos.Add(new Vector2(11.81f, 1.93f));
            break;
            case "ThirdStage": 
                puntos.Add(new Vector2(-0.01f, 3.93f));
                puntos.Add(new Vector2(10.23f, 2.98f));
                puntos.Add(new Vector2(-10.02f, 2.2f));
                puntos.Add(new Vector2(14.3f, 6.72f));
                puntos.Add(new Vector2(-14.23f, 1.63f));
                puntos.Add(new Vector2(-14.23f, 6.56f));
                puntos.Add(new Vector2(-12.84f, 6.56f));
                puntos.Add(new Vector2(-5.06f, 6.08f));
                puntos.Add(new Vector2(10.81f, 6.0f));
                puntos.Add(new Vector2(-13.58f, 2.2f));
                puntos.Add(new Vector2(11.81f, 2.2f));
            break;
        }
         
        
        
    }
}
