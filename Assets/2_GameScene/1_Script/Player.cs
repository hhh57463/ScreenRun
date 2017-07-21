using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public JoyStick JoyStickSc;
    float fSpeed = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (JoyStickSc.bUse)
            transform.localPosition += new Vector3(JoyStickSc.DirVec.x, JoyStickSc.DirVec.y, JoyStickSc.DirVec.z) * fSpeed * Time.deltaTime;
    }
}
