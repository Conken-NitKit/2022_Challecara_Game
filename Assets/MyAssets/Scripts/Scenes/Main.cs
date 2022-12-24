using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

namespace MyScript.Scene
{
    public class Main : MonoBehaviour
    {
        int killcount;
        double timesurvived;

        public void SetArguments(string liveURL,string battleLevel)
        {
            Debug.Log("ok");
        }
    
        public async Task PassMaintoResult()
        {
            var result = await SceneLoader.Load<Result>("Result");
            result.SetArguments(killcount,timesurvived);
        }

        public void Loadresult()
        {
            PassMaintoResult();
        }
    }
}
