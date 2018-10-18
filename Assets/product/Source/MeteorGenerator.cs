using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{
    public GameObject Meteor1;
    public GameObject Meteor2;
    public GameObject Meteor3;
    public GameObject Meteor4;
    public GameObject Meteor5;
    public GameObject Meteor6;

    float enemyintervalTime1;
    float enemyintervalTime2;
    float enemyintervalTime3;
    float enemyintervalTime4;
    float enemyintervalTime5;
    float enemyintervalTime6;

    float randomrange = 30;

    // Use this for initialization
    void Start()
    {
        enemyintervalTime1 = 0;
        enemyintervalTime2 = 0;
        enemyintervalTime3 = 0;
        enemyintervalTime4 = 0;
        enemyintervalTime5 = 0;
        enemyintervalTime6 = 0;
    }

    // Update is called once per frame
    void Update()
    {

        // プレイヤーの座標を取得
        Vector3 pos = transform.position;

        //メテオ発生
        if (enemyintervalTime1 >= (0.4f / StarfighterControl.Z_Speed))
        {
            enemyintervalTime1 = 0;
            MeteorGenerate(Meteor1);
            MeteorGenerate(Meteor1);
        }

        if (enemyintervalTime2 >= (0.8f / StarfighterControl.Z_Speed))
        {
            enemyintervalTime2 = 0;
            MeteorGenerate(Meteor2);
        }

        if (enemyintervalTime3 >= (10.0f / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= 2.2)
        {
            enemyintervalTime3 = 0;
            MeteorGenerate(Meteor3);
        }

        if (enemyintervalTime4 >= (0.4f / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= 2.5)
        {
            enemyintervalTime4 = 0;
            MeteorGenerate(Meteor4);
        }

        if (enemyintervalTime5 >= (5f / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= 2.7)
        {
            enemyintervalTime5 = 0;
            MeteorGenerate(Meteor5);
        }

        if (enemyintervalTime6 >= (10f / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= 3)
        {
            enemyintervalTime6 = 0;
            MeteorGenerate(Meteor6);
        }

    }

    private void FixedUpdate()
    {

        //メテオ発生
        enemyintervalTime1 += Time.deltaTime;
        enemyintervalTime2 += Time.deltaTime;
        enemyintervalTime3 += Time.deltaTime;
        enemyintervalTime4 += Time.deltaTime;
        enemyintervalTime5 += Time.deltaTime;
        enemyintervalTime6 += Time.deltaTime;

    }

    void MeteorGenerate(GameObject meteor)
    {
        Instantiate(meteor, new Vector3(Random.Range(-randomrange, randomrange), Random.Range(-randomrange, randomrange), transform.position.z + 1000), Quaternion.identity);

    }
}
