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
    public int Score = 0;
    public int SingleScore = 10;

    //关卡
    public int MaxLevelNum = 5;//最大关卡数
    public int CurrentLevel = 0;//当前关卡号

    //文本
    public GameObject LoseText, WinText, RestartText;

	// Use this for initialization
	void Awake () {
        //实例
        _Instance = this;
        //获取当前场景编号
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 0;
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
    }

    //增加积分 每捡取一次垃圾就调用一次
   public void AddScore()
    {
        Score += SingleScore;
    }


    //游戏结束
   public void GameOver(bool isdead)
    {
        if(isdead)
        {

        }
    }


    //失败
   public void Lose()
    {
        //重来
        GameRestart();
        //退出
        QuitGame();
    }

    //重新开始
   public void GameRestart()
    {
        SceneManager.LoadScene(CurrentLevel);
    }

    //退出
   public void QuitGame()
    {
        Application.Quit();
    }

    //胜利
   public void Win()
    {
        //若不是最后一关则跳转至下一关
        if (CurrentLevel != MaxLevelNum-1)
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
