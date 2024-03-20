using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneController : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI progressText;

    public void LoadStartScene(GameSceneManager.Scene scene)
    {
        StartCoroutine(IELoadScene(scene));
    }

    private IEnumerator IELoadScene(GameSceneManager.Scene scene)
    {
        gameObject.SetActive(true);
        progressBar.value = 0;
        var async = GameSceneManager.LoadSceneSync(scene);
        async.allowSceneActivation = false;
        var progress = 0f;
        while (!async.isDone)
        {
            progress = Mathf.MoveTowards(progress, async.progress, Time.deltaTime);
            progressBar.value = progress;
            progressText.text = (int)(progress * 100f) + "%";
            if (progress >= .9f)
            {
                progressBar.value = 1;
                progress = 1f;
                progressText.text = (int)(progress * 100f) + "%";
                yield return new WaitForEndOfFrame();
                async.allowSceneActivation = true;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
        yield return null;
    }
}
