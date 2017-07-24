using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject ResultSceneGams;
    public GameObject[] GameUIs;
    public Transform HeroParentTr;
    public JoyStick JoyStickSc;
    float fSpeed = 4f;
    public MapScroll MapSc;
    public bool bHeroDie = false;
    SpriteRenderer HeroSr;
    public int nTimeCount = 0;

    // Use this for initialization
    void Start()
    {
        HeroSr = GetComponent<SpriteRenderer>();
        StartCoroutine(TimeCount());
    }

    // Update is called once per frame
    void Update()
    {
        if (!bHeroDie)
            Move();

        if (bHeroDie)
        {
            StartCoroutine(HeroDie());
        }
    }

    public void Move()
    {
        if (JoyStickSc.bUse)
            HeroParentTr.localPosition += new Vector3(JoyStickSc.DirVec.x, JoyStickSc.DirVec.y, JoyStickSc.DirVec.z) * fSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, JoyStickSc.PlayerAngle - 90));

        switch (MapSc.nMapNum)
        {
            case 0:
                HeroParentTr.Translate(Vector2.up * 0.5f * Time.deltaTime);
                break;

            case 1:
                HeroParentTr.Translate(Vector2.right * 0.5f * Time.deltaTime);
                break;

            case 2:
                HeroParentTr.Translate(Vector2.left * 0.5f * Time.deltaTime);
                break;

            case 3:
                HeroParentTr.Translate(Vector2.down * 0.5f * Time.deltaTime);
                break;

            case 4:
                HeroParentTr.Translate(Vector2.right * 0.5f * Time.deltaTime);
                HeroParentTr.Translate(Vector2.up * 0.5f * Time.deltaTime);
                break;

            case 5:
                HeroParentTr.Translate(Vector2.left * 0.5f * Time.deltaTime);
                HeroParentTr.Translate(Vector2.down * 0.5f * Time.deltaTime);
                break;

            case 6:
                HeroParentTr.Translate(Vector2.right * 0.5f * Time.deltaTime);
                HeroParentTr.Translate(Vector2.down * 0.5f * Time.deltaTime);
                break;

            case 7:
                HeroParentTr.Translate(Vector2.left * 0.5f * Time.deltaTime);
                HeroParentTr.Translate(Vector2.up * 0.5f * Time.deltaTime);
                break;

        }

    }

    IEnumerator HeroDie()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < GameUIs.Length; i++)
        {
            GameUIs[i].SetActive(false);
        }
        ResultSceneGams.SetActive(true);
    }

    public IEnumerator TimeCount()
    {
        yield return new WaitForSeconds(1f);
        if (!bHeroDie)
        {
            nTimeCount++;
            StartCoroutine(TimeCount());
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall") || col.CompareTag("Fire") || col.CompareTag("Hand"))
        {
            bHeroDie = true;
            HeroSr.enabled = false;
            Debug.Log("게임오버");
        }
    }

}
