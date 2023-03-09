using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] List<Sprite> explostionEffect;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAnimation(explostionEffect));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayAnimation(List<Sprite> input)
    {
        int idx = 0;

        while (idx < explostionEffect.Count -1 )
        {
            idx++;
            spriteRenderer.sprite = explostionEffect[idx];
            yield return new WaitForSeconds(0.05f);
        }
    }
}
