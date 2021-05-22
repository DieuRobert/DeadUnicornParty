using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_02 : MonoBehaviour

{
    protected Joystick joystick;
    protected JoyButton_tir joybuttontir;
    protected bool tir;
    private float fin;
    private float y;
    private float _Z;
    private float _x;
    public float X { get { return _x; } }

    [SerializeField]
    private float fireRate = 0f;

    [SerializeField]
    private float damage = 10f;

    [SerializeField]
    private LayerMask notToHIT;

    private float timeToFire = 0;
    
    private Transform firePoint;

    [SerializeField]
    private Transform bulletTrailPrefab;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform effetPrefab;

   

    [SerializeField]
    private int Speed = 10;

    private Player player;

    private Vector2 tirDirection = Vector2.zero;


    private void Awake()
    {
        firePoint = transform.GetChild(0);

        if (firePoint == null)
        {
            Debug.LogError("pas de firepoint");
        }
    }
    private void Start()
    {
        player = GameManager.Instance.PlayerInstanciate.GetComponent<Player>();
    
        
            joystick = FindObjectOfType<Joystick>();
            joybuttontir = FindObjectOfType<JoyButton_tir>();
            fin = transform.localPosition.x;
            y = transform.localPosition.y;
            tirDirection = Vector2.right;
   
    }

    void Update()
    {
        if (joystick.Horizontal != 0)
       {
            if (joystick.Horizontal < 0)
          {
                _x = -1;


            }
           if (joystick.Horizontal > 0)
            {
               _x = 1;

            }
        }
        if (joystick.Horizontal == 0)
        {
            _x = Input.GetAxisRaw("Horizontal");
       }

        if (_x == -1)
        {
            //GetComponent<SpriteRenderer>().flipX = true;

            //GetComponentInChildren<SpriteRenderer>().flipX = true;
            //transform.localPosition = new Vector3(-fin, y);
            firePoint.transform.rotation = Quaternion.Euler(0f, 0f, -180f);
            tirDirection = -Vector2.right;
        }
        else if (_x == 1)
        {
           //GetComponent<SpriteRenderer>().flipX = false;
            //GetComponentInChildren<SpriteRenderer>().flipX = false;

           //transform.localPosition = new Vector3(fin, y);
           firePoint.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
           tirDirection = Vector2.right;

        }
        
        if (fireRate == 0)
        {
            //code  pour  mobil
            //if ( joybuttontir.TirPressed)

            //code  pour partie mobil +pc
            if (Input.GetKeyDown("x") || joybuttontir.TirPressed)

            { 
                   
                Shoot();
            }
        }//code  pour  mobil 
        //else if (joybuttontir.TirPressed && Time.time > timeToFire)

        //code  pour partie mobil +pc
        else if (Input.GetKeyDown("x") && Time.time > timeToFire || joybuttontir.TirPressed && Time.time > timeToFire)
        
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
       }

    }
    private void Shoot()
    {

        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody2D>().velocity = tirDirection * Speed * Time.deltaTime * 100f;
        Destroy(Bullet.gameObject, 1f);
      
        Effect();
    }
    private void Effect()
    {

        //fx de tirr
        Transform clone = Instantiate(effetPrefab, firePoint.position, firePoint.rotation) as Transform;
        Debug.Log("rotation" + firePoint.rotation);

        float size = Random.Range(0.6f, 0.9f);

        clone.localScale = new Vector3(size, size, size);

        Destroy(clone.gameObject, 0.02f);

    }
}
