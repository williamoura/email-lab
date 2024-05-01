using System.Net.Mail;
using System.Net;

string emailBody = @"
<html>
<head>
    <style>
        body { font-family: Arial, sans-serif; }
    </style>
</head>
<body>
    <h2>Header test</h2>
    <p>Dear [key1],</p>
    <p>Some text</p>
    <p>Best regards,</p>
    <p>[key2]</p>
</body>
</html>";

// Replace keys
var value1 = "test01";
var value2 = "test02";

emailBody = emailBody.Replace("[key1]", value1)
                     .Replace("[key2]", value2);

string smtpServer = "smtp.server.net";
int smtpPort = 587; // Default SMTP port for TLS
string smtpUsername = "test@test.com"; // Or another user, if applicable
string smtpPassword = "password";

// Set up the SMTP client
SmtpClient client = new SmtpClient(smtpServer, smtpPort)
{
    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
    EnableSsl = true
};

// Create the email message
MailMessage emailMessage = new MailMessage(new MailAddress("test@test.com"), new MailAddress("test@test.com"))
{
    Subject = "Account Creation",
    Body = emailBody,
    IsBodyHtml = true // If the email body contains HTML
};

try
{
    // Send the email
    client.Send(emailMessage);
    Console.WriteLine("Email sent successfully.");
}
catch (Exception ex)
{
    Console.WriteLine("Error sending email: " + ex.Message);
}