using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMonster : MonoBehaviour {

    public GameObject HandParentGams;
    public HandParent HandParentSc;
    public SpriteRenderer HandSr;
    public Sprite HandSprite;
    BoxCollider2D Box;

	// Use this for initialization
	void Start () {

        HandParentGams = GameObject.Find("Hand");
        HandParentSc = HandParentGams.GetComponent<HandParent>();
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
        StartCoroutine(HandParentSc.HandMonsterSKill());
        Destroy(gameObject);
    }

}
