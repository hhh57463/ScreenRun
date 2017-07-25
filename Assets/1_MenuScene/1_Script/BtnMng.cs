using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnMng : MonoBehaviour {

    public Transform SettingTr;

    public void PlayBtn()
    {
        SceneManager.LoadScene("2_GameScene");
    }

    public void Setting()
    {
        SettingTr.localPosition = Vector2.zero;
    }

    public void SettingClose()
    {
        SettingTr.localPosition = new Vector2(1500f, 0f);
    }

    public void JoyStickPosLeft()
    {
        Mng.I.nJoyStickPos = 1;
    }

    public void JoyStickPosRight()
    {
        Mng.I.nJoyStickPos = 2;
    }

}
