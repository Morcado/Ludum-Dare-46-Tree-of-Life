using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject bush;
    public GameObject seed;
    public GameObject watercan;
    public GameObject fertilizer;

    // Start is called before the first frame update
    void Start() {
        // level 1.

    }

    public void SpawnMinitrees(bool left) {
        if (left) {
            Instantiate(bush, new Vector3(0.855f, 1.505f, 0), Quaternion.identity);
        }
        else {
            Instantiate(bush, new Vector3(-0.855f, 1.505f, 0), Quaternion.identity);
        }
    }

    void SpawnLV1() {
        if (GameObject.FindWithTag("Bush") != null) {

        }
        if (GameObject.FindWithTag("WaterCan") != null) {

        }
        if (GameObject.FindWithTag("Fertilizer") != null) {

        }
        if (GameObject.FindWithTag("Energy") != null) {
            
        }
    }

    // Update is called once per frame
    void Update(){
        SpawnLV1();
    }
}
