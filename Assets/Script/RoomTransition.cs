using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : PreviousData
{

    private BoxCollider2D transition;
    private string nextStage;
    private string currentStage;
    private Transform player;
    private Transform returnPosition;
    
    void Start()
    {
        transition = GetComponent<BoxCollider2D>();
        nextStage = gameObject.name;
        currentStage = SceneManager.GetActiveScene().name;

        GetStartLocation();
        SetStartingLocation();

        previousStage = currentStage;
    }

   public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextStage);
        }
    }

    public void SetStartingLocation()
    {
        if(returnPosition != null)
        {
            GetPlayerObject();

            player.position = returnPosition.position;

            if (player.position != returnPosition.position)
            {
                Debug.LogError("Failed to set start position");
            }
        }
    }

    public void GetPlayerObject()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null) 
        {
            Debug.LogError("Player object not found");
        }
    }

    public void GetStartLocation()
    {
        try
        {
            returnPosition = GameObject.Find(previousStage + "_ReturnPosition").transform;
        }
        catch
        {
            Debug.Log("No previous stage found");
        }
        
    }
}
