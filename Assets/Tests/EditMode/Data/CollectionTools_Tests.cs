using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SneakawayUtilities;

public class CollectionTools_Tests
{

	/////////////////////////////////
	//////////// FORMAT /////////////
	/////////////////////////////////

	public enum Colors { Red, Green, Blue, Yellow };

	[Test]
	[TestCase(Colors.Red, "Red")]
	[TestCase(Colors.Blue, "Blue")]
	public void GetStringFromEnum(Colors color, string expected)
	{
		string val = CollectionTools.GetStringFromEnum(color);
		Assert.IsTrue(val.GetType() == typeof(string), "Type passes");
		Assert.IsTrue(val == expected, "Value passes");
	}

	[Test]
	[TestCase(Colors.Red, 0)]
	[TestCase(Colors.Blue, 2)]
	public void GetEnumFromInt(Colors expected, int index)
	{
		Colors val = CollectionTools.GetEnumFromInt<Colors>(index);
		Assert.IsTrue(val.GetType() == typeof(Colors), "Type passes");
		Assert.IsTrue(val == expected, "Value passes");
	}

	[Test]
	[TestCase(Colors.Red, 0)]
	[TestCase(Colors.Blue, 2)]
	public void GetIntFromEnum(Colors color, int expected)
	{
		int index = CollectionTools.GetIntFromEnum(color);
		Assert.IsTrue(index.GetType() == typeof(int), "Type passes");
		Assert.IsTrue(index == expected, "Value passes");
	}



	/////////////////////////////////
	//////////// LIST<T> ////////////
	/////////////////////////////////


	public class ClassWithProps
	{
		public string slug;
		public ClassWithProps(string _slug)
		{
			slug = _slug;
		}
	}

	[Test]
	public void FindListIndexByPropertyValue()
	{
		// setup
		List<ClassWithProps> list1 = new List<ClassWithProps>
		{
			new ClassWithProps("item1"),
			new ClassWithProps("item2"),
			new ClassWithProps("item3")
		};
		int index = CollectionTools.FindListIndexByPropertyValue(list1, "slug", "item2");
		// check
		Assert.IsTrue(index.GetType() == typeof(int), "Type passes");
		Assert.IsTrue(index == 1, "Value passes");
	}

	[Test]
	public void RemoveAllFromList()
	{
		// setup
		List<string> list1 = new List<string> { "item1", "item2", "item3" };
		List<string> list2 = CollectionTools.RemoveAllFromList(list1);
		// check
		Assert.IsTrue(list2.GetType() == typeof(List<string>), "Type passes");
		Assert.IsTrue(list2.Count == 0, "Length passes");
	}




}
