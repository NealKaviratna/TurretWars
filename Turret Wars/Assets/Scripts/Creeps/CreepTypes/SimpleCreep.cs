using UnityEngine;
using System.Collections;
using System;

public class SimpleCreep : Poolable {

    #region Creep
    public BoxCollider spawnzone;
    public Transform target;

    private float maxHp = 100.0f;
    private uint creepId;
    private Player creator;

    private float hp = 100.0f;
    private float speed = 0.1f;
    private bool inUse = false;
    private CreepNo creepNo = CreepNo.SimpleCreep;

    private CreepController controller;
    #endregion

    #region IPoolable overrides
    public override uint ObjectId
    {
        get { return creepId; }
    }

    public override bool InUse
    {
        get { return inUse; }
    }

    public override Poolable Create(Player creator, uint creepId, Vector3 position)
    {
        this.spawnzone = creator.targetBattlezone.CreepSpawner;
        this.target = creator.targetBattlezone.Nexus.transform;
        this.creepId = creepId;

        transform.position = Util.GetPointInCollider(creator.TargetBattlezone.CreepSpawner);
        this.hp = maxHp;
        this.gameObject.SetActive(true);
        this.inUse = true;
        return this;
    }

    public override void Die()
    {
        controller.CmdRecallCreep(this.creepId);
        //this.gameObject.SetActive(false);
        //this.inUse = false;
    }

    public override void Recall()
    {
        this.gameObject.SetActive(false);
        this.inUse = false;
    }

    public override string ToString()
    {
        return "SimpleCreep";
    }
    #endregion

    #region Monobehaviour
    void Awake()
    {
        controller = GameObject.Find("CreepController").GetComponent<CreepController>();
        this.Recall();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }
    #endregion
}
