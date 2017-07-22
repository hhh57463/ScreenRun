using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScroll : MonoBehaviour
{

    public float ScrollSpeed = 0.5f;
    Material MapMat;
    public int nMapNum;
    public Image DirectionImg;                  //UI중 방향이미지
    public Sprite[] DirectionSpt;                 //방향이미지들


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
                ScrollSpeed = 0.6f;
                newOffset.Set(0, newOffset.y + (ScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[0];
                break;
            case 1:                                                                                     //Right
                ScrollSpeed = 0.5f;
                newOffset.Set(newOffset.x + (ScrollSpeed * Time.deltaTime), 0);
                DirectionImg.sprite = DirectionSpt[1];
                break;
            case 2:                                                                                     //Left
                ScrollSpeed = 0.5f;
                newOffset.Set(newOffset.x - (ScrollSpeed * Time.deltaTime), 0);
                DirectionImg.sprite = DirectionSpt[2];
                break;
            case 3:                                                                                     //Down
                ScrollSpeed = 0.6f;
                newOffset.Set(0, newOffset.y - (ScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[3];
                break;
            case 4:                                                                                     //RightUp
                ScrollSpeed = 0.4f;
                newOffset.Set(newOffset.x + (ScrollSpeed * Time.deltaTime), newOffset.y + (ScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[4];
                break;
            case 5:                                                                                     //LeftDown
                ScrollSpeed = 0.4f;
                newOffset.Set(newOffset.x - (ScrollSpeed * Time.deltaTime), newOffset.y - (ScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[5];
                break;
            case 6:                                                                                     //RightDown
                ScrollSpeed = 0.4f;
                newOffset.Set(newOffset.x + (ScrollSpeed * Time.deltaTime), newOffset.y - (ScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[6];
                break;
            case 7:                                                                                     //LeftUp
                ScrollSpeed = 0.4f;
                newOffset.Set(newOffset.x - (ScrollSpeed * Time.deltaTime), newOffset.y + (ScrollSpeed * Time.deltaTime));
                DirectionImg.sprite = DirectionSpt[7];
                break;
        }

        MapMat.mainTextureOffset = newOffset;

    }

    IEnumerator MapScrollNumSet()                                                                   //5초마다 맵 스크롤 방향 바뀜
    {
        nMapNum = Random.Range(0, 8);
        yield return new WaitForSeconds(5f);
        StartCoroutine(MapScrollNumSet());
    }

}
