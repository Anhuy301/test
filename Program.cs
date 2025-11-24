using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Web_Test_DevExpress_ClaudeAI.Data;
using Web_Test_DevExpress_ClaudeAI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Thêm MudBlazor services
builder.Services.AddMudServices();

// Thêm DbContext với SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Tự động tạo database khi chạy app
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated(); // Tạo database tự động

        // Thêm dữ liệu mẫu nếu chưa có
        if (!context.Employees.Any())
        {
            context.Employees.AddRange(
                new Web_Test_DevExpress_ClaudeAI.Models.Employee
                {
                    FullName = "Nguyễn Văn A",
                    EmployeeCode = "NV001",
                    Department = "IT",
                    Position = "Developer",
                    PhoneNumber = "0901234567",
                    Email = "nva@company.com",
                    HireDate = new DateTime(2023, 1, 15),
                    IsActive = true
                },
                new Web_Test_DevExpress_ClaudeAI.Models.Employee
                {
                    FullName = "Trần Thị B",
                    EmployeeCode = "NV002",
                    Department = "Kế toán",
                    Position = "Accountant",
                    PhoneNumber = "0907654321",
                    Email = "ttb@company.com",
                    HireDate = new DateTime(2023, 3, 20),
                    IsActive = true
                }
            );
            context.SaveChanges();
        }

        Console.WriteLine("✅ Database đã được tạo và seed data thành công!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Lỗi khi tạo database: {ex.Message}");
        Console.WriteLine($"Chi tiết: {ex.InnerException?.Message}");
    }
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<Web_Test_DevExpress_ClaudeAI.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();