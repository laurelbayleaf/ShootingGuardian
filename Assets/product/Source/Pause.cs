using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p") && GameObject.Find("Main Camera").GetComponent<GameControl>().playingFlag == true)
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf)
            {
            //　ポーズUIが表示されてる時は停止
                Time.timeScale = 0f;
                BgmManager.Instance.Pause();
            }
            else
            {
            //　ポーズUIが表示されてなければ通常通り進行
                Time.timeScale = 1f;
                BgmManager.Instance.UnPause();

            }
        }
    }
}