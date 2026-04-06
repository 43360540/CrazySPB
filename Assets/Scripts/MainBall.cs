using UnityEngine;
using URandom = UnityEngine.Random;

public class MainBall : MonoBehaviour
{
    [SerializeField] private Transform _center;

    public Transform Center => _center;

    private void OnDestroy()
    {
        SpawnAndThrow.Instance.SapwnMain();
    }
}