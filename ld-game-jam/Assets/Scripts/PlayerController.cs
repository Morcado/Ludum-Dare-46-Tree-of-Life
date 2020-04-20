using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Modificable stuff for the player
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpHeight = 10f;
    private bool switcher = true;
    private bool facingLeft = false;
    private int numFertilizer = 0;

    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource pickUpSFX;
    [SerializeField] private AudioSource beamSFX;

    [SerializeField] private GameObject beam;

    private SpriteRenderer spriteRend;
    private Animator animator;
    private Rigidbody2D player;
    private Collider2D coll;
    [SerializeField] private LayerMask Foreground;
    private enum State {idle, run, jump, fall, melee, special}; // States of the player
    private State state = State.idle;

    // Start is called before the first frame update
    void Start() {
        // Get components of the player to later modify them.
        spriteRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        
        // Ingnore collision between player and tree.
        Physics2D.IgnoreCollision(coll, GameObject.FindWithTag("Tree").GetComponent<Collider2D>());       
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.FindWithTag("Bush") != null) {
            Physics2D.IgnoreCollision(coll, GameObject.FindWithTag("Bush").GetComponent<Collider2D>());
        }
        Jump();
        Move();
        Shoot();
        VelocityState();

        // Changes animation of the player every time
        animator.SetInteger("state", (int)state);
        Debug.Log("fertilizer: " + numFertilizer);

    }

    // Moving the player
    public void Move() {
        // Gets the left or right action pressed
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        // Changes player position
        transform.position += movement * Time.deltaTime * moveSpeed;

        // Flips the player sprite if it's moving to the left or right;
        if (horizontalInput < 0) {
            facingLeft = true;
            spriteRend.flipX = true;
        }
        else if (horizontalInput > 0) {
            facingLeft = false;
            spriteRend.flipX = false;
        }

    }

    public void Shoot(){
        if (Input.GetButtonDown("Fire1")){
            if (facingLeft) {
                Instantiate(beam, new Vector3(transform.position.x - 3, transform.position.y, 0), Quaternion.identity);

                beamSFX.Play();
            }
            else {
                Instantiate(beam, new Vector3(transform.position.x + 3, transform.position.y, 0), Quaternion.identity);

                beamSFX.Play();
            }

        }
    }
    /* This controls the state of the player*/
    private void VelocityState() {
        /* If player it's jumping then it changes to the falling state when
        the velocity of player reaches 0 (highest point)*/
        if (state == State.jump) {
            if (player.velocity.y < 0.1f) {
                state = State.fall;
            }
        }
        /* Changes the state of falling to idle if it touches the layer foreground (the floor)*/
        else if (state == State.fall) {
            if (coll.IsTouchingLayers(Foreground)) {
                state = State.idle;
            }
        }
        /* If player velocity changes more than epsilon, it's sprite changes to running animation.
        This is ignored when the player it's jumping or falling*/
        else if (Mathf.Abs(player.velocity.x) > Mathf.Epsilon) {
            state = State.run;
        }
        else {
            state = State.idle;
        }
        // Debug.Log("state:" + (int)state);
    }

    /* This is called every time to check if the player is jumping. it checks on the jump button.*/
    public void Jump()
    {
        
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Foreground)){
            //player.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse); // another way?
            player.velocity = new Vector2(player.velocity.x, jumpHeight);
            state = State.jump;

            jumpSFX.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Fertilizer") {
            Destroy(collision.gameObject);
            numFertilizer++;
            GameObject.FindWithTag("Tree").GetComponent<TreeController>().GrowTree(numFertilizer);
            pickUpSFX.Play();
        }
        else if (collision.tag == "WaterCan") {
            GameObject.FindWithTag("Tree").GetComponent<TreeController>().AddLife();
            Destroy(collision.gameObject);
            pickUpSFX.Play();
        }
        else if (collision.tag == "Energy") {
            Destroy(collision.gameObject);
            pickUpSFX.Play();
        }
        else if (collision.tag == "Seed") {
            switcher = !switcher;
            Destroy(collision.gameObject);
            GameObject.FindWithTag("Spawner").GetComponent<Spawner>().SpawnMinitrees(true);
            pickUpSFX.Play();
        }
    }
}
