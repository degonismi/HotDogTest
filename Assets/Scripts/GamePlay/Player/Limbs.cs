using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LimbsLineAdder : MonoBehaviour
{
    [SerializeField] private Transform _midle;
    [SerializeField] private Transform _end;

    [SerializeField] private LineRenderer _lineRenderer;

    private Vector3[] _points = new Vector3[3];

    private void OnValidate()
    {
        SetPoints();
        _lineRenderer.SetPositions(_points);
    }

    private void LateUpdate()
    {
        SetLines();
    }

    private void SetPoints()
    {
        _points[0] = transform.position;
        _points[1] = _midle.position;
        _points[2] = _end.position;
    }

    [ContextMenu("Set lines")]
    private void SetLines()
    {
        SetPoints();
        _lineRenderer.SetPositions(_points);
    }
}
