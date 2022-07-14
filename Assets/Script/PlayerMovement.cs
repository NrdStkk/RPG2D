using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float spd = 7f;
    private Vector2 vector;
    private Rigidbody2D rb;
    private Animator anim;
    private CircleCollider2D attackCollider;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;
    }

    public void Mover(float h, float v)
    {
        AnimatorControl();
        vector = new Vector2(h * spd, v * spd);
        rb.velocity = vector;
        anim.SetFloat("moveX", vector.x);
        anim.SetFloat("moveY", vector.y);
        
    }

    private void AnimatorControl() 
    {
        if (vector.x != 0 || vector.y != 0)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    public void Update()
    {
        Mover(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Este comando busca o estado atual do player, e garante que ele não consiga atacar, antes de terminar a cena do primeiro ataque (20 ms)
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("Player_Attack");

        //Comando que ao pressionar, ativa o Trigger de ataque
        if (Input.GetKeyDown("e") || Input.GetMouseButtonDown(0) && !attacking)
        {
            anim.SetTrigger("attacking");
        }

        if (vector != Vector2.zero)
        {
            attackCollider.offset = new Vector2(vector.x / 10, vector.y / 10);
        }

        if (attacking)
        {
            float playbackTime = stateInfo.normalizedTime;
            if (playbackTime > 0.63 && playbackTime < 1.266)
            {
                attackCollider.enabled = true;
            }else
            {
                attackCollider.enabled = false;
            }
            
        }
    }

}
