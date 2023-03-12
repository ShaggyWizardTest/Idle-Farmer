using UnityEngine;


[CreateAssetMenu]
public class PlayerInputScriptableObject : ScriptableObject, IDirection
{
    private PlayerInput _playerInput;


    private void OnEnable()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }


    public Vector3 Direction
    {
        get
        {
            if (_playerInput == null) return Vector3.zero;

            Vector2 inputVector = _playerInput.Player.Move.ReadValue<Vector2>();
            return new Vector3(inputVector.x, 0, inputVector.y);
        }
    }
}