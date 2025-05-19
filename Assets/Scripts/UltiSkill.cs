using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UltiSkill : MonoBehaviour
{
    [SerializeField] private Image leafImage;
    [SerializeField] private Button skillButton; 
    [SerializeField] private float fillSpeed = 0.2f;
    [SerializeField] private ParticleSystem UltiEffect;

    private float currentFill = 0f;
    private bool isFilling = false;

    private void Start()
    {
        skillButton.interactable = false;
        UltiEffect.gameObject.SetActive(false);
        StartFilling();
    }

    private void Update()
    {
        if (isFilling && currentFill < 1f)
        {
            currentFill += fillSpeed * Time.deltaTime;
            leafImage.fillAmount = currentFill;

            if (currentFill >= 1f)
            {
                currentFill = 1f;
                isFilling = false;
                skillButton.interactable = true;  
            }
        }
    }

    public void StartFilling()
    {
        isFilling = true;
        currentFill = 0f;
        leafImage.fillAmount = 0f;
        skillButton.interactable = false;  
    }

    public void OnSkillButtonClicked()
    {
        if (!skillButton.interactable) return;

        EnemyAttack[] currentEnemies = FindObjectsOfType<EnemyAttack>();
        UltiEffect.gameObject.SetActive(true);
        UltiEffect.Play();
        StartCoroutine(DisableEffectAfterPlay());
        foreach (EnemyAttack enemy in currentEnemies)
        {
            enemy.EnemyTakeDamage(3);
        }

        skillButton.interactable = false;
        StartFilling();
    }

    IEnumerator DisableEffectAfterPlay()
    {
        yield return new WaitForSeconds(UltiEffect.main.duration);
        UltiEffect.gameObject.SetActive(false);
    }
}
