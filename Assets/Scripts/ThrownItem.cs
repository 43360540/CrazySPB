using UnityEngine;

public class ThrownItem : MonoBehaviour
{
    [SerializeField] float _speed = 1f;

    private Transform _target;
    private Vector3 _velocity;

    private void Start()
    {
        _velocity = (_target.position - this.transform.position).normalized;
    }

    private void Update()
    {
        this.transform.position += _velocity * Time.deltaTime * _speed;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
