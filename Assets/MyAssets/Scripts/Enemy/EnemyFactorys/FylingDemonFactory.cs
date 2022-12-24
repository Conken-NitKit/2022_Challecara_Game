using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FylingDemonFactory : EnemyFactory
{
    private ArrayList enemys = new ArrayList();
    protected override GameObject AddEnemyComponent(GameObject obj) {
        return obj;
    }

    protected override void RegisterEnemy(Enemy fylingDemon) {
        enemys.Add( ((FylingDemon)fylingDemon) );
    }

    public override ArrayList GetEnemys() {
        return enemys;
    }
}
