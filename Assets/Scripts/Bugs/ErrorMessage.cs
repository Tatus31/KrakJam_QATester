using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    [SerializeField]
    private Transform errorMessage;
    private int errorChance  = 3500;

    void Start()
    {
        errorMessage.gameObject.SetActive(false);
    }

    void Update()
    {
        ErrorMessageChance();
    }

    private void StartErrorMessageAppear()
    {
        StartCoroutine(OnErrorMassageAppear());
    }

    private IEnumerator OnErrorMassageAppear()
    {
        errorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        errorMessage.gameObject.SetActive(false);
    }

    private void ErrorMessageChance()
    {
        int randomAppearChace = Random.Range(0, errorChance);
        if (randomAppearChace == 1)
        {
            StartErrorMessageAppear();
        }
    }
}
