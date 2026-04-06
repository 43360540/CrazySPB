using System.Collections.Generic;
using UnityEngine;

public class SPBSpawner : MonoSingleton<SPBSpawner>
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private float _spacing;
    [SerializeField] private Transform _parent;

    public List<Transform> Targets { get; set; } = new();

    protected override void Awake()
    {
        base.Awake();
        Targets.Clear();
    }

    public void Spawn()
    {
        Vector2 startPoint = new Vector2(_startPoint.position.x,
                            _startPoint.position.y - (_spacing * Targets.Count));
        Targets.Add(Instantiate(_target, startPoint, _startPoint.rotation, _parent));
    }
}
