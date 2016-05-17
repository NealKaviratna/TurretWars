using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

// Will exist on clients
public class CreepFactory : MonoBehaviour {

    #region Object Pool declarations
    private ObjectPool<SimpleCreep> simpleCreepPool;
    #endregion

    private Dictionary<uint, IPoolable> activeCreeps;

    public IPoolable CreateCreep (CreepNo creepNo, Player creator, uint creepId)
    {
        // Debug.Log("Creating: " + creepNo);
        switch (creepNo)
        {
            case CreepNo.SimpleCreep:
                var creep = simpleCreepPool.Create(creator, creepId);
                activeCreeps.Add(creepId, creep);
                return creep;
            default:
                Debug.Log("Problem creating creep in factory.");
                return null;
        }
    }

    public void RecallCreep(uint creepId)
    {
        IPoolable creep;
        activeCreeps.TryGetValue(creepId, out creep);
        if (creep != null)
        {
            creep.Recall();
            activeCreeps.Remove(creepId);
        }
    }

    // Use this for initialization
    void Start () {
        // Would be really cool, but won't work in Unity due to Generics and MB's not playing nice.
        //Type objectPoolType = typeof(ObjectPool<>);
        //foreach (Type t in creepTypes)
        //{
        //    objectPoolType.MakeGenericType(t.MakeGenericType());
        //    simpleCreepPool = gameObject.GetComponent<ObjectPool<SimpleCreep>>();
        //    activeCreeps = new Dictionary<uint, IPoolable>();
        //}
        
        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        #region Object Pool instantiation
        simpleCreepPool = new ObjectPool<SimpleCreep>(DummyGameObject);
        #endregion
        activeCreeps = new Dictionary<uint, IPoolable>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
