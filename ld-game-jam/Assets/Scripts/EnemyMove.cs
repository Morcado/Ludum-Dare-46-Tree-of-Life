using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    private bool facingLeft = false;
    [SerializeField] private float moveSpeed = 1f;
    private SpriteRenderer spriteRend;
    private Rigidbody2D enemy;
    private Animator animator;
    private enum State {idle, walk, attack, death}
    private State state = State.idle;

    void Start() {
        enemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        spriteRend = GetComponent<SpriteRenderer>();

        if (transform.position.x < 0) {
            facingLeft = true;
        }
        else {
            facingLeft = false;
        }
        
    }

    // Update is called once per frame
    void Update() {
        Move();
        ZombieState();
        animator.SetInteger("state", (int)state);

    }

    private void Move() {
        Vector3 movement = new Vector3(1, 0f, 0f);
        if (facingLeft) {
            movement.x = 0.5f;
            spriteRend.flipX = false;
        }
        else {
            movement.x = -0.5f;
            spriteRend.flipX = true;
        }
        if (state != State.idle){
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }

    private void ZombieState() {
        // if (state == State.attack) {

        // }
        // else if (state == State.death) {

        // }
        // else 
        if (Mathf.Abs(enemy.velocity.x) > Mathf.Epsilon) {
            state = State.walk;      
        }
        else {
            if (transform.position.x < 0.30f || transform.position.x > -0.30f) {
                state = State.idle;

            }
        }
        
    }
}
