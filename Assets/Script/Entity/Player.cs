using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Entity {
    /*
     * Variáveis
     */
    private CircleCollider2D interactCollider;
    //public Button btnAttack;
    //public Button btnInteract;


    public void Start()
    {
        //btnAttack.onClick.AddListener(Attack);
        //btnInteract.onClick.AddListener(Interact);
        currentState = EntityState.idle;
        entRigidBody = GetComponent<Rigidbody2D>();
        entAnimator = GetComponent<Animator>();
        entSpeed = 6f;
        entDamage = 2;
        entTotalHealth = 10;
        entCurHealth = entTotalHealth;


        attackCollider = GameObject.FindGameObjectWithTag("Attack").GetComponent<CircleCollider2D>();
        attackCollider.gameObject.SetActive(false);
        interactCollider = GameObject.FindGameObjectWithTag("Interacting").GetComponent<CircleCollider2D>();
        interactCollider.gameObject.SetActive(false);
    }

    public void Update()
    { 

        if (Input.GetKeyDown("e") && currentState != EntityState.interacting)
        {
            Interact();
        }
        else if (Input.GetKeyDown("space")&& currentState != EntityState.attacking)
        {
            Attack();
        }

        //  Comando de movimento para desktop
        //Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //  Comando de movimento para mobile (tambem funciona desktop)
        Move(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
    }

    public void Interact()
    {
        StartCoroutine(InteractCo());
    }

    public void Attack()
    {
        currentState = EntityState.attacking;
        StartCoroutine(AttackCo());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyObject))
        {
            this.TakeDamage(enemyObject.GetDamage(), enemyObject.transform);   
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

    private IEnumerator InteractCo()
    {
        interactCollider.gameObject.SetActive(true);
        currentState = EntityState.interacting;
        yield return new WaitForSeconds(0.5f);
        interactCollider.gameObject.SetActive(false);
        currentState = EntityState.idle;
    }

}
