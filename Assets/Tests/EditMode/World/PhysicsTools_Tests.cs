using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SneakawayUtilities;

public class PhysicsTools_Tests
{



    /////////////////////////////////
    /////////// BOUNDS //////////////
    /////////////////////////////////

    [Test]
    public void RandomPointInBounds()
    {
        // Create bounding box centered at the origin
        Bounds b = new Bounds(new Vector3(0, 0, 0), new Vector3(2, 2, 2));
        // Debug.Log(b.size.x);
        // The total size of the box. This is always twice as large as the extents.
        Assert.IsTrue((b.size.x == 2), "Bounds size passes");
        // The extents of the Bounding Box. This is always half of the size of the Bounds.
        Assert.IsTrue((b.extents.x == 1), "Bounds extents passes");
        Vector3 point = PhysicsTools.RandomPointInBounds(b);
        // Debug.Log(point);
        Assert.IsTrue(point.GetType() == typeof(Vector3), "Type passes");
        Assert.IsTrue((point.x >= -1 && point.x <= 1), "X passes");
        Assert.IsTrue((point.y >= -1 && point.y <= 1), "Y passes");
        Assert.IsTrue((point.z >= -1 && point.z <= 1), "Z passes");
    }

    [Test]
    public void GetBoundsCorners()
    {
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(10, 10, 10));
        Vector3[] points = PhysicsTools.GetBoundsCorners(bounds);
        Assert.IsTrue(points.GetType() == typeof(Vector3[]), "Type passes");
        Assert.IsTrue(points.Length == 8, "Length passes");
        Assert.IsTrue(points[0].x == -5f, "bounds.min.x passes");
        Assert.IsTrue(points[1].z == 5f, "bounds.max.z passes");
    }



}
