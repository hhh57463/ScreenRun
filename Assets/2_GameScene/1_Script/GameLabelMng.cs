using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLabelMng : MonoBehaviour
{

    public Player HeroSc = null;
    public Text TimeCountText = null;
    public Text ResultTimeCount = null;
    public Text ResultBestTime = null;
    public Text LevelText = null;
    public Text ResultLevelText = null;
    public Text ResultBestLevelText = null;
    public Text MapOutCountText = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeCountText.text = HeroSc.nTimeCount.ToString() + " 초";
        ResultTimeCount.text = HeroSc.nTimeCount.ToString() + " 초";
        LevelText.text = HeroSc.nLevel.ToString();
        ResultLevelText.text = HeroSc.nLevel.ToString();
        if (HeroSc.nMapOutCount > 0)
            MapOutCountText.text = "사망" + HeroSc.nMapOutCount.ToString() + "초전";
        else
            MapOutCountText.text = "사망";
    }
}
