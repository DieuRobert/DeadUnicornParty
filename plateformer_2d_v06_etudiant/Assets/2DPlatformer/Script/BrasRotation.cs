using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrasRotation : MonoBehaviour
{


 
    void Update()
    {
       Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotz);

    }
}
