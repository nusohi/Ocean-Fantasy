using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour {

    private static GameManager _Instance;
    public static GameManager Instance { get { return _Instance; } }

    public float test;//显示当前timescale

    //垃圾数
    public int TargetRubbishNum = 10;//目标垃圾数
    public int GotRubbishNum = 0;//已收垃圾数
    public int FishBody = 0;
    public Text scoreText;
    public int fishnum = 1;
    public int rubbishnum = 1;//生成垃圾数
    
    //角色是否死亡
    public bool isDead = false;

    //游戏是否结束
    public bool isGameOver = false;

    //得分
    public static int Score = 0;
    public int SingleScore = 10;

    //关卡
    public int MaxLevelNum = 4;//最大关卡数
    public int CurrentLevel = 0;//当前关卡号

    //文本
    public GameObject LoseText, WinText, RestartText,FishDieText;
    //按钮
    public GameObject LoseButton, RestartButton, NextLevelButton;

	// Use this for initialization
	void Awake () {
        //实例
	    if (_Instance == null)
	        _Instance = this;
        //获取当前场景编号
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
       
          DifficultyControl(CurrentLevel);
	}

    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
        test = Time.timeScale;
        //角色死亡则调用失败结局
        if (isDead||FishBody==rubbishnum-TargetRubbishNum)
         Lose();
     
        else if (GotRubbishNum == TargetRubbishNum)
            Win();//回收垃圾达到目标则胜利

        // score text
        scoreText.text= GotRubbishNum.ToString()+" / "+TargetRubbishNum.ToString();
	}

    public void GameStart(GameObject t)
    {
        GameObject temp=t;
        temp.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

        GotRubbishNum = 0;
        CurrentLevel = 1;
    }

    //增加积分 每捡取一次垃圾就调用一次
   public void AddScore()
    {
        Score += SingleScore;
        GotRubbishNum += 1;
    }
    
    //失败
   public void Lose()
   {
        Debug.Log("ggggggggggggggg");
       if (FishBody != rubbishnum - TargetRubbishNum)
       {
            FishDieText.SetActive(false);
            LoseText.SetActive(true);
            Time.timeScale = 0;
            if (!isGameOver)
            {
                Time.timeScale = 1;
                isGameOver = true;
            }
            Debug.Log("s");
        }
       else
       {
           FishDieText.SetActive(true);
           
           Debug.Log("sb");
       }
        LoseButton.SetActive(true);
        RestartButton.SetActive(true);
       

   }

    //重新开始
   public void GameRestart()
    {
        isGameOver = false;
        isDead = false;
        Debug.Log("nmsl");
        SceneManager.LoadScene(CurrentLevel);
        Time.timeScale = 1;
    }

    //退出
   public void QuitGame()
    {
        Application.Quit();
    }

    //胜利
   public void Win()
   {
       Time.timeScale = 0;
       Debug.Log("W");
        WinText.SetActive(true);
        if (CurrentLevel != MaxLevelNum)
            NextLevelButton.SetActive(true);
        else LoseText.SetActive(true);
    }

    //下一关
    public void NextLevel()
    {
        Time.timeScale = 1;
        //若不是最后一关则跳转至下一关
        if (CurrentLevel != MaxLevelNum)
        {
            SceneManager.LoadScene(++CurrentLevel);
            DifficultyControl(CurrentLevel);
        }
        //是最后一关则游戏结束
        else
        {
            WinText.SetActive(true);
        }

    }

    //难度控制
    void DifficultyControl(int num)
    {
       
       
        switch (num)
        {
            case 1:
                fishnum = 1;
                rubbishnum = 4;
                TargetRubbishNum = 3;
                Debug.Log("111");
                break;
            case 2:
                fishnum = 3;
                rubbishnum = 6;
                TargetRubbishNum = 5;
                Debug.Log("222");
                break;
            case 3:
                fishnum = 5;
                rubbishnum = 8;
                TargetRubbishNum = 6;
                Debug.Log("333");
                break;
            case 4:
                fishnum = 7;
                rubbishnum = 10;
                TargetRubbishNum = 7;
                break;
           
   
        }
        GameObject.Find("RubbishMaker").SendMessage("Initialize",rubbishnum);
        GameObject.Find("FishMake").SendMessage("InitializeFish", fishnum);
    }


}
