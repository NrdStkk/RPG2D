using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWood : Enemy
{
    void Start()
    {
        SetValues("Wood Monster", 5f, 2, 6, 2, 4.5f, .3f);
        target = GameObject.FindWithTag("Player").transform;
        if (GameObject.FindWithTag("Player").TryGetComponent<Player>(out Player tempPlayerObject))
        {
            playerObject = tempPlayerObject;
        } 
        else
        {
            Debug.LogError("Player Object not foud");
        }
    }


    void Update()
    {
        DistanceCheck();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
            TakeDamage(playerObject.GetDamage(), playerObject.transform);
        }
    }

}
