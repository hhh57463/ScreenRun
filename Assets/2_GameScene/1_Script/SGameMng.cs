using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameMng : MonoBehaviour {

    private static SGameMng _Instance = null;
    public float fFireSpeed = 0.5f;
    public float fMapScrollSpeed = 0.5f;
    public float fHandSpeed = 5.0f;
    public float fHeroCompulsionMoveSpeed = 0.5f;
    public float fHeroSpeed = 4f;

    public static SGameMng I
    {
        get
        {
            if (_Instance == null)
            {
                Debug.Log("instance is null");
            }
            return _Instance;
        }
    }

    void Awake()
    {
        _Instance = this;
    }

}
