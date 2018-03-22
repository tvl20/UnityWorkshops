using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    public Unit Prototype;
    public Map Map;


    public List<ResourceCost> Costs;
    
    public void SpawnUnit(Cell spawnCell)
    {

        bool canAfford = true;
        for (int i = 0; i < Costs.Count; i++)
        {
            if (!Costs[i].CanAfford())
            {
                canAfford = false;
            }
        }
        
        
        if (canAfford)
        {
            for (int i = 0; i < Costs.Count; i++)
            {
                Costs[i].Pay();
            }

            Unit newUnit = Instantiate(Prototype);
        
            newUnit.transform.SetParent(spawnCell.transform, false);
        }
        else
        {
            Debug.Log("Not enough resources!");
        }

    }

    [System.Serializable]
    public class ResourceCost
    {
        public Resource Resource;
        public int Cost;

        public bool CanAfford()
        {
            return Resource.CanAfford(Cost);
        }

        public void Pay()
        {
            Resource.RemoveAmount(Cost);
        }
        
    }
}