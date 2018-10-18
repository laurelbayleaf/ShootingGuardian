using UnityEngine;

using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject Explosion;

    float bulletSpeed = 2;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 5);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float playerspeed = StarfighterControl.Z_Speed;
        transform.Translate(0, 0, bulletSpeed + playerspeed);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}