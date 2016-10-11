using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

/// <summary>
/// Local code for Creep System
/// </summary>
public class CreepFactory : NetworkBehaviour
{

    #region Object Pool declarations
    private ObjectPool<WalkerCreep> walkerCreepPool;
    private ObjectPool<TankCreep> tankCreepPool;
    private ObjectPool<FlankCreep> flankCreepPool;
    #endregion

    private Dictionary<uint, Poolable> activeCreeps;
    private Game game;
    
    public void CreateCreep(CreepNo creepNo, int creator, uint creepId)
    {
        BaseCreep creep;
        switch (creepNo)
        {
            case CreepNo.Walker1:
                creep = walkerCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(1);
                break;
            case CreepNo.Walker2:
                creep = walkerCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(2);
                break;
            case CreepNo.Walker3:
                creep = walkerCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(3);
                break;
            case CreepNo.Tank1:
                creep = tankCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(1);
                break;
            case CreepNo.Tank2:
                creep = tankCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(2);
                break;
            case CreepNo.Tank3:
                creep = tankCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(3);
                break;
            case CreepNo.Flank1:
                creep = flankCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(1);
                break;
            case CreepNo.Flank2:
                creep = flankCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(2);
                break;
            case CreepNo.Flank3:
                creep = flankCreepPool.Create(game.GetPlayerByID(creator), creepId, Vector3.zero) as BaseCreep;
                creep.SetLevel(3);
                break;
            default:
                Debug.Log("Problem creating creep in factory.");
                return;
        }
        activeCreeps.Add(creepId, creep);
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
        walkerCreepPool = new ObjectPool<WalkerCreep>(DummyGameObject);
        tankCreepPool = new ObjectPool<TankCreep>(DummyGameObject);
        flankCreepPool = new ObjectPool<FlankCreep>(DummyGameObject);
        #endregion

        activeCreeps = new Dictionary<uint, Poolable>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
