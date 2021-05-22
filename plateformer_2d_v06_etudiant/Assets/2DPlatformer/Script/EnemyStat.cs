using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStat : MonoBehaviour
{
    public float MaxHealth{ get; set; }

    public float CurHealth { get; set; }

    //public float PV { get; set; }

   

    public EnemyStat()
    {
        MaxHealth = 0f;
        CurHealth = MaxHealth;
       
    }

    
}
