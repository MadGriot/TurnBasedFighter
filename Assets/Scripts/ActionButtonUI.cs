using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Button button;

    public void SetBaseManeuver(BaseManeuver baseManeuver)
    {
        textMeshPro.text = baseManeuver.Name;
        button.onClick.AddListener(() =>
        {
            ActorActionSystem2D.Instance.SelectedManeuver = baseManeuver;
        });
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
