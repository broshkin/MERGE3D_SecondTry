using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float total_score = 0;
    private float timely_score = 0;
    public static int score = 0;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI multiply_text;
    public TextMeshProUGUI timely_score_text;
    public float multiply = 1;
    public bool combo_active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "—чЄт: " + total_score.ToString();
        multiply_text.text = "ћножитель: " + multiply.ToString();
        timely_score_text.text = "ќчки за комбо: " + (Mathf.Round(timely_score * multiply)).ToString();
        if (score != 0)
        {
            if (!combo_active)
            {
                timely_score += score;
                combo_active = true;
                StartCoroutine(StopCombo());
            }
            else
            {
                StopAllCoroutines();
                timely_score += score;
                multiply += 0.2f;
                StartCoroutine(StopCombo());
            }
            score = 0;
        }
    }

    IEnumerator StopCombo()
    {
        yield return new WaitForSeconds(3f);
        FinishCombo();
    }   

    public void FinishCombo()
    {
        combo_active = false;
        total_score += Mathf.Round(timely_score * multiply);
        timely_score = 0;
        multiply = 1;

    }
}
