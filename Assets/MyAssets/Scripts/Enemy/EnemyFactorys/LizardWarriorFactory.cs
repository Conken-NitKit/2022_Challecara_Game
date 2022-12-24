using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardWarriorFactory : EnemyFactory
{
    private ArrayList enemys = new ArrayList();
    protected override GameObject AddEnemyComponent(GameObject obj) {
        return obj;
    }

    protected override void RegisterEnemy(Enemy lizardWarrior) {
        enemys.Add( ((LizardWarrior)lizardWarrior) );
    }

    public override ArrayList GetEnemys() {
        return enemys;
    }
}
