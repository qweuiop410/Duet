using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo_Dolli : MonoBehaviour {

    public TextMesh text;

    private float timer = 0;
    
	void Start () {
        gameObject.SetActive(false);
    }
	
	void Update () {
        timer += Time.deltaTime * 1;

        if (timer > 2.5f)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
	}
}
