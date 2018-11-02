using UnityEngine;

namespace Assets.product.Source.MeteorGenerator
{
    public class MeteorGenerater4 : MeteorGeneraterBase
    {
        public MeteorGenerater4()
        {
            _meteor = Resources.Load<GameObject>("Prefabs/AsteroidRocky_Blue2");
        }

        public override void Generate()
        {
            if (_enemyintervalTime >= (0.4f / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= 2.5)
            {
                _enemyintervalTime = 0;
                GenerateMeteor(_meteor);
            }
        }
    }
}
