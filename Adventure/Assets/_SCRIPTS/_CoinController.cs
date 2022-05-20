using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _CoinController : MonoBehaviour
{
    [SerializeField] private int coins;

    public Text coinText;
    void Start()
    {
        coinText.text = coins.ToString();
    }
    public void AddCoin(int count)
    {
        coins += count;
        coinText.text = coins.ToString();
    }

}
