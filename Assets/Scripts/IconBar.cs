using UnityEngine;

public class IconBar : MonoBehaviour
{
    public GameObject icon;

    public void SetValue(int value) {
        int currentValues = GetCurrentValues();
        int diff = value - currentValues;
        bool isShouldAdd = diff > 0;

        if (diff == 0) return;
        for (int i = 0; i < Mathf.Abs(diff); i++)
        {
            ChangeValue(isShouldAdd);
        }
        currentValues = value;
    }

    public int GetCurrentValues(){
        return transform.childCount;
    }

    private void ChangeValue(bool isShouldAdd) {
        if (isShouldAdd) {
            AddIcon();
        }else {
            RemoveIcon();
        }
    }

    private void RemoveIcon() {
        if (transform.childCount < 1) return;
        Destroy(transform.GetChild(0).gameObject);
    }

    private void AddIcon() {
        GameObject newIcon = Instantiate(icon, transform.position, Quaternion.identity);
        newIcon.transform.SetParent(this.transform);
    }
}
