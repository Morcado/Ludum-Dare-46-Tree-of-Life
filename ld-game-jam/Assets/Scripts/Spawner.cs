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
    private float timeLeft2 = 2.0f;
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
        if (GameObject.FindWithTag("Bush") != null) {
            timeLeft2 -= Time.deltaTime;
            if(timeLeft2 < 0){
                timeLeft2 = 7f;
                Destroy(GameObject.FindWithTag("Bush"));
            }
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
                puntos.Add(new Vector2(-13.01f, -6.52f));
                puntos.Add(new Vector2(-9.23f, 5.98f));
                puntos.Add(new Vector2(14.02f, -6.55f));
                puntos.Add(new Vector2(10.44f, -3.54f));
                puntos.Add(new Vector2(-9.1f, 4.86f));
                puntos.Add(new Vector2(-14.05f, 1.34f));
                puntos.Add(new Vector2(-12.84f, 4.96f));
                puntos.Add(new Vector2(-5.06f, 5.08f));
                puntos.Add(new Vector2(10.81f, 4.9f));
                puntos.Add(new Vector2(-9.58f, -0.73f));
                puntos.Add(new Vector2(12.81f, -0.73f));
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
