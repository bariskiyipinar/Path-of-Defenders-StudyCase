# Path-of-Defenders Study-Case

# 🛡️ Path of Defenders

**Path of Defenders**, düşman dalgalarına karşı kuleler yerleştirerek savunma yapman gereken bir 2D tower defense oyunudur. Oyuncular stratejik kararlarla kule yerleştirir, düşman dalgalarını engeller ve her dalgadan sonra daha da güçlenen düşmanlara karşı koymaya çalışır.

## 🎮 Oynanış

- Düşmanlar belirli aralıklarla yollar boyunca ilerler.
- Oyuncu, düşmanları durdurmak için belirli noktalara kuleler yerleştirir.
- Her dalga sonrasında düşman sayısı ve zorluk seviyesi artar.
- Son dalgadaki tüm düşmanlar öldüğünde, özel bir efekt tetiklenir ve oyun sona erer.

## 🚀 Özellikler

- ✅ Artan zorlukta dalgalar
- ✅ Farklı düşman türleri
- ✅ Erken dalga çağırma (space tuşu ile)
- ✅ Düşmanlar öldüğünde otomatik sahne geçişi
- ✅ Basit ses yönetimi (arkaplan müziği ve toggle ile kontrol)

## 🛠️ Kurulum

1. Unity Hub ile Unity 2021.3 veya daha güncel bir sürümü indirin.
2. Bu projeyi Unity üzerinden açın.
3. `Scenes/Menu` veya `Scenes/Game` sahnesini başlatın.
4. Oynat (▶️) tuşuna basarak oyunu test edin.

## 🎹 Ses Sistemi

- Arka plan müziği `SoundManager` scripti ile kontrol edilir.
- `DontDestroyOnLoad` ile sahneler arasında müzik devam eder.
- Menüde ses aç/kapat toggle'ı mevcuttur.

## ⌨️ Kontroller

| Tuş         | İşlev                         |
|-------------|-------------------------------|
| `Space`     | Sıradaki düşman dalgasını erken başlatır |
| Fare (Mouse)| Kule yerleştirme ve seçim     |

## 📁 Proje Yapısı

![Ana Menü](Assets/Screenshots/111.png)
![Oyun İçi](Assets/Screenshots/ingame_wave.png)
