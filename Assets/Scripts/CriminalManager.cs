using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class CriminalManager : MonoBehaviour
{
    public NavMeshAgent MyAgent;
    public bool ActivateFollow = false;
    public bool MoveToPrison = false;
    private bool _isOnList = false;
    private readonly float _handCuffOffSet = 0.1f;
    [SerializeField] private GameObject _prison;
    [SerializeField] private float _speed;

   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _isOnList == false && GameManager.Instance.HandCuffs.Count > 1) // it must be (> 1) because there is an extra handcuff on the list that is used for placement only
        {
            _isOnList = true;
            GameManager.Instance.Criminals.Add(gameObject);
            ActivateFollow = true;
            GameManager.Instance.HandCuffs[^1].transform.parent = null;
            GameManager.Instance.HandCuffs[^1].transform.SetPositionAndRotation(gameObject.transform.position + transform.forward * _handCuffOffSet, gameObject.transform.rotation);
            GameManager.Instance.HandCuffs[^1].transform.parent = gameObject.transform;
            GameManager.Instance.HandCuffs.RemoveAt(GameManager.Instance.HandCuffs.Count - 1);
        }
    }
    private void Update()
    {
        if (ActivateFollow)
        {
            MyAgent.destination = GameManager.Instance.Criminals[GameManager.Instance.Criminals.IndexOf(gameObject) - 1].transform.position;
        }
        else if (MoveToPrison)
        {
            transform.position = Vector3.MoveTowards(transform.position, _prison.transform.position, _speed * Time.deltaTime);
            transform.LookAt(_prison.transform);
        }
    }
}
