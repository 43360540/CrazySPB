using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class SpawnAndThrow : MonoSingleton<SpawnAndThrow>
{
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _target;

    [Header("RandomBall")]
    [SerializeField] private ThrownItem _thrownItem;
    [SerializeField] private Vector2 _itemSize; 
    [SerializeField] private float _spawnTime;

    [Header("MainBall")]
    [SerializeField] private MainBall _mainItem;
    private Transform _centerPoint;

    private float HalfHeight => _cam.orthographicSize;
    private float HalfWidth => _cam.orthographicSize * _cam.aspect;

    private float top, bottom, right, left;
    private float _timer;
    public List<Transform> Balls { get; private set; } = new();

    protected override void Awake()
    {
        base.Awake();

        if (_cam == null)
            _cam = Camera.main;
        _centerPoint = _mainItem.Center;
    }

    private void Start()
    {
        top = _cam.transform.position.y + HalfHeight;
        bottom = _cam.transform.position.y - HalfHeight;
        right = _cam.transform.position.x + HalfWidth;
        left = _cam.transform.position.x - HalfWidth;

        Balls.Add(SapwnMain().transform);
    }

    private void Update()
    {
        if (_timer >= _spawnTime)
        {
            var item = SpawnThrown();
            item.SetTarget(_target);

            Balls.Add(item.transform);
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    public MainBall SapwnMain()
    {
        return Instantiate(_mainItem, _centerPoint.position, this.transform.rotation, this.transform);
    }

    public ThrownItem SpawnThrown()
    {
        var wantPos = RandomPos();
        return Instantiate(_thrownItem, wantPos, this.transform.rotation, this.transform);
    }

    public Vector2 RandomPos()
    {
        Vector2 wantPos;

        do
        {
            wantPos = new Vector2(URandom.Range(left - _itemSize.x, right + _itemSize.x),
                                    URandom.Range(bottom - _itemSize.y, top + _itemSize.y));
        }
        while (wantPos.y < top && wantPos.y > bottom && wantPos.x < right && wantPos.x > left);

        return wantPos;
    }

}
