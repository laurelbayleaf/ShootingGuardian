using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    public Vector3 difference;
    float differenceX;

    // Use this for initialization
    void Start()
    {
        difference = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.Find("SF_Free-Fighter(Clone)") == true)
        {
            Vector3 startVec = GameObject.Find("SF_Free-Fighter(Clone)").transform.localPosition;
            difference.z = StarfighterControl.Z_Speed - 10;

            transform.localPosition = new Vector3(difference.x, difference.y + 5, startVec.z + difference.z);
        }

    }
}