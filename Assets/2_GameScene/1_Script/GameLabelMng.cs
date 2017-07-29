using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLabelMng : MonoBehaviour {

    public Player HeroSc;
    public Text TimeCountText;
    public Text ResultTimeCount;
    public Text ResultBestTime;
    public Text LevelText;
    public Text ResultLevelText;
    public Text ResultBestLevelText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeCountText.text = HeroSc.nTimeCount.ToString() + " 초";
        ResultTimeCount.text = HeroSc.nTimeCount.ToString() + " 초";
        LevelText.text = HeroSc.nLevel.ToString();
        ResultLevelText.text = HeroSc.nLevel.ToString();
	}
}
