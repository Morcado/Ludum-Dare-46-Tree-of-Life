using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private GameObject bush = null;
    [SerializeField] private GameObject seed;
    [SerializeField] private GameObject watercan;
    [SerializeField] private GameObject fertilizer;
    [SerializeField] private GameObject energy;
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
            chose = Mathf.RoundToInt(Random.Range(0f, 21f));
            Instantiate(watercan, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
        }

        if (GameObject.FindWithTag("Fertilizer") == null) {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0) {
                chose = Mathf.RoundToInt(Random.Range(0f, 21f));

                Instantiate(fertilizer, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
            }
        }
        if (GameObject.FindWithTag("Seed") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 21f));
            Instantiate(seed, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
        }
        if (GameObject.FindWithTag("Energy") == null) {
            chose = Mathf.RoundToInt(Random.Range(0f, 21f));
            Instantiate(energy, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
        }
    }

    void AddPoints() {
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
        
    }
}
