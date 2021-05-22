using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_02_move : MonoBehaviour
{

    private Player player;
    private float offsetFx =1f ;

    [SerializeField]
    private Transform effetimpactPrefab;

    private Transform firePointImpact;
    [SerializeField]
    private LayerMask ToHIT;


    private void Start()
    {
       
        player = GameManager.Instance.PlayerInstanciate.GetComponent<Player>();
        PlayerController PlayerGo = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        if (PlayerGo.directionPlayer <= -1)
        {
            offsetFx = -1;
        }
        if (PlayerGo.directionPlayer >= 1)
        {
            offsetFx = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        

        firePointImpact = gameObject.transform;
    }
    void OnCollisionEnter2D(Collision2D coll)
    //void OnTriggerEnter2D(Collider2D coll)
    {

           //if (coll.gameObject != null)
           //{
         if ((ToHIT & 1 << coll.gameObject.layer) == 1 << coll.gameObject.layer)
         {
            //Debug.Log("destructible");
            //GetComponent<BoxCollider2D>().enabled = false;
            if (coll.gameObject.tag == "enemy")
            {
                        //Debug.Log("prends desdegats");
                        EnemyFight enemy = coll.gameObject.GetComponent<EnemyFight>();
                        player.Attaque(enemy);
                        //Destroy(coll.gameObject);
                        //EffectImpact();
                        //Destroy(gameObject);

            }
                   
            if (coll.gameObject.tag == "Untagged")
            { 
                Destroy(coll.gameObject);

            }
            //EffectImpact();
            //Destroy(gameObject);

        }
        EffectImpact();
        Destroy(gameObject);
    }
   

    private void EffectImpact()
    {

        //fx de tirr
        
        Transform clone = Instantiate(effetimpactPrefab, firePointImpact.position + new Vector3(offsetFx, 0, 0), firePointImpact.rotation) as Transform;
        

        float size = Random.Range(0.6f, 0.9f);

        clone.localScale = new Vector3(size, size, size);

        Destroy(clone.gameObject, 0.10f);

    }
}




