using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFactory : EnemyFactory {
    private ArrayList enemys = new ArrayList();
    protected override Enemy CreateEnemy() {
        return new TestEnemy();
    }

    protected override void RegisterEnemy(Enemy testEnemy) {
        enemys.Add( ((TestEnemy)testEnemy) );
    }

    public override ArrayList GetEnemys() {
        return enemys;
    }
}
