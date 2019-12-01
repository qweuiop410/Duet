using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerEgg_Dolli : MonoBehaviour {

    public GameController_Dolli gcd;
    public ParticleSystem ps;
    public GameObject lineBreakParticle;
    
    void Update()
    {
        ps.startColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.name == transform.name)
        {
            //Debug.Log("성공  :  " + gcd.score);
            gcd.score += gcd.stage + 1;
            gcd.currentBreakLineCount++;
            
            lineBreakParticle.GetComponent<ParticleSystem>().startColor = col.GetComponent<SpriteRenderer>().color;
            Instantiate(lineBreakParticle, col.transform.position, col.transform.rotation);

            Destroy(col.gameObject);
        }
        else
        {
            //Debug.Log("실패");
            Destroy(col.gameObject);
            SceneManager.LoadScene("Dolli");
        }
    }
}
