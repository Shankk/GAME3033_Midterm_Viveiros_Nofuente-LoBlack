using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI Timer;
    float TimerThreshold;
    float TimeAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        TimerThreshold += Time.deltaTime;
        if(TimerThreshold >= 1)
        {
            TimeAmount++;
            TimerThreshold = 0f;
            Timer.text = "Time: " + TimeAmount;
        }
    }
}
