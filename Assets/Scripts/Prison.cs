using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour
{
    public GameObject Player;
    private int _handCuffChildIndex = 1;
    private float _handCuffOffSet = 0.2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Criminal") && !GameManager.Instance.Criminals.Contains(other.gameObject))
        {
            GameObject _handCuff = other.transform.GetChild(_handCuffChildIndex).gameObject;  //handcuff is the second child of the criminal (red hat is the first child)
            _handCuff.transform.parent = null;
            Vector3 _newPos = GameManager.Instance.HandCuffs[^1].transform.position;
            _newPos.y += _handCuffOffSet;
            _handCuff.transform.SetPositionAndRotation(_newPos, GameManager.Instance.HandCuffs[^1].transform.rotation);
            _handCuff.transform.parent = Player.transform;
            GameManager.Instance.HandCuffs.Add(_handCuff);
            Destroy(other.gameObject);
        }
    }
}
