using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected enum EntityState
    {
        idle,
        walking,
        attacking,
        interacting,
        dead
    }

    protected EntityState currentState;
    protected float entSpeed;
    protected int entTotalHealth;
    [SerializeField]protected int entCurHealth;
    protected int entDamage;
    protected Vector2 vector;
    protected Rigidbody2D entRigidBody;
    protected Animator entAnimator;
    [SerializeField]protected CircleCollider2D attackCollider;


    protected void Move(float h, float v)
    {

        if (currentState == EntityState.attacking)
        {
            entRigidBody.velocity = Vector2.zero;
        }
        else if (h != 0 || v != 0)
        {
            currentState = EntityState.walking;
            vector = new Vector2(h * entSpeed, v * entSpeed);
            entAnimator.SetBool("moving", true);
            entRigidBody.velocity = vector;
        }
        else
        {
            entAnimator.SetBool("moving", false);
            currentState = EntityState.idle;
            entRigidBody.velocity = Vector2.zero;
        }

        entAnimator.SetFloat("moveX", vector.x);
        entAnimator.SetFloat("moveY", vector.y);
    }

    protected void Attack()
    {
        currentState = EntityState.attacking;
        StartCoroutine(AttackCo());
    }

    public void TakeDamage(int damageTaken, Transform attacker)
    {
        Debug.Log("Dano recebido:" + damageTaken);

        this.entCurHealth -= damageTaken;

        if (this.entCurHealth <= 0)
        {
            IAmDead();
        }
        else 
        {
            Vector2 difference = this.transform.position - attacker.position;
            difference = difference.normalized * 5;
            Debug.Log("Difference:" + difference);
            StartCoroutine(KnockCo(difference));
        }
    }

    public int GetDamage()
    {
        return entDamage;
    }

    private void IAmDead()
    {
        this.currentState = EntityState.dead;

        if (this.tag == "Player")
        {
            PauseGame.gameOver = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator AttackCo()
    {
        entAnimator.SetBool("attacking", true);
        entAnimator.SetBool("moving", false);
        attackCollider.gameObject.SetActive(true);
        yield return null;
        entAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(.22f);
        attackCollider.gameObject.SetActive(false);
        currentState = EntityState.idle;
    }

    private IEnumerator KnockCo(Vector2 difference)
    {
        this.entRigidBody.velocity = Vector2.zero;
        this.entRigidBody.AddForce(difference, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.5f);
        entRigidBody.velocity = Vector2.zero;
    }
}
