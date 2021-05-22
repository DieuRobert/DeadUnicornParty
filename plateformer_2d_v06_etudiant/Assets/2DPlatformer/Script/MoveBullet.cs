using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    [SerializeField]
    private float speedBullet;

    [SerializeField]
    private float timeLife = 1;


    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedBullet);
        Destroy(gameObject, timeLife);
    }
}
