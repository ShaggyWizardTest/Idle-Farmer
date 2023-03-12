using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour, ICollectible
{
    [SerializeField] private GameObject _model;
    [SerializeField] private GameObject _pickup;
    [SerializeField] private bool _ready;


    public bool Ready => _ready;


    public GameObject Collect()
    {
        _model.SetActive(false);
        _ready = false;
        return _pickup;
    }
}
