﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vertSurfaceConfig : MonoBehaviour
{
    private double minAngle { get; set; }
    private double maxAngle { get; set; }
    public double minHeight { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getRandInRange()
    {
        System.Random rng = new System.Random();

        // first generate # between 0 and 1 to indicate if we are doing negative or positive angle
        double maxAgl = this.maxAngle;
        double newAngle;
        double randNegPos = rng.NextDouble();
        if (randNegPos < 0.5)
        {
            maxAgl = -maxAgl;
        }

        if (maxAgl < 0)
        {
            // then calculate the angle between min and max (for negative angle)
            newAngle = rng.NextDouble() * (-this.minAngle - (maxAgl)) + maxAgl;
        }
        else
        {
            // then calculate the angle between min and max (for positive angle)
            newAngle = rng.NextDouble() * (maxAgl - (this.minAngle)) + this.minAngle;
        }

        return (float)newAngle;
    }

    // sets the angle relative to horizontal based on min/max angle params
    // assumes max and min angles in json are positive. Logic takes care of negative angles.
    public void setAngleWithHorizontal()
    {
        // only care about x and z rotation
        Quaternion rotation = this.transform.rotation;
        rotation.x = getRandInRange();
        rotation.z = getRandInRange();
    }

    public void setVertSurfaceHeight()
    {
        Vector3 locScale = this.transform.localScale;
        locScale.y = (float) this.minHeight;
        this.transform.localScale = locScale;
    }

    public void setMinAngle(double angle)
    {
        this.minAngle = angle;
    }

    public void setMaxAngle(double angle)
    {
        this.maxAngle = angle;
    }

    // mainly so player can walk
    public void setMinHeight(double height)
    {
        this.minHeight = height;
    }
}
