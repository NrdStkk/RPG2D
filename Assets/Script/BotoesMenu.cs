using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Função para mudar a cena ao clicar em NOVO JOGO
    public void NovoJogo()
    {
        SceneManager.LoadScene("Jogo");
    }


    // Função para mudar a cena ao clicar em CARREGAR JOGO
    public void CarregarJogo()
    {
        SceneManager.LoadScene("Jogo");
    }
}
