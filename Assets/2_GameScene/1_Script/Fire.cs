using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public MapScroll MapSc;



    // Update is called once per frame
    void Update()
    {

        Move();

    }

    public void Move()
    {
        transform.Translate(Vector2.down * SGameMng.I.fFireDownSpeed * Time.deltaTime);
        if (transform.localPosition.y <= -9f && !SGameMng.I.bHeroDie)
        {
            transform.localPosition = new Vector2(0f, 8f);
        }

        switch (MapSc.nMapNum)
        {
            case 0:
                transform.Translate(Vector2.down * SGameMng.I.fFireSpeed * Time.deltaTime);
                break;

            case 1:
                transform.Translate(Vector2.left * SGameMng.I.fFireSpeed * Time.deltaTime);
                break;

            case 2:
                transform.Translate(Vector2.right * SGameMng.I.fFireSpeed * Time.deltaTime);
                break;

            case 3:
                transform.Translate(Vector2.up * SGameMng.I.fFireSpeed * Time.deltaTime);
                break;

            case 4:
                transform.Translate(Vector2.left * SGameMng.I.fFireSpeed * Time.deltaTime);
                transform.Translate(Vector2.down * SGameMng.I.fFireSpeed * Time.deltaTime);
                break;

            case 5:
                transform.Translate(Vector2.right * SGameMng.I.fFireSpeed * Time.deltaTime);
                transform.Translate(Vector2.up * SGameMng.I.fFireSpeed * Time.deltaTime);
                break;

            case 6:
                transform.Translate(Vector2.left * SGameMng.I.fFireSpeed * Time.deltaTime);
                transform.Translate(Vector2.up * SGameMng.I.fFireSpeed * Time.deltaTime);
                break;

            case 7:
                transform.Translate(Vector2.right * SGameMng.I.fFireSpeed * Time.deltaTime);
                transform.Translate(Vector2.down * SGameMng.I.fFireSpeed * Time.deltaTime);
                break;

        }
    }

}
