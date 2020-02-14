using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Store/Coins")]
public class IapCoins : InAppPurchaseBase
{
    [FormerlySerializedAs("Coin")] public IntData coin;

    public void BuyCoins()
    {
        coin.value = Value;
    }
}