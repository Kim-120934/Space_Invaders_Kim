using UnityEngine;

public class New_Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;

    private SpriteRenderer _spriteRender;

    private int _animationFrame;
    internal int pointValue;

    private void Awake()
    {
        _spriteRender = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime); 
    }
    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }
        _spriteRender.sprite= this.animationSprites[_animationFrame];
    }
    
}
