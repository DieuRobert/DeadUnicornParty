using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]



public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float updateRate = 2f;

    [SerializeField]
    private Path path;

    [SerializeField]
    private float speed;

    [SerializeField]
    private ForceMode2D fMode;

    [SerializeField]
    private float nextWaypointDistance;

    private Seeker seeker;

    private bool pathIsEnded;

    private int currentWaypoint;

    private Rigidbody2D rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GameManager.Instance.PlayerInstanciate;

        if (target == null)
        {
            Debug.LogError("no player found");
        }
        StartCoroutine(UpdatePath());
    }
    private IEnumerator UpdatePath()
    {
        if (target != null)
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);
            yield return new WaitForSeconds(1f / updateRate);
            StartCoroutine(UpdatePath());
        }
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    private void FixedUpdate()
    {
        if(target == null)
        {
            if (GameManager.Instance.PlayerInstanciate !=null)
            {
                target = GameManager.Instance.PlayerInstanciate;
                StartCoroutine(UpdatePath());
            }
            return;
        }
        if(path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }

            pathIsEnded = true;
            return;

        }

        pathIsEnded = false;

        Vector3 dir = path.vectorPath[currentWaypoint] - transform.position;

        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
        
    }
}
