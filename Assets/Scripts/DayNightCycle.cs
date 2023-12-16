using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    //code based from https://www.youtube.com/watch?v=H3JpkcGi8DI
    [Range(0, 24)]
    public float time_of_day;
    private float speed = 0.3f;
    public Light sun;
    public Light moon;
    private bool is_night;

    void Update()
    {
        time_of_day += Time.fixedDeltaTime * speed;
        if(time_of_day > 23.5f)
        {
            time_of_day = 0.5f;
        }
        update_sun();
    }

    private void OnValidate()
    {
        update_sun();
    }

    private void update_sun()
    {
        float rot = time_of_day/24.0f;
        float sun_rot = Mathf.Lerp(-90,270,rot);
        sun.transform.rotation = Quaternion.Euler(sun_rot, -150.0f, 0);
        moon.transform.rotation = Quaternion.Euler(sun_rot-180, -150.0f, 0);
        CheckShadow();
    }
    private void CheckShadow(){
        if(is_night){
          if(moon.transform.rotation.eulerAngles.x > 180){
              is_night = false;
              sun.shadows = LightShadows.Soft;
              moon.shadows = LightShadows.None;
            }
        }else{
            if(sun.transform.rotation.eulerAngles.x > 180){
                is_night = true;
                moon.shadows = LightShadows.Soft;
                sun.shadows = LightShadows.None;
            }
        }
    }
}
