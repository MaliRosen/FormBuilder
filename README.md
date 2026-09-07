# Form Builder & Milestones Management System

מערכת Full Stack לניהול ובניית טפסים עבור מחלקת משאבי אנוש.

המערכת מאפשרת יצירת תבניות טפסים, הגדרת שדות וניהול שלבי אישור.

## Technologies

### Backend

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* REST API
* DTOs
* Service Layer

### Frontend

* Angular
* TypeScript
* HTML / CSS

### Development Tools

* Visual Studio
* Git / GitHub
* AI development tools

---

## Architecture

המערכת בנויה בארכיטקטורת Client-Server:

```text
Angular Frontend
       |
       | HTTP / REST API
       v
ASP.NET Core Web API
       |
       | Entity Framework Core
       v
SQLite Database
```

ה־Frontend אחראי על ממשק המשתמש והצגת הנתונים.

ה־Backend אחראי על הלוגיקה העסקית, ולידציה וגישה למסד הנתונים.

---

## Project Structure

```text
ServerApp/
│
├── Controllers/
│   └── FormsController.cs
│
├── DTO/
│   ├── ApprovalStepDto.cs
│   ├── CreateFormDto.cs
│   ├── FormFieldDto.cs
│   └── FormResponseDto.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Entities/
│   ├── ApprovalStep.cs
│   ├── FormField.cs
│   └── FormTemplate.cs
│
├── Migrations/
│   └── InitialCreate
│
├── Services/
│   ├── IFormService.cs
│   └── FormService.cs
│
├── Program.cs
├── ServerApp.csproj
├── ServerApp.http
├── appsettings.json
└── .gitignore
```

---

## Data Model

המערכת כוללת את הישויות המרכזיות:

### FormTemplate

מייצגת תבנית טופס.

### FormField

מייצגת שדה השייך לתבנית הטופס.

### ApprovalStep

מייצגת שלב בתהליך האישור של הטופס.

הקשרים בין הישויות מאפשרים להגדיר טופס הכולל מספר שדות ומספר שלבי אישור.

---

## Backend Structure

ה־Backend מחולק למספר שכבות:

```text
Controller
    ↓
Service
    ↓
DbContext
    ↓
Database
```

### Controllers

`FormsController` אחראי על קבלת HTTP requests והחזרת HTTP responses.

### Services

`FormService` מכיל את הלוגיקה העסקית ומפריד אותה מה־Controller.

### DTO

המערכת משתמשת ב־DTOs להעברת מידע בין ה־API ל־Frontend, לדוגמה:

* `CreateFormDto`
* `FormFieldDto`
* `ApprovalStepDto`
* `FormResponseDto`

גישה זו מאפשרת להפריד בין מודלי ה־Database לבין המידע שנחשף באמצעות ה־API.

---

## Database

המערכת משתמשת ב־SQLite.

Entity Framework Core משמש כ־ORM לניהול הגישה למסד הנתונים.

הפרויקט כולל Migration ראשוני:

```text
InitialCreate
```

### Update Database

לאחר הורדת הפרויקט יש להריץ:

```bash
dotnet restore
dotnet ef database update
```

---

## Running the Backend

מתוך תיקיית `ServerApp`:

```bash
dotnet restore
dotnet build
dotnet run
```

ה־API יעלה בכתובת שמוצגת ב־Terminal.

---

## Frontend

מתוך תיקיית ה־Angular:

```bash
npm install
ng serve
```

לאחר מכן ניתן לפתוח:

```text
http://localhost:4200
```

---

## API

ה־API מספק פעולות לניהול הטפסים באמצעות REST.

התקשורת בין ה־Frontend ל־Backend מתבצעת באמצעות HTTP ו־JSON.

---

## AI – Design Consideration

במסגרת הרחבה עתידית ניתן לשלב Generative AI לצורך יצירת טפסים באמצעות שפה טבעית.

ארכיטקטורה אפשרית:

```text
Angular
   ↓
.NET API
   ↓
AI Service
   ↓
Generative AI
   ↓
Structured JSON
   ↓
Validation
   ↓
Dynamic Form
```

ה־AI יחזיר מבנה נתונים מוגדר ולא HTML או JavaScript להרצה ישירה.

לאחר Validation, המבנה יומר למודל הטופס ויוצג באמצעות Angular.

---

## Cloud / On-Premise Integration

בתרחיש של אינטגרציה עם מערכת On-Premise, הגישה המומלצת היא:

```text
Cloud API
    ↓
Integration Service / Queue
    ↓
Secure VPN
    ↓
On-Premise API
    ↓
On-Premise Database
```

כך נשמרת הפרדה בין המערכת בענן לבין מערכות ארגוניות פנימיות.

---

## Security Considerations

במערכת Production יש להקפיד על:

* HTTPS
* Authentication & Authorization
* Input Validation
* Secure API communication
* הגבלת גישה למסד הנתונים
* שמירת Secrets מחוץ לקוד
* Logging ו־Monitoring
* Validation של תוצרי AI לפני שימוש בהם

---

## Git Repository

Repository:

`https://github.com/MaliRosen/ServerApp`

Branch:

`main`

קבצים זמניים כגון `bin`, `obj`, `.vs` וקבצי Database מוחרגים באמצעות `.gitignore`.

---

## Author

**Malka Shapira**

Full Stack Developer


מצורף קישור להקלטות מסך 
https://drive.google.com/file/d/1ospdyMSDTqS7M4qNm9Imj94VJpJbfAWR/view?usp=sharing

