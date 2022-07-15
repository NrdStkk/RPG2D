using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust;
    public float duration;

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && gameObject.tag == "attacking")
        {
            Rigidbody2D enemyRB = other.GetComponent<Rigidbody2D>();
            if (enemyRB != null)
            {
                Vector2 difference = enemyRB.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemyRB.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemyRB));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemyRB)
    {
        if (enemyRB != null)
        {
            yield return new WaitForSeconds(duration);
            enemyRB.velocity = Vector2.zero;
        }
    }
}
