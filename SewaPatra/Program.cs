using SewaPatra.BusinessLayer;
using SewaPatra.DataAccess;
using SewaPatra.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Database Connection String
builder.Services.AddSingleton<AreaRepository>();
builder.Services.AddSingleton<AreaService>();
builder.Services.AddSingleton<CoordinatorRepository>();
builder.Services.AddSingleton<CoordinatorService>();
builder.Services.AddSingleton<DonationBoxRepository>();
builder.Services.AddSingleton<DonationBoxService>();
builder.Services.AddSingleton<DonorRepository>();
builder.Services.AddSingleton<DonorService>();
builder.Services.AddSingleton<SewaPatraIssueRepository>();
builder.Services.AddSingleton<SewaPatraIssueService>();
builder.Services.AddSingleton<PaymentVoucherRepository>();
builder.Services.AddSingleton<PaymentVoucherService>();
builder.Services.AddSingleton<ReceiptVoucherRepository>();
builder.Services.AddSingleton<ReceiptVoucherService>();
builder.Services.AddSingleton<DropDownService>();
builder.Services.AddSingleton<ReportRepository>();
builder.Services.AddSingleton<ReportService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Privacy}/{id?}");

app.Run();
