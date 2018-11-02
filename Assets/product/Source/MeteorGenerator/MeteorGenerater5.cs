using UnityEngine;

namespace Assets.product.Source.MeteorGenerator
{
    public class MeteorGenerater5 : MeteorGeneraterBase
    {
        public MeteorGenerater5()
        {
            _meteor = Resources.Load<GameObject>("Prefabs/AsteroidRocky_Orange5");
        }

        public override void Generate()
        {
            if (_enemyintervalTime >= (5f / StarfighterControl.Z_Speed) && StarfighterControl.Z_Speed >= 2.7)
            {
                _enemyintervalTime = 0;
                GenerateMeteor(_meteor);
            }
        }
    }
}
