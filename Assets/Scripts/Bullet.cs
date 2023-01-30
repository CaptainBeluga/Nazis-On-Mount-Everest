using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;

    void Start()
    {
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, MovementSystem.lastMoveTowardsPos, bulletSpeed * Time.deltaTime);

        if(transform.position == MovementSystem.lastMoveTowardsPos)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("enemy"))
        {
            print(string.Format("Enemy Killed: {0}",collision.gameObject.name));
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
