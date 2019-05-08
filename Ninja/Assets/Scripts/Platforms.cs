using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(PlatformEffector2D))]
public class Platforms : MonoBehaviour
{
    public static Color RED_LAYER = Color.red, BLUE_LAYER = Color.blue;

    SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

   public void ChangeLayer(int layer)
   {
       if (layer == LayerMask.NameToLayer("Red"))
       {
           _renderer.color = RED_LAYER;
       
       }
       if (layer == LayerMask.NameToLayer("Blue"))
       {
           _renderer.color = BLUE_LAYER;
       }

       
       gameObject.layer = layer;
   }
}
