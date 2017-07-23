using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandParent : MonoBehaviour {

    public GameObject HeroGams;
    public GameObject HandPre;
    Vector3 PosVec3;

	// Use this for initialization
	void Start () {
        StartCoroutine(HandMonsterSKill());
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    public IEnumerator HandMonsterSKill()
    {
        Debug.Log("ASDFASDFASDFADSFADSFA");
        yield return new WaitForSeconds(1f);
        Debug.Log("QWEQWRQEQEWQEQWEE");
        PosVec3 = HeroGams.transform.localPosition;
        Instantiate(HandPre, PosVec3, Quaternion.identity, transform);
    }

}
