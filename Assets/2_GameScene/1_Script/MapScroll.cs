using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScroll : MonoBehaviour
{
    Material MapMat;
    public int nMapNum;
    public Image DirectionImg = null;                 //UI중 방향이미지
    public Sprite[] DirectionSpt = null;                 //방향이미지들


    // Use this for initialization
    void Start()
    {
        MapMat = GetComponent<SpriteRenderer>().material;
        StartCoroutine(MapScrollNumSet());
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 newOffset = MapMat.mainTextureOffset;

        switch (nMapNum)
        {
            case 0:                                                                                     //Up
                newOffset.Set(0, newOffset.y + (SGameMng.I.fMapScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[0];
                break;
            case 1:                                                                                     //Right
                newOffset.Set(newOffset.x + (SGameMng.I.fMapScrollSpeed * Time.deltaTime), 0);
                DirectionImg.sprite = DirectionSpt[1];
                break;
            case 2:                                                                                     //Left
                newOffset.Set(newOffset.x - (SGameMng.I.fMapScrollSpeed * Time.deltaTime), 0);
                DirectionImg.sprite = DirectionSpt[2];
                break;
            case 3:                                                                                     //Down
                newOffset.Set(0, newOffset.y - (SGameMng.I.fMapScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[3];
                break;
            case 4:                                                                                     //RightUp
                newOffset.Set(newOffset.x + (SGameMng.I.fMapScrollSpeed * Time.deltaTime), newOffset.y + (SGameMng.I.fMapScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[4];
                break;
            case 5:                                                                                     //LeftDown
                newOffset.Set(newOffset.x - (SGameMng.I.fMapScrollSpeed * Time.deltaTime), newOffset.y - (SGameMng.I.fMapScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[5];
                break;
            case 6:                                                                                     //RightDown
                newOffset.Set(newOffset.x + (SGameMng.I.fMapScrollSpeed * Time.deltaTime), newOffset.y - (SGameMng.I.fMapScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[6];
                break;
            case 7:                                                                                     //LeftUp
                newOffset.Set(newOffset.x - (SGameMng.I.fMapScrollSpeed * Time.deltaTime), newOffset.y + (SGameMng.I.fMapScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[7];
                break;
        }

        MapMat.mainTextureOffset = newOffset;

    }

    IEnumerator MapScrollNumSet()                                                                   //10초마다 맵 스크롤 방향 바뀜
    {
        nMapNum = Random.Range(0, 8);
        yield return new WaitForSeconds(10f);
        StartCoroutine(MapScrollNumSet());
    }

}
