using UnityEngine;

public class IconBar : MonoBehaviour
{
    public GameObject icon;

    public void SetValue(int value) {
        int currentValues = GetCurrentValues();
        int diff = value - currentValues;
        bool isShouldAdd = diff > 0;
        
        for (int i = 0; i < currentValues; i++)
        {
            RemoveIcon();
        }

        for (int i = 0; i < value; i++)
        {
            AddIcon();
        }
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
        Transform child = transform.GetChild(0);
        child.SetParent(null);
        Destroy(child.gameObject);
    }

    private void AddIcon() {
        GameObject newIcon = Instantiate(icon, transform.position, Quaternion.identity);
        newIcon.transform.SetParent(this.transform);
    }
}
