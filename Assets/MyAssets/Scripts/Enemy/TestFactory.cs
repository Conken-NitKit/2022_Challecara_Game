using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFactory : EnemyFactory {
    private ArrayList enemys = new ArrayList();
    protected override GameObject CreateEnemy(GameObject obj) {
        var addComponent = obj.AddComponent(typeof(TestEnemy))as TestEnemy;
        return obj;
    }

    protected override void RegisterEnemy(Enemy testEnemy) {
        enemys.Add( ((TestEnemy)testEnemy) );
    }

    public override ArrayList GetEnemys() {
        return enemys;
    }
    
}
