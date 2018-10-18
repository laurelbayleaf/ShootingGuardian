using UnityEngine;
using System.Collections;

public class MeteorControl : MonoBehaviour
{

    public GameObject Explosion;

    public int Pointrate;
    float Point;
    public int HP;
    public float rotate;
    public float movevelocity;
    Vector3 meteorspeed = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 15);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = new Vector3(Random.Range(-rotate, rotate), Random.Range(-rotate, rotate), Random.Range(-rotate, rotate));
    }

    // Update is called once per frame
    void Update()
    {
        meteorspeed -= new Vector3(Random.Range(-movevelocity, movevelocity), Random.Range(-movevelocity, movevelocity), Random.Range(-movevelocity, movevelocity));
        transform.Translate(meteorspeed);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            HP--;
            if (HP <= 0)
            {
                Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Destroy(this.gameObject);
                Point = Pointrate * StarfighterControl.ammocost / StarfighterControl.Z_Speed;
                FindObjectOfType<Score>().AddPoint((int)Point);
            }
        }

    }

}