using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWood : Enemy
{
    /*
     *  Classe de inimigos Wood que herda a classe Enemy 
     */

    // Start is called before the first frame update
    void Start()
    {
        SetAttributes();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetAttributes()
    {
        enemyName = "Wood Monster";
        spd = 3f;
    }

}
