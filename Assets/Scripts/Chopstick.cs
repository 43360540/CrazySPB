using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Chopstick : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _triggerPoint;
    [SerializeField] private Vector2 _triggerSize;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private SpearedSPB _spawner;
    [SerializeField] private int _lifePoints;

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

        if (poked.Length <= 0)
            DecreaseLifePoint(1);

        foreach (var x in poked)
        {
            _spawner.Spawn();
            Destroy(x.gameObject);
        }
    }

    public void DecreaseLifePoint(int points)
    {
        _lifePoints -= points;
        if (_lifePoints <= 0)
            Time.timeScale = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(_triggerPoint.position, _triggerSize);
    }
}
