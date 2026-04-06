using UnityEngine;

public class SpawnAndThrow : MonoBehaviour
{
    [SerializeField] private ThrownItem _item;
    [SerializeField] private Vector2 _itemSize;
    [SerializeField] private Camera _cam;
    [SerializeField] private float _spawnTime;
    [SerializeField] private Transform _target;

    private float HalfHeight => _cam.orthographicSize;
    private float HalfWidth => _cam.orthographicSize * _cam.aspect;

    private float _timer;

    private void Awake()
    {
        if (_cam == null)
            _cam = Camera.main;
    }

    private void Update()
    {
        if (_timer >= _spawnTime)
        {
            var item = Spawn();
            item.SetTarget(_target);
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }

    public ThrownItem Spawn()
    {
        var wantPos = RandomPos();
        return Instantiate(_item, wantPos, this.transform.rotation, this.transform);
    }

    public Vector2 RandomPos()
    {
        float top = _cam.transform.position.y + HalfHeight;
        float bottom = _cam.transform.position.y - HalfHeight;
        float right = _cam.transform.position.x + HalfWidth;
        float left = _cam.transform.position.x - HalfWidth;

        Vector2 wantPos;

        do
        {
            wantPos = new Vector2(Random.Range(left - _itemSize.x, right + _itemSize.x),
                                    Random.Range(bottom - _itemSize.y, top + _itemSize.y));
        }
        while (wantPos.y < top && wantPos.y > bottom && wantPos.x < right && wantPos.x > left);

        return wantPos;
    }

}
