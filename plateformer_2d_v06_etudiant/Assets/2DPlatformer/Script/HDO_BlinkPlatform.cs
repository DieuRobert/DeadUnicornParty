using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HDO_BlinkPlatform : MonoBehaviour
{
    enum platType { tilemap, box}
    //choisit ton type de plateforme

    [SerializeField]
    platType type;

    [Header("Stats")]
    [SerializeField]
    bool isRandomized;
    [SerializeField]
    float duration;

    [Header("If Randomized")]
    [SerializeField]
    float minInvisibleDuration;
    [SerializeField]
    float maxInvisibleDuration, minVisibleDuration, maxVisibleDuration;

    float elapsedTime;
    bool visible;

    //si c'est un asset unique avec un boxCollider2D

    BoxCollider2D box;
    SpriteRenderer sr;

    //si c'est une tilemap de mort

    TilemapCollider2D tc;
    TilemapRenderer tr;


    // Start is called before the first frame update
    void Start()
    {
        if(type == platType.box)
        {
            box = GetComponent<BoxCollider2D>();
            sr = GetComponent<SpriteRenderer>();
        }
        else
        {
            tc = GetComponent<TilemapCollider2D>();
            tr = GetComponent<TilemapRenderer>();

        }

        visible = true;
        if (isRandomized)
        {
            elapsedTime = Random.Range(minVisibleDuration, maxVisibleDuration);
        }
        else
        {
            elapsedTime = duration;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime -= Time.deltaTime;

        if(elapsedTime <= 0 && visible)
        {
            Disappear();
        }
        else if(elapsedTime <= 0 && !visible)
        {
            Appear();
        }
    }

    void Disappear()
    {
        visible = false;

        if(type == platType.box)
        {
            if (isRandomized)
            {
                elapsedTime = Random.Range(minInvisibleDuration, maxInvisibleDuration);
            }
            else
            {
                elapsedTime = duration;
            }

            sr.enabled = false;
            box.enabled = false;
        }
        else
        {
            if (isRandomized)
            {
                elapsedTime = Random.Range(minInvisibleDuration, maxInvisibleDuration);
            }
            else
            {
                elapsedTime = duration;
            }

            tr.enabled = false;
            tc.enabled = false;
        }
    }

    void Appear()
    {

        visible = true;

        if (type == platType.box)
        {
            if (isRandomized)
            {
                elapsedTime = Random.Range(minInvisibleDuration, maxInvisibleDuration);
            }
            else
            {
                elapsedTime = duration;
            }

            sr.enabled = true;
            box.enabled = true;
        }
        else
        {
            if (isRandomized)
            {
                elapsedTime = Random.Range(minInvisibleDuration, maxInvisibleDuration);
            }
            else
            {
                elapsedTime = duration;
            }

            tr.enabled = true;
            tc.enabled = true;
        }
    }
}
