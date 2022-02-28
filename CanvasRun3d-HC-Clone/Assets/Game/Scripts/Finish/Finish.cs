using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static event Action FinishGameObserver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            FinishGameObserver?.Invoke();
        }
    }
}
