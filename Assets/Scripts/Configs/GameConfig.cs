using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/Game")]
public class GameConfig : Config
{
    public int EnemyCount;
    public int CollectableCount;

    public override IEnumerator Init()
    {
        yield return null;
    }
}
