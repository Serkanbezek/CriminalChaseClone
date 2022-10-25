using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandCuffSpawner : MonoBehaviour
{
    public GameObject HandCuff;
    public GameObject Player;
    private bool _isSpawnerActive = true;
    private float _handCuffOffSet = 0.2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _isSpawnerActive)
        {
            _isSpawnerActive = false;
            GameObject _handCuff = Instantiate(HandCuff, transform.position, transform.rotation) as GameObject;
            Vector3 _newPos = GameManager.Instance.HandCuffs[^1].transform.position;
            _newPos.y += _handCuffOffSet;
            _handCuff.transform.SetPositionAndRotation(_newPos, GameManager.Instance.HandCuffs[^1].transform.rotation);
            _handCuff.transform.parent = Player.transform;
            GameManager.Instance.HandCuffs.Add(_handCuff);
        }
    }
}
