using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private GameObject _cellPrefab;
    private const int BOARD_SIZE = 2048;
    private float _xMultiplier;
    private float _yMultiplier;
    private float _xOffset;
    private float _yOffset;
    private float _scale;

    private List<GameObject> _objects = new List<GameObject>();
    private List<Vector2> _coordinates = new List<Vector2>();

    public void GenerateField(int width, int height)
    {
        if (_objects.Count > 0)
        {
            _objects.ForEach(x => Destroy(x));
            _objects.Clear();
            _coordinates.Clear();
        }
        _width = width;
        _height = height;

        SetDeminsions();
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                var coords = new Vector2(i * _xMultiplier - _xOffset, j * _yMultiplier - _yOffset);

                var obj = Instantiate(_cellPrefab, new Vector2(0, 0), Quaternion.identity);
                _coordinates.Add(coords);

                obj.transform.SetParent(this.transform);
                obj.transform.GetComponent<RectTransform>().localScale = new Vector3(_scale, _scale, 1);
                obj.transform.GetComponent<RectTransform>().localPosition = coords;

                _objects.Add(obj);
            }
        }
    }

    public void RemixField()
    {
        RemixCordinates();
        for (int i = 0; i < _objects.Count; i++)
        {
            _objects[i].GetComponent<Cell>().ChangePosition(_coordinates[i]);
        }
    }


    private void RemixCordinates()
    {

        for (int i = _coordinates.Count - 1; i >= 1; i--)
        {
            int j = Random.Range(0, i + 1);

            var tmp = _coordinates[j];
            _coordinates[j] = _coordinates[i];
            _coordinates[i] = tmp;
        }
    }
    private void SetDeminsions()
    {
        _xMultiplier = BOARD_SIZE / _width;
        _yMultiplier = BOARD_SIZE / _height;
        _xOffset = BOARD_SIZE / 2 - _xMultiplier / 2;
        _yOffset = BOARD_SIZE / 2 - _yMultiplier / 2;


        if (_width > _height)
        {
            _scale = 10f / _width;
            return;
        }
        _scale = 10f / _height;
    }
}
