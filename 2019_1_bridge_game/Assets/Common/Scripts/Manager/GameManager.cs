﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 게임 상태와 씬 등 전반을 관리하는 매니저 클래스
 * 
 * 19.03.03 Scene 흐름
 * logo -> title -> loading -> ingame
 * 
 */

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    #region variables
    private enum GameState { NOT_STARTED, GAME_OVER, PLAYING, CLEAR, ENDING }
    //public enum GameMode { NORMAL, RUSH }
    public enum GameScene { LOGO = 0, TITLE = 1, LOBBY = 2, IN_GAME = 3, BOSS_RUSH = 4 }

    private GameState gameState = GameState.NOT_STARTED;
    //[SerializeField]
    //private GameMode gameMode = GameMode.NORMAL;
    [SerializeField]
    private GameScene gameScene = GameScene.LOGO;

    private string nextScene;

    // 새 게임, 로드 게임 구분
    private bool loadsGameData = false;
    #endregion

    #region get / set
    public bool GetLoadsGameData() { return loadsGameData; }
    public GameScene GetGameScene() { return gameScene; }
    //public GameMode GetMode() { return gameMode; }

    // 인게임씬에서 바로 시작할 때 설정해줄 디버깅 용
    public void SetGameScene(GameScene gameScene) { this.gameScene = gameScene; }
    public void SetLoadsGameData(bool _loadsGameData) { loadsGameData = _loadsGameData; }
    //public void SetMode(GameMode gameMode) { this.gameMode = gameMode; }
    #endregion

    #region unityFunc
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    #endregion


    #region func
    //public bool IsInGame()
    //{
    //    return gameScene == GameScene.IN_GAME || gameScene == GameScene.BOSS_RUSH;
    //}


    public void LoadInGame()
    {
        //if (!GameDataManager.Instance.isFirst)
        //{
        //    SceneDataManager.SetNextScene("TutorialScene");
        //    SceneManager.LoadScene("LoadingScene");
        //    return;
        //}
        //if (GameMode.NORMAL == gameMode)
        //{
        //    gameScene = GameScene.IN_GAME;
        //    SceneDataManager.SetNextScene("InGameScene");
        //}
        //else if (GameMode.RUSH == gameMode)
        //{
        //    gameScene = GameScene.BOSS_RUSH;
        //    SceneDataManager.SetNextScene("BossRushScene");
        //}
        nextScene = "IngameScene";
        SceneManager.LoadScene("LoadingScene");
    }
    public void LoadTitle()
    {
        gameScene = GameScene.TITLE;
        SceneManager.LoadScene("TitleScene");
        //SceneDataManager.SetNextScene("TitleScene");
        //SceneManager.LoadScene("LoadingScene");
    }
    //public void LoadLobby()
    //{
    //    gameScene = GameScene.LOBBY;
    //    SceneManager.LoadScene("LobbyScene");
    //}

    //public void GameOver()
    //{
    //    gameState = GameState.GAME_OVER;
    //    GameDataManager.Instance.ResetData(GameDataManager.UserDataType.INGAME);
    //}
    #endregion
}