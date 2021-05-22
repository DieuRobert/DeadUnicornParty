using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMouvement_v : MonoBehaviour
{
    [SerializeField]
    private Transform pointDepart;
    [SerializeField]
    private Transform pointArrivee;
    [SerializeField]
    private int vitesse = 5;
    private float fin;
    private float debut;
    private bool sens = true;
    [SerializeField]
    private bool flipY = false;

    // [SerializeField]
    //private Transform plateform_mouvement;

    // Start is called before the first frame update
    void Start()
    {
        fin = pointArrivee.transform.position.y;
        debut = pointDepart.transform.position.y;
    }

    // Update is called once per frame

    void Update()
    {
        Debug.Log(sens);
        if (sens == true)
        {
            if (fin >= transform.position.y)
            {
                transform.Translate(Vector3.up * Time.deltaTime * vitesse);
                if (fin <= transform.position.y)
                {
                    sens = false;
                    GetComponent<SpriteRenderer>().flipY = false;
                }
            }
        }
        if (sens == false)
        {
            if (debut <= transform.position.y)
            {
                transform.Translate(Vector3.down * Time.deltaTime * vitesse);
                if (debut >= transform.position.y)
                {
                    sens = true;
                    if (flipY == true)
                    {
                        GetComponent<SpriteRenderer>().flipY = true;
                    }
                }
            }
        }
    }
}
