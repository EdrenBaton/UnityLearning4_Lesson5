using System.Collections.Generic;
using Asteroids.EnemyCompositeFactory;
using Asteroids.Object_Pool;
using Newtonsoft.Json;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private const string unitsJson =
            "[{\"Type\":\"Mage\",\"Health\":100},{\"Type\":\"Infantry\",\"Health\":150},{\"Type\":\"Warrior\",\"Health\":50}]";

        [SerializeField] private InspectorDictionary _tmp;

        private void Start()
        {
            PoolServiceLocator.SetPool(new EnemyPool(5));

            var units = JsonConvert.DeserializeObject<List<Unit>>(unitsJson);
            var unitFactory = new CompositeFactory();
            unitFactory.AddFactory(new MageFactory());
            unitFactory.AddFactory(new InfantryFactory());

            foreach (var unit in units)
            {
                unitFactory.CreateUnit(unit, out var newUnit);
            
                Debug.Log(newUnit?.Name ?? "fail");
            }
        } /*

        private void ExamplePool()
        {
            var enemy = PoolServiceLocator.Resolve<EnemyPool>().GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);

            ThreadPool.QueueUserWorkItem(state => Debug.Log("Test"));
        }

        private void ExampleFactory()
        {
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            Enemy.Factory.Create(new Health(100.0f, 100.0f));

            new PlatformFactory().Create(Application.platform);

            Task.Factory.StartNew(() => Debug.Log("Test"));
        }*/
    }
}