using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnMng : MonoBehaviour {

    public void PlayBtn()
    {
        SceneManager.LoadScene("2_GameScene");
    }

}
