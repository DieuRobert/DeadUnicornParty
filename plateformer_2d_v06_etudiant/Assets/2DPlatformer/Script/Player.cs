using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerStats
  
{
    private bool flash;
    private float bonusLife;
    private float damageplayer;

    [SerializeField]
    private Color colorImpact;

    [SerializeField]
    private HealthBar healthBar;


    public event Action MonEvent;
    public bool PlayerIsDead { get { return CurHealth <= 0f; }

    }

    
    public void Start()
    {
        healthBar.HealthBarText.text = $"{MaxHealth}/{MaxHealth} PV";
    }

    void Update()
    {
        if (MonEvent !=null && PlayerIsDead)
        {
            MonEvent(); 
        }
    }


    public void RecevoirDegat(float degat)
    {
        CurHealth -= degat;
        if(CurHealth >=MaxHealth)
        {
            CurHealth = MaxHealth;
        }
        healthBar.SetHealth(CurHealth, MaxHealth);
    }

    public void Attaque(EnemyFight enemyFight)
    {
        enemyFight.RecevoirDegat(Damage);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
       
        if (coll.gameObject.tag == "Plateforme")
        {
            gameObject.transform.SetParent(coll.gameObject.transform);

        }
        
    }
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bonus")
        {
            Bonus bonuslifeGo = GameObject.FindWithTag("Bonus").GetComponent<Bonus>();
            bonusLife = bonuslifeGo.BonusLife;
            RecevoirDegat(-bonusLife);
          
        }
    }

        void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            //gameObject.GetComponentInChildren<Renderer>().material.color = colorImpact;

            
            if (flash == false)
            {
                EnemyFight damageGo = GameObject.FindWithTag("enemy").GetComponent<EnemyFight>();
                damageplayer = damageGo.DamagePlayer;
                RecevoirDegat(damageplayer);
                StartCoroutine(flashImpact());
            }
            
        }

    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Plateforme")
        {
            gameObject.transform.SetParent(null);
            
        }
        if (coll.gameObject.tag == "enemy")
        {
            //gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 1);
            

        }
    }
    IEnumerator flashImpact()
    {

        gameObject.GetComponentInChildren<Renderer>().material.color = colorImpact;
        flash = true;

        yield return new WaitForSeconds(0.1f);

        //After we have waited 1 second print the time again.
        gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 1);

        yield return new WaitForSeconds(0.3f);
        flash = false;
    }
}
