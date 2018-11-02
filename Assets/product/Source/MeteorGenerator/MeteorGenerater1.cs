using UnityEngine;

namespace Assets.product.Source.MeteorGenerator
{
    public class MeteorGenerater1 : MeteorGeneraterBase
    {
        public MeteorGenerater1()
        {
            _meteor = Resources.Load<GameObject>("Prefabs/Asteroid_Brown1");
        }

        public override void Generate()
        {
            if (_enemyintervalTime >= (0.4f / StarfighterControl.Z_Speed))
            {
                _enemyintervalTime = 0;
                GenerateMeteor(_meteor);
                GenerateMeteor(_meteor);
            }
        }
    }
}
