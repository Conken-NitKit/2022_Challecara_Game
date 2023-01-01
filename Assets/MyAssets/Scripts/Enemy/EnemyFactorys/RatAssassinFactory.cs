using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RatAssassinのFactoryクラス
/// </summary>
public class RatAssassinFactory : EnemyFactory
{
    private ArrayList enemys = new ArrayList();
    protected override GameObject AddEnemyComponent(GameObject obj) {
        return obj;
    }

    protected override void RegisterEnemy(Enemy ratAssassin) {
        enemys.Add( ((RatAssassin)ratAssassin) );
    }

    public override ArrayList GetEnemys() {
        return enemys;
    }
}
