using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class PlayerData
{
    public int Level;

    public PlayerData (GameManager CurrentLevel)
    {
        Level = CurrentLevel.Level;
    }
}
