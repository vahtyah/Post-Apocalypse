using System;
using UnityEngine;

public class MapScene : MonoBehaviour
{
    [SerializeField] private Transform playerStartPos;

    private void Start()
    {
        Player.Instance.transform.position = playerStartPos.position;
        Debug.Log(playerStartPos.position);
    }
}
