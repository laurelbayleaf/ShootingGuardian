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
    bool Horizontalmove = false;
    bool Verticalmove = false;
    float vertical;
    float horizontal;
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
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        //移動
        if (Input.GetKey("up")) Verticalmove = true;
        if (Input.GetKey("down"))   Verticalmove = true;
        if (Input.GetKey("left"))   Horizontalmove = true;
        if (Input.GetKey("right"))  Horizontalmove = true;

        // プレイヤーの座標を取得
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(transform.position.x, -10, 10);
        pos.y = Mathf.Clamp(transform.position.y, -1, 10);
        transform.position = pos;

        //弾発射
        if (Input.GetKey("space") && intervalTime >= 1.0f)
        {
            intervalTime = 0.0f;
            Instantiate(Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            FindObjectOfType<Score>().AddPoint((int)Z_Speed * -20);
        }

        //メテオ発生
        if (enemyintervalTime1 >= (0.4f / Z_Speed))
        {
            enemyintervalTime1 = 0;
            Instantiate(EnemyObject1, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 300), Quaternion.identity);
            Instantiate(EnemyObject1, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 300), Quaternion.identity);
        }
        if (enemyintervalTime2 >= (0.8f / Z_Speed))
        {
            enemyintervalTime2 = 0;
            Instantiate(EnemyObject2, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 500), Quaternion.identity);
        }

        //点数加算
        while (travelscore >= 1)
        {
            FindObjectOfType<Score>().AddPoint(1);
            travelscore--;
        }

        //飛行速度によるＢＧＭ切り替え
        if (Z_Speed >= 5.03)
        {
            BgmManager.Instance.Play("reflectable");
        }
        else if (Z_Speed >= 4.55)
        {
            BgmManager.Instance.Play("Edge of the Galaxy");
        }
        else if (Z_Speed >= 3.5)
        {
            BgmManager.Instance.Play("dear Dragon");
        }
        else if (Z_Speed >= 2.75)
        {
            BgmManager.Instance.Play("Aquilegia");
        }
        else
        {
            BgmManager.Instance.Play("Different_Dimension");
        }

        //デバッグ
        if (Input.GetKey(KeyCode.W))
        {
            Z_Speed += 0.005f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Z_Speed -= 0.005f;
        }

    }

    private void FixedUpdate()
    {
        //移動
        if (Verticalmove == true) transform.Translate(0, vertical * Y_Speed * 0.25f, 0);
        if (Horizontalmove == true) transform.Translate(horizontal * X_Speed * 0.5f, 0, 0);
        transform.Translate(0, 0, Z_Speed);
        Z_Speed += 0.0001f;

        //弾装填
        intervalTime += Time.deltaTime;


        //メテオ発生
        enemyintervalTime1 += Time.deltaTime;
        enemyintervalTime2 += Time.deltaTime;

        //航行によるポイント加算
        travelscore += Z_Speed * 0.2;

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
            GameObject.Find("Main Camera").GetComponent<GameControl>().playingFlag = false;

        }
    }
}