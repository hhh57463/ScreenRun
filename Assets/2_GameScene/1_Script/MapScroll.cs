using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{

    public float ScrollSpeed = 0.5f;
    Material MapMat;
    public int nMapNum = 0;

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

        switch(nMapNum)
        {
            case 1:
                newOffset.Set(0, newOffset.y + (ScrollSpeed * Time.deltaTime));
                break;
            case 2:
                newOffset.Set(newOffset.x + (ScrollSpeed * Time.deltaTime), 0);
                break;
            case 3:
                newOffset.Set(newOffset.x + (ScrollSpeed * Time.deltaTime), newOffset.y + (ScrollSpeed * Time.deltaTime));
                break;
            case 4:
                newOffset.Set(newOffset.x - (ScrollSpeed * Time.deltaTime), newOffset.y - (ScrollSpeed * Time.deltaTime));
                break;
            case 5:
                newOffset.Set(newOffset.x + (ScrollSpeed * Time.deltaTime), newOffset.y - (ScrollSpeed * Time.deltaTime));
                break;
            case 6:
                newOffset.Set(newOffset.x - (ScrollSpeed * Time.deltaTime), newOffset.y + (ScrollSpeed * Time.deltaTime));
                break;
        }

        MapMat.mainTextureOffset = newOffset;

    }

    IEnumerator MapScrollNumSet()                                                                   //5초마다 맵 스크롤 방향 바뀜
    {
        yield return new WaitForSeconds(1f);
        nMapNum = Random.Range(1, 7);
        yield return new WaitForSeconds(4f);
        StartCoroutine(MapScrollNumSet());
    }

}
