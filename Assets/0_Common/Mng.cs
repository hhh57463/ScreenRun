using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mng : MonoBehaviour {

    private static Mng _Instance = null;
    public int nJoyStickPos = 0;
    public static Mng I
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
        Screen.SetResolution(1280, 720, false);
        DontDestroyOnLoad(transform.gameObject);
    }

}