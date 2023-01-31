using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField]
    float speed, speedJump;

    public GameObject bullet;
    public static Vector3 lastMoveTowardsPos;

    bool isJumping;

    //Reloading Stuffs
    bool startTimer;
    float time;
    public float reloadingTime;

    Transform gun;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isJumping = false;

        startTimer = false;
        time = 0f;
    }

    void Update()
    {

        gun = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1);

        //Cursor.visible = false;

        Movements();

        Shooting();
    }

    void Movements()
    {
        //Movements
        float horizontalAss = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        Vector3 movementDirection = new Vector3(horizontalAss, 0, 0);

        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * speedJump, ForceMode2D.Impulse);
        }

        transform.localScale = horizontalAss >= 0 ? new Vector3(1, 1, 1): new Vector3(-1, 1, 1);
        GunScript.mousePos = horizontalAss >= 0 ? Input.mousePosition : -Input.mousePosition;
    }


    void Shooting()
    {

        if (Input.GetMouseButtonDown(0) && !startTimer)
        {
            startTimer = true;

            Vector2 spawnPos = new Vector2(gun.position.x, gun.position.y);

            lastMoveTowardsPos = GameObject.Find("MoveTowards").transform.position;

            Instantiate(bullet, spawnPos, Quaternion.Euler(new Vector3(0, 0, -GunScript.angle)));
        }

        //Reloading Time
        if (startTimer)
        {
            time += Time.deltaTime;

            if(time >= reloadingTime)
            {
                startTimer = false;
                time = 0f;
            }
        }

        else
        {
            time = 0f;
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
