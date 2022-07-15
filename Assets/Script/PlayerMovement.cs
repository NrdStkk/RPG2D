using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    /*
     * Enumerador que define os possiveis estados do player
     */
    public enum PlayerState
    {
        idle,
        walking,
        attacking,
        interacting,
        dead
    }

    /*
     * Variáveis
     */
    public PlayerState currentState;
    private float spd = 6f;
    private Vector2 vector;
    private Rigidbody2D rb;
    private Animator anim;
    private CircleCollider2D attackCollider;
    private CircleCollider2D interactCollider;
    public Button btnAttack;
    public Button btnInteract;


    public void Start()
    {
        currentState = PlayerState.idle;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        btnAttack.onClick.AddListener(Attack);
        btnInteract.onClick.AddListener(Interact);

        attackCollider = GameObject.FindGameObjectWithTag("Attack").GetComponent<CircleCollider2D>();
        attackCollider.gameObject.SetActive(false);
        interactCollider = GameObject.FindGameObjectWithTag("Interacting").GetComponent<CircleCollider2D>();
        interactCollider.gameObject.SetActive(false);
    }

    public void Update()
    { 

        if (Input.GetMouseButtonDown(1) && currentState != PlayerState.interacting)
        {
            Interact();
        }
        else if (Input.GetMouseButtonDown(2) && currentState != PlayerState.attacking)
        {
            Attack();
        }

        //  Comando de movimento para desktop
        //Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //  Comando de movimento para mobile
        Move(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));

        anim.SetFloat("moveX", vector.x);
        anim.SetFloat("moveY", vector.y);
    }

    public void Move(float h, float v)
    {
        if (currentState == PlayerState.attacking)
        {
            rb.velocity = Vector2.zero;
        }
        else if (h != 0 || v != 0)
        {
            currentState = PlayerState.walking;
            vector = new Vector2(h * spd, v * spd);
            anim.SetBool("moving", true);
            rb.velocity = vector;
        }
        else
        {
            anim.SetBool("moving", false);
            currentState = PlayerState.idle;
            rb.velocity = Vector2.zero;
        }
    }

    public void Interact()
    {
        StartCoroutine(InteractCo());
    }

    public void Attack()
    {
        currentState = PlayerState.attacking;
        StartCoroutine(AttackCo());
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            PauseGame.gameOver = true;
            currentState = PlayerState.dead;
        }
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("attacking", true);
        anim.SetBool("moving", false);
        attackCollider.gameObject.SetActive(true);
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.22f);
        attackCollider.gameObject.SetActive(false);
        currentState = PlayerState.idle;
    }

    private IEnumerator InteractCo()
    {
        interactCollider.gameObject.SetActive(true);
        currentState = PlayerState.interacting;
        yield return new WaitForSeconds(0.5f);
        interactCollider.gameObject.SetActive(false);
        currentState = PlayerState.idle;
    }

}
