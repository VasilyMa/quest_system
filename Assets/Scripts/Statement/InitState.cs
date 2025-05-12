using UnityEngine.SceneManagement;

namespace Statement
{
    public class InitState : State
    {
        public static new InitState Instance
        {
            get
            {
                return (InitState)State.Instance;
            }
        }
        
        public override void Start()
        {
            ConfigModule.Initialize(this, onConfigLoaded);
        }

        void onConfigLoaded()
        {
            EntityModule.Initialize();

            SceneManager.LoadScene(1);
        }
            
        public override void Update()
        {

        }

        public override void OnDisable()
        {

        }
    }
}