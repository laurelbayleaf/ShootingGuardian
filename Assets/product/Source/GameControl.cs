using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{

    public GameObject GameStartBtn;
    public GameObject starFighterPrefab;
    public GameObject GameOverSet;
    public GameObject GameOverSet2;

    public bool gameFlag;
    public bool playingFlag;

    // Use this for initialization
    void Start()
    {
        gameFlag = true;
        playingFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFlag == false)
        {
            GameOverSet.SetActive(true);
            GameOverSet2.SetActive(true);
        }

        if (gameFlag == true&& playingFlag == false&& Input.GetKey("space"))
        {
            GameStartButton();
        }

        if (gameFlag == false && Input.GetKeyDown("r"))
        {
            GameOverButton();
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

    public void GameStartButton()
    {
        Instantiate(starFighterPrefab);
        GameStartBtn.SetActive(false);
        playingFlag = true;

    }

    public void GameOverButton()
    {

        FindObjectOfType<Score>().Save();
        Application.LoadLevel("battle");
    }

}