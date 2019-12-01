using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineParticleBreaker_Dolli : MonoBehaviour {

    private float timer;

	void Update () {
        timer += Time.deltaTime * 1;
        if (timer > 5)
            Destroy(gameObject);
	}
}
