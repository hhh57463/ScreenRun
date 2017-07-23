using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLabelMng : MonoBehaviour {

    public Player HeroSc;
    public Text TimeCountText;
    public Text ResultTimeCount;
    public Text ResultBestTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeCountText.text = HeroSc.nTimeCount.ToString() + " 초";
        ResultTimeCount.text = HeroSc.nTimeCount.ToString() + " 초";
	}
}
