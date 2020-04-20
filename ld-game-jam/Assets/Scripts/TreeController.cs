using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : MonoBehaviour {

    [SerializeField] private int hp = 30;
    [SerializeField] private int[] fertilizer = {5, 10, 15};
    
    [SerializeField] private Text lifesText = null; // show number in GUI

    private enum Stage {stage1, stage2, stage3};
    private enum State {normal, damaged, death, hit};

    private Stage stage = Stage.stage1;
    private State state = State.normal;

    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        lifesText.text = hp.ToString(); //updates the life in GUI
    }

    // This is called every time the zombie animation it's in the middle. It
    // reduces the tree life by one. This can be changed later in game to increase difficulty
    public void ReduceLife() {
        if (hp > 0) {
            hp--;
        }
    }

    /* Called after the player picks up a watering can. Add 5 to life- This can be changed 
    later in game increase difficulty*/
    public void AddLife() {
        hp += 5;
    }

    public void GrowTree() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
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
