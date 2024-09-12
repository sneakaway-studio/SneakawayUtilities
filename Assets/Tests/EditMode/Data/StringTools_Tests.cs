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



	[Test]
	public void LinesToList()
	{
		string str = "hello\nworld\n!";
		List<string> val = StringTools.LinesToList(str);
		Assert.IsTrue(val.GetType() == typeof(List<string>), "Type passes");
		Debug.Log(val);
		Assert.IsTrue(val.Count == 3, "Length passes");
		Assert.IsTrue(val[2] == "!", "Value passes");
	}


}
