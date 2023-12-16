using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS_Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fps_counter;
    private float polling_time = 1f;
    private float time;
    private int frame_count;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        frame_count++;
        if (time >= polling_time)
        {
            int frameRate = Mathf.RoundToInt(frame_count / time);
            fps_counter.text = frameRate.ToString() + " FPS";
            time -= polling_time;
            frame_count = 0;
        }
    }
}
