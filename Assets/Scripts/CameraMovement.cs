using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    float x_offset, y_offset, z_offset, smooth;

    Vector3 velocity = Vector3.zero;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 target = new Vector3(player.transform.position.x + x_offset, player.transform.position.y + y_offset, player.transform.position.z + z_offset);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smooth);
    }
}
