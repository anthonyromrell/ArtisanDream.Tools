using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CoinCollection : ScriptableObject
{
    public List<Coin> coinList;

    
    public void AddCoin(Coin coinObj)
    {
        if (!coinList.Contains(coinObj))
        {
            coinList.Add(coinObj);
        }
    }

    public void UseCoin()
    {
        coinList[0].Spend();
        coinList.RemoveAt(0);
    }

    public void UseCoinWithValue(int value)
    {
        var number = 5;
        for (var i = 0; i < coinList.Count; i++)
        {
            var coin = coinList[i];
            if (coin.value > number)
            {
                coin.Spend();
                coinList.Remove(coin);
            }
        }
    }

    public void UseAllCoins()
    {
        foreach (var coin in coinList)
        {
            coin.Spend();
        }
        coinList.Clear();
    }

    public void UpgradeAllCoins(int value)
    {
        foreach (var coin in coinList)
        {
            coin.value = value;
        }
    }
}
