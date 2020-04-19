using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start() {
        Instantiate(myPrefab, new Vector3(0.855f, 1.505f, 0), Quaternion.identity);
    }

    void SpawnMinitrees(bool left) {
        if (left) {
            Instantiate(myPrefab, new Vector3(0.855f, 1.505f, 0), Quaternion.identity);
        }
        else {
            Instantiate(myPrefab, new Vector3(-0.855f, 1.505f, 0), Quaternion.identity);
        }
    }

    void SpawnLV1() {

    }

    // Update is called once per frame
    void Update(){
        
    }
}
