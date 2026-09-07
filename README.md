# Form Builder & Milestones Management System

מערכת Full Stack לניהול ובניית טפסים עבור מחלקת משאבי אנוש.

המערכת מאפשרת יצירה וניהול של תבניות טפסים, הגדרת שדות, וניהול שלבי אישור עבור כל טופס.

---

## 🏗️ Architecture

המערכת בנויה בארכיטקטורת Client-Server:

```text
┌──────────────────────┐
│      Angular         │
│     Frontend         │
└──────────┬───────────┘
           │ HTTP / REST API
           ▼
┌──────────────────────┐
│   ASP.NET Core API   │
│       Backend        │
└──────────┬───────────┘
           │ Entity Framework Core
           ▼
┌──────────────────────┐
│     SQLite DB        │
└──────────────────────┘
```

### Frontend

* Angular
* TypeScript
* HTML / CSS
* REST API integration
* Dynamic form rendering

### Backend

* C#
* ASP.NET Core Web API
* Entity Framework Core
* REST APIs
* DTOs
* Service Layer

### Database

* SQLite
* Entity Framework Core Migrations

---

## 📁 Project Structure

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
│   ├── 20260906192500_InitialCreate.cs
│   ├── 20260906192500_InitialCreate.Designer.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Services/
│   ├── FormService.cs
│   └── IFormService.cs
│
├── Properties/
│   └── launchSettings.json
│
├── Program.cs
├── ServerApp.csproj
├── ServerApp.http
├── appsettings.json
├── appsettings.Development.json
└── .gitignore
```

---

## 🧩 Main Entities

### FormTemplate

מייצג תבנית טופס במערכת.

התבנית מכילה את פרטי הטופס ואת השדות השייכים אליו.

### FormField

מייצג שדה בתוך הטופס.

השדה כולל את המידע הנדרש לצורך הצגת השדה והגדרת ההתנהגות שלו.

### ApprovalStep

מייצג שלב בתהליך האישור של הטופס.

לכל טופס ניתן להגדיר מספר שלבי אישור בהתאם לתהליך העסקי.

---

## 🔄 Application Flow

תהליך העבודה המרכזי במערכת:

```text
Create Form Template
        │
        ▼
Add Form Fields
        │
        ▼
Define Approval Steps
        │
        ▼
Save Form
        │
        ▼
Display / Manage Form
```

ה־Frontend אחראי על ממשק המשתמש והצגת הטפסים.

ה־Backend אחראי על הלוגיקה העסקית, ולידציה, גישה לנתונים וחשיפת REST API.

ה־Database משמש לשמירת תבניות הטפסים, השדות ושלבי האישור.

---

## ⚙️ Backend

ה־Backend פותח באמצעות ASP.NET Core Web API.

מבנה השכבות:

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

האחריות של ה־Controller היא לקבל HTTP Requests, לבצע את הפעולות הנדרשות מול שכבת השירות ולהחזיר HTTP Responses.

לדוגמה:

```text
FormsController
```

מטפל בפעולות הקשורות לטפסים.

### Services

הלוגיקה העסקית מופרדת מה־Controller באמצעות Service Layer.

לדוגמה:

```text
IFormService
FormService
```

הפרדה זו מאפשרת:

* קוד נקי יותר
* הפרדת אחריות
* בדיקות קלות יותר
* אפשרות להרחבת הלוגיקה העסקית בעתיד

### DTOs

נעשה שימוש ב־DTOs להעברת מידע בין ה־API לבין ה־Client.

לדוגמה:

```text
CreateFormDto
FormFieldDto
ApprovalStepDto
FormResponseDto
```

השימוש ב־DTOs מונע חשיפה ישירה של ה־Entities ומאפשר שליטה במבנה המידע שעובר דרך ה־API.

---

## 🗄️ Database

המערכת משתמשת ב־SQLite לצורך אחסון הנתונים.

Entity Framework Core משמש כ־ORM ומאפשר עבודה מול מסד הנתונים באמצעות C#.

ה־DbContext המרכזי:

```text
AppDbContext
```

### Migrations

הפרויקט כולל EF Core Migrations לצורך יצירה ועדכון של מבנה מסד הנתונים.

Migration ראשוני:

```text
InitialCreate
```

---

## 🚀 Running the Backend

### Prerequisites

יש להתקין:

* .NET SDK
* Node.js
* Angular CLI
* Git

### Clone the repository

```bash
git clone https://github.com/MaliRosen/ServerApp.git
```

כניסה לתיקיית הפרויקט:

```bash
cd ServerApp
```

---

## 📦 Restore Dependencies

הרצת:

```bash
dotnet restore
```

---

## 🗄️ Database Setup

יצירת/עדכון מסד הנתונים באמצעות ה־Migrations:

```bash
dotnet ef database update
```

הפקודה יוצרת את מסד הנתונים בהתאם ל־Entity Framework Core Migrations.

---

## ▶️ Run the Backend

```bash
dotnet run
```

לאחר הפעלת השרת ניתן להשתמש ב־API דרך הכתובת שמוצגת ב־Terminal.

---

## 🌐 Frontend

ה־Frontend מבוסס Angular.

מתוך תיקיית ה־Angular:

```bash
npm install
```

ולאחר מכן:

```bash
ng serve
```

המערכת תהיה זמינה בכתובת:

```text
http://localhost:4200
```

> יש לוודא שה־Frontend מוגדר לפנות לכתובת שבה ה־Backend רץ.

---

## 🔌 REST API

ה־Backend חושף REST API עבור ניהול הטפסים.

ה־API משמש את ה־Angular Frontend לצורך:

* יצירת טפסים
* שליפת טפסים
* עדכון טפסים
* מחיקת טפסים
* ניהול שדות
* ניהול שלבי אישור

התקשורת מתבצעת באמצעות HTTP/JSON.

---

## 🔐 Validation & Error Handling

המערכת מתוכננת להפריד בין שכבת התצוגה לבין הלוגיקה העסקית.

ב־Backend מתבצעת ולידציה של הנתונים לפני שמירתם במסד הנתונים.

במקרה של שגיאה ה־API מחזיר HTTP Status Code מתאים.

דוגמאות:

```text
200 OK
201 Created
400 Bad Request
404 Not Found
500 Internal Server Error
```

---

# 🤖 Generative AI – Design

אחד מהתרחישים שניתן לשלב במערכת הוא יצירת טופס באמצעות שיחה עם מודל Generative AI.

הארכיטקטורה המתוכננת:

```text
Angular Chat
     │
     ▼
.NET API
     │
     ▼
AI Orchestrator
     │
     ▼
Generative AI Model
     │
     ▼
Structured JSON / Schema
     │
     ▼
Validation
     │
     ▼
Form State
     │
     ▼
Angular Dynamic Form
```

### Example

המשתמש יכול לתאר באופן טבעי את הטופס שהוא מעוניין ליצור.

לדוגמה:

```text
Create an employee onboarding form
with name, email, start date and department.
```

ה־AI אינו אמור להחזיר HTML או JavaScript שרצים ישירות בדפדפן.

במקום זאת, הוא מחזיר מבנה נתונים מוגדר מראש, לדוגמה:

```json
{
  "name": "Employee Onboarding",
  "fields": [
    {
      "name": "employeeName",
      "type": "text",
      "required": true
    },
    {
      "name": "email",
      "type": "email",
      "required": true
    },
    {
      "name": "startDate",
      "type": "date",
      "required": true
    }
  ]
}
```

לאחר קבלת התוצאה:

1. השרת מבצע Validation.
2. המבנה מומר למודל פנימי של המערכת.
3. הנתונים נשמרים בהתאם לצורך.
4. Angular מציג את הטופס באופן דינמי.

גישה זו מאפשרת שימוש ב־AI תוך שמירה על שליטה במבנה הנתונים ואבטחת המערכת.

---

# 🔗 Cloud / On-Premise Integration – Design

בתרחיש שבו המערכת צריכה לעבוד מול מערכות On-Premise, לא מומלץ לאפשר גישה ישירה מה־Frontend למסד הנתונים.

ארכיטקטורה אפשרית:

```text
Angular
   │
   ▼
Cloud API
   │
   ▼
Integration Service / Queue
   │
   │ Secure VPN
   ▼
On-Premise API
   │
   ▼
On-Premise Database
```

התקשורת בין המערכות תתבצע באמצעות API מאובטח ו־JSON.

לדוגמה:

```json
{
  "templateId": 123,
  "name": "Employee Form",
  "version": 1,
  "fields": []
}
```

בנוסף ניתן להשתמש ב־Queue לצורך:

* Retry במקרה של כשל
* שמירת הודעות שלא עובדו
* מניעת אובדן מידע
* ניטור תהליכים
* הפרדת המערכות

---

# 🔒 Security Considerations

במערכת Production יש להקפיד על:

* HTTPS
* Authentication
* Authorization
* Secure API communication
* Input validation
* Output validation
* הגנה מפני SQL Injection באמצעות EF Core
* שמירת Secrets מחוץ לקוד
* הגבלת גישה למסדי נתונים
* אין לאפשר גישה ישירה מה־Frontend למסד נתונים
* אין להריץ HTML/JavaScript שמגיעים ישירות ממודל AI
* Logging ו־Monitoring

---

# 🧪 Testing

לפני הגשה מומלץ לבדוק:

### Backend

```bash
dotnet build
```

ולוודא שהפרויקט מתקמפל ללא שגיאות.

הרצת:

```bash
dotnet run
```

ולבדוק את פעולות ה־API.

### Database

לוודא שה־Migration רץ בהצלחה:

```bash
dotnet ef database update
```

### Frontend

```bash
npm install
ng serve
```

ולבדוק את התרחישים המרכזיים בממשק.

---

# 📌 Git

הפרויקט מנוהל באמצעות Git.

ה־Repository:

```text
https://github.com/MaliRosen/ServerApp
```

הענף הראשי:

```text
main
```

קבצים שאינם נדרשים ל־Repository, כגון:

```text
bin/
obj/
.vs/
*.db
```

מוחרגים באמצעות `.gitignore`.

---

# 📝 Development Notes

המערכת פותחה בגישה מודולרית המאפשרת להרחיב בעתיד את המערכת עם:

* סוגי שדות נוספים
* Validation מתקדם
* הרשאות משתמשים
* Workflow מתקדם
* גרסאות לטפסים
* Audit Log
* שמירת תשובות משתמשים
* אינטגרציה למערכות ארגוניות
* Generative AI
* Dynamic Form Generation

---

# 👩‍💻 Author

**Malka Shapira**

Full-Stack Developer

Technologies:

```text
C#
.NET / ASP.NET Core
Angular
TypeScript
Entity Framework Core
SQLite
REST APIs
SQL
Git
AI Development Tools
```
