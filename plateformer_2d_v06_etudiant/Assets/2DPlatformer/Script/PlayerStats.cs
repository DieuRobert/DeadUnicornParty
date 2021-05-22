using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float MaxHealth { get; set; }

    public float CurHealth { get; set; }

    // public float PV { get; set; }

   
    public float Damage { get; set; }
   
    //public float BonusLife { get; set; }

    public PlayerStats()
    {
        MaxHealth = 6f;
        CurHealth = MaxHealth;
        Damage = 1f;
        
       
    }
}
