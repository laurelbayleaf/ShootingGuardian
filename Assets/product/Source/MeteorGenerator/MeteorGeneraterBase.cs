using UnityEngine;

namespace Assets.product.Source.MeteorGenerator
{
    public abstract class MeteorGeneraterBase : IMeteorGenerater
    {
        protected GameObject _player;

        protected GameObject _meteor;

        protected const float _randomRange = 30;

        protected float _enemyintervalTime = 0;

        public abstract void Generate();

        protected MeteorGeneraterBase()
        {
            _player = GameObject.Find("SF_Free-Fighter(Clone)");
        }

        public void FixedUpdate()
        {
            _enemyintervalTime += Time.deltaTime;
        }

        protected void GenerateMeteor(GameObject meteor)
        {
            Object.Instantiate(meteor, new Vector3(Random.Range(-_randomRange, _randomRange), Random.Range(-_randomRange, _randomRange), _player.transform.position.z + 1000), Quaternion.identity);
        }
    }
}
