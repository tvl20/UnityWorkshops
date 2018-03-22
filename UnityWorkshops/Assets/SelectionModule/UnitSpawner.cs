using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour 
{
	private UnitFactory factory;

	private bool isBuilding = false;

	void Update () 
	{
		if(isBuilding)
		{
			if(Input.GetMouseButton(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hitObject;
				if(Physics.Raycast(ray, out hitObject))
				{
					Cell hitCell = hitObject.collider.GetComponentInParent<Cell>();
					if (hitCell != null)
					{
						factory.SpawnUnit(hitCell);
						ExitSpawnMode();
					}
				}
			}
		}
	}

	void OnDisable()
	{
		ExitSpawnMode();
	}

	public void ExitSpawnMode()
	{
		isBuilding = false;
	}

	public void EnterSpawnMode(UnitFactory factory)
	{
		this.factory = factory;
		isBuilding = true;
	}
}
