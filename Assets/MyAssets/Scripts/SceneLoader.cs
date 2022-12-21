using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// シーンをロードする
/// ロード先シーンのコンポーネントが取得できるのでパラメーターを渡せる
/// 取得できるコンポーネントはロード先シーンのルート階層のGameObjectに設置されているもの
/// 指定コンポーネントが取得できるのはAwakeの後、Startの前のタイミング
/// </summary>
public static class SceneLoader
{
    /// <summary>
    /// ロードする
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    /// <param name="mode">シーンロードモード</param>
    /// <returns>ロード先シーンのコンポーネント</returns>
    public static UniTask<TComponent> Load<TComponent>(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        where TComponent : Component
    {
        var tcs = new UniTaskCompletionSource<TComponent>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName, mode);
        return tcs.Task;

        void OnSceneLoaded(Scene scene, LoadSceneMode _mode)
        {
            // 一度イベントを受けたら不要なので解除
            SceneManager.sceneLoaded -= OnSceneLoaded;

            // ロードしたシーンのルート階層のGameObjectから指定コンポーネントを1つ取得する
            var target = GetFirstComponent<TComponent>(scene.GetRootGameObjects());

            tcs.TrySetResult(target);
        }
    }

    /// <summary>
    /// ロードする
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    /// <param name="mode">シーンロードモード</param>
    public static void Load(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(sceneName, mode);
    }

    /// <summary>
    /// 非同期ロードする
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    /// <param name="mode">シーンロードモード</param>
    /// <returns>ロード先シーンのコンポーネント</returns>
    public static async UniTask<TComponent> LoadAsync<TComponent>(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        where TComponent : Component
    {
        await SceneManager.LoadSceneAsync(sceneName, mode);

        Scene scene = SceneManager.GetSceneByName(sceneName);

        return GetFirstComponent<TComponent>(scene.GetRootGameObjects());
    }

    /// <summary>
    /// GameObject配列から指定のコンポーネントを一つ取得する
    /// </summary>
    /// <typeparam name="TComponent">取得対象コンポーネント</typeparam>
    /// <param name="gameObjects">GameObject配列</param>
    /// <returns>対象コンポーネント</returns>
    private static TComponent GetFirstComponent<TComponent>(GameObject[] gameObjects)
        where TComponent : Component
    {
        TComponent target = null;
        foreach (GameObject go in gameObjects)
        {
            target = go.GetComponent<TComponent>();
            if (target != null) break;
        }
        return target;
    }
}