using System.Collections;
using UnityEngine;

public class CellMover : MonoBehaviour
{

    public AnimationCurve curve;
    public float lerpTime = 2f;
    private float _currentLerpTime;
    private Vector2 _targetPoint;
    private void Update()
    {

    }

    public void Move(Vector2 newPosition)
    {
        StopAllCoroutines();
        _targetPoint = newPosition;
        var mover = StartCoroutine(MoveToTarget(_targetPoint));
    }



    private IEnumerator MoveToTarget(Vector2 target)
    {
        _currentLerpTime = 0;
        while (true)
        {
            _currentLerpTime += Time.deltaTime;
            if (_currentLerpTime > lerpTime)
            {
                _currentLerpTime = lerpTime;
            }
            float t = curve.Evaluate(_currentLerpTime);
            transform.GetComponent<RectTransform>().localPosition = Vector2.Lerp(transform.GetComponent<RectTransform>().localPosition, target, t);
            yield return null;
        }
    }


}
