using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpiritController : MonoBehaviour
{
    [SerializeField] private bool facingLeft = false;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveSpeedFactor = 0.5f;
    [SerializeField] private GameObject fireball;
    private SpriteRenderer spriteRend;
    private Rigidbody2D enemy;
    private Animator animator;
    private Collider2D coll;
    private enum State {idle, attack, death};
    private State state = State.idle;
    private float timeLeft = 5.0f;

    // Start is called before the first frame update
    void Start() {
        enemy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();


        /* this defines if the enemy starts moving towards left or towards right.
         it checks the center of the screen. This has to be changed to check the 
         tree x position */
        facingLeft = transform.position.x < 0 ? true : false;
       
    }

    // Update is called once per frame
    void Update() {
        IgnoreCollisions();
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0) 
            state = State.attack;
        //if (state != State.attack)
            //Shoot();
        animator.SetInteger("state", (int)state);
    }

    private void IgnoreCollisions() {
        GameObject test;

        test = GameObject.FindWithTag("Fire");
        if (test != null)
            Physics2D.IgnoreCollision(coll, test.GetComponent<Collider2D>());
            
        test = GameObject.FindWithTag("Fireball");
        if (test != null)
            Physics2D.IgnoreCollision(coll, test.GetComponent<Collider2D>());  

        test = GameObject.FindWithTag("Skeleton");
        if (test != null)
            Physics2D.IgnoreCollision(coll, test.GetComponent<Collider2D>());      

        test = GameObject.FindWithTag("Zombie");
        if (test != null)
            Physics2D.IgnoreCollision(coll, test.GetComponent<Collider2D>());     

    }

    public void Shoot() {
    
        if (facingLeft) {
            Instantiate(fireball, new Vector3(transform.position.x + 1, transform.position.y, 0), Quaternion.identity);
        }
        else {
            Instantiate(fireball, new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.identity);
        }
    
    }
    private void OnCollisionEnter2D(Collision2D other) {
       if (other.gameObject.tag == "Player") {
            state = State.death; // switches to death state
        }
    }
    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public void ReturnIdle() {
        timeLeft = 2.0f;
        state = State.idle;
    }
}
