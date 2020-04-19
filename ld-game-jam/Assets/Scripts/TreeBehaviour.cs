using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeBehaviour : MonoBehaviour {

    [SerializeField] private int lifes = 15;
    [SerializeField] private Text lifesText; // show number in GUI

    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        lifesText.text = lifes.ToString(); //updates the life in GUI
    }

    // This is called every time the zombie animation it's in the middle. It
    // reduces the tree life by one. This can be changed later in game to increase difficulty
    public void ReduceLife() {
        if (lifes > 0) {
            lifes--;
        }
    }

    /* Called after the player picks up a watering can. Add 5 to life- This can be changed 
    later in game increase difficulty*/
    public void AddLife() {
        lifes += 5;
    }
}
