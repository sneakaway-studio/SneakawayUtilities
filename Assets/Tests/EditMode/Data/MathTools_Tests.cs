using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SneakawayUtilities;

public class MathTools_Tests
{

    /////////////////////////////////
    ///////////// TYPES /////////////
    /////////////////////////////////

    [Test]
    public void Range()
    {
        MathTools.Range val = new MathTools.Range(0, 1);
        Assert.AreEqual(0f, val.min, "Range min passes");
        Assert.AreEqual(1f, val.max, "Range max passes");
    }


    /////////////////////////////////
    //////// RANDOM CHANCE //////////
    /////////////////////////////////

    [Test]
    public void RandomChance_Bool()
    {
        bool val = MathTools.RandomChance(0.5f);
        Assert.IsTrue(val.GetType() == typeof(bool), "Type passes");
        // 1 in a million
        bool val1 = MathTools.RandomChance(0.999999f);
        Assert.IsTrue(val1 == true, "Value passes");
        bool val2 = MathTools.RandomChance(0.000001f);
        Assert.IsTrue(val2 == false, "Value passes");
    }


    /////////////////////////////////
    ////////// RANDOM INT ///////////
    /////////////////////////////////

    [Test]
    public void RandomInt_Int()
    {
        int val = MathTools.RandomInt(0, 1);
        Assert.IsTrue(val.GetType() == typeof(int), "Type passes");
        Assert.IsTrue((val >= 0 && val <= 1), "Value passes");
    }
    [Test]
    public void RandomInt_Float()
    {
        int val = MathTools.RandomInt(0f, 1f);
        Assert.IsTrue(val.GetType() == typeof(int), "Type passes");
        Assert.IsTrue((val >= 0 && val <= 1), "Value passes");
    }


    /////////////////////////////////
    ///////// RANDOM FLOAT //////////
    /////////////////////////////////

    [Test]
    public void RandomFloat()
    {
        float val = MathTools.RandomFloat();
        Assert.IsTrue(val.GetType() == typeof(float), "Type passes");
        Assert.IsTrue((val >= 0 && val <= 1), "Value passes");
    }
    [Test]
    public void RandomFloatFromRange()
    {
        float val = MathTools.RandomFloatFromRange(new MathTools.Range(3f, 4f));
        Assert.IsTrue(val.GetType() == typeof(float), "Type passes");
        Assert.IsTrue((val >= 3 && val <= 4), "Value passes");
    }
    [Test]
    public void RandomFloatFromVector2()
    {
        float val = MathTools.RandomFloatFromVector2(new Vector2(3f, 4f));
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
        MathTools.Range testRange = new MathTools.Range(3f, 4f);
        Vector3 val = MathTools.RandomVector3FromRange(testRange, testRange, testRange);
        Assert.IsTrue(val.GetType() == typeof(Vector3), "Type passes");
        Assert.IsTrue((val.x >= 3f && val.x <= 4f), "x passes");
        Assert.IsTrue((val.y >= 3f && val.y <= 4f), "y passes");
        Assert.IsTrue((val.z >= 3f && val.z <= 4f), "z passes");
    }
    [Test]
    public void RandomVector3FromRange_1Range()
    {
        MathTools.Range testRange = new MathTools.Range(0f, 100f);
        Vector3 val = MathTools.RandomVector3FromRange(testRange);
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
        Quaternion q = MathTools.RandomQuaternion();
        Assert.IsTrue(q.GetType() == typeof(Quaternion), "Type passes");

        // check that it is within the range
        Vector3 angles = q.eulerAngles;
        Assert.IsTrue((angles.x >= 0 && angles.x <= 360), "x passes");
        Assert.IsTrue((angles.y >= 0 && angles.y <= 360), "y passes");
        Assert.IsTrue((angles.z >= 0 && angles.z <= 360), "z passes");
    }
    [Test]
    public void RandomQuaternion_Range()
    {
        Quaternion q = MathTools.RandomQuaternion(
            new MathTools.Range(0f, 10f),
            new MathTools.Range(0f, 20f),
            new MathTools.Range(0f, 30f)
        );
        Assert.IsTrue(q.GetType() == typeof(Quaternion), "Type passes");

        // check that it is within the range
        Vector3 angles = q.eulerAngles;
        Assert.IsTrue((angles.x >= 0 && angles.x <= 10), "x passes");
        Assert.IsTrue((angles.y >= 0 && angles.y <= 20), "y passes");
        Assert.IsTrue((angles.z >= 0 && angles.z <= 30), "z passes");
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
        Vector3 point = MathTools.RandomPointInBounds(b);
        // Debug.Log(point);
        Assert.IsTrue(point.GetType() == typeof(Vector3), "Type passes");
        Assert.IsTrue((point.x >= -1 && point.x <= 1), "X passes");
        Assert.IsTrue((point.y >= -1 && point.y <= 1), "Y passes");
        Assert.IsTrue((point.z >= -1 && point.z <= 1), "Z passes");
    }




}
