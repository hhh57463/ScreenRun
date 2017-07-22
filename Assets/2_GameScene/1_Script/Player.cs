using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform HeroParentTr;
    public JoyStick JoyStickSc;
    float fSpeed = 5f;
    public MapScroll MapSc;
    public bool bHeroDie = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!bHeroDie)
            Move();
    }

    public void Move()
    {
        if (JoyStickSc.bUse)
            HeroParentTr.localPosition += new Vector3(JoyStickSc.DirVec.x, JoyStickSc.DirVec.y, JoyStickSc.DirVec.z) * fSpeed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, JoyStickSc.PlayerAngle - 90));

        switch (MapSc.nMapNum)
        {
            case 0:
                HeroParentTr.Translate(Vector2.up * 2f * Time.deltaTime);
                break;

            case 1:
                HeroParentTr.Translate(Vector2.right * 2f * Time.deltaTime);
                break;

            case 2:
                HeroParentTr.Translate(Vector2.left * 2f * Time.deltaTime);
                break;

            case 3:
                HeroParentTr.Translate(Vector2.down * 2f * Time.deltaTime);
                break;

            case 4:
                HeroParentTr.Translate(Vector2.right * Time.deltaTime);
                HeroParentTr.Translate(Vector2.up * Time.deltaTime);
                break;

            case 5:
                HeroParentTr.Translate(Vector2.left * Time.deltaTime);
                HeroParentTr.Translate(Vector2.down * Time.deltaTime);
                break;

            case 6:
                HeroParentTr.Translate(Vector2.right * Time.deltaTime);
                HeroParentTr.Translate(Vector2.down * Time.deltaTime);
                break;

            case 7:
                HeroParentTr.Translate(Vector2.left * Time.deltaTime);
                HeroParentTr.Translate(Vector2.up * Time.deltaTime);
                break;

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Wall"))
        {
            bHeroDie = true;
            Debug.Log("게임오버");
        }
    }

}
