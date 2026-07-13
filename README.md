# AutomationExerciseHybridTests

Bu proje, [Automation Exercise](https://automationexercise.com/) web sitesinin UI (Kullanıcı Arayüzü) ve API testlerini otomatize etmek için oluşturulmuş bir **Hibrit Test Otomasyon Çerçevesidir (Hybrid Test Automation Framework)**.

## 🚀 Teknolojiler ve Araçlar

Proje modern C# ve .NET ekosistemi üzerinde inşa edilmiştir:

- **Dil & Platform:** C#, .NET 8.0
- **Test Çerçevesi:** NUnit 3
- **UI Otomasyonu:** Microsoft Playwright
- **API Otomasyonu:** RestSharp
- **Raporlama:** Allure Report
- **Tasarım Deseni:** Page Object Model (POM)
- **Konfigürasyon Yönetimi:** `appsettings.json` ve `Microsoft.Extensions.Configuration`

## 📁 Proje Yapısı

Proje içerisindeki temel klasörlerin ve yapıların görevleri:

- **`Api/`**: API testleri için gerekli servis metotlarını, HTTP istek yapılandırmalarını ve istemcileri (client) içerir.
- **`Models/`**: API isteklerinde veya UI verilerinde kullanılacak olan C# Veri Modellerini (DTO'lar vb.) barındırır.
- **`Config/`**: Ortam değişkenlerinin ve yapılandırma ayarlarının (`appsettings.json`) okunmasından sorumludur (`ConfigReader.cs`).
- **`Pages/`**: Page Object Model (POM) tasarım desenine uygun olarak oluşturulmuş, web sayfalarını temsil eden sınıfları içerir. Element tanımlamaları ve sayfa etkileşimleri burada yer alır (`HomePage.cs`, `SignupLoginPage.cs` vb.).
- **`Tests/`**: 
  - **`UI/`**: Playwright kullanılarak yazılan web arayüz testleri burada bulunur. Ortak test kurulumları ve kapanışları `BaseTest.cs` içerisinde yönetilir.
  - **`Api/`**: RestSharp kullanılarak yazılan API ve servis testleri burada bulunur.

## ⚙️ Kurulum ve Çalıştırma

### Gereksinimler

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Bir IDE (Visual Studio 2022, JetBrains Rider veya VS Code)
- [Node.js](https://nodejs.org/) (Playwright tarayıcı indirmeleri ve diğer araçlar için faydalı olabilir)

### Adımlar

1. **Projeyi Klonlayın:**
   ```bash
   git clone <repository-url>
   cd AutomationExerciseHybridTests/AutomationExerciseHybridTests
   ```

2. **Bağımlılıkları Yükleyin:**
   ```bash
   dotnet restore
   ```

3. **Playwright Tarayıcılarını Kurun:**
   Playwright'ın testleri koşabilmesi için gerekli tarayıcı motorlarını indirmesi gerekir:
   ```bash
   dotnet build
   pwsh bin/Debug/net8.0/playwright.ps1 install
   ```
   *(Windows'ta PowerShell (pwsh) yerine doğrudan `playwright install` komutunu da uygun global araç yüklüyse kullanabilirsiniz.)*

4. **Testleri Çalıştırın:**
   Tüm testleri çalıştırmak için:
   ```bash
   dotnet test
   ```

## 📊 Raporlama (Allure)

Proje, detaylı test raporları oluşturmak için **Allure.NUnit** kullanmaktadır. 

1. Test koşumundan sonra projenin derleme dizininde veya belirlenen kök dizinde `allure-results` klasörü oluşur.
2. Raporu görüntülemek için sisteminizde Allure komut satırı aracının (Allure CLI) yüklü olması gerekir.
3. Raporu oluşturmak ve tarayıcıda açmak için:
   ```bash
   allure serve allure-results
   ```

## 📝 Yapılandırma (`appsettings.json`)

Ortam bilgileri ve temel URL'ler `appsettings.json` dosyasında tutulur:
```json
{
  "BaseUrl": "https://automationexercise.com",
  "ApiBaseUrl": "https://automationexercise.com/api"
}
```
Testler sırasında `ConfigReader` sınıfı üzerinden bu URL'lere erişilir, böylece farklı ortamlar (test, stage, prod) için değişiklik yapmak kolaylaşır.

## 🚀 CI/CD Pipeline (GitHub Actions)

Projeye ait sürekli entegrasyon (CI) süreçleri **GitHub Actions** ile otomatikleştirilmiştir.

- **Tetikleyici (Trigger):** `master` branch'ine yapılan her `push` ve `pull_request` işlemi pipeline'ı otomatik olarak başlatır.
- **İşlemler:** 
  - Ubuntu makine üzerinde `.NET 8.0` ortamı kurulur.
  - Proje bağımlılıkları (`dotnet restore`) yüklenir.
  - Proje derlenir (`dotnet build`).
  - Playwright tarayıcıları (`chromium`) kurulur.
  - UI ve API Testleri (`dotnet test`) otomatik olarak koşulur.

İlgili workflow konfigürasyonuna `.github/workflows/tests.yml` dosyasından ulaşabilirsiniz.

## ✨ Katkıda Bulunma
Yeni bir özellik veya test eklemek isterseniz, lütfen uygun POM (Page Object Model) kurallarına ve projede yer alan mevcut kodlama standartlarına sadık kalın. API testlerinde RestSharp standartlarını takip edin.