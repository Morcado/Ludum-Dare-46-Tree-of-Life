using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : MonoBehaviour {

    [SerializeField] private int hp = 30;
    [SerializeField] private int[] fertilizer = {5, 10, 15};
    private Animator animator;
    [SerializeField] private Text lifesText = null; // show number in GUI

    private enum Stage {stage1, stage2, stage3};
    private enum State {normal, damaged, death, hit};

    private Stage stage = Stage.stage1;
    private State state = State.normal;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update() {
        lifesText.text = hp.ToString(); //updates the life in GUI
        animator.SetInteger("state", (int)state);
        animator.SetInteger("stage", (int)stage);
        Debug.Log("state: " + (int)state);
        Debug.Log("stage: " + (int)stage);

        if (state != State.hit){
        
            if (hp >= 15) {
                state = State.normal;
                Debug.Log("normal");
            }
            else {
                state = State.damaged;
                Debug.Log("damaged");
            }
        }
    }

    // This is called every time the zombie animation it's in the middle. It
    // reduces the tree life by one. This can be changed later in game to increase difficulty
    public void ReduceLife(int monster) {
        state = State.hit;
        if (hp > 1) {
            switch (monster) {
                case 0: //zombie
                    hp -= 2;
                break;
                case 1: //skeleton
                    hp--;
                break;
                case 2: //firespirit
                    hp -= 2;
                break;
            }
        }
        else {
            state = State.death;
        }
    }

    /* Called after the player picks up a watering can. Add 5 to life- This can be changed 
    later in game increase difficulty*/
    public void AddLife() {
        hp += 2;
        
    }

    public void GrowTree(int numFertilizer) {
        if (numFertilizer < 5) {
            stage = Stage.stage1;
        }
        else if (numFertilizer == 5) {
            stage = Stage.stage2;
        }
        else if (numFertilizer == 15) {
            stage = Stage.stage3;
        }
        else {
            // win
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Fireball") {
            ReduceLife(2);
            // GameObject.FindWithTag("Tree").GetComponent<TreeController>().ReduceLife();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Fireball") {
            ReduceLife(2);
        }
        // GameObject.FindWithTag("Fireball").GetComponent<TreeController>().ReduceLife();

    }

    private void BackToNormal() {
        state = State.normal;
    }

    private void BackToDamaged() {
        state = State.damaged;

    }
}
