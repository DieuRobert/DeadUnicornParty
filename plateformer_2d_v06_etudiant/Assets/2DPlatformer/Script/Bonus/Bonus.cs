using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Bonus : MonoBehaviour
{
   
    [SerializeField]
    
    public float BonusLife = 1f;
    Text pvLife;
    Animation myAnimation;

    void Start()
    {
        pvLife = gameObject.GetComponentInChildren<Text>();
        myAnimation = GetComponent<Animation>();
        pvLife.text = "+"+BonusLife +"hp";
       
    }
    private void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Player")
        {
            
            myAnimation.Play("bonus_life01");
            Destroy(gameObject,1);

        }
    }

   
}
