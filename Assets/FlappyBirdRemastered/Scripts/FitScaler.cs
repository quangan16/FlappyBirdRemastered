using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class FitScaler : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private float camHeight;
    [SerializeField] private float camWidth;
    [SerializeField] private GameObject asset;
   [SerializeField] private SpriteRenderer backgroundSprite;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        backgroundSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Start()
    {
        
     
       
    }

    void Update()
    {
      
    }

    void Fit()
    {
         camHeight = cam.orthographicSize * 2.0f;
         camWidth = camHeight * cam.aspect;
        
        float spriteWidth = backgroundSprite.sprite.bounds.size.x;
        float spriteHeight = backgroundSprite.sprite.bounds.size.y;

        float scaleX = camWidth / spriteWidth;
        float scaleY = camHeight / spriteHeight;

        transform.localScale = new Vector3(scaleX, scaleY, 1);
    }
}
