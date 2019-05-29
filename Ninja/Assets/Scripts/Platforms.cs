using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(PlatformEffector2D))]
public class Platforms : MonoBehaviour
{

    public Color normalColor, player1Color, player2Color;

    SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = normalColor;
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
}
