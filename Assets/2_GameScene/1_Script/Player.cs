using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject ResultSceneGams = null;
    public GameObject[] GameUIs = null;
    public GameObject LevelUpAniGams = null;
    public GameObject ShiledGams = null;
    public GameObject AngelGams = null;
    [SerializeField]
    GameObject[] PlayerTransBubble = null;

    public Transform HeroParentTr = null;

    public JoyStick JoyStickSc = null;

    public MapScroll MapSc = null;

    SpriteRenderer HeroSr = null;

    //public bool bHeroDie = false;
    public bool bDifficulty = false;
    [SerializeField]
    bool bMapOut = false;
    [SerializeField]
    bool[] bOutPos;
    [SerializeField]
    bool bAngelSkill = false;


    public int nTimeCount = 0;
    public int nLevel = 1;
    public int nAbilityCount = 0;
    [SerializeField]
    int nMapOutCount = 0;

    // Use this for initialization
    void Start()
    {
        HeroSr = GetComponent<SpriteRenderer>();
        StartCoroutine(TimeCount());
        StartCoroutine(Difficulty());
    }

    // Update is called once per frame
    void Update()
    {
        if (!SGameMng.I.bHeroDie)
            Move();

        if (SGameMng.I.bHeroDie)
        {
            StartCoroutine(HeroDie());
        }
        if (bDifficulty)
        {
            LevelUpAniGams.SetActive(true);
            SGameMng.I.fHeroSpeed += 0.5f;
            SGameMng.I.fMapScrollSpeed += 0.1f;
            SGameMng.I.fHeroCompulsionMoveSpeed += 0.1f;
            SGameMng.I.fFireSpeed += 0.1f;
            SGameMng.I.fFireDownSpeed += 0.5f;
            SGameMng.I.fDifficultyUpTime += 5f;
            nLevel++;
            if (SGameMng.I.fHandSpeed < 0.5)
            {
                SGameMng.I.fHandSpeed -= 0.5f;
            }
            bDifficulty = false;
            StartCoroutine(Difficulty());
        }
        PlayerBubble();
        /////////////////////////////스킬 호출 구간 지울 것!////////////////////////////
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Shiled();
            Angel();
        }
        //////////////////////////////////////////////////////////////////////////////
        if (nMapOutCount == 5)                                                             //맵밖에서 5초동안 있을시 사망
        {
            SGameMng.I.bHeroDie = true;
        }
        if (bAngelSkill && Time.time > SGameMng.I.fAngelDmgAccessCount + 2f)              //천사스킬 발동 후 3초간 무적
        {
            bAngelSkill = false;
            SGameMng.I.fAngelDmgAccessCount = 0f;
        }
    }

    public void Move()
    {
        if (JoyStickSc.bUse)
            HeroParentTr.localPosition += new Vector3(JoyStickSc.DirVec.x, JoyStickSc.DirVec.y, JoyStickSc.DirVec.z) * SGameMng.I.fHeroSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, JoyStickSc.PlayerAngle - 90));

        switch (MapSc.nMapNum)
        {
            case 0:
                HeroParentTr.Translate(Vector2.down * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                break;

            case 1:
                HeroParentTr.Translate(Vector2.left * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                break;

            case 2:
                HeroParentTr.Translate(Vector2.right * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                break;

            case 3:
                HeroParentTr.Translate(Vector2.up * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                break;

            case 4:
                HeroParentTr.Translate(Vector2.left * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                HeroParentTr.Translate(Vector2.down * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                break;

            case 5:
                HeroParentTr.Translate(Vector2.right * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                HeroParentTr.Translate(Vector2.up * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                break;

            case 6:
                HeroParentTr.Translate(Vector2.left * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                HeroParentTr.Translate(Vector2.up * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                break;

            case 7:
                HeroParentTr.Translate(Vector2.right * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                HeroParentTr.Translate(Vector2.down * SGameMng.I.fHeroCompulsionMoveSpeed * Time.deltaTime);
                break;

        }

    }

    void PlayerBubble()
    {
        if (bOutPos[0])
        {
            if (PlayerTransBubble[0].transform.localPosition.x <= 8f && PlayerTransBubble[0].transform.localPosition.x >= -8f)
                PlayerTransBubble[0].transform.localPosition = new Vector3(HeroParentTr.localPosition.x, 4.15f, 0f);
        }
        else if (bOutPos[1])
        {
            if (PlayerTransBubble[1].transform.localPosition.x <= 8f && PlayerTransBubble[1].transform.localPosition.x >= -8f)
                PlayerTransBubble[1].transform.localPosition = new Vector3(HeroParentTr.localPosition.x, -4.15f, 0f);
        }
        else if (bOutPos[2])
        {
            if (PlayerTransBubble[2].transform.localPosition.y <= 4f && PlayerTransBubble[2].transform.localPosition.y >= -4f)
                PlayerTransBubble[2].transform.localPosition = new Vector3(8.15f, HeroParentTr.localPosition.y, 0f);
        }
        else if (bOutPos[3])
        {
            if (PlayerTransBubble[3].transform.localPosition.y <= 4f && PlayerTransBubble[3].transform.localPosition.y >= -4f)
                PlayerTransBubble[3].transform.localPosition = new Vector3(-8.15f, HeroParentTr.localPosition.y, 0f);
        }
    }

    public void RandomAbility()
    {
        switch (nAbilityCount)
        {
            case 1:
                Shiled();
                break;

            case 2:
                Angel();
                break;

            case 3:

                break;

            case 4:

                break;
        }
    }

    void Shiled()
    {
        int nRand = Random.Range(0, 4);
        ShiledGams.SetActive(true);

        Debug.Log(nRand);
        switch (nRand)
        {
            case 0:
                ShiledGams.transform.localPosition = new Vector3(0f, 0.5f, 0f);
                ShiledGams.transform.localRotation = Quaternion.Euler(Vector3.zero);
                break;

            case 1:
                ShiledGams.transform.localPosition = new Vector3(0f, -0.5f, 0f);
                ShiledGams.transform.localRotation = Quaternion.Euler(Vector3.zero);
                break;

            case 2:
                ShiledGams.transform.localPosition = new Vector3(-0.5f, 0f, 0f);
                ShiledGams.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
                break;

            case 3:
                ShiledGams.transform.localPosition = new Vector3(0.5f, 0f, 0f);
                ShiledGams.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
                break;
        }

    }

    void Angel()
    {
        int nAngelRand = Random.Range(0, 4);
        switch(nAngelRand)
        {
            case 0:
                SGameMng.I.bHeroDmgAccess = true;
                SGameMng.I.fAngelDmgAccessCount = Time.time;
                break;

            case 1:

                break;

            case 2:

                break;

            case 3:

                break;
        }
        bAngelSkill = true;
        AngelGams.SetActive(true);
        StartCoroutine(AngelDel());
    }

    IEnumerator AngelDel()
    {
        yield return new WaitForSeconds(5f);
        AngelGams.SetActive(false);
    }

    IEnumerator Difficulty()
    {
        yield return new WaitForSeconds(SGameMng.I.fDifficultyUpTime);
        bDifficulty = true;
    }

    IEnumerator HeroDie()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < GameUIs.Length; i++)
            GameUIs[i].SetActive(false);

        SGameMng.I.AniGams.SetActive(false);
        SGameMng.I.GameObjects.SetActive(false);
        ResultSceneGams.SetActive(true);
    }

    public IEnumerator TimeCount()
    {
        yield return new WaitForSeconds(1f);
        if (!SGameMng.I.bHeroDie)
        {
            nTimeCount++;
            StartCoroutine(TimeCount());
        }
    }

    IEnumerator MapOutCount()
    {
        yield return new WaitForSeconds(1f);
        if (bMapOut)
        {
            StartCoroutine(MapOutCount());
            nMapOutCount++;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!SGameMng.I.bHeroDmgAccess)
        {
            if (/*col.CompareTag("Wall") || */col.CompareTag("Fire") || col.CompareTag("Hand"))
            {
                SGameMng.I.bHeroDie = true;
                HeroSr.enabled = false;
                Debug.Log("게임오버");
            }
        }

        if (col.name == "UpWall")
        {
            bOutPos[0] = true;
            PlayerTransBubble[0].SetActive(true);
            if (!bMapOut)
            {
                bMapOut = true;
                StartCoroutine(MapOutCount());
            }
        }
        else if (col.name == "DownWall")
        {
            bOutPos[1] = true;
            PlayerTransBubble[1].SetActive(true);
            if (!bMapOut)
            {
                bMapOut = true;
                StartCoroutine(MapOutCount());
            }
        }
        else if (col.name == "RightWall")
        {
            bOutPos[2] = true;
            PlayerTransBubble[2].SetActive(true);
            if (!bMapOut)
            {
                bMapOut = true;
                StartCoroutine(MapOutCount());
            }
        }
        else if (col.name == "LeftWall")
        {
            bOutPos[3] = true;
            PlayerTransBubble[3].SetActive(true);
            if (!bMapOut)
            {
                bMapOut = true;
                StartCoroutine(MapOutCount());
            }
        }

        if (bMapOut)
        {
            if (col.CompareTag("Map"))
            {
                bMapOut = false;
                for (int i = 0; i < PlayerTransBubble.Length; i++)
                {
                    PlayerTransBubble[i].SetActive(false);
                    PlayerTransBubble[i].transform.localPosition = Vector3.zero;
                    bOutPos[i] = false;
                }
                StopCoroutine("MapOutCount");
                nMapOutCount = 0;
            }
        }
    }

}
