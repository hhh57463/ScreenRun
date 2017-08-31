using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandParent : MonoBehaviour {

    public GameObject HeroGams;
    public GameObject HandPre;
    //public Player HeroSc;
    public bool bSkillUse = false;
    Vector3 PosVec3;

	// Use this for initialization
	void Start () {
        bSkillUse = true;	
	}
	
	// Update is called once per frame
	void Update () {

        if (bSkillUse && !SGameMng.I.bHeroDie) 
        {
            StartCoroutine(HandMonsterSKill());
            bSkillUse = false;
        }
	}

    IEnumerator HandMonsterSKill()
    {
        yield return new WaitForSeconds(SGameMng.I.fHandSpeed);
        PosVec3 = HeroGams.transform.localPosition;
        Instantiate(HandPre, PosVec3, Quaternion.identity, transform);
    }

}
