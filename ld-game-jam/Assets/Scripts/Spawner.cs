using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject bush;
    public GameObject seed;
    public GameObject watercan;
    public GameObject fertilizer;
    public GameObject energy;
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
            chose = Mathf.RoundToInt(Random.Range(0f, 21f));

            Instantiate(fertilizer, new Vector3(puntos[chose].x, puntos[chose].y, 0), Quaternion.identity);
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
        puntos.Add(new Vector2(0f, 13.19f));
        puntos.Add(new Vector2(-10.65f, 9.51f));
        puntos.Add(new Vector2(13.78f, 9.57f));
        puntos.Add(new Vector2(13.83f, 16.27f));
        puntos.Add(new Vector2(5.02f, 16.16f));
        puntos.Add(new Vector2(-6.6f, 16.16f));
        puntos.Add(new Vector2(-13.25f, 12.97f));
        puntos.Add(new Vector2(-7.25f, 13.19f));
        puntos.Add(new Vector2(0.16f, 13.19f));
        puntos.Add(new Vector2(12.92f, 8.91f));
        puntos.Add(new Vector2(-1.35f, 9.56f));
        puntos.Add(new Vector2(4.92f, 9.61f));
        puntos.Add(new Vector2(-9.13f, 5.07f));
        puntos.Add(new Vector2(-3.62f, 5.29f));
        puntos.Add(new Vector2(13.47f, 6.1f));
        puntos.Add(new Vector2(9.2f, 5.56f));
        puntos.Add(new Vector2(12.98f, 2.97f));
        puntos.Add(new Vector2(-13.34f, 2.16f));
        puntos.Add(new Vector2(-8.2f, 2.27f));
        puntos.Add(new Vector2(-2.74f, 2.47f));
        puntos.Add(new Vector2(13.96f, 2.54f));
        puntos.Add(new Vector2(6.55f, 2.32f));
    }
}
