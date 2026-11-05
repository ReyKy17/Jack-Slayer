using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

// Klik kiri pada musuh = menyerang.
// DPS pemain = damage / cooldown = 7 / 0,5 = 14 (sama dengan Level 1 di Bagian A).
public class PlayerAttack : MonoBehaviour
{
    public float damage = 7f;
    public float cooldown = 0.5f;

    private float siapLagi;

    void Update()
    {
        bool klik;
        Vector2 posisi;

#if ENABLE_LEGACY_INPUT_MANAGER
        klik = Input.GetMouseButtonDown(0);
        posisi = Input.mousePosition;
#elif ENABLE_INPUT_SYSTEM
        klik = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
        posisi = Mouse.current != null ? Mouse.current.position.ReadValue() : Vector2.zero;
#else
        klik = false;
        posisi = Vector2.zero;
#endif

        if (!klik || Time.time < siapLagi) return;

        Ray ray = Camera.main.ScreenPointToRay(posisi);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Enemy musuh = hit.collider.GetComponent<Enemy>();
            if (musuh != null)
            {
                musuh.TerimaDamage(damage);
                siapLagi = Time.time + cooldown;
            }
        }
    }
}
