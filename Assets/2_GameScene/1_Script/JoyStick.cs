using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour {

    public Image StickImg = null;
    public Vector3 OldVec;
    float fStickRadius = 0f;
    public Vector3 DirVec;
    public Transform StickTrans = null;
    public bool bUse = false;

    // Use this for initialization
    void Start()
    {
        // 조이스틱 반경 계산
        OldVec = StickImg.transform.position;

        // 반지름으로 이동가능한 범위 설정
        fStickRadius = StickImg.rectTransform.sizeDelta.x / 2;
    }

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        StickTrans.transform.localPosition = new Vector3(0f, 0f, 0f);
    //        transform.position = Input.mousePosition;
    //    }
    //}

    public void Drag()
    {
        bUse = true;

        Vector3 touch = Input.mousePosition;

        DirVec = (new Vector3(touch.x, touch.y, OldVec.z) - OldVec).normalized;

        float fTouchArea = Vector3.Distance(OldVec, new Vector3(touch.x, touch.y, OldVec.z));

        if (fTouchArea > fStickRadius)
        {
            // 조이스틱이 범위 밖에 있을때 방향으로 반지름 만큼만 가도록 계산
            StickImg.rectTransform.position = OldVec + (DirVec * fStickRadius);
        }
        else
        {
            // 조이스틱이 반경 안에서 움직일대 마우스 좌표로 움직이게
            StickImg.rectTransform.position = touch;
        }
    }

    public void EndDrag()
    {
        StickImg.rectTransform.position = OldVec;
        bUse = false;
    }
}
