using UnityEngine;

public class Field : MonoBehaviour, IField
{
    [SerializeField] private GameObject _cropPrefab;
    [SerializeField] private Vector2 _fieldSize;
    [SerializeField] private Vector2Int _gridSize;


    private void Start()
    {
        GenerateGrid();
    }


    private void GenerateGrid()
    {
        float stepX = _fieldSize.x / (_gridSize.x - 1);
        float stepY = _fieldSize.y / (_gridSize.y - 1);
        Vector3 offset = new Vector3(-_fieldSize.x * 0.5f, 0, -_fieldSize.y * 0.5f);
        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                var instance = Instantiate(_cropPrefab, transform);
                instance.transform.localPosition = new Vector3(stepX * x, 0, stepY * y) + offset;
            }
        }
    }
}
