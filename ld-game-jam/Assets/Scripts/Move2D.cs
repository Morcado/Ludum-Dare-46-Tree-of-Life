using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpHeight = 10f;
    
    private SpriteRenderer spriteRend;
    private Animator animator;
    private Rigidbody2D player;
    private Collider2D coll;
    [SerializeField] private LayerMask Foreground;
    private enum State {idle, run, jump, fall}
    private State state = State.idle;

    void Start() {
        spriteRend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update() {
        Jump();
        Move();
        VelocityState();
        animator.SetInteger("state", (int)state);
        
    }

    public void Move() {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (horizontalInput < 0) {
            spriteRend.flipX = true;
        }
        else if (horizontalInput > 0) {
            spriteRend.flipX = false;
        }

    }

    private void VelocityState() {
        if (state == State.jump) {
            if (player.velocity.y < 0.1f) {
                state = State.fall;
            }
        }
        else if (state == State.fall) {
            if (coll.IsTouchingLayers(Foreground)) {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(player.velocity.x) > Mathf.Epsilon) {
            state = State.run;
        }
        else {
            state = State.idle;
        }
        Debug.Log("state:" + (int)state);
    }

    public void Jump() {
        
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Foreground)){
            //player.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
            player.velocity = new Vector2(player.velocity.x, jumpHeight);
            state = State.jump;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Fertilizer") {
            // Debug.Log("fertilizaer");
            Destroy(collision.gameObject);
        }
    }
}
