using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousData : MonoBehaviour
{
    /*
     *  Classe com variáveis estáticas que guardam os valores prevalecentes durante a troca de estágio
     */

    public static int savedCoins;
    public static string previousStage;
    public static string currentStage;

    public static void ResetValues()
    {
        previousStage = "";
        savedCoins = 0;
    }

}
