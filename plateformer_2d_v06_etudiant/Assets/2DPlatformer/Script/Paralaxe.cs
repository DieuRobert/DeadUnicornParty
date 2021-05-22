using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaxe : MonoBehaviour
{
    [SerializeField]
    private GameObject[] parraGameObjects;

    [SerializeField]
    private float[] parraSpeedHorizontal;

    [SerializeField]
    private float[] parraSpeedVertical;

    private Camera cam;

    private Vector3 previousCamPosition;

    void Start()
    {
        cam = Camera.main;

        previousCamPosition = cam.transform.position;
    }


    void Update()
    {
        for (int i = 0; i< parraGameObjects.Length;i++)
        {
            float speed = (previousCamPosition.x - cam.transform.position.x) * parraSpeedHorizontal[i];

            // modif parralaxe hauteur.
            float speedh = (previousCamPosition.y - cam.transform.position.y) * parraSpeedVertical[i];

            Vector3 newPosition = new Vector3(parraGameObjects[i].transform.position.x + speed, parraGameObjects[i].transform.position.y + speedh, parraGameObjects[i].transform.position.z);

            parraGameObjects[i].transform.position = newPosition;
        }

    previousCamPosition = cam.transform.position;
    }
}