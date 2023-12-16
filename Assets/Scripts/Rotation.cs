using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotation_speed = 10f;
    public GameObject game_object ;

    // Update is called once per frame
    void Update()
    {
        Vector3 vec_3 = new Vector3(0,1,0);
        transform.RotateAround(game_object.transform.position, vec_3, rotation_speed*Time.fixedDeltaTime);
    }
}
