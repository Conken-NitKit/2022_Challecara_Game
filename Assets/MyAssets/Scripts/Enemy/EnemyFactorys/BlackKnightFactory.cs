using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnightFactory : EnemyFactory
{
    private ArrayList enemys = new ArrayList();
    protected override GameObject AddEnemyComponent(GameObject obj) {
        return obj;
    }

    protected override void RegisterEnemy(Enemy blackKnight) {
        enemys.Add( ((BlackKnight)blackKnight) );
    }

    public override ArrayList GetEnemys() {
        return enemys;
    }
}
