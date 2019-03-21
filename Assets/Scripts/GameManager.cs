using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _Instance;
    public static GameManager Instance { get { return _Instance; } }

    //垃圾数
    public int TargetRubbishNum = 10;//目标垃圾数
    public int GotRubbishNum = 0;//已收垃圾数

    //角色是否死亡
    public bool isDead = false;

    //得分
    public static int Score = 0;
    public int SingleScore = 10;

    //关卡
    public int MaxLevelNum = 4;//最大关卡数
    public int CurrentLevel = 0;//当前关卡号

    //文本
    public GameObject LoseText, WinText, RestartText;
    //按钮
    public GameObject LoseButton, RestartButton, NextLevelButton;

	// Use this for initialization
	void Awake () {
        //实例
	    if (_Instance == null)
	        _Instance = this;
        //获取当前场景编号
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
       // Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //角色死亡则调用失败结局
        if (isDead)
            Lose();
        else if (GotRubbishNum == TargetRubbishNum)
            Win();//回收垃圾达到目标则胜利
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
        LoseText.SetActive(true);
        LoseButton.SetActive(true);
        RestartButton.SetActive(true);
    }

    //重新开始
   public void GameRestart()
    {
        Debug.Log("nmsl");

        SceneManager.LoadScene(CurrentLevel);
        isDead = false;
    }

    //退出
   public void QuitGame()
    {
        Application.Quit();
    }

    //胜利
   public void Win()
    {
        WinText.SetActive(true);
        if (CurrentLevel != MaxLevelNum)
            NextLevelButton.SetActive(true);
        else LoseText.SetActive(true);
    }

    //下一关
    public void NextLevel()
    {

        //若不是最后一关则跳转至下一关
        if (CurrentLevel != MaxLevelNum)
            SceneManager.LoadScene(++CurrentLevel);
        //是最后一关则游戏结束
        else
        {
            WinText.SetActive(true);
        }

    }

    //难度控制
    void DifficultyControl(int num,int speed)
    {
        GameObject.Find("RubbishManager").SendMessage("Initialize");
        //Initialize(num,speed)
    }


}
