using UnityEngine;

using System.Collections;

public class Bullet : MonoBehaviour
{

    float bulletSpeed = 2;
    //GameObject SF;
    //StarfighterControl player;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 5);
        //SF = GameObject.Find("SF_Free-Fighter");
        //player = SF.GetComponent<StarfighterControl>();

    }
    // Update is called once per frame
    void Update()
    {
        float playerspeed = StarfighterControl.Z_Speed;
        transform.Translate(0, 0, bulletSpeed + playerspeed);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}