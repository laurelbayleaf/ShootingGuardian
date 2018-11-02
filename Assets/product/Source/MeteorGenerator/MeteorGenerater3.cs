using UnityEngine;

namespace Assets.product.Source.MeteorGenerator
{
    public class MeteorGenerater3 : MeteorGeneraterBase
    {
        public MeteorGenerater3()
        {
            _meteor = Resources.Load<GameObject>("Prefabs/Asteroid_White2");
        }

        public override void Generate()
        {
            if (_enemyintervalTime >= (10.0f / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= 2.2)
            {
                _enemyintervalTime = 0;
                GenerateMeteor(_meteor);
            }
        }
    }
}
