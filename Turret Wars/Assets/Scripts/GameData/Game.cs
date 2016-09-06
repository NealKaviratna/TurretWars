using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public List<Player> Players = new List<Player>();
    public Battlezone battlezone1;
    public Battlezone battlezone2;

    public CreepController cc;

    public Player GetPlayerByID(int id)
    {
        return Players[id];
    }

    public int addPlayer(Player player)
    {
        Players.Add(player);
        if (Players.Count == 1)
        {
            player.battlezone = battlezone1;
            player.targetBattlezone = battlezone2;
            player.CreepController = cc;
        }
        else
        {
            player.battlezone = battlezone2;
            player.targetBattlezone = battlezone1;
            player.CreepController = cc;

            cc.GameStart();
        }
        return Players.Count;
    }
}
