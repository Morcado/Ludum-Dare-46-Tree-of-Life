using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Modificable fields for enemies
    [SerializeField] private bool facingLeft = false;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveSpeedFactor = 0.5f;
    private SpriteRenderer spriteRend;
    private Rigidbody2D enemy;
    private Animator animator;
    /* Four different styles for enemies. Maybe add a falling state*/
    private enum State {idle, walk, attack, death};
    private State state = State.idle;
    // Start is called before the first frame update
    void Start() {
        // Get the rigidbody, animator and sprite renderer of the current enemy.
        // this is used in the methods below 
        enemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

        /* this defines if the enemy starts moving towards left or towards right.
         it checks the center of the screen. This has to be changed to check the 
         tree x position */
        if (transform.position.x < 0) {
            facingLeft = true;
        }
        else {
            facingLeft = false;
        }
        
    }

    // Update is called once per frame
    void Update() {
        // Enemies will only move or idle if they are not attacking or dying
        if (state != State.attack && state != State.death) {
            MoveAction();
        }

        // This checks the zombie state and do some stuff (wip)
        ZombieState();
        // changes the sprite animation regarding of it's state
        animator.SetInteger("state", (int)state);
    }

    // Controls the zombie and the skeleton movement (states 0 and 1)
    private void MoveAction() {
        // zombie speed factor, and skeleton speed factor
        moveSpeedFactor = gameObject.tag == "Zombie" ? 0.5f : 0.3f;

        Vector3 movement = new Vector3(1, 0f, 0f);
        // changes the speed to move the sprite to the left or to the right depending
        // if he is facing left or right
        if (facingLeft) {
            movement.x = moveSpeedFactor;
            spriteRend.flipX = false;
        }
        else {
            movement.x = -moveSpeedFactor;
            spriteRend.flipX = true;
        }
        // changes the position of the zombie if it's not idle
        if (state != State.idle){
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }

    /* Function called when the animation of attacking it's at half, then it calls
     the tree function to reduce it's life by one. This can be changed in the animation event*/
    public void AttackAction() {
        GameObject.FindWithTag("Tree").GetComponent<TreeBehaviour>().ReduceLife();

    }

    /* Collision of the enemy with different tiles */
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Tree") {
            state = State.attack; // switches to atack state
        }
        else if (other.gameObject.tag == "Player") {
            state = State.death; // switches to death state
        }
        else if (other.gameObject.tag == "Ground") {
            /* Checks when the enemy falls off a platform. Theenemy changes it's
            direction if the plant it's in the oposite direction */
            if (transform.position.x < 0) {
                facingLeft = true;
            }
            else {
                facingLeft = false;
            }
        }
    }

    /* This function it's called after the dying animation it's played. Removes the enemy from the game*/
    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    /* Controls the state of the zombie WIP*/
    private void ZombieState() {
        if (state == State.death) {
            
        }
        else if (Mathf.Abs(enemy.velocity.x) > Mathf.Epsilon && state != State.attack) {
            state = State.walk;      
        }
        
    }
}
