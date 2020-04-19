using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool facingLeft = false;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveSpeedFactor = 0.5f;
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
        if (state != State.attack && state != State.death) {
            MoveAction();
        }

        ZombieState();
        animator.SetInteger("state", (int)state);
    }

    // Controls the zombie and the skeleton movement
    private void MoveAction() {
        if (gameObject.tag == "Zombie") {
            moveSpeedFactor = 0.5f;
        }
        else {
            moveSpeedFactor = 0.3f;
        }

        Vector3 movement = new Vector3(1, 0f, 0f);
        if (facingLeft) {
            movement.x = moveSpeedFactor;
            spriteRend.flipX = false;
        }
        else {
            movement.x = -moveSpeedFactor;
            spriteRend.flipX = true;
        }
        if (state != State.idle){
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }

    public void AttackAction() {
        GameObject.FindWithTag("Tree").GetComponent<TreeBehaviour>().ReduceLife();

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Tree") {
            state = State.attack;
        }
        else if (other.gameObject.tag == "Player") {
            state = State.death;
        }
        else if (other.gameObject.tag == "Ground") {
            if (transform.position.x < 0) {
                facingLeft = true;
            }
            else {
                facingLeft = false;
            }
        }
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    private void ZombieState() {
        if (state == State.death) {
            
        }
        else if (Mathf.Abs(enemy.velocity.x) > Mathf.Epsilon && state != State.attack) {
            state = State.walk;      
        }
        
    }
}
