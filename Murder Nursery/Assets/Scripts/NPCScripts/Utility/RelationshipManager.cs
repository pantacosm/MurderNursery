using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager : MonoBehaviour
{
    public int coolMeter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoolMeter(int relationship, int change) //Updates a certain relationship trait, +vly or -vly
    {
        relationship += change;
        print("Coolness now at " + relationship + "! Rock On!!!");
    }
}
