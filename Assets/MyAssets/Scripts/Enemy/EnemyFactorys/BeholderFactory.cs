using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderFactory : EnemyFactory
{
    private ArrayList enemys = new ArrayList();
    protected override GameObject AddEnemyComponent(GameObject obj) {
        return obj;
    }

    protected override void RegisterEnemy(Enemy beholder) {
        enemys.Add( ((Beholder)beholder) );
    }

    public override ArrayList GetEnemys() {
        return enemys;
    }
}
