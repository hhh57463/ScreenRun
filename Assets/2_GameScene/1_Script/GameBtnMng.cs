using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBtnMng : MonoBehaviour {

    public void Home()
    {
        SceneManager.LoadScene("1_MenuScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("2_GameScene");
    }

}
