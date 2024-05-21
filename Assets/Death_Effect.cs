using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Effect : MonoBehaviour
{
    public static Death_Effect instance;
    private GameObject Player;
    private Transform CheckPawn;
    IEnumerator coroutine;

    private void Awake()
    {
        if( instance != null)
        {
            Debug.LogError("Singleton problem");
            return;

        }

        instance = this;
    }

    private void Start()
    {
        CheckPawn = GameObject.FindWithTag("Spawn").transform;
        Player = GameObject.FindWithTag("Player");
    }

    public void Death_Player()
    {        
        StartCoroutine(Time_Death_effect());
    }

    IEnumerator Time_Death_effect()
    {
        // Animation mort
        yield return new WaitForSeconds(1);
        Player.transform.position = CheckPawn.position;
        // Animation Respawn
    }

}
