using UnityEngine;

namespace Assets.product.Source.MeteorGenerator
{
    public class MeteorGenerater2 : MeteorGeneraterBase
    {
        public MeteorGenerater2()
        {
            _meteor = Resources.Load<GameObject>("Prefabs/Asteroid_Grey2");
        }

        public override void Generate()
        {
            if (_enemyintervalTime >= (0.8f / StarfighterControl.Z_Speed))
            {
                _enemyintervalTime = 0;
                GenerateMeteor(_meteor);
            }
        }
    }
}
