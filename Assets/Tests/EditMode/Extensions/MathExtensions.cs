using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SneakawayUtilities;

public class MathExtensions
{

    /////////////////////////////////
    ///////////// TYPES /////////////
    /////////////////////////////////

    [Test]
    public void Range()
    {
        Math.Range val = new Math.Range(0, 1);
        Assert.AreEqual(0f, val.min, "Range min passes");
        Assert.AreEqual(1f, val.max, "Range max passes");
    }


    /////////////////////////////////
    ////////// RANDOM INT ///////////
    /////////////////////////////////

    [Test]
    public void RandomInt_Int()
    {
        int val = Math.RandomInt(0, 1);
        Assert.IsTrue(val.GetType() == typeof(int), "Type passes");
        Assert.IsTrue((val >= 0 && val <= 1), "Value passes");
    }
    [Test]
    public void RandomInt_Float()
    {
        int val = Math.RandomInt(0f, 1f);
        Assert.IsTrue(val.GetType() == typeof(int), "Type passes");
        Assert.IsTrue((val >= 0 && val <= 1), "Value passes");
    }

    /////////////////////////////////
    ///////// RANDOM FLOAT //////////
    /////////////////////////////////

    [Test]
    public void RandomFloatFromRange()
    {
        float val = Math.RandomFloatFromRange(new Math.Range(3f, 4f));
        Assert.IsTrue(val.GetType() == typeof(float), "Type passes");
        Assert.IsTrue((val >= 3 && val <= 4), "Value passes");
    }
    [Test]
    public void RandomFloatFromVector2()
    {
        float val = Math.RandomFloatFromVector2(new Vector2(3f, 4f));
        Assert.IsTrue(val.GetType() == typeof(float), "Type passes");
        Assert.IsTrue((val >= 3 && val <= 4), "Value passes");
        Assert.IsTrue(!(val < 3 && val > 4), "Value passes");
    }

    /////////////////////////////////
    //////// RANDOM VECTOR3 /////////
    /////////////////////////////////

    [Test]
    public void RandomVector3FromRange_3Ranges()
    {
        Math.Range testRange = new Math.Range(3f, 4f);
        Vector3 val = Math.RandomVector3FromRange(testRange, testRange, testRange);
        Assert.IsTrue(val.GetType() == typeof(Vector3), "Type passes");
        Assert.IsTrue((val.x >= 3f && val.x <= 4f), "x passes");
        Assert.IsTrue((val.y >= 3f && val.y <= 4f), "y passes");
        Assert.IsTrue((val.z >= 3f && val.z <= 4f), "z passes");
    }
    [Test]
    public void RandomVector3FromRange_1Range()
    {
        Math.Range testRange = new Math.Range(0f, 100f);
        Vector3 val = Math.RandomVector3FromRange(testRange);
        Assert.IsTrue(val.GetType() == typeof(Vector3), "Type passes");
        Assert.IsTrue((val.x >= 0 && val.x <= 100), "x passes");
        Assert.IsTrue((val.y >= 0 && val.y <= 100), "y passes");
        Assert.IsTrue((val.z >= 0 && val.z <= 100), "z passes");
    }

    /////////////////////////////////
    /////// RANDOM QUATERNION ///////
    /////////////////////////////////

    [Test]
    public void RandomQuaternion()
    {
        Quaternion q = Math.RandomQuaternion();
        Assert.IsTrue(q.GetType() == typeof(Quaternion), "Type passes");

        // check that it is within the range
        Vector3 angles = q.eulerAngles;
        Assert.IsTrue((angles.x >= 0 && angles.x <= 360), "x passes");
        Assert.IsTrue((angles.y >= 0 && angles.y <= 360), "y passes");
        Assert.IsTrue((angles.z >= 0 && angles.z <= 360), "z passes");
    }



    /////////////////////////////////
    //////// RANDOM LIST<T> /////////
    /////////////////////////////////

    [Test]
    public void RandomListIndex()
    {
        List<int> list = new List<int>();
        list.Add(123);
        int val = list.RandomListIndex();
        Assert.IsTrue(val.GetType() == typeof(int), "Type passes");
        Assert.IsTrue((val == 0), "Value passes");
    }

    [Test]
    public void RandomListValue()
    {
        List<int> list = new List<int>();
        list.Add(123);
        int val = list.RandomListValue();
        Assert.IsTrue(val.GetType() == typeof(int), "Type passes");
        Assert.IsTrue((val == 123), "Value passes");
    }


    /////////////////////////////////
    //////// RANDOM <space> /////////
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
        Vector3 point = Math.RandomPointInBounds(b);
		// Debug.Log(point);
        Assert.IsTrue(point.GetType() == typeof(Vector3), "Type passes");
        Assert.IsTrue((point.x >= -1 && point.x <= 1), "X passes");
        Assert.IsTrue((point.y >= -1 && point.y <= 1), "Y passes");
        Assert.IsTrue((point.z >= -1 && point.z <= 1), "Z passes");
    }




}