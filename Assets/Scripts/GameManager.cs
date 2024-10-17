using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private double _clickCount = 0;
    [SerializeField] private double _clcikMultiplier = 1;

    [SerializeField] private double _convertedCount = 0;

    [SerializeField] private TMP_Text _clickCounterTxt;

    public static GameManager Singleton;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _clickCount = Convert.ToDouble(PlayerPrefs.GetString("ClickCount", "0"));
        UpdateText();

        print ("Loaded!");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("ClickCount", _clickCount.ToString());

        print ("Saved!");
    }

    public void OnClick()
    {
        _clickCount += _clcikMultiplier;
        UpdateText();
        print(_clickCount);
    }

    public void UpdateText()
    {
        if (_clickCount < 1000)
        {
            _clickCounterTxt.text = _clickCount.ToString();
        }

        //Thousand
        else if (_clickCount >= 1000 && _clickCount < 1000000)
        {
            _convertedCount += _clickCount / 1000;

            _clickCounterTxt.text = _convertedCount.ToString("F2") + "K";
        }

        //Million
        else if (_clickCount >= 1000000 && _clickCount < 1000000000)
        {
            _convertedCount += _clickCount / 1000000;

            _clickCounterTxt.text = _convertedCount.ToString("F2") + "M";
        }

        //Billion
        else if (_clickCount >= 1000000000 && _clickCount < 1000000000000)
        {
            _convertedCount += _clickCount / 1000000000;

            _clickCounterTxt.text = _convertedCount.ToString("F2") + "B";
        }

        //Trillion
        else if (_clickCount >= 1000000000000 && _clickCount < 1000000000000000)
        {
            _convertedCount += _clickCount / 1000000000000;

            _clickCounterTxt.text = _convertedCount.ToString("F2") + "T";
        }

        //Quadrillion
        else if (_clickCount >= 1000000000000000 && _clickCount < 1000000000000000000)
        {
            _convertedCount += _clickCount / 1000000000000000;

            _clickCounterTxt.text = _convertedCount.ToString("F2") + "Q";
        }
    }
}
