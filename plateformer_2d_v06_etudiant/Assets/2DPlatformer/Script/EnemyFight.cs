using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : EnemyStat
{
    

    [SerializeField]
    private Transform effetExplosPrefab;

    [SerializeField]
    private float _YOffset;

    [SerializeField]
    private float _XOffset;

    private Transform effetPointexplose;

    [SerializeField]
    private HealthBar healthBar;

    [SerializeField]
    private Color colorImpact = Color.red;

    [SerializeField]
    public float DamagePlayer =1f;

    [SerializeField]
    private float LifeEnemy = 100f;

    public bool IsAlive { get { return CurHealth >= 0f; } }
    
    void Update()
    {
        effetPointexplose =  gameObject.transform ;
        
    }

    private void Start()
    {
        MaxHealth = MaxHealth + LifeEnemy;
        CurHealth = MaxHealth;
        healthBar.HealthBarText.text = $"{MaxHealth}/{MaxHealth} PV";
    }

    public void RecevoirDegat( float degat)
    {
        CurHealth -= degat;
        healthBar.SetHealth(CurHealth,MaxHealth);
        StartCoroutine(flashImpact());

        if (IsAlive == false)
        {
            EffectExplos();
            Destroy(gameObject);
        }

    }
    
    private void EffectExplos()
    {

        //fx de tirr
        Transform clone = Instantiate(effetExplosPrefab, effetPointexplose.position + new Vector3(_XOffset,_YOffset,0), effetPointexplose.rotation) as Transform;


        //float size = Random.Range(0.6f, 0.9f);

        //clone.localScale = new Vector3(size, size, size);
        clone.localScale = new Vector3(1, 1, 1);

        //Destroy(clone.gameObject, 0.10f);

    }

    IEnumerator flashImpact()
    {
       
        gameObject.GetComponentInChildren<Renderer>().material.color = colorImpact;

        
        yield return new WaitForSeconds(0.1f);

        //After we have waited 1 second print the time again.
        gameObject.GetComponentInChildren<Renderer>().material.color = new Color(1, 1, 1);
    }



}