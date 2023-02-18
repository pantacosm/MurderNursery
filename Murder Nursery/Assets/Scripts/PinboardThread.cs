using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PinboardThread : MonoBehaviour
{
    public Sprite lineImage; //Stores the line sprite 
    public GameObject pointA; //The first point of the line
    public GameObject pointB; //The second point of the line
    //private float graphScale = 1; //Scale of the line
    private float lineWidth = 10; // Width of the line
    public float offsetX; //X axis offset
    public float offsetY; //Y axis offset

    public GameObject MakeLine(float ax, float ay, float bx, float by, Color col) //Method creates a line betweeen two evidence pieces on the pinboard
    {
        GameObject NewObj = new GameObject();
        NewObj.name = "line from " + ax + " to " + bx;
        Image NewImage = NewObj.AddComponent<Image>();
        NewImage.sprite = lineImage;
        NewImage.color = col;
        RectTransform rect = NewObj.GetComponent<RectTransform>();
        rect.SetParent(transform);
        rect.localScale = Vector3.one;

        Vector3 a = new Vector3(ax *2f +offsetX, ay *2f +offsetY, 0);
        Vector3 b = new Vector3(bx *2f +offsetX , by *2f +offsetY, 0);


        rect.localPosition = (a + b) / 2;
        Vector3 dif = a - b;
        rect.sizeDelta = new Vector3(dif.magnitude, lineWidth);
        rect.rotation = Quaternion.Euler(new Vector3(0, 0, 180 * Mathf.Atan(dif.y / dif.x) / Mathf.PI));
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.zero;
        return NewObj;
    }
}
