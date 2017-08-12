using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGameMng : MonoBehaviour
{

    private static SGameMng _Instance = null;

    public GameObject ItemPre;
    public Transform ItemZenPr;

    public Vector3 ItemPosVec;

    public bool bItemZenStart = false;

    public float fFireDownSpeed = 2f;
    public float fFireSpeed = 0.5f;
    public float fMapScrollSpeed = 0.5f;
    public float fHandSpeed = 10.0f;
    public float fItemSpeed = 2f;
    public float fHeroCompulsionMoveSpeed = 0.5f;
    public float fHeroSpeed = 4f;
    public float fDifficultyUpTime = 10f;
    public float fIteZenTime = 10f;
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
        Instantiate(ItemPre, ItemPosVec, Quaternion.identity, ItemZenPr);
    }

    void ItemPosRandomSetting()
    {
        fZenPos[0] = Random.Range(-6f, 6f);
        fZenPos[1] = Random.Range(-4f, 4f);
        ItemPosVec = new Vector3(fZenPos[0], fZenPos[1], 0f);
    }

}
