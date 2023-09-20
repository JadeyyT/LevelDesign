using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Waypoint : MonoBehaviour
{
    public Image img;
    public Transform target;
    public Transform target2;
    public Transform target3;
    public Text distance1;
    public Text distance2;
    public Text distance3;

    void Update()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            //Target is behind player
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
        distance1.text = ((int) Vector3.Distance(target.position, transform.position)).ToString() + "m";
        distance2.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
        distance3.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";


    }
}