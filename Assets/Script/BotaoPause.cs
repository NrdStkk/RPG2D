using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPause : MonoBehaviour
{
    public void PausarJogo()
    {
        GameState.paused = !GameState.paused;

    }


}
