using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class SendToPrison : MonoBehaviour
{
    [SerializeField] private GameObject _prison;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.Criminals.Count > 1) // it's > 1 because there is an extra criminal in the list that is used for placement only
        {
            for (int i = 1; i < GameManager.Instance.Criminals.Count; i++)
            {
                GameManager.Instance.Criminals[i].GetComponent<CriminalManager>().ActivateFollow = false;
                GameManager.Instance.Criminals[i].GetComponent<NavMeshAgent>().isStopped = true;
                GameManager.Instance.Criminals[i].GetComponent<CriminalManager>().MoveToPrison = true;
                GameManager.Instance.Criminals.RemoveAt(i);
            }
        }
    }
}
