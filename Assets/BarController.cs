using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    float currentTime;
    float elapsedTime;

    private void Start()
    {
        currentTime = LoadingManager.timeLeft; //120sec
        
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        float percentage = elapsedTime / currentTime;

        slider.value = Mathf.LerpUnclamped(1, 0, percentage);
        Debug.Log(Mathf.LerpUnclamped(1, 0, percentage));
    }
}
