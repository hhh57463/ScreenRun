using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public MapScroll MapSc;

    // Use this for initialization
    void Start()
    {
        MapSc = GameObject.Find("Map").GetComponent<MapScroll>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (MapSc.nMapNum)
        {
            case 0:
                transform.Translate(Vector2.down * SGameMng.I.fItemSpeed * Time.deltaTime);
                break;

            case 1:
                transform.Translate(Vector2.left * SGameMng.I.fItemSpeed * Time.deltaTime);
                break;

            case 2:
                transform.Translate(Vector2.right * SGameMng.I.fItemSpeed * Time.deltaTime);
                break;

            case 3:
                transform.Translate(Vector2.up * SGameMng.I.fItemSpeed * Time.deltaTime);
                break;

            case 4:
                transform.Translate(Vector2.left * SGameMng.I.fItemSpeed * Time.deltaTime);
                transform.Translate(Vector2.down * SGameMng.I.fItemSpeed * Time.deltaTime);
                break;

            case 5:
                transform.Translate(Vector2.right * SGameMng.I.fItemSpeed * Time.deltaTime);
                transform.Translate(Vector2.up * SGameMng.I.fItemSpeed * Time.deltaTime);
                break;

            case 6:
                transform.Translate(Vector2.left * SGameMng.I.fItemSpeed * Time.deltaTime);
                transform.Translate(Vector2.up * SGameMng.I.fItemSpeed * Time.deltaTime);
                break;

            case 7:
                transform.Translate(Vector2.right * SGameMng.I.fItemSpeed * Time.deltaTime);
                transform.Translate(Vector2.down * SGameMng.I.fItemSpeed * Time.deltaTime);
                break;

        }

        if (transform.localPosition.x <= -12f)
        {
            SGameMng.I.bItemZenStart = true;
            Destroy(gameObject);
        }

        if (transform.localPosition.x >= 12f)
        {
            SGameMng.I.bItemZenStart = true;
            Destroy(gameObject);
        }

        if (transform.localPosition.y <= -7f)
        {
            SGameMng.I.bItemZenStart = true;
            Destroy(gameObject);
        }

        if (transform.localPosition.y >= 7f)
        {
            SGameMng.I.bItemZenStart = true;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hero"))
        {
            //StartCoroutine(SGameMng.I.ItemZen());
            Debug.Log("아이템 획득!");
            SGameMng.I.bItemZenStart = true;
            Destroy(gameObject);
        }
    }
}
