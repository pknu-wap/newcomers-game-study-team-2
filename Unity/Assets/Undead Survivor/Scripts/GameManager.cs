using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Mnobehaviour
{
    public static GameManager instance;
    public Player player;

    void Awake()
    {
        instance = this;
    }
}