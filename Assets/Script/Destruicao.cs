using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruicao : MonoBehaviour
{
    // Variavel para guardar o nome do estado de destruição
    public string destroyState;
    // Variavel com os segundos para esperar antes de desativar a colisão
    public float timeForDisable;

    //Animador para controlar a animação
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Função para detectar a colisão
    IEnumerator OnTriggerEnter2D (Collider2D col)
    {
        // Se estiver marcado com a tag Attack
        if (col.tag == "Attack")
        {
            // Reproduz a animação de destruição e aguarda
            anim.Play(destroyState);
            yield return new WaitForSeconds(timeForDisable);

            // Passados os segundos de espera, desativamos os Colliders 2D
            foreach(Collider2D c in GetComponents<Collider2D>())
            {
                c.enabled = false;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Destruir o objeto e finalizar a animação de destruição
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(destroyState) && stateInfo.normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }
}
