using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    float sens;

    private void Update()
    {
        var objectPos = Camera.main.ScreenToWorldPoint(transform.position);
        var dir = (-Input.mousePosition - objectPos) * sens * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg));
    }
}
