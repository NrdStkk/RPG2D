using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGame : MonoBehaviour
{
    public GameObject saveMenu;
    public BoxCollider2D saveCollider;
    public bool interaction = false;

    void Start()
    {
        saveCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction)
        {
            OpenSaveMenu(); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Interacting"))
        {
            interaction = true;
        }
        else
        {
            interaction = false;
        }
    }

    public void OpenSaveMenu()
    {
        interaction = false;
        saveMenu.SetActive(true);
        PauseGame.Pause();
    }
}
