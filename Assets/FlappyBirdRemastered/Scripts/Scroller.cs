using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage backgroundImg;
    [SerializeField] private RectTransform rectTF;
    [SerializeField] private float scrollSpeed;
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrollParallax();
    }

    public void ScrollParallax()
    {
        backgroundImg.uvRect = new Rect(backgroundImg.uvRect.position + Vector2.right * scrollSpeed * Time.deltaTime, backgroundImg.uvRect.size);
    }
}
