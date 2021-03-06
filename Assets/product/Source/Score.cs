﻿using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // スコアを表示する
    public Text scoreText;
    // ハイスコアを表示する
    public Text highScoreText;

    //スコアボード調整
    public GameObject score;
    public GameObject travel;

    // スコア
    private int scores;


    // ハイスコア
    private int highScores;

    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";


    //飛行速度
    public Text Z_speedText;
    private float Z_speed;

    //オーバークロック
    public GameObject OCBoard;
    public Text OCTimer;
    public static float OCtime;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        // スコアがハイスコアより大きければ
        if (highScores < scores)
        {
            highScores = scores;
        }
        // スコア・ハイスコアを表示する
        if (GameObject.Find("Main Camera").GetComponent<GameControl>().gameFlag == false || GameObject.Find("Main Camera").GetComponent<GameControl>().playingFlag == true)
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            score.SetActive(true);
            travel.SetActive(true);

        }

        //スコア数値を文字に置き換え
        scoreText.text = scores.ToString();
        highScoreText.text = highScores.ToString();


        //飛行速度の表示
        Z_speed = (float)StarfighterControl.Z_Speed;
        Z_speedText.text = Z_speed.ToString("f2");

    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        scores = 0;

        // ハイスコアを取得する。保存されてなければ0を取得する。
        highScores = PlayerPrefs.GetInt(highScoreKey, 0);

        //OC初期化
        OCtime = 0;
        OCBoard.SetActive(false);
    }

    // ポイントの追加
    public void AddPoint(int Point)
    {
        scores = scores + Point;
    }

    //正のポイントになるかどうか
    public bool HasPoint(int Point)
    {
        return (scores + Point >= 0) ? true : false;
    }


    // ハイスコアの保存
    public void Save()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt(highScoreKey, highScores);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Initialize();
    }

    public void SaveDelete()
    {
        PlayerPrefs.SetInt(highScoreKey, 0);
        PlayerPrefs.Save();
    }

    public void OCmode()
    {
        OCBoard.SetActive(true);
        OCTimer.text = OCtime.ToString("f1");
        if (OCtime <= 0)
        {
            StarfighterControl.OC = false;
            OCBoard.SetActive(false);
        }
        else OCtime -= Time.deltaTime;

    }
}