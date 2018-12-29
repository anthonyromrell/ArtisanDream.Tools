using UnityEngine;

[CreateAssetMenu(menuName = "Store/Coins")]
public class IAPCoins : InAppPurchaseBase
{
    public IntData Coin;

    public void BuyCoins()
    {
        Coin.Value = Value;
    }
}