using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private double _clickCount = 0;

    public static GameManager Singleton;

    private void Awake()
    {
        Singleton = this;
    }
}
