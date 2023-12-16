using System;
using UnityEngine;
using TMPro;

public class Memory_Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI memory_counter;
    private float polling_time = 1f;
    private long total_memory;
    private float time;
    private string formatted_memory;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= polling_time)
        {
            total_memory = GC.GetTotalMemory(false);
            formatted_memory = ByteSize(total_memory);
            memory_counter.text = "Memory: " + formatted_memory;
            time -= polling_time;
        }
    }

    private string ByteSize(long bytesize)
    {
        string[] size = { "B", "KB", "MB", "GB", "TB" };
        int x = 0;
        double formatted_size = bytesize;

        while (formatted_size >= 1024 && x < size.Length - 1)
        {
            formatted_size = formatted_size / 1024;
            x++;
        }
        return $"{formatted_size:0.##}{size[x]}";
    }
}

