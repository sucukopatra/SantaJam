using UnityEngine;
using UnityEngine.Rendering.Universal; // Iþýða eriþmek için þart

public class DayNightGlobal : MonoBehaviour
{
    public Light2D globalLight; // Inspector'dan SunLight'ý sürükle
    public float cycleSpeed = 0.1f;

    // Renkleri özelleþtirebilirsin
    public Color dayColor = Color.white;
    public Color nightColor = new Color(0.1f, 0.1f, 0.25f); // Hafif lacivert gece

    private float timer = 0f;
   public static DayNightGlobal instance;

void Awake() 
{
    if (instance == null) 
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    } 
    else 
    {
        Destroy(gameObject); // Eðer zaten bir tane varsa yenisini yok et
    }
}
    void Update()
    {
        timer += Time.deltaTime * cycleSpeed;

        // 0 ile 1 arasý gidip gelen deðer (Sinüs dalgasý)
        float t = (Mathf.Sin(timer) + 1f) / 2f;

        // Iþýk þiddetini ayarla: Gündüz 1.0, Gece 0.2
        globalLight.intensity = Mathf.Lerp(0.2f, 1.0f, t);

        // Rengi ayarla: Gündüz beyaz, Gece lacivert
        globalLight.color = Color.Lerp(nightColor, dayColor, t);
    }
}