using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class limite_zone : MonoBehaviour
{
    [SerializeField]
    private GameObject nameObjet;


    //[SerializeField]
    //private Vector3 _taille;


    void Start()
    {
        
    }

    
    void Update() { }
   
    private void OnDrawGizmos()
    {
    Gizmos.DrawCube(nameObjet.transform.position, nameObjet.transform.localScale);
    }

   
}
