using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Bonus_PT : MonoBehaviour
{
    [SerializeField]
    public int BonusPoint = 20;
   
    Text bonusPT;
    Animation myAnimation;

    void Start()
    {
        bonusPT = gameObject.GetComponentInChildren<Text>();
        myAnimation = GetComponent<Animation>();
        bonusPT.text = "+" + BonusPoint ;

    }
    private void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Score.scoreValue += BonusPoint;
            myAnimation.Play("bonus_pt02");
            Destroy(gameObject, 1);

        }
    }

}
