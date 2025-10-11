using UnityEngine;

public class Boulder : MonoBehaviour
{
    [SerializeField] private int m_Health;
    public int m_SpeedRequiredToDamage;

    public void DecreaseHealth()
    {
        m_Health--;
        if (m_Health <= 0)
        {
            Destroy(gameObject);
        }
    } 
}
