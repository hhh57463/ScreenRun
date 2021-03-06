﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameMng : MonoBehaviour
{

    private static SGameMng _Instance = null;

    public GameObject ItemPre = null;
    public GameObject ItemAni = null;
    public GameObject GameObjects = null;
    public GameObject AniGams = null;

    public Transform ItemZenPr = null;

    public Vector3 ItemPosVec;

    public bool bHeroDie = false;
    public bool bHeroDmgAccess = false;
    public bool bItemZenStart = false;

    public float fFireDownSpeed = 2f;
    public float fFireSpeed = 0.5f;
    public float fMapScrollSpeed = 0.5f;
    public float fHandSpeed = 10.0f;
    public float fItemSpeed = 2f;
    public float fHeroCompulsionMoveSpeed = 0.5f;                   //플레이어 강제 속도
    public float fHeroSpeed = 4f;
    public float fDifficultyUpTime = 10f;
    public float fIteZenTime = 10f;
    public float fAngelDmgAccessCount = 0f;
    public float[] fZenPos;


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
        StartCoroutine(ItemZen());
    }

    void Update()
    {
        if (bItemZenStart)
        {
            StartCoroutine(ItemZen());
            bItemZenStart = false;
        }
    }

    public IEnumerator ItemZen()
    {
        ItemPosRandomSetting();
        yield return new WaitForSeconds(fIteZenTime);
        ItemAni.SetActive(true);
        Instantiate(ItemPre, ItemPosVec, Quaternion.identity, ItemZenPr);
    }

    void ItemPosRandomSetting()
    {
        fZenPos[0] = Random.Range(-2f, 2f);
        fZenPos[1] = Random.Range(-1.5f, 1.5f);
        ItemPosVec = new Vector3(fZenPos[0], fZenPos[1], 0f);
    }

}
