using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

// Local code for creep system
public class CreepFactory : NetworkBehaviour
{

    #region Object Pool declarations
    private ObjectPool<SimpleCreep> simpleCreepPool;
    #endregion

    private Dictionary<uint, Poolable> activeCreeps;
    private Game game;
    
    public void CreateCreep(CreepNo creepNo, int creator, uint creepId)
    {
        switch (creepNo)
        {
            case CreepNo.SimpleCreep:
                var creep = simpleCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero);
                activeCreeps.Add(creepId, creep);
                return;
            default:
                Debug.Log("Problem creating creep in factory.");
                return;
        }
    }
    
    public void RecallCreep(uint creepId)
    {
        Poolable creep;
        activeCreeps.TryGetValue(creepId, out creep);
        if (creep != null)
        {
            creep.Recall();
            activeCreeps.Remove(creepId);
        }
    }

    // Use this for initialization
    void Start()
    {
        // Would be really cool, but won't work in Unity due to Generics and MB's not playing nice.
        //Type objectPoolType = typeof(ObjectPool<>);
        //foreach (Type t in creepTypes)
        //{
        //    objectPoolType.MakeGenericType(t.MakeGenericType());
        //    simpleCreepPool = gameObject.GetComponent<ObjectPool<SimpleCreep>>();
        //    activeCreeps = new Dictionary<uint, IPoolable>();
        //}
        this.game = FindObjectOfType<Game>();

        var DummyGameObject = Instantiate(Resources.Load("dgo")) as GameObject;
        #region Object Pool instantiation
        simpleCreepPool = new ObjectPool<SimpleCreep>(DummyGameObject);
        #endregion
        activeCreeps = new Dictionary<uint, Poolable>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
