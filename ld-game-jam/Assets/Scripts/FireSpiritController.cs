using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpiritController : MonoBehaviour
{
    [SerializeField] private bool facingLeft = false;
    [SerializeField] private float moveSpeedFactor = 0.5f;
    [SerializeField] private GameObject fireball;

    [SerializeField] private AudioSource fireAtackSFX;

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
        animator.SetInteger("state", (int)state);
        IgnoreCollisions();
        Move();

        timeLeft -= Time.deltaTime;
        // atcacks at certain time
        if(timeLeft < 0) 
            state = State.attack;
    }

    public void Move() {
        Vector3 movement = new Vector3(1, 0f, 0f);
        if (facingLeft) {
            movement.x = moveSpeedFactor;
            spriteRend.flipX = false;
        }
        else {
            movement.x = -moveSpeedFactor;
            spriteRend.flipX = true;
        }
        transform.position += movement * Time.deltaTime;
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

            fireAtackSFX.Play();
        }
        else {
            Instantiate(fireball, new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.identity);
            fireAtackSFX.Play();
        }
    
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Physics2D.IgnoreCollision(coll, other.gameObject.GetComponent<Collider2D>());
            state = State.death; // switches to death state
        }
        else if (other.gameObject.tag == "Ground") {
            // flip firespirit direction when hit wall
            facingLeft = !facingLeft;
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
