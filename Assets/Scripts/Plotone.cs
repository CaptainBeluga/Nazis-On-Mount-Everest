using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plotone : MonoBehaviour
{
    bool onRange;
    Vector2 startPoint;

    [SerializeField]
    float enemySpeed, maxDistance;

    GameObject player;

    void Start()
    {
        onRange = false;

        player = GameObject.Find("Player");

        startPoint = transform.position;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < maxDistance)
        {
            onRange = true;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
        }
    }
}
