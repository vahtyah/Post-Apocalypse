using System;
using UnityEngine;

public class MapScene : MonoBehaviour
{
    [SerializeField] private Transform playerStartPos;

    private void Start()
    {
        Player.Instance.transform.position = playerStartPos.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.Instance.Movement.SetPosition(playerStartPos.position);
        }
    }
}
