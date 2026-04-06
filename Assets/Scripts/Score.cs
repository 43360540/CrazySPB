using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    public void FixedUpdate()
    {
        _score.text = SPBSpawner.Instance.Targets.Count.ToString();
    }
}
