using UnityEngine;
using System.Collections;

public class StarfighterControl : MonoBehaviour
{

    float X_Speed = 1;
    float Z_Speed = 1;

    public GameObject Prefab;
    public GameObject EnemyObject;
    public GameObject Explosion;
    float intervalTime;
    float enemyintervalTime;

    // Use this for initialization
    void Start()
    {
        intervalTime = 0;
        enemyintervalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float vertical = Input.GetAxis("Vertical");

        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey("up"))
        {
            transform.Translate(0, 0, vertical * Z_Speed);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(0, 0, vertical * Z_Speed);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(horizontal * X_Speed, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(horizontal * X_Speed, 0, 0);
        }

        intervalTime += Time.deltaTime;
        if (Input.GetKey("space"))
        {
            if (intervalTime >= 0.1f)
            {
                intervalTime = 0.0f;
                Instantiate(Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }

        // プレイヤーの座標を取得
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(transform.position.x, -35, 35);

        transform.position = pos;

        enemyintervalTime += Time.deltaTime;
        if (enemyintervalTime >= 4.0f)
        {
            enemyintervalTime = 0;
            Instantiate(EnemyObject, new Vector3(Random.Range(-35.0f, 35.0f), transform.position.y, transform.position.z + 200), Quaternion.identity);
        }

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "EnemyBullet")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
            GameObject.Find("Main Camera").GetComponent<GameControl>().gameFlag = false;
        }
    }
}