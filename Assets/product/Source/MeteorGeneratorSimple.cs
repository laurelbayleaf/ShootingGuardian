using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGeneratorSimple : MonoBehaviour
{


    public GameObject Meteor;
    public double Interval;
    public int Multipul;
    public double Level;

    float enemyintervalTime;
    float randomrange = 30;

    void Start()
    {
        enemyintervalTime = 0;
    }

    void Update()
    {

        // プレイヤーの座標を取得
        Vector3 pos = transform.position;

        //メテオ発生
        if (enemyintervalTime >= (Interval / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= Level)
        {
            enemyintervalTime = 0;
            MeteorGenerate(Meteor);
        }

    }

    private void FixedUpdate()
    {
        //メテオ発生
        enemyintervalTime += Time.deltaTime;
    }

    void MeteorGenerate(GameObject meteor)
    {
        Instantiate(meteor, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 1000), Quaternion.identity);
    }
}

