using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SneakawayUtilities;

public class StringTools_Tests
{

	/////////////////////////////////
	//////////// FORMAT /////////////
	/////////////////////////////////

	[Test]
	public void FormatZerosInt()
	{
		string val = StringTools.FormatZeros(99, "000");
		Assert.IsTrue(val.GetType() == typeof(string), "Type passes");
		Assert.IsTrue(val.Length == 3, "Value passes");
	}
	[Test]
	public void FormatZerosFloat()
	{
		string val = StringTools.FormatZeros(.1f, "0000");
		Assert.IsTrue(val.GetType() == typeof(string), "Type passes");
		Assert.IsTrue(val.Length == 4, "Value passes");
	}


	/////////////////////////////////
	/////////// CONVERT /////////////
	/////////////////////////////////

	[Test]
	public void LinesToList()
	{
		// setup
		string str = "hello\nworld\n!";
		List<string> val = StringTools.LinesToList(str);
		// check
		Assert.IsTrue(val.GetType() == typeof(List<string>), "Type passes");
		Assert.IsTrue(val.Count == 3, "Length passes");
		Assert.IsTrue(val[2] == "!", "Value passes");
	}

	[Test]
	public void StringToVector3()
	{
		// setup
		string str = "(1,2f,3.0f)";
		Vector3 val = StringTools.StringToVector3(str);
		// check
		Assert.IsTrue(val.GetType() == typeof(Vector3), "Type passes");
		Debug.Log(val);
		Assert.IsTrue(val.x == 1f, "Value passes");
	}



}
