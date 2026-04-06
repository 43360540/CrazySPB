using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Spear : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _triggerPoint;
    [SerializeField] private Vector2 _triggerSize;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private SPBSpawner _spawner;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Attack");
        }
    }

    public void Poke()
    {
        var poked =
            Physics2D.OverlapBoxAll(_triggerPoint.position, _triggerSize, 0f, _targetLayer);

        foreach (var x in poked)
        {
            _spawner.Spawn();
            Destroy(x.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(_triggerPoint.position, _triggerSize);
    }
}
