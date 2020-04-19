using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeBehaviour : MonoBehaviour {

    [SerializeField] private int lifes = 15;
    [SerializeField] private Text lifesText;

    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        lifesText.text = lifes.ToString();
    }

    public void ReduceLife() {
        if (lifes > 0) {
            lifes--;
        }
    }
    public void AddLife() {
        lifes += 5;
    }
}
