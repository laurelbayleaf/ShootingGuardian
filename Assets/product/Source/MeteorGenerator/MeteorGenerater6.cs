using UnityEngine;

namespace Assets.product.Source.MeteorGenerator
{
    public class MeteorGenerater6 : MeteorGeneraterBase
    {
        public MeteorGenerater6()
        {
            _meteor = Resources.Load<GameObject>("Prefabs/AsteroidRocky_Green5");
        }

        public override void Generate()
        {
            if (_enemyintervalTime >= (10f / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= 3)
            {
                _enemyintervalTime = 0;
                GenerateMeteor(_meteor);
            }
        }
    }
}
