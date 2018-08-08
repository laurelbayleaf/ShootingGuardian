using UnityEngine;
using System.Collections;

public class MeteorControl : MonoBehaviour
{

    public GameObject Explosion;
    float Z_Speed = 0.7f;
    float intervalTime;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -5 * Z_Speed);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);

        }
        
    }
}