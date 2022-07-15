using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWood : Enemy
{

    public float chaseRadius;
    public float attackRadius;
    private Transform target;
    private Transform homePos;
    private Vector2 chaseVector;


    void Start()
    {
        SetValues();

        target = GameObject.FindWithTag("Player").transform;
    }


    void Update()
    {
        DistanceCheck();
    }


    /*
     *  Função que define os valores herdados da classe enemy e desta classe.
     */
    private void SetValues()
    {
        enemyName = "Wood Monster";
        enemyMoveSpeed = 4f;
        enemyDamage = 2;
        enemyHealth = 5;
        coinDrop = 2;
        chaseRadius = 4.5f;
        attackRadius = .3f;
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }


    /*
     *  Função que verifica a distancia entre o player e o inimigo
     */
    private void DistanceCheck()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            enemyAnimator.SetBool("walking", true);

            Vector2 direction = target.position - gameObject.transform.position;
            AnimationControl(direction);

            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, enemyMoveSpeed * Time.deltaTime);

            enemyRigidbody.MovePosition(temp);
        }
        else
        {
            enemyAnimator.SetBool("walking", false);
            enemyAnimator.SetFloat("movX", 0);
            enemyAnimator.SetFloat("movY", 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Attack")
        {
            gameObject.SetActive(false);
        }
    }

    private void AnimationControl(Vector2 direction)
    {
        enemyAnimator.SetFloat("movX", direction.x);
        enemyAnimator.SetFloat("movY", direction.y);
    }

}
