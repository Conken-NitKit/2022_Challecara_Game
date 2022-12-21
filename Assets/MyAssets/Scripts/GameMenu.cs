using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;

public class GameMenu : MonoBehaviour
{
    string liveURL;
    string battleLevel;
    
    public async Task PassGameMenutoMain()
    {
        var main = await SceneLoader.Load<Main>("Main");
        main.SetArguments(liveURL,battleLevel);
    }
    public void LoadTitle()
    {
        SceneLoader.Load<Title>("Title");
    }
    public void LoadMain()
    {
        PassGameMenutoMain();
    }
    public void LoadResult()
    {
        SceneLoader.Load<Result>("Result");
    }
}
