using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : PreviousData
{
    public int totalScore;
    public Text pauseText;
    public TextMeshProUGUI scoreText;
    public Button btn_save;
    public Button btn_cancel;
    public Button btn_menu;
    public static string[] saveData = new string[4];
    public InputField inputName;
    public InputField inputPass;
    public GameObject menu;
    public GameObject GameOverMenu;

    public string addUrl = "http://www.lab.educacao.ws/2020/rpg2d/recordrpg2d.php";

    public static GameController gameController;
        
    void Start()
    {
        GameOverMenu.SetActive(false);
        menu.SetActive(false);
        gameController = this;
        totalScore = savedCoins;
        scoreText.text = totalScore.ToString();
        btn_save.onClick.AddListener(SaveGame);
        btn_cancel.onClick.AddListener(CancelSave);
        btn_menu.onClick.AddListener(ReturnMainMenu);
    }

    void Update()
    {
        if (PauseGame.paused)
        {
            pauseText.gameObject.SetActive(true);
        }
        else
        {
            pauseText.gameObject.SetActive(false);
        }

        if (PauseGame.gameOver == true)
        {
            GameOverMenu.SetActive(true);
        }

    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
        savedCoins = totalScore;
    }

    public void CancelSave()
    {
        menu.SetActive(false);
        PauseGame.Resume();
    }

    public void SaveGame()
    {
        Debug.Log("Saving Data");
        saveData[0] = inputName.text;
        saveData[1] = scoreText.text;
        saveData[2] = inputPass.text;
        saveData[3] = SceneManager.GetActiveScene().name;
        menu.SetActive(false);
        PauseGame.Resume();

        StartCoroutine(PostData(saveData[0], saveData[1], saveData[2], saveData[3]));
        
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public IEnumerator PostData(string saveName, string score, string pass, string scene)
    {
        // Estes comandos inician a chamada do PHP que deve de estar nos ervidor
        // É feita a montagem de uma mensagem com uma URL e a mensagem anexada a string

        string post_url = addUrl + "?nome=" + WWW.EscapeURL(saveName) + "&pontuacao=" + WWW.EscapeURL(score) + "&senha=" + WWW.EscapeURL(pass) + "&cena=" + WWW.EscapeURL(scene);

        // Cria um objeto para receber a informação enviada pelo servidor
        WWW hs_post = new WWW(post_url);

        yield return hs_post; // Adiciona um comando de espera para travar o código até a resposta do servidor

        if (hs_post.error != null)
        {
            print("OPA! Tivemos um erro ao enviar a mensagem: " + hs_post.error);
        }
    }

}
