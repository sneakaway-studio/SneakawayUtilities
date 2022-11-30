using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SneakawayUtilities;

public class ColorTools_Tests
{




    /////////////////////////////////
    ///////// RANDOM COLOR //////////
    /////////////////////////////////

    [Test]
    public void RandomColor()
    {
        Color val = ColorTools.RandomColor();
        Assert.IsTrue(val.GetType() == typeof(Color), "Type passes");
        Assert.IsTrue((val.r >= 0 && val.r <= 1), "Value passes");
    }

    /////////////////////////////////
    /////////// EQUALITY ////////////
    /////////////////////////////////

    [Test]
    public void AreEqual()
    {
        bool val = ColorTools.AreEqual(Color.red, Color.red);
        Assert.IsTrue(val.GetType() == typeof(bool), "Type passes");
        Assert.IsTrue(val, "Value passes");
    }
    [Test]
    public void AreEqual_Not()
    {
        bool val = ColorTools.AreEqual(Color.red, Color.blue);
        Assert.IsTrue(val.GetType() == typeof(bool), "Type passes");
        Assert.IsTrue(!val, "Value passes");
    }

}
