using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float velocidade = 8f;
    public Vector3 vector = new Vector3(0, 0, 0);
    public Rigidbody2D rb;

    public void Mover(float h, float v)
    {
        rb.velocity = new Vector2(h * velocidade, v * velocidade);
    }

    public void Update()
    {
        Mover(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

}
