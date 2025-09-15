# .NET Web API Projeleri

## 📌Projenin Ortak Özellikleri
- **Mimari & Patternlar**: Onion Architecture, Repository Pattern, UnitOfWork, CQRS + MediatR, FluentValidation
- **Teknolojiler**: .NET 6 Web API, Entity Framework Core, PostgreSQL, Swagger

---

## Proje 1: UserManagementAPI
Kullanıcı yönetimi için geliştirilmiş bir Web API projesidir.
- Kullanıcı ekleme, güncelleme, silme, listeleme işlemleri yapılabilir.

 **🔑EndPointler**
- GET /api/User/getAll → Tüm kullanıcıları getirir
- POST /api/User/create → Yeni kullanıcı ekler
- PUT /api/User/update → Kullanıcı günceller
- DELETE /api/User/delete/id → Kullanıcı siler

---

## Proje 2: HotelReservationAPI
Otel rezervasyon yönetimi için geliştirilmiş Web API projesidir.
- Müşteri yönetimi, oda yönetimi ve rezervasyon işlemleri yapılabilir.
- Ekstra Özellik : Exception Handler Middleware

**🔑Bazı EndPointler**
- GET /api/Customer/update → Müşteri günceller
- GET /api/Room/getAll → Odaları listeler
- POST /api/Reservation/create → Mevcut Müşteri ile yeni rezervasyon yapar
- POST /api/Reservation/createWithCustomer → Yeni Müşteri bilgileri ile rezervasyon yapar
- GET /api/Reservation/getById/{id} → Rezervasyon detayını getirir

---
