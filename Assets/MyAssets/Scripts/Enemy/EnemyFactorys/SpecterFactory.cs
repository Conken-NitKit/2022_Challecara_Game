using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SpecterのFactoryクラス
/// </summary>
public class SpecterFactory : EnemyFactory
{
    private ArrayList enemys = new ArrayList();
    protected override GameObject AddEnemyComponent(GameObject obj) {
        return obj;
    }

    protected override void RegisterEnemy(Enemy specter) {
        enemys.Add( ((Specter)specter) );
    }

    public override ArrayList GetEnemys() {
        return enemys;
    }
}
