using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMonster : MonoBehaviour {

    //public GameObject HandParentGams;
    public HandParent HandParentSc = null;
    public SpriteRenderer HandSr = null;
    public Sprite HandSprite = null;
    BoxCollider2D Box = null;

	// Use this for initialization
	void Start () {

        //HandParentGams = GameObject.Find("Hand");
        HandParentSc = GameObject.Find("Hand").GetComponent<HandParent>();
        HandSr = GetComponent<SpriteRenderer>();
        Box = GetComponent<BoxCollider2D>();
        StartCoroutine(Skill());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(1f);
        HandSr.sprite = HandSprite;
        Box.enabled = true;
        yield return new WaitForSeconds(1f);
        HandParentSc.bSkillUse = true;
        Destroy(gameObject);
    }

}
