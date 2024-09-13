using UnityEngine;
using UnityEngine.UI;

public class Scorebar : MonoBehaviour
{
	public Image scorebarFill;
	public int maxTokens = 3;

	public void UpdateScorebar(int currentTokens) {
		float fillAmount = (float)currentTokens / maxTokens;

		scorebarFill.fillAmount = fillAmount;
		if ( currentTokens >= maxTokens ){
			this.gameObject.SetActive(false);
		}
	}
}
