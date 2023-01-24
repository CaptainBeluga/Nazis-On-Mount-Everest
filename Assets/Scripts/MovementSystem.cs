using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField]
    float speed, speedJump;

    bool isJumping;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isJumping = false;
    }

    void Update()
    {

        float horizontalAss = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        Vector3 movementDirection = new Vector3(horizontalAss, 0, 0);

        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * speedJump, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "terrain")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            isJumping = true;
        }
    }
}
