using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController_Dolli : MonoBehaviour {

    [Header("Setting")]
    public GameObject player;
    public GameObject line;

    private float spawnTimer = 0;

    [Header("Score")]
    public TextMesh scoreText;
    public int score;

    [Header("Stage")]
    public GameObject stageInfo;
    public AudioSource effectSound;
    public int stage = 1;
    public int lineCount = 0;

    public float stageTerm = 0;

    public int currentBreakLineCount = 0;
    private int maxStageLineCount = 0;

    private float stageTermTimer = 0;

    private bool stagePlay = true;

    [Header("UI")]
    public Image stageGage;
    public Text rightStage;
    public Text leftStage;

    void Start () {
        line.GetComponent<Line_Dolli>().gcd = this;
        line.GetComponent<Line_Dolli>().Player = player;
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = score + "";

        SpawnLine();

        StageCounter();

        UISetting();
    }
    
    void UISetting()
    {
        stageGage.fillAmount = (float)currentBreakLineCount / maxStageLineCount;
        rightStage.text = (stage + 1).ToString();
        leftStage.text = stage.ToString();
    }

    void SpawnLine()
    {
        spawnTimer += Time.deltaTime * 1;

        if (spawnTimer > 2f && stagePlay)
        {
            Instantiate(line);
            lineCount++;
            spawnTimer = 0;
        }
    }

    void StageCounter()
    {
        maxStageLineCount = 2;// (stage + 1) * 5;
        if (lineCount == maxStageLineCount)
        {
            if (stageTerm >= stageTermTimer)
            {
                stageTermTimer += Time.deltaTime * 1;
                stagePlay = false;
            }
            else
            {
                //Debug.Log(stage + "스테이지 성공");
                
                lineCount = 0;
                stageTermTimer = 0;

                stagePlay = true;
            }
        }

        if (currentBreakLineCount == maxStageLineCount)
        {
            Debug.Log("Stage Up");
            stage++;

            StageInfoMessage();

            score += stage * 10;

            player.GetComponent<Player_Dolli>().StageSetting();

            currentBreakLineCount = 0;
        }
    }

    void StageInfoMessage()
    {
        effectSound.Play();
        stageInfo.SetActive(true);
        string infoMessage = "Stage " + stage;
        switch (stage)
        {
            case 0:
                infoMessage += "\r\n" + "Tutorial";
                break;
            case 1:
                infoMessage += "\r\n" + "Start";
                break;
            case 2:
                infoMessage += "\r\n" + "2 + 1";
                break;
            case 3:
                infoMessage += "\r\n" + "Random Color";
                break;
            case 4:
                infoMessage += "\r\n" + "3 + 1";
                break;
            case 5:
                infoMessage += "\r\n" + "W + T + F";
                break;
            case 6:
                break;
        }
        stageInfo.GetComponent<StageInfo_Dolli>().text.text = infoMessage;
    }
}
