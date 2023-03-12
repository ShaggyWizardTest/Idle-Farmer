using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private ScriptableObject _directionInput;
    [SerializeField] private GameObject _scyse;
    [SerializeField] private Transform _hitBox;
    [SerializeField] private Transform _backpack;
    [SerializeField] private float _slotOffset;


    private Rigidbody _rigidbody;
    private IDirection _direction;


    private float _backpackOffset;


    private void Start()
    {
        if (!(
            Utils.TryGetClass(_directionInput, out _direction) &&
            TryGetComponent(out _rigidbody)
            ))
        {
            Debug.LogError("Error occured while initing!");
            Destroy(this);
        }

    }
    private void Update()
    {
        if (_direction.Direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(_direction.Direction);
        if (_scyse.activeInHierarchy)
        {
            Collider[] hits = Physics.OverlapBox(_hitBox.position, _hitBox.lossyScale * 0.5f, _hitBox.rotation);

            foreach (var hit in hits)
            {
                if (!hit.transform.TryGetComponent(out ICollectible collectible)) continue;
                if (!collectible.Ready) continue;

                var collected = collectible.Collect();
                collected.transform.parent = _backpack;
                collected.transform.localPosition = Vector3.up * _backpackOffset;
                collected.transform.localRotation = Quaternion.identity;
                _backpackOffset += _slotOffset;
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (_hitBox == null) return;
        var originalMatrix = Gizmos.matrix;
        Gizmos.matrix *= Matrix4x4.TRS(_hitBox.position, _hitBox.rotation, _hitBox.lossyScale);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        Gizmos.matrix = originalMatrix;
    }
    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _direction.Direction * 10f * Time.fixedDeltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IField _))
        {
            _scyse.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IField _))
        {
            _scyse.SetActive(false);
        }
    }
}
