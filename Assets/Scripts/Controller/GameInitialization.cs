using System.Collections.Generic;
using UnityEngine;

namespace ExampleGame
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var uiReferences = new UIReferences();
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.Player);
            var bulletFactory = new BulletFactory(data.PlayerBulletMissile);
            var enemyParser = new EnemyParserFromJson(new EnemySaveDataRepository<SavedDataEnemy>(), data);
            var enemyFactory = new EnemyFactory(enemyParser);
            var playerInitialization = new PlayerInitialization(playerFactory, data.Player);
            var enemyInitialization = new EnemyInitialization(enemyFactory);
            var bulletInstantiator = new BulletInstantiator(bulletFactory,
                new ModificationShootType(playerInitialization.GetPlayerTransform(), data.PlayerBulletMissile),
                bulletFactory.GetBulletViewServices());
            var playerShootProxy = new PlayerShootProxy(
                new PlayerShootController(inputInitialization.GetMouseInput(), bulletInstantiator),
                new UnlockWeapon(true));
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(enemyInitialization);
            controllers.Add(enemyInitialization.GetEnemiesTimeBodies());
            controllers.Add(new CameraController(playerInitialization.GetPlayerTransform(), camera.transform));
            controllers.Add(new PlayerBridge(
                new PlayerMoveController(inputInitialization.GetMoveInput(), playerInitialization, data.Player), 
                playerShootProxy));
            controllers.Add(new PlayerRotation(inputInitialization.GetMouseInput(),
                playerInitialization.GetPlayerTransform(), camera));
            controllers.Add(new InputController(inputInitialization.GetMoveInput(), inputInitialization.GetMouseInput(),
                inputInitialization.GetUiInput()));
            controllers.Add(new BulletSelfDestructionController(bulletFactory));
            controllers.Add(new EnemySpawnerProxy(
                new EnemySpawner(enemyInitialization, enemyFactory, playerInitialization.GetPlayerTransform()),
                enemyInitialization.GetSpawnEnabler()));
            controllers.Add(new EnemyMoveController(enemyInitialization.GetMovesEnemies(),
                playerInitialization.GetPlayerTransform(), enemyFactory.GetEnemiesDates()));
            controllers.Add(new EnemyTriggerController(enemyInitialization, playerInitialization, bulletFactory));
            controllers.Add(new EnemyAbilitiesController(enemyInitialization.GetEnemyAbilities()));
            controllers.Add(new UserInterfaceController(inputInitialization.GetUiInput(),
                new List<BaseUi>()
                {
                    new PanelOne(uiReferences.PlayerHealthPanel, playerInitialization.GetPlayerHp()),
                    new PanelTwo(uiReferences.PlayerScorePanel, playerInitialization.GetPlayerScore())
                }));
            new GameObject("BulletDictionaryViewer").AddComponent<BulletDictionaryViewer>()
                .SetDictionary(bulletFactory.GetBulletsWithID());
        }
    }
}