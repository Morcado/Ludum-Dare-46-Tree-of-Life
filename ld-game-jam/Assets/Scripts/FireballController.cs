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

    }

    void Move() {
        Debug.Log(xrate);
        Debug.Log(yrate);
        //if (transform.position.x < tree.transform.position.x && transform.position.y < tree.transform.position.y)
        transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y - 0.02f, transform.position.z);
    }
}
