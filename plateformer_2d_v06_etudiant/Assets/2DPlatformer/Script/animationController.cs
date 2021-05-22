using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum stateAnim
{
    Idle,
    Run,
    Jump
}

public class animationController : MonoBehaviour
{

    private Animator anim;
    private PlayerController player;
    private PlayerMotor playerMotor;
    private stateAnim state;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerMotor = GetComponent<PlayerMotor>();
        
    }


    void Update()
    {
       bool run =  player.X >=1 || player.X<= -1;
        Debug.Log("player" + player.X);
 
        if (run && playerMotor.Grounded)
        {
            state = stateAnim.Run;
            Debug.Log("je cours");
        }
        else  if(!run && playerMotor.Grounded)
        {
            state = stateAnim.Idle;
            Debug.Log("je ne fais rien");
        }
        else if (!playerMotor.Grounded)
        {
            state = stateAnim.Jump;
            Debug.Log("je saute");
        }
        Animation();
    }

    private void Animation()
    {
        switch (state)
        {
            case stateAnim.Idle:
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", true);

                break;
            case stateAnim.Run:
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
                anim.SetBool("Ground", true);
                break;
            case stateAnim.Jump:
                anim.SetBool("Idle", false);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", false);
                break;

        }
    }
}
