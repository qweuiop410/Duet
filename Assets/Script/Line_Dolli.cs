using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Dolli : MonoBehaviour {

    public GameController_Dolli gcd;

    public GameObject Player;

    public Rigidbody2D rb;

    public float speed = 0;

    public SpriteRenderer sr;

    public int[] randomColorStage = new int[] { 0 };

    private Color originalColor;
    private float colorTimer = 0;
    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        
        TagSetting();

        PositionSetting();

        originalColor = sr.color;
    }
	
	void Update () {
        rb.AddForce(transform.up * speed * Time.deltaTime);

        ColorRandom(randomColorStage);
    }

    void ColorRandom(int[] activeStage)
    {
        bool active = false;

        for (int i = 0; i < activeStage.Length; i++)
        {
            if (gcd.stage == activeStage[i])
            {
                active = true;
                break;
            }
            else
                active = false;
        }

        if (active)
        {
            if (Vector3.Distance(transform.position, gcd.player.transform.position) > 2.85f)
            {
                if (colorTimer < 0.5f)
                    colorTimer += Time.deltaTime * 1;
                else
                {
                    int ran_r = Random.Range(0, 255);
                    int ran_g = Random.Range(0, 255);
                    int ran_b = Random.Range(0, 255);
                    sr.color = new Color32((byte)ran_r, (byte)ran_g, (byte)ran_b, 255);
                    colorTimer = 0;
                }
            }
            else
            {
                sr.color = originalColor;
            }
        }
        else
            sr.color = originalColor;
    }

    void TagSetting()
    {
        int num = 0;

        for (int i = 0; i < Player.GetComponent<Player_Dolli>().eggs.Count; i++)
        {
            if (Player.GetComponent<Player_Dolli>().eggs[i].activeInHierarchy)
                num++;
        }

        int ran = Random.Range(0, num);

        transform.name = ran.ToString();
        sr.color = Player.GetComponent<Player_Dolli>().eggs[ran].GetComponent<SpriteRenderer>().color;
    }

    void PositionSetting()
    {
        int ran = Random.Range(0, 8);
        float x = 0;
        float y = 0;
        
        switch (ran)
        {
            case 0:
                x = Random.Range(0f, 6f);
                y = 6f;
                break;

            case 1:
                x = 6f;
                y = Random.Range(0f, 6f);
                break;

            case 2:
                x = 6f;
                y = Random.Range(-6f, 0f);
                break;

            case 3:
                x = Random.Range(0f, 6f);
                y = -6f;
                break;

            case 4:
                x = Random.Range(-6f, 0f);
                y = -6f;
                break;

            case 5:
                x = -6f;
                y = Random.Range(-6f, 0f);
                break;

            case 6:
                x = -6f;
                y = Random.Range(0f, 6f);
                break;

            case 7:
                x = Random.Range(-6f, 0f);
                y = 6;
                break;
        }
        transform.position = new Vector3(x, y, 0);

        RotationSetting();
    }

    void RotationSetting()
    {
        Vector2 direction = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        transform.up = direction;
    }
}
