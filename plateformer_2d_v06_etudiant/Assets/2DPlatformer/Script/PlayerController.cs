using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;
    protected JoyButton_jump joybutton;
    protected bool jump;




    private PlayerMotor motor;
    private float _x;
    public float X { get { return _x; } }
    private float _y;
    public float Y { get { return _y; } }
    public float directionPlayer { get; set; }

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoyButton_jump>();
        

        motor = GetComponent<PlayerMotor>();
    }


    void Update()
    {
      
        if(joystick.Horizontal != 0)
        {
           if (joystick.Horizontal < 0)
           {
               _x = -1;
                directionPlayer = -1;

            }
            if (joystick.Horizontal > 0)
            {
                _x = 1;
                directionPlayer = 1;
            }
        }
        if (joystick.Horizontal == 0)
        {
            _x = Input.GetAxisRaw("Horizontal");
        }
           


        if (_x == -1)
        {
            // GetComponent<SpriteRenderer>().flipX = true;
            GetComponentInChildren<RectTransform>().localScale = new Vector3(-1,1);
           transform.localScale = new Vector3(-1, 1);
            directionPlayer = -1;
        }
        else if(_x ==1)
        {
            //GetComponent<SpriteRenderer>().flipX = false;
            GetComponentInChildren<RectTransform>().localScale = new Vector3(1, 1);
            transform.localScale = new Vector3(1, 1);
            directionPlayer = 1;
        }

        if(!jump && joybutton.Pressed)

        {
            jump = true;
             _y = 1;
            
        }

        if (jump && !joybutton.Pressed)
        {
             jump = false;
            _y = 0;
        }

         //bout de code a enlever pour la partie mobile
       if (!jump)
       {
         _y = Input.GetAxisRaw("Jump");
       }
       
        Vector2 _velocity = new Vector2(_x , _y);

        motor.runandjump(_velocity);

       

    }

}
