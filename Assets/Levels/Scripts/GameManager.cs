using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action<GameObject> LinkBallToCamera;
    public static Action ResetUI;

    [SerializeField] private Vector3 _position = Vector3.up;
    [SerializeField] private GameObject _prefab;

    private GameObject _parent;
    private GameObject _ball;

    void Awake()
    {
        _parent = GameObject.FindGameObjectWithTag("Level");
        _ball = SpawnBallAtLocation(_position);
    }

    private void Start()
    {
        AddBallToCamera();
    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    GameObject SpawnBallAtLocation(Vector3 position)
    {
        return Instantiate(_prefab, position, Quaternion.identity, _parent.transform);
    }

    void AddBallToCamera()
    {
        LinkBallToCamera(_ball);
    }
}