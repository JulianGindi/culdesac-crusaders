using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using RAIN.Navigation;

[RAINAction]
public class AttackPlayer : RAINAction
{
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		// First we will retrieve the player we want to attack
		GameObject playerToAttack = ai.WorkingMemory.GetItem<GameObject>("foundPlayer");

		ai.Body.gameObject.GetComponent<EnemyAttackController>().AttackPlayer(playerToAttack.transform);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }	
}