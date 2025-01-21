using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string playerName;
    public static float volume;
    public static Material[] playerColor;
    public static int lives;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }
}
