using UnityEngine;

public class Spikes : SpecialTile
{
    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public override void DoAction()
    {
        spriteRenderer.sprite = enabledSprite;
    }
    public override void DoOther()
    {
        spriteRenderer.sprite = disabledSprite;
    }
}
