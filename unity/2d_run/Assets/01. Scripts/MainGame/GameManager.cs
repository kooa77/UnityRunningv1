using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton

    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(null == _instance)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }


	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}


    // Interface

    public PlayerController PlayerControllerScr;

    public PlayerController GetPlayer()
    {
        return PlayerControllerScr;
    }
}
