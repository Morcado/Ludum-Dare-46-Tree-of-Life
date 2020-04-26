using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{

    private GameObject tree = null;
    private SpriteRenderer spriteRend;
    [SerializeField]
    private bool facingLeft = false;

    float distance_x;
    float distance_y;

    void Start()
    {
        //float 
        spriteRend = GetComponent<SpriteRenderer>();

        tree = GameObject.FindWithTag("Tree");
        facingLeft = transform.position.x < 0 ? true : false;

        distance_x = Mathf.Abs(tree.transform.position.x - transform.position.x);
        distance_y = Mathf.Abs(tree.transform.position.y - transform.position.y - 1.0f);

        spriteRend.flipX = facingLeft ? false : true;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float speed_y = 0.05f;

        if (transform.position.x > tree.transform.position.x)
            transform.position = new Vector3(transform.position.x - distance_x / (distance_y / speed_y), transform.position.y - speed_y, transform.position.z);
        else if (transform.position.x < tree.transform.position.x)
            transform.position = new Vector3(transform.position.x + distance_x / (distance_y / speed_y), transform.position.y - speed_y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y - speed_y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tree")
        {
            GameObject.FindWithTag("Tree").GetComponent<TreeController>().ReduceLife(2);
            Destroy(gameObject);
        }
    }
}