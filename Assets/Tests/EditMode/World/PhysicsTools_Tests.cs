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
        Assert.IsTrue((point.x >= -1 && point.x <= 1), "X Value passes");
        Assert.IsTrue((point.y >= -1 && point.y <= 1), "Y Value passes");
        Assert.IsTrue((point.z >= -1 && point.z <= 1), "Z Value passes");
    }

    [Test]
    public void GetBoundsCorners()
    {
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(10, 10, 10));
        Vector3[] points = PhysicsTools.GetBoundsCorners(bounds);
        Assert.IsTrue(points.GetType() == typeof(Vector3[]), "Type passes");
        Assert.IsTrue(points.Length == 8, "Length passes");
        Assert.IsTrue(points[0].x == -5f, "bounds.min.x Value passes");
        Assert.IsTrue(points[1].z == 5f, "bounds.max.z Value passes");
    }

    [Test]
    public void GetBoundsLocal()
    {
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(10, 10, 10));
        Vector3 min = PhysicsTools.GetBoundsLocalMin(bounds);
        Assert.IsTrue(min.GetType() == typeof(Vector3), "Type passes");
        Assert.IsTrue(min == new Vector3(-5f, -5f, -5f), "min Value passes");

        Vector3 max = PhysicsTools.GetBoundsLocalMax(bounds);
        Assert.IsTrue(max.GetType() == typeof(Vector3), "Type passes");
        Assert.IsTrue(max == new Vector3(5f, 5f, 5f), "max Value passes");
    }

    [Test]
    public void GetBoundsFarPoints_X()
    {
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(10, 10, 10));
        Vector3[] points = PhysicsTools.GetBoundsFarPoints(bounds, new Vector3(1, 0, 0));
        Assert.IsTrue(points.GetType() == typeof(Vector3[]), "Type passes");
        Assert.IsTrue(points[0] == new Vector3(-5f, 0, 0), "min Value passes");
        Assert.IsTrue(points[1] == new Vector3(5f, 0, 0), "max Value passes");
    }
    [Test]
    public void GetBoundsFarPoints_Y()
    {
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(10, 10, 10));
        Vector3[] points = PhysicsTools.GetBoundsFarPoints(bounds, new Vector3(0, 1, 0));
        Assert.IsTrue(points.GetType() == typeof(Vector3[]), "Type passes");
        Assert.IsTrue(points[0] == new Vector3(0, -5f, 0), "min Value passes");
        Assert.IsTrue(points[1] == new Vector3(0, 5f, 0), "max Value passes");
    }


}
