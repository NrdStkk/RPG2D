using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
     *  Classe pai que os inimigos irão herdar, com os valores communs entre cada
     */
    

    /*
     * Variáveis comuns em todos os tipos de inimigos
     */
    public int enemyHealth;
    public float enemyMoveSpeed;
    public int coinDrop;
    public string enemyName;
    public float enemyDamage;
    public Rigidbody2D enemyRigidbody;
    public Animator enemyAnimator;

}
