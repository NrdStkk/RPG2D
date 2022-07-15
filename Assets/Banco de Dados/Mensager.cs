using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Mensager : GameController {

    public string addUrl = "http://www.lab.educacao.ws/record.php"; // URL para enviar cargas de dados
    public string getUrl = "http://www.lab.educacao.ws/display.php";// URL para receber cargas de dados

    public string saveName = saveData[0];
    public int score = Int32.Parse(saveData[1]);

    public UnityEngine.UI.Text output;  // Saida de informações

    void Start () {
        //StartCoroutine ( GetScores () ); // Cria uma corrotina, uma função atrelada a outro nucleo de processamento.
    }

    public void EnviarMensagem()
    {
        StartCoroutine( PostData(saveName, score) );
    }

    // Voce deve utilizar esta função como corrotina.
    IEnumerator PostData ( string saveName, int score ) {
        // Estes comandos inician a chamada do PHP que deve de estar nos ervidor
        // É feita a montagem de uma mensagem com uma URL e a mensagem anexada a string
        
        string post_url = addUrl + "?nome=" + WWW.EscapeURL ( saveName ) + "&pontuacao=" + score;

        // Cria um objeto para receber a informação enviada pelo servidor
        WWW hs_post = new WWW ( post_url );

        yield return hs_post; // Adiciona um comando de espera para travar o código até a resposta do servidor

        if ( hs_post.error != null )
        {
            print ( "OPA! Tivemos um erro ao enviar a mensagem: " + hs_post.error );
        }

        //StartCoroutine(GetScores());
    }


    /*
    // Pega as informações do banco de dados do MySQL DB to display in a GUIText.
    IEnumerator GetScores () {
        output.text = "Loading..."; // Muda a mensagem para um LOADING enquanto não recebe o retorno do servidor.
        WWW hs_get = new WWW ( getUrl );
        yield return hs_get;

        if ( hs_get.error != null )
        {
            print ( "There was an error getting the high score: " + hs_get.error );
        } else
        {
            output.text = hs_get.text; // Este carinha aqui vai nos mostrar a resposta quando estiver disponivel ;).
        }
    }
    */

}
