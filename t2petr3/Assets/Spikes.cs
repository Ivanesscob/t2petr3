using UnityEngine;

public class Spikes : SpecialTile
{
    [SerializeField] private Sprite enabledSprite;
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D collider;
    public override void DoAction()
    {
        spriteRenderer.sprite = enabledSprite;
        collider.enabled = true;
    }
    public override void DoOther()
    {
        spriteRenderer.sprite = disabledSprite;
        collider.enabled = false;
    }
}
