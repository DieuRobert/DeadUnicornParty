using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
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
    private Transform effetPrefab;

    private Player player;


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
    }


    void Update()
    {
        // pour tirer
        if (fireRate == 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
        else if (Input.GetMouseButton(0) && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }

    }
    private void Shoot()
    {
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 mousePosition = new Vector2(mousePositionWorld.x, mousePositionWorld.y);

        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
       

        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, Mathf.Infinity , notToHIT);
       
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100);
        
        if (hit.collider != null)
        {
            //Debug.Log("toucher enemy");
            Debug.DrawLine(firePointPosition, hit.point, Color.red);

            if (hit.collider.tag.Equals("enemy"))
            {
                EnemyFight enemy = hit.collider.gameObject.GetComponent<EnemyFight>();
                player.Attaque(enemy);
            }
        }

         Vector3 hitPos;
      
        if (hit.collider == null)
        {
             hitPos = (mousePosition - firePointPosition) *10;
           
        }
        else
        {
            hitPos = hit.point;
        }

        Effect(hitPos);

    }

    private void Effect(Vector3 hitPos)
   
    {
        
            Transform Trail = Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);
            
            LineRenderer lr = Trail.GetComponent<LineRenderer>();
            if (lr != null)
            {
                lr.SetPosition(0, firePoint.position);
                lr.SetPosition(1, hitPos);
            }

            Destroy(Trail.gameObject, 0.03f);

            Transform clone = Instantiate(effetPrefab, firePoint.position, firePoint.rotation) as Transform;
           

            float size = Random.Range(0.6f, 0.9f);

            clone.localScale = new Vector3(size, size, size);
           
            Destroy(clone.gameObject, 0.02f);
        
    }
}

