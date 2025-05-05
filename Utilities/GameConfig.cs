using UnityEngine;

[CreateAssetMenu(menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    //gravity
    public float gravity = -9.81f;
    //enemycount
    public int enemyCount = 5;
    //platformcount
    public int platformCount = 5;
}
