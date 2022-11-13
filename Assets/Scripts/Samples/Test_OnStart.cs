using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SneakawayUtilities;

public class Test_OnStart : MonoBehaviour
{
	public BoxCollider c;
	public Bounds b;
	public Vector3 p;
	public GameObject prefab;

    void Start()
    {
        // Debug.Log(Test_StaticClass.greeting);

		InstantiateInBounds();
    }


	void InstantiateInBounds()
	{
		c = GetComponent<BoxCollider>();
		b = c.bounds;
		p = Math.RandomPointInBounds(b);
		Instantiate(prefab, p, Quaternion.identity);
	}

}
