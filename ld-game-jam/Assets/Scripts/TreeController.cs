using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : MonoBehaviour {

    [SerializeField] private int lifes = 15;
    [SerializeField] private Text lifesText = null; // show number in GUI

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

    public void GrowTree() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hit trigger");
        if (other.gameObject.tag == "Fireball") {
            ReduceLife();
            // GameObject.FindWithTag("Tree").GetComponent<TreeController>().ReduceLife();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("hit collision");
        if (other.gameObject.tag == "Fireball") {
            ReduceLife();
        }
        // GameObject.FindWithTag("Fireball").GetComponent<TreeController>().ReduceLife();

    }
}
