using System.Collections;
using UnityEngine;


public class Grass : MonoBehaviour, ICollectible
{
    [SerializeField] private GameObject _pickup;
    [SerializeField] private bool _ready;
    [SerializeField] private float _growTime;


    private Material _material;


    public bool Ready => _ready;


    private void Start()
    {
        if (!(
            TryGetComponent(out MeshRenderer meshRenderer)
            ))
        {
            Debug.LogError("Error occured while initing!");
            Destroy(this);
        }

        _material = meshRenderer.material;
    }


    public GameObject Collect()
    {
        _material.SetFloat("_Progress", 0);
        _ready = false;
        StartCoroutine(Grow());
        return Instantiate(_pickup);
    }

    private IEnumerator Grow()
    {
        float time = 0;
        while (time < _growTime)
        {
            _material.SetFloat("_Progress", time / _growTime);
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _material.SetFloat("_Progress", 1);
        _ready = true;
    }
}
