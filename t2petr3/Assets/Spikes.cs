using UnityEngine;

public class Spikes : SpecialTile
{
    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private Sprite disabledSprite;
    public override void DoAction()
    {
        enabled = true;
    }
    public override void DoOther()
    {
        enabled = false;
    }
}
