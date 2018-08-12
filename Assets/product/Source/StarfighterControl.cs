using UnityEngine;
using System.Collections;

public class StarfighterControl : MonoBehaviour
{
    float X_Speed = 1;
    float Y_Speed = 1;
    public static float Z_Speed = 4;
    public GameObject Prefab;
    public GameObject EnemyObject1;
    public GameObject EnemyObject2;
    public GameObject Explosion;
    float intervalTime;
    float enemyintervalTime1;
    float enemyintervalTime2;
    float randomrange = 30;


    // Use this for initialization
    void Start()
    {
        intervalTime = 0;
        enemyintervalTime1 = 0;
        enemyintervalTime2 = 0;
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
            transform.Translate(horizontal * X_Speed, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(horizontal * X_Speed, 0, 0);
        }
        transform.Translate(0, 0, Z_Speed);

        //弾発射
        intervalTime += Time.deltaTime;
        if (Input.GetKey("space"))
        {
            if (intervalTime >= 1.0f)
            {
                intervalTime = 0.0f;
                Instantiate(Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }

        // プレイヤーの座標を取得
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(transform.position.x, -10, 10);
        pos.y = Mathf.Clamp(transform.position.y, -1, 10);


        transform.position = pos;

        //メテオ発生
        enemyintervalTime1 += Time.deltaTime;
        if (enemyintervalTime1 >= 0.125f)
        {
            enemyintervalTime1 = 0;
            Instantiate(EnemyObject1, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 300), Quaternion.identity);
            Instantiate(EnemyObject1, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 300), Quaternion.identity);
        }
        enemyintervalTime2 += Time.deltaTime;
        if (enemyintervalTime2 >= 0.25f)
        {
            enemyintervalTime2 = 0;
            Instantiate(EnemyObject2, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 500), Quaternion.identity);
        }


    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);

            GameObject.Find("Main Camera").GetComponent<GameControl>().gameFlag = false;
        }
    }
}