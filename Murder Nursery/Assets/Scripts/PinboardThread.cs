using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PinboardThread : MonoBehaviour
{
    public Sprite lineImage;
    public GameObject pointA;
    public GameObject pointB;
    private float graphScale = 1;
    private float lineWidth = 10;
    public float offsetX;
    public float offsetY;
    
    public void MakeLine(float ax, float ay, float bx, float by, Color col)
    {
        GameObject NewObj = new GameObject();
        NewObj.name = "line from " + ax + " to " + bx;
        Image NewImage = NewObj.AddComponent<Image>();
        NewImage.sprite = lineImage;
        NewImage.color = col;
        RectTransform rect = NewObj.GetComponent<RectTransform>();
        rect.SetParent(transform);
        rect.localScale = Vector3.one;

        Vector3 a = new Vector3(ax *1.5f +offsetX, ay *1.5f +offsetY, 0);
        Vector3 b = new Vector3(bx *1.5f +offsetX , by *1.5f +offsetY, 0);


        rect.localPosition = (a + b) / 2;
        Vector3 dif = a - b;
        rect.sizeDelta = new Vector3(dif.magnitude, lineWidth);
        rect.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.zero;
    }
}
