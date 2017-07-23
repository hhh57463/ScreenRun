using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandParent : MonoBehaviour {

    public GameObject HeroGams;
    public GameObject HandPre;
    public bool bSkillUse = false;
    Vector3 PosVec3;

	// Use this for initialization
	void Start () {
        bSkillUse = true;	
	}
	
	// Update is called once per frame
	void Update () {

        if (bSkillUse)
        {
            StartCoroutine(HandMonsterSKill());
            bSkillUse = false;
        }
	}

    IEnumerator HandMonsterSKill()
    {
        Debug.Log("ASDFASDFASDFADSFADSFA");
        yield return new WaitForSeconds(1f);
        Debug.Log("QWEQWRQEQEWQEQWEE");
        PosVec3 = HeroGams.transform.localPosition;
        Instantiate(HandPre, PosVec3, Quaternion.identity, transform);
    }

}
