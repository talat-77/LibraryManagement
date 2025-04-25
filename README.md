# Library Management System - Backend Case

Bu proje, bir kütüphane yönetim sistemi için backend mimarisi üzerine inşa edilmiştir. Siem Grup tarafından verilen case çalışması kapsamında geliştirilmiştir.

##  Kullanılan Teknolojiler ve Yapılar

- .NET 8**
- Onion Architecture**
- Entity Framework Core**
- SQL Server**
- FluentValidation** - DTO düzeyinde validasyon kuralları
- AutoMapper** - DTO ↔ Entity dönüşümleri
- Repository Pattern** - Veri erişimi soyutlamak için
  
##  Özellikler

- Kitap ve yazar CRUD işlemleri
-  “Loosely coupled” ve “SOLID” prensiplerine uygun bir yapı hedeflenmiştir
- Temiz ve sürdürülebilir kod
- FluentValidation ile gelişmiş veri doğrulama
- AutoMapper profilleri ile model dönüşümleri
- SQL Server üzerinde veri kalıcılığı

##  Kurulum

Aşağıdaki adımları izleyerek projeyi bilgisayarınızda çalıştırabilirsiniz.

### 1. Projeyi Klonlayın
İlk olarak projeyi bilgisayarınıza klonlayın:

```bash
git clone https://github.com/talat-77/LibraryManagement.git
cd LibraryManagement
