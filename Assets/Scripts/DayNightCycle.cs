using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DayNightCycle : MonoBehaviour
{
    public float DayCounter = 1;

    public float DayTimeLength;
    public float NightTimeLength;

    public bool IsDayTime;
    public bool IsNightTime;

    private bool EndOfday;
    private bool Nextday;
    public Text DayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DayCounter == 2)
        {
            SceneManager.LoadScene("Victory");
        }

        if (transform.eulerAngles.x>0 && transform.eulerAngles.x<180)
        {
            IsNightTime = false;
            IsDayTime = true;
        }

        else if (transform.eulerAngles.x>180 && transform.eulerAngles.x <360)
        {
            IsNightTime = true;
            IsDayTime = false;
        }

        if (IsDayTime)
            transform.Rotate(1 * DayTimeLength * Time.deltaTime, 0, 0);

        if (IsNightTime)
            transform.Rotate(1 * NightTimeLength * Time.deltaTime, 0, 0);

        IncreaseNumberOfDays();

        DayText.text = DayCounter.ToString();

        
    }

    void IncreaseNumberOfDays()
    {
        if(transform.eulerAngles.x>270 && transform.eulerAngles.x < 280)
        {
            EndOfday = true;
        }

        else
        {
            Nextday = false;
            EndOfday = false;
        }

        if(EndOfday && !Nextday)
        {
            Nextday = true;
            DayCounter += 1;
        }
    }
}
