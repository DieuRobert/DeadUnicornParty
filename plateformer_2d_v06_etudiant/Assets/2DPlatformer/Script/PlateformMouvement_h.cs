using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformMouvement_h : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform pointDepart;
    [SerializeField]
    private Transform pointArrivee;
    [SerializeField]
    private int vitesse = 5;
    private float fin;
    private float debut;
    private bool sens = false;
    [SerializeField]
    private bool flipX = false;

    // [SerializeField]
    //private Transform plateform_mouvement;

    // Start is called before the first frame update
    void Start()
    {
        fin = pointArrivee.transform.position.x;
        debut = pointDepart.transform.position.x ;
    }

    // Update is called once per frame
    
    void Update()
    {
        Debug.Log(sens);
        if(sens == true)
        {
            if (fin >= transform.position.x)
            {
                transform.Translate(Vector3.right * Time.deltaTime * vitesse);
                if (fin <= transform.position.x)
                {
                    sens = false;
                    enemy.GetComponent<SpriteRenderer>().flipX = true;
                    //GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
        if (sens == false)
        {
            if (debut <= transform.position.x)
            {
                transform.Translate(Vector3.left * Time.deltaTime * vitesse);
                if (debut >= transform.position.x)
                {

                    sens = true;
                    if (flipX == true)
                    {
                        enemy.GetComponent<SpriteRenderer>().flipX = false;
                        //GetComponent<SpriteRenderer>().flipX = false;
                    }
                }
            }
        }
    }
        
}
