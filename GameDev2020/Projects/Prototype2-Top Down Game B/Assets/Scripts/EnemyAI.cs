using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    // Occures at a fixed per frame (not every frame, good for frame)
    void FixedUpdate ()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }

}
