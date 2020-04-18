using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool facingLeft = false;
    [SerializeField] private float moveSpeed = 2.5f;
    private SpriteRenderer spriteRend;


    void Start() {
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
        Vector3 movement = new Vector3(1, 0f, 0f);
        if (facingLeft) {
            movement.x = 1;
            spriteRend.flipX = true;
        }
        else {
            movement.x = -1;
            spriteRend.flipX = false;
        }
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
