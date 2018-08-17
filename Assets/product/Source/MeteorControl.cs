using UnityEngine;
using System.Collections;

public class MeteorControl : MonoBehaviour
{

    public GameObject Explosion;

    public int Pointrate;
    int Point;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 10);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
            Point = Pointrate * StarfighterControl.ammocost;
            FindObjectOfType<Score>().AddPoint(Pointrate);
        }
        
    }
}