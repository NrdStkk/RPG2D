using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    public int coinDrop;
    public string enemyName;
    public float chaseRadius;
    public float attackRadius;
    protected Player playerObject;
    protected Transform target;
    protected Transform homePos;
    protected Vector2 chaseVector;

    protected void SetValues(string name, float speed, int damage, int health, int coin, float chase, float attack)
    {
        enemyName = name;
        entSpeed = speed;
        entDamage = damage;
        entTotalHealth = health;
        entCurHealth = health;
        coinDrop = coin;
        chaseRadius = chase;
        attackRadius = attack;
        entRigidBody = GetComponent<Rigidbody2D>();
        entAnimator = GetComponent<Animator>();
    }

    /*
     *  Função que verifica a distancia entre o player e o inimigo
     */
    protected void DistanceCheck()
    {
        if (Vector2.Distance(target.position, transform.position) <= chaseRadius
            && Vector2.Distance(target.position, transform.position) > attackRadius)
        {
            entAnimator.SetBool("walking", true);

            Vector2 direction = target.position - gameObject.transform.position;
            entAnimator.SetFloat("moveX", direction.x);
            entAnimator.SetFloat("moveY", direction.y);

            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, entSpeed * Time.deltaTime);

            entRigidBody.MovePosition(temp);
        }
        else
        {
            entAnimator.SetBool("walking", false);
            entAnimator.SetFloat("moveX", 0);
            entAnimator.SetFloat("moveY", 0);
        }
    }

}
