using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]

public class SpriteTiler : MonoBehaviour {

    SpriteRenderer sprite;

    // Use this for initialization
    void Awake()
    {
        // Get the current sprite with an unscaled size.
        sprite = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = new Vector2(sprite.bounds.size.x / transform.localScale.x, sprite.bounds.size.y / transform.localScale.y);

        // Generate a child prefab of the sprite renderer
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        childPrefab.transform.position = transform.position;
        childSprite.sprite = sprite.sprite;

        // Loop through and spit out repeated tiles
        GameObject child;
        for (int i = 1, j = (int)Mathf.Round(sprite.bounds.size.x); i < j; i++) {
            child = Instantiate(childPrefab) as GameObject;
            child.transform.position = transform.position + (new Vector3(spriteSize.x, 0, 0) * i);
            child.transform.parent = transform;
        }

        // Set the parent last on the prefab to prevent transform displacement
        childPrefab.transform.parent = transform;

        // Disable the currenty existing sprite component since it's now a repeated image.
        sprite.enabled = false;
    }
}
