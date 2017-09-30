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


    public int nTimeCount = 0;
    public int nLevel = 1;
    public int nAbilityCount = 0;

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
        /////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shiled();
        }
        //////////////////////////////////////////////////////////
        //if (bMapOut)
        //{
        //    if (transform.localPosition.x <= 8.9 && transform.localPosition.x >= -8.9 && transform.localPosition.y <= 5.2 && transform.localPosition.y >= -5.2)
        //    {
        //        Debug.Log("맵안");
        //        for (int i = 0; i < PlayerTransBubble.Length; i++)
        //            PlayerTransBubble[i].SetActive(false);
        //    }
        //}
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
            PlayerTransBubble[0].transform.localPosition = new Vector3(HeroParentTr.localPosition.x, 4.15f, 0f);
        }
        else if (bOutPos[1])
        {
            PlayerTransBubble[1].transform.localPosition = new Vector3(HeroParentTr.localPosition.x, -4.15f, 0f);
        }
        else if (bOutPos[2])
        {
            PlayerTransBubble[2].transform.localPosition = new Vector3(8.15f, HeroParentTr.localPosition.y, 0f);
        }
        else if (bOutPos[3])
        {
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (/*col.CompareTag("Wall") || */col.CompareTag("Fire") || col.CompareTag("Hand"))
        {
            SGameMng.I.bHeroDie = true;
            HeroSr.enabled = false;
            Debug.Log("게임오버");
        }

        if (col.name == "UpWall")
        {
            bMapOut = true;
            bOutPos[0] = true;
            PlayerTransBubble[0].SetActive(true);
            Debug.Log("UP");
        }
        else if (col.name == "DownWall")
        {
            bMapOut = true;
            bOutPos[1] = true;
            PlayerTransBubble[1].SetActive(true);
            Debug.Log("Down");
        }
        else if (col.name == "RightWall")
        {
            bMapOut = true;
            bOutPos[2] = true;
            PlayerTransBubble[2].SetActive(true);
            Debug.Log("Right");
        }
        else if (col.name == "LeftWall")
        {
            bMapOut = true;
            bOutPos[3] = true;
            PlayerTransBubble[3].SetActive(true);
            Debug.Log("Left");
        }

        if (bMapOut)
        {
            if (col.CompareTag("Map"))
            {
                Debug.Log("맵안");
                for (int i = 0; i < PlayerTransBubble.Length; i++)
                {
                    PlayerTransBubble[i].SetActive(false);
                    bOutPos[i] = false;
                }
            }
        }
    }

}
