using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Battle_State
{
    START,
    PLAYER_TURN,
    ENEMY_TURN,
    WON,
    LOST
}
public class BattleField : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform playerBattleStation;

    public GameObject enemyPrefab;
    public Transform enemyBattleStation;

    public Battle_State BattleState;

    // Start is called before the first frame update
    void Start()
    {
        BattleState = Battle_State.START;
        SetUpBattle();
    }

    // Update is called once per frame
    void SetUpBattle()
    {
        Instantiate(playerPrefab, playerBattleStation);
        Instantiate(enemyPrefab, enemyBattleStation);
    }
}
