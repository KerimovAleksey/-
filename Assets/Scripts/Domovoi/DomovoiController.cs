using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomovoiController : MonoBehaviour
{
    private SkeletonAnimation _animator;

    private Dictionary<string, string> _domovoiPhrases = new Dictionary<string, string>()
    {
        {"choose", "Укажи правильную последовательность! -> " },
        {"correct", "Молодец!" },
        {"incorrect", "Попробуй ещё раз! :)" }
    };

	private void Awake()
	{
		_animator = GetComponent<SkeletonAnimation>();
	}

	private void Start()
	{
        SetAnimation("greet");
	}

	public void SetAnimation(string name)
    {
        StartCoroutine(nameof(ChangeAnimationAndReturnToIdle), name);
    }

    private IEnumerator ChangeAnimationAndReturnToIdle(string name)
    {
        var track = _animator.state.SetAnimation(0, name, false);
        yield return new WaitForSpineAnimationComplete(track);
		_animator.state.SetAnimation(0, "idle", true);
	}

	public string GetPhrase(string key)
    {
        return _domovoiPhrases[key];
    }
}
