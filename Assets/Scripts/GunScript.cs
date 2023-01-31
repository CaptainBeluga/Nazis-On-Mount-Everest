using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public static Vector3 mousePos, direction;
    public static float angle;

    private void Awake()
    {
        mousePos = Vector3.zero;
    }

    private void Update()
    {
        var objectPos = Camera.main.ScreenToWorldPoint(transform.position);
        direction = (mousePos - objectPos);

        angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
