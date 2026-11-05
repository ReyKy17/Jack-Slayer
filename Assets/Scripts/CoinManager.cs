using UnityEngine;
using TMPro;

// Singleton: hanya ada satu CoinManager dan bisa dipanggil dari script mana pun
// lewat CoinManager.Instance
public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public TextMeshProUGUI teksCoin;   // tarik objek teks UI ke sini
    public int totalCoin { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        PerbaruiTeks();
    }

    public void TambahCoin(int jumlah)
    {
        totalCoin += jumlah;
        PerbaruiTeks();
    }

    void PerbaruiTeks()
    {
        if (teksCoin != null)
            teksCoin.text = "Cells: " + totalCoin;
    }
}
