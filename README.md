# 🏗️ نمط Repository Pattern

تطبيق عملي لنمط Repository Pattern مع ASP.NET Core 6.0

## 📋 وصف المشروع

Repository Pattern هو مشروع تعليمي متقدم يوضح كيفية تطبيق نمط التصميم Repository Pattern في تطبيقات ASP.NET Core 6.0. المشروع يركز على فصل منطق الوصول إلى البيانات عن منطق الأعمال التجارية، مما يجعل الكود أكثر قابلية للاختبار والصيانة.

## ✨ الميزات الرئيسية

### 🏗️ نمط Repository Pattern
- **Generic Repository**: مستودع عام يعمل مع أي كائن
- **Interface Separation**: فصل الواجهات عن التنفيذ
- **Dependency Injection**: حقن التبعيات للمستودعات
- **Unit Testing**: تسهيل اختبار الوحدات
- **Code Reusability**: إعادة استخدام الكود

### 🗄️ إدارة البيانات
- **Entity Framework Core**: التعامل مع قواعد البيانات
- **DbContext**: سياق قاعدة البيانات الموحد
- **Migrations**: إدارة تغييرات المخطط
- **LINQ Queries**: استعلامات قوية ومحسنة

### 🎨 بنية المشروع
- **Clean Architecture**: بنية نظيفة ومقسمة
- **Separation of Concerns**: فصل الاهتمامات
- **SOLID Principles**: تطبيق مبادئ SOLID
- **Testable Code**: كود قابل للاختبار

### 🔧 المفاهيم المتقدمة
- **Generic Programming**: البرمجة العامة
- **Interfaces**: استخدام الواجهات البرمجية
- **Abstraction**: التجريد والتجسيد
- **Inversion of Control**: عكس التحكم

## 🏗️ البنية التقنية

- **الإطار**: ASP.NET Core 6.0
- **لغة البرمجة**: C# 10.0
- **قاعدة البيانات**: SQL Server
- **ORM**: Entity Framework Core 6.0
- **النمط**: Repository Pattern
- **المبادئ**: SOLID Principles
- **الاختبار**: Unit Testing Support

## 📁 هيكل المشروع

```
Lecture9- Repositry/
├── g13lec6/
│   ├── Controllers/
│   │   ├── HomeController.cs
│   │   ├── StudentController.cs
│   │   └── TestController.cs
│   ├── Models/
│   │   ├── group13.cs
│   │   ├── group13Context.cs
│   │   ├── Student.cs
│   │   └── group13Context.cs
│   ├── Repositories/
│   │   ├── GenericRepository.cs
│   │   └── IRepository.cs
│   ├── Views/
│   │   ├── Home/
│   │   ├── Student/
│   │   ├── Test/
│   │   └── Shared/
│   ├── Program.cs
│   ├── appsettings.json
│   └── g13lec6.csproj
├── Repsitry.txt
└── README.md
```

## 🚀 التثبيت

### المتطلبات
- .NET 6.0 SDK
- Visual Studio 2022 أو Visual Studio Code
- SQL Server 2019+
- Git

### خطوات التثبيت

1. **نسخ المشروع**
```bash
git clone https://github.com/mohammed-alshaibani/RepositoryPattern.git
cd RepositoryPattern
```

2. **استعادة الحزم**
```bash
dotnet restore
```

3. **إعداد قاعدة البيانات**
```bash
dotnet ef database update
```

4. **تشغيل المشروع**
```bash
dotnet run
```

## 🎯 المفاهيم والمبادئ

### 📚 نمط Repository Pattern

#### **ما هو Repository Pattern؟**
Repository Pattern هو نمط تصميم يفصل منطق الوصول إلى البيانات عن بقية التطبيق. يوفر واجهة موحدة للوصول إلى البيانات مع إخفاء تفاصيل التخزين.

#### **المكونات الأساسية**
- **Repository Interface**: واجهة تعريف العمليات
- **Generic Repository**: مستودع عام قابل لإعادة الاستخدام
- **Entity Framework**: طبقة الوصول إلى البيانات
- **Dependency Injection**: حقن المستودعات في المتحكمات

#### **المزايا**
- **فصل الاهتمامات**: فصل منطق الأعمال عن الوصول للبيانات
- **قابلية الاختبار**: تسهيل كتابة اختبارات الوحدات
- **إعادة الاستخدام**: مستودع عام يعمل مع أي كائن
- **صيانة أسهل**: تعديل طريقة الوصول للبيانات في مكان واحد

### 🎯 مبادئ SOLID

#### **S - Single Responsibility Principle**
كل كلاس لديه مسؤولية واحدة فقط
- **Repository**: مسؤول عن الوصول للبيانات فقط
- **Controller**: مسؤول عن منطق الأعمال فقط
- **Model**: مسؤول عن البيانات فقط

#### **O - Open/Closed Principle**
الكلاسات مفتوحة للتمديد ولكن مغلقة للتعديل
- **IRepository<T>**: واجهة مفتوحة
- **GenericRepository<T>**: تنفيذ مغلق للتعديل

#### **L - Liskov Substitution Principle**
الكلاسات الفرعية يجب أن تكون قابلة للاستبدال بكلاسها الأساسي

#### **I - Interface Segregation Principle**
العملاء لا يجب أن يعتمدوا على واجهات لا يستخدمونها

#### **D - Dependency Inversion Principle**
الاعتماد على التجريدات وليس على التجسيدات
- حقن التبعيات عبر المنشئ

## 📄 أمثلة عملية

### 📝 IRepository Interface
```csharp
public interface IRepository<T> where T : class
{
    T Add(T entity);
    T Update(T entity);
    T Delete(int id);
    T GetById(int id);
    List<T> GetAll();
}
```

### 🏗️ GenericRepository Implementation
```csharp
public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly group13Context context;

    public GenericRepository(group13Context context)
    {
        this.context = context;
    }

    public T Add(T entity)
    {
        try
        {
            var res = context.Add(entity); 
            var rowcount = context.SaveChanges();
            return res.Entity as T;
        }
        catch (Exception ex)
        {
            return default(T);
        }
    }

    public T Update(T entity)
    {
        try
        {
            var res = context.Update(entity);
            var rowcount = context.SaveChanges();
            return res.Entity as T;
        }
        catch (Exception ex)
        {
            return default(T);
        }
    }

    public T Delete(int id)
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        return context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }
}
```

### 🎯 Controller Usage
```csharp
public class StudentController : Controller
{
    private readonly IRepository<Student> _studentRepository;

    public StudentController(IRepository<Student> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IActionResult> Index()
    {
        var students = _studentRepository.GetAll();
        return View(students);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        if (ModelState.IsValid)
        {
            _studentRepository.Add(student);
            return RedirectToAction(nameof(Index));
        }
        return View(student);
    }
}
```

### 🔧 Dependency Injection Setup
```csharp
// Program.cs
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<group13Context>();

// Register Generic Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();
```

## 🎯 الوحدات الرئيسية

### 🏠 الصفحة الرئيسية
- **الترحيب**: عرض معلومات المشروع
- **التنقل**: قائمة التنقل الرئيسية
- **المفاهيم**: شرح مبادئ Repository Pattern

### 👥 إدارة الطلاب
- **قائمة الطلاب**: عرض جميع الطلاب باستخدام Repository
- **إضافة طالب**: إضافة طالب جديد عبر Repository
- **عمليات CRUD**: جميع عمليات Create-Read-Update-Delete

### 🧪 صفحة الاختبار
- **اختبار المستودع**: اختبار عمليات Repository
- **أمثلة عملية**: أمثلة على استخدام النمط
- **النتائج**: عرض نتائج العمليات

## 🔧 إعدادات التطبيق

### **appsettings.json**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=group13;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### **Program.cs**
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<group13Context>();

// Register Generic Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

## 🛠️ التقنيات المستخدمة

- **C#**: 10.0
- **ASP.NET Core**: 6.0
- **Entity Framework Core**: 6.0
- **SQL Server**: LocalDB
- **Repository Pattern**: Design Pattern
- **Dependency Injection**: IoC Container
- **Generic Programming**: C# Generics
