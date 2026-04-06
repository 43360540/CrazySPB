using UnityEngine;
using UnityEngine.Events;

public class AnimEventReceiver : MonoBehaviour
{
    [SerializeField] private UnityEvent _animEvent;

    public void AnimeEvent() => _animEvent.Invoke();
}
