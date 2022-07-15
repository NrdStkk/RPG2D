using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadMenu;
    public Button btnNewGame;
    public Button btnLoadGame;
    public Button btnLoad;
    public Button btnCancel;
    public InputField loadName;
    public InputField loadPass;
    public Text output;
    
    public string getUrl = "http://www.lab.educacao.ws/2020/rpg2d/displayrpg2d.php";

    void Start()
    {
        btnNewGame.onClick.AddListener(NewGame);
        btnLoadGame.onClick.AddListener(LoadGame);
        btnCancel.onClick.AddListener(CancelLoad);
        btnLoad.onClick.AddListener(MakeLoad);

        PauseGame.gameOver = false;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene");
        PreviousData.ResetValues();
    }

    public void LoadGame()
    {
        loadMenu.SetActive(true);
    }

    public void MakeLoad()
    {
        StartCoroutine(GetLoad(loadName.text, loadPass.text));
    }

    public void CancelLoad()
    {
        loadMenu.SetActive(false);
    }

    public void SetLoadData(string loadData)
    {
        string[] formatedData = loadData.Split(null);

        PreviousData.savedCoins = int.Parse(formatedData[0]);
        PreviousData.currentStage = formatedData[1];

        SceneManager.LoadScene(PreviousData.currentStage);
    }

    public IEnumerator GetLoad(string loadName, string loadPass)
    {
        output.text = "Loading..."; // Muda a mensagem para um LOADING enquanto não recebe o retorno do servidor.
        WWW hs_get = new WWW(getUrl + "?nome=" + WWW.EscapeURL(loadName) + "&senha=" + WWW.EscapeURL(loadPass));
        yield return hs_get;

        output.text = hs_get.text;

        SetLoadData(hs_get.text);
    }
}
