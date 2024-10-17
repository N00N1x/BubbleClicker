using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private double _clickCount = 0;
    [SerializeField] private double _clcikMultiplier = 1;

    public static GameManager Singleton;

    private void Awake()
    {
        Singleton = this;
    }

    public void OnClick()
    {
        _clickCount += _clcikMultiplier;

        print(_clickCount);
    }
}
