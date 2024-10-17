using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private double _clickCount = 0;
    [SerializeField] private double _clcikMultiplier = 1;

    [SerializeField] private TMP_Text _clickCounterTxt;

    public static GameManager Singleton;

    private void Awake()
    {
        Singleton = this;
    }

    public void OnClick()
    {
        _clickCount += _clcikMultiplier;
        UpdateText();
        print(_clickCount);
    }

    public void UpdateText()
    {
        _clickCounterTxt.text = _clickCount.ToString();
    }
}
