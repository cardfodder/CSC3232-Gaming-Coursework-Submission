using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Profiling;

public class FPSdisplay : MonoBehaviour
{
    [ SerializeField ]
    public Text fpsText;
    public Text memText;

    public float deltaTime;

    ProfilerRecorder totalReservedMemoryRecorder;

    void Start() 
    {
        totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
    }

    // Update is called once per frame
    void Update()
    {
        float fps = 1f/Time.deltaTime;
        fpsText.text = "Current FPS: " + Mathf.Ceil(fps).ToString();

        if (totalReservedMemoryRecorder.Valid){
            memText.text = "Total Reserved Memory: " + totalReservedMemoryRecorder.CurrentValue.ToString();
        }
            
    }
}
