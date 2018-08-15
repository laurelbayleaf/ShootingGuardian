using UnityEngine;
using System.Collections;

public class StarfighterControl : MonoBehaviour
{
    float X_Speed = 1;
    float Y_Speed = 1;
    public static float Z_Speed = 2;
    public GameObject Prefab;
    public GameObject EnemyObject1;
    public GameObject EnemyObject2;
    public GameObject Explosion;
    float intervalTime;
    float enemyintervalTime1;
    float enemyintervalTime2;
    float randomrange = 30;
    double travelscore = 0;

    // Use this for initialization
    void Start()
    {
        intervalTime = 0;
        enemyintervalTime1 = 0;
        enemyintervalTime2 = 0;
        BgmManager.Instance.TimeToFade = 3.0f;
        BgmManager.Instance.CrossFadeRatio = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //移動
        if (Input.GetKey("up"))
        {
            transform.Translate(0, vertical * Y_Speed * 0.25f, 0);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(0, vertical * Y_Speed * 0.25f, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(horizontal * X_Speed * 0.5f, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(horizontal * X_Speed * 0.5f, 0, 0);
        }
        transform.Translate(0, 0, Z_Speed);
        Z_Speed += 0.0001f;

        //弾発射
        intervalTime += Time.deltaTime;
        if (Input.GetKey("space"))
        {
            if (intervalTime >= 1.0f)
            {
                intervalTime = 0.0f;
                Instantiate(Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                FindObjectOfType<Score>().AddPoint((int)Z_Speed*-20);
            }
        }

        // プレイヤーの座標を取得
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(transform.position.x, -10, 10);
        pos.y = Mathf.Clamp(transform.position.y, -1, 10);


        transform.position = pos;

        //メテオ発生
        enemyintervalTime1 += Time.deltaTime;
        if (enemyintervalTime1 >= (0.4f / Z_Speed))
        {
            enemyintervalTime1 = 0;
            Instantiate(EnemyObject1, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 300), Quaternion.identity);
            Instantiate(EnemyObject1, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 300), Quaternion.identity);
        }
        enemyintervalTime2 += Time.deltaTime;
        if (enemyintervalTime2 >= (0.8f / Z_Speed))
        {
            enemyintervalTime2 = 0;
            Instantiate(EnemyObject2, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 500), Quaternion.identity);
        }

        //航行によるポイント加算
        travelscore += Z_Speed * 0.25;
        while (travelscore >= 1)
        {
            FindObjectOfType<Score>().AddPoint(1);
            travelscore--;
        }

        //飛行速度によるＢＧＭ切り替え
        if (Z_Speed >= 5.63)
        {
            BgmManager.Instance.Play("reflectable");
        }
        else if (Z_Speed >= 5.05)
        {
            BgmManager.Instance.Play("Edge of the Galaxy");
        }
        else if (Z_Speed >= 3.8)
        {
            BgmManager.Instance.Play("dear Dragon");
        }
        else if (Z_Speed >= 2.95)
        {
            BgmManager.Instance.Play("Aquilegia");
        }
        else if (Z_Speed >= 2)
        {
            BgmManager.Instance.Play("Different_Dimension");
        }

        //デバッグ
        //if (Input.GetKey(KeyCode.W))
        //{
        //    Z_Speed += 0.001f;
        //}
        if (Input.GetKey(KeyCode.S))
        {
            Z_Speed -= 0.001f;
        }

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
            Z_Speed = 2;
            BgmManager.Instance.StopImmediately ();
            GameObject.Find("Main Camera").GetComponent<GameControl>().gameFlag = false;
        }
    }
}