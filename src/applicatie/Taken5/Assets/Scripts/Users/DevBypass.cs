using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevBypass : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void bypass()
    {
        Info.ActivePuzzel = -1;
        Info.Diamanten = 0;
        Info.SessieCode = "BARTJE";
        Info.SessieId = 1;
        Info.spelerId = 2;
        Info.TeamId = 1;
        Info.TeamNaam = "Antwerp!!!";
        levelLoader.LoadLevel(5);
    }
}
