using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilling : MonoBehaviour
{
    private Transform[] spritesBg;

    private int indexDroit;

    private int indexGauche;

    private float viewZone;

    private void Start()
    {
        spritesBg = new Transform[transform.childCount];
        for (int i = 0; i < spritesBg.Length; i++)
        {
            spritesBg[i] = transform.GetChild(i);
        }

        indexGauche = 0;
        indexDroit = spritesBg.Length - 1;
    }



    private void Update()
    {
        viewZone = (Camera.main.orthographicSize * Screen.width) / Screen.height;

        if (Camera.main.transform.position.x >= (spritesBg[indexDroit].position.x + spritesBg[indexDroit].GetComponent<SpriteRenderer>().bounds.size.x / 2) - viewZone)
        {
            spritesBg[indexGauche].position = new Vector3(spritesBg[indexDroit].position.x + spritesBg[indexDroit].GetComponent<SpriteRenderer>().bounds.size.x, spritesBg[indexDroit].position.y, spritesBg[indexDroit].position.z);

            indexDroit = indexGauche;
            indexGauche++;
            if (indexGauche > spritesBg.Length -1)
            {
                indexGauche = 0;
            }

        }
        if (Camera.main.transform.position.x <= (spritesBg[indexGauche].position.x - spritesBg[indexGauche].GetComponent<SpriteRenderer>().bounds.size.x / 2) + viewZone)
        {
            spritesBg[indexDroit].position = new Vector3(spritesBg[indexGauche].position.x - spritesBg[indexGauche].GetComponent<SpriteRenderer>().bounds.size.x, spritesBg[indexDroit].position.y, spritesBg[indexDroit].position.z);

            indexGauche = indexDroit;
            indexDroit--;
            if (indexDroit < 0)
            {
                indexDroit = spritesBg.Length - 1;
            }

        }
    }
}
