using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject Restart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Death()
    {
        Time.timeScale = 0.2f;
        Restart.SetActive(true);
        gameObject.SetActive(false);
        
    }
}
