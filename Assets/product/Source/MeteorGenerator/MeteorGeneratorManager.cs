using System.Collections.Generic;
using UnityEngine;

namespace Assets.product.Source.MeteorGenerator
{
    public class MeteorGeneratorManager : MonoBehaviour
    {
        private List<IMeteorGenerater> _meteorGeneraters;

        private void Start()
        {
            _meteorGeneraters = new List<IMeteorGenerater>
            {
                new MeteorGenerater1(),
                new MeteorGenerater2(),
                new MeteorGenerater3(),
                new MeteorGenerater4(),
                new MeteorGenerater5(),
                new MeteorGenerater6()
            };
        }

        private void Update()
        {
            foreach (var meteorGenerater in _meteorGeneraters)
            {
                meteorGenerater.Generate();
            }
        }

        private void FixedUpdate()
        {
            foreach (var meteorGenerater in _meteorGeneraters)
            {
                meteorGenerater.FixedUpdate();
            }
        }
    }
}