using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour {

    private GameObject tree = null;
    private SpriteRenderer spriteRend;
    [SerializeField] private bool facingLeft = false;
    private Vector3 initialPos;
    private Vector3 finalPos;
    [SerializeField] private float moveSpeedFactor = 0.5f;
    [SerializeField] private float moveSpeed = 1f;
    private float xrate = 0.1f;
    private float yrate = 0.1f;


    // Start is called before the first frame update
    void Start() {
        spriteRend = GetComponent<SpriteRenderer>();
        
        tree = GameObject.FindWithTag("Tree");
        facingLeft = transform.position.x < 0 ? true : false;
        
        Vector3 initialPos = new Vector3(transform.position.x, transform.position.y, 0f);
        Vector3 finalPos = new Vector3(tree.transform.position.x, tree.transform.position.y, 0f);

        spriteRend.flipX = facingLeft ? false : true;
        xrate = Mathf.Abs(tree.transform.position.x + 0.001f/ (transform.position.x + 0.001f))/10f;
        yrate = Mathf.Abs(tree.transform.position.y + 0.001f/ (transform.position.y + 0.001f))/10f;
    }

    // Update is called once per frame
    void Update() {
        Move();
        if (transform.position.y < -50f) {
            Destroy(gameObject);
        }
    }

    void Move() {
        //if (transform.position.x < tree.transform.position.x && transform.position.y < tree.transform.position.y)
        if(facingLeft)
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y - 0.075f, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y - 0.075f, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // if (other.gameObject.tag == "Tree") {
        //     GameObject.FindWithTag("Tree").GetComponent<TreeController>().ReduceLife();
        // }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // GameObject.FindWithTag("Tree").GetComponent<TreeController>().ReduceLife();

    }
}
