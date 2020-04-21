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
    private float timeLeft = 3.0f;
    private List<Vector2> puntos = new List<Vector2>();

    // Start is called before the first frame update
    void Start() {
        // level 1.
        AddPoints();
    }

    public void SpawnMinitrees(bool left) {
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
        if (GameObject.FindWithTag("Bush") == null) {
            
            //Instantiate(bush, new Vector3(0.855f, 1.505f, 0), Quaternion.identity);
        }
        if (GameObject.FindWithTag("WaterCan") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            Instantiate(watercan, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
        }

        if (GameObject.FindWithTag("Fertilizer") == null) {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0) {
                chose = Mathf.RoundToInt(Random.Range(0f, 10f));

                Instantiate(fertilizer, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            }
        }
        if (GameObject.FindWithTag("Seed") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            Instantiate(seed, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
        }
        if (GameObject.FindWithTag("Energy") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            Instantiate(energy, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
        }
        if (GameObject.FindWithTag("Skeleton") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            Instantiate(skeleton, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
        }
        if (GameObject.FindWithTag("Zombie") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            Instantiate(zombie, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
        }
        if (GameObject.FindWithTag("Fire") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 10f));
            Instantiate(fire, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
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
                puntos.Add(new Vector2(-14.43f, 9.04f));
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
                puntos.Add(new Vector2(11.81f, 1.9f));
            break;
            case "ThirdStage": 
                puntos.Add(new Vector2(-1.89f, 14f));
                puntos.Add(new Vector2(-6.93f, 11.92f));
                puntos.Add(new Vector2(6.99f, 12.01f));
                puntos.Add(new Vector2(-11.4f, 8.96f));
                puntos.Add(new Vector2(11.58f, 8.96f));
                puntos.Add(new Vector2(-0.04f, 9.98f));
                puntos.Add(new Vector2(-6.71f, 5.91f));
                puntos.Add(new Vector2(6.42f, 6f));
                puntos.Add(new Vector2(-12.05f, 2.02f));
                puntos.Add(new Vector2(12.05f, 1.98f));
                puntos.Add(new Vector2(2.22f, 1f));
            break;
        }
         
        
        
    }
}
