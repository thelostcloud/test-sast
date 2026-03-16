using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace dotnet_semgrep_test.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    // SQL Injection vulnerability
    public void VulnerableSqlQuery(string userId)
    {
        string query = "SELECT * FROM Users WHERE UserId = " + userId;
        SqlConnection conn = new SqlConnection("Server=localhost;Database=test;");
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.ExecuteReader();
    }

    // Path Traversal vulnerability
    public string ReadUserFile(string filename)
    {
        string baseDir = "/var/app/data/";
        string filePath = Path.Combine(baseDir, filename); // Unsafe path concatenation
        return System.IO.File.ReadAllText(filePath);
    }

    // Hardcoded credentials
    public void ConnectToDatabase()
    {
        string connectionString = "Server=localhost;User ID=admin;Password=P@ssw0rd123;";
        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
    }

    // Command Injection vulnerability
    public string ExecuteSystemCommand(string userInput)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "bash",
            Arguments = "-c \"ls " + userInput + "\""  // Unsafe command concatenation
        };
        Process process = Process.Start(psi);
        return "Command executed";
    }

    // XSS vulnerability - returning unsanitized user input
    public string GetUserContent(string userContent)
    {
        return "<div>" + userContent + "</div>";  // Direct HTML without encoding
    }

    // Weak hash algorithm
    public string HashPassword(string password)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return System.Convert.ToBase64String(hashBytes);
        }
    }

    // Hardcoded API key
    public string GetApiKey()
    {
        return "sk_live_abc123def456ghi789";
    }

    // Unsafe XML parsing with XXE vulnerability
    public void ParseXmlUnsafely(string xmlData)
    {
        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.LoadXml(xmlData);  // Vulnerable to XXE attacks
    }
}
