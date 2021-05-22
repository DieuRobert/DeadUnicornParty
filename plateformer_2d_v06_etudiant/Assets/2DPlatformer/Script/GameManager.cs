using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    [SerializeField]
    private Transform playerPrefab;

    private Transform playerInstantiate;

    private Player playerSript;

    public Transform PlayerInstanciate { get { return playerInstantiate; }}
    

    [SerializeField]
    private Transform SpawnPoint;

    private Camera2DFollow cam;

    [SerializeField]
    private GameObject effectSpawn;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;

        cam = Camera.main.GetComponent<Camera2DFollow>();

        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        playerInstantiate = Instantiate(playerPrefab, SpawnPoint.position, Quaternion.identity);

        cam.target = playerInstantiate;

        playerSript = playerInstantiate.GetComponent<Player>();

        playerSript.MonEvent += PlayerSript_MonEvent;
    }
    private void PlayerSript_MonEvent()
    {
        Destroy(playerInstantiate.gameObject);
        StartCoroutine(respawnplayer());
    }


    private IEnumerator respawnplayer()
    {
        Debug.Log("3");

        yield return new WaitForSeconds(0.5f);

        Debug.Log("2");


        yield return new WaitForSeconds(0.5f);

        

        Debug.Log("1");

        yield return new WaitForSeconds(0.5f);



        yield return new WaitForSeconds(0.2f);

        InstantiatePlayer();
        EffectSpawn();

    }

    private void EffectSpawn()
    {

        var clone = Instantiate(effectSpawn, playerInstantiate.position , Quaternion.identity);
        Destroy(clone, 3f);
    }
}
