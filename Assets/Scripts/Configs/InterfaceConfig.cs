using System.Collections;

using UnityEngine;

[CreateAssetMenu(fileName = "InterfaceConfig", menuName = "Config/Interface")]
public class InterfaceConfig : Config
{
    public Sprite CompleteSliderIcon;

    public override IEnumerator Init()
    {
        yield return null;
    }

}
