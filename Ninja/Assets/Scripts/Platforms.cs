using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(PlatformEffector2D))]
public class Platforms : MonoBehaviour
{

    public Color normalColor, player1Color, player2Color;

    [SerializeField]
    private bool autoChangeColor;

    SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = normalColor;
    }

    private void Start()
    {
        if (autoChangeColor) StartCoroutine(AutoChangeColor());
    }

   public void ChangeLayer(int layer)
   {
       if (layer == LayerMask.NameToLayer("Red"))
       {
           _renderer.color = player1Color;
       
       }
       if (layer == LayerMask.NameToLayer("Blue"))
       {
           _renderer.color = player2Color;
       }

       
       gameObject.layer = layer;
   }

   public IEnumerator AutoChangeColor()
   {
       while (true)
       {
           ChangeLayer(gameObject.layer == LayerMask.NameToLayer("Red") ? LayerMask.NameToLayer("Blue") : LayerMask.NameToLayer("Red"));
           yield return new WaitForSeconds(2f);
       }
   }
}
