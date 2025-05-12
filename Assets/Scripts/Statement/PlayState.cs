using UnityEngine;
using System.Collections.Generic;

namespace Statement
{
    public class PlayState : State
    {
        public EnemyUnit EnemyUnitRef;
        public CollectableItem CollectRef;
        private List<EnemyUnit> _enemies = new List<EnemyUnit>();
        private List<CollectableItem> _collectables = new List<CollectableItem>();

        public override void Start()
        {
            var gameConfig = ConfigModule.GetConfig<GameConfig>();

            int enemyCount = gameConfig.EnemyCount;

            int collectCount = gameConfig.CollectableCount;

            for (int i = 0; i < enemyCount; i++)
            {
                _enemies.Add(Instantiate(EnemyUnitRef, GetRandomPointAround(), Quaternion.identity));
            }

            for (int i = 0; i < collectCount; i++) 
            {
                 _collectables.Add(Instantiate(CollectRef, GetRandomPointAround(), Quaternion.identity));
            }

            foreach (var enemy in _enemies)
            {
                enemy.Init();
            }
        }
        public override void Update()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Run();
            }
        }
        public override void OnDisable()
        {

        }

        Vector3 GetRandomPointAround()
        {
            float radius = Random.Range(2, 9f);

            Vector3 center = Vector3.zero;

            Vector2 randomOffset = Random.insideUnitCircle * radius;

            return new Vector3(center.x + randomOffset.x, center.y, center.z + randomOffset.y);
        }
    }
}
