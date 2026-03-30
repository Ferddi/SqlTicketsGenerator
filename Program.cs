//
// dotnet run          (default to 1000 tickets)
// dotnet run -- 500   (500 tickets are randomly generated)
//
// sqlite3 HelpDeskDb.db < ..\SqlTicketsGenerator\seed_1000_tickets.sql
//
// To completely reset the sqlite3 database:
// 1. Delete Migrations directory & HelpDeskDb.db.
// 2. dotnet-ef migrations add InitialCreate (InitialCreate is a comment)
// 3. dotnet-ef database update
//
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program
{
    public enum TicketPriority
    {
        Low,
        Medium,
        High
	}

    public enum TicketStatus
    {
        Open,
        InProgress,
        Resolved
    }

    static void Main(string[] args)
    {
        // Default to 1000 if not provided
        int ticketCount = 1000;

        if (args.Length > 0 && int.TryParse(args[0], out int parsed))
        {
           ticketCount = parsed;
        }

        if (ticketCount <= 0)
        {
            Console.WriteLine("Ticket count must be greater than 0.");
            return;
        }
 
        Console.WriteLine($"Generating {ticketCount} tickets...");

        var random = new Random();

        var users = new List<string?> { 
            "30e3a7ec-3ed7-496c-822d-24d02c18e4f2", 
			"c738a8a8-6ad6-4d86-b70b-0ef3812353f6", 
			"55561e29-04d3-464d-8b2a-bd683c71b193", 
			"b7b09b1a-db67-43c9-a6ec-c0d2aa7a909b", 
			"7a84ef47-0ce6-4c7b-ad0a-6ea91cf12256", 
			null 
		};

        var titles = new[]
        {
            "Cannot login", 
			"Email not sending", 
			"Printer offline", 
			"Application crash",
            "Slow report generation", 
            "Slow performance", 
			"Password reset needed", 
			"Network disconnects",
			"Network issue", 
            "Software update failure", 
			"Report error", 
			"Keyboard not responding",
            "VPN issues", 
			"VPN failure", 
			"Software installation", 
			"Mouse not detected", 
			"Phone system offline",
            "Access denied", 
			"Database timeout", 
			"Error 404", 
			"Laptop overheating", 
			"File sync issue",
            "Software license expired"
        };

        //
		// TODO: Title should match to description.
		//
        var descriptions = new[]
        {
            "User reports an issue affecting daily work.",
            "System error encountered during operation.",
            "Intermittent issue reported by multiple users.",
            "Failure observed under normal conditions.",
            "Needs investigation and resolution.",
            "Blocking business operations.",
            "Unexpected behaviour detected.",
            "Requires urgent attention.",
            "User reports being unable to login.",
            "Outgoing emails fail intermittently.",
            "Office printer is not connecting.",
            "App crashes immediately after opening.",
            "Reports take too long to load.",
            "User forgot password.",
            "Frequent office network drops.",
            "Automated updates fail.",
            "Monthly reports fail with exception.",
            "New keyboards are unresponsive.",
            "Cannot connect to VPN.",
            "Cannot install required software.",
            "Wireless mouse stops working.",
            "Desk phones are not working.",
            "User cannot access shared folder.",
            "Database queries timing out.",
            "Internal web page missing.",
            "Laptop shuts down unexpectedly.",
            "Files not syncing to cloud.",
            "Cannot use licensed software."
        };

        var sb = new StringBuilder();

        sb.AppendLine("BEGIN TRANSACTION;");
        sb.AppendLine("DELETE FROM AspNetUsers;");
        sb.AppendLine("DELETE FROM Tickets;");

        //
        // Password = Abc123$
        //
        sb.AppendLine("INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES ('30e3a7ec-3ed7-496c-822d-24d02c18e4f2', 'alice@example.com', 'ALICE@EXAMPLE.COM', 'alice@example.com', 'ALICE@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEEDpjBggvD3ljixdrGlDK4BcCqVYxFk6MtFQmqQ6/l1i7Xe60+rnvKJQJN7oOp5wFA==', 'VDHCL32B4NMIQEDVRHAZTC6LXV6BXZT7', 'e71cf91a-8c99-424d-ae26-2a6734cc517b', 0, 0, 0, 0);");

		sb.AppendLine("INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES ('c738a8a8-6ad6-4d86-b70b-0ef3812353f6', 'bob@example.com', 'BOB@EXAMPLE.COM', 'bob@example.com', 'BOB@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEMWTIeqKMjmI34BJ87lJypQ2cn8ANFImNw2WGSdtQ4993Xx+6sMfI33K2qkqOCInEA==', '3EGUM56RE5CBCSWMKTZ7VXWHXH6YJXS6', 'f623c6cb-3c61-4e50-95e1-6bcf8747a8af', 0, 0, 0, 0);");

		sb.AppendLine("INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES ('55561e29-04d3-464d-8b2a-bd683c71b193', 'tom@example.com', 'TOM@EXAMPLE.COM', 'tom@example.com', 'TOM@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEBJR8zTRcdmROy+tnO0vl9mdox/x5wkpBHRPtdnn+lnYOOhwvg2M1KZKcsGEB1f5fQ==', 'HLWZ6TJP4DND4UBSLAOB3HOKTV62XHY6', '335a485a-a9a9-40e5-888a-2aa21d779578', 0, 0, 0, 0);");

        sb.AppendLine("INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES ('b7b09b1a-db67-43c9-a6ec-c0d2aa7a909b', 'steve@example.com', 'STEVE@EXAMPLE.COM', 'steve@example.com', 'STEVE@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPi1+q4kjZe+RoXs2sBkM/yy8Hjf+sv1Vzud61X3ktLc/fNLbcr8f3FHi2WEaHa1tg==', 'KYWIEQPW2U7SKPOOMAJ7NQPEC4DVFRSM', '2566f2d0-a993-4917-a4c3-7b6c065a8958', 0, 0, 0, 0);");

        sb.AppendLine("INSERT INTO AspNetUsers (Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount) VALUES ('7a84ef47-0ce6-4c7b-ad0a-6ea91cf12256', 'jane@example.com', 'JANE@EXAMPLE.COM', 'jane@example.com', 'JANE@EXAMPLE.COM', 1, 'AQAAAAIAAYagAAAAEPfFPGW/pA4CrwwtLloQaTCSeungZS8ELjH4SKf4mqJ1IwASIhZKuIgCEFiaGiGgsw==', 'GSNSSTUGF35VXGYDL43VSPDDXUGWGEXQ', 'dfca672a-b897-4623-8e1f-40041ef7f61b', 0, 0, 0, 0);");

        var startDate = new DateTime(2026, 3, 1, 9, 0, 0);

        for (int i = 1; i <= ticketCount; i++)
        {
            var title = $"{titles[random.Next(titles.Length)]}".Replace("'", "''");
            var description = descriptions[random.Next(descriptions.Length)].Replace("'", "''");

			var priority = random.Next(Enum.GetValues(typeof(TicketPriority)).Length);

            // Bias toward Open tickets
            // var status = random.Next(100) < 60 ? 0 : random.Next(Enum.GetValues(typeof(TicketStatus)).Length);
            var status = random.Next(100) < 60 ? TicketStatus.Open : (TicketStatus)random.Next(Enum.GetValues(typeof(TicketStatus)).Length);

            // Some unassigned tickets
            var assigned = random.Next(5) == 0 ? null : users[random.Next(0, 5)];

			if (status == TicketStatus.InProgress || status == TicketStatus.Resolved)
			{
				// If this ticket is unassigned then assigned it to someone.
				if (assigned == null) {
					assigned = users[random.Next(0, 5)];
				}
			}

            var assignedSql = assigned == null ? "NULL" : $"'{assigned}'";

            var created = startDate.AddMinutes(i * 5).ToString("yyyy-MM-dd HH:mm:ss");

            sb.AppendLine($@"INSERT INTO Tickets (Title, Description, Priority, Status, AssignedToUserId, CreatedAt) VALUES ('{title}', '{description}', '{priority}', '{(int)status}', {assignedSql}, '{created}');");
        }

        sb.AppendLine("COMMIT;");

        var fileName = $"seed_{ticketCount}_tickets.sql";
        File.WriteAllText(fileName, sb.ToString());

        Console.WriteLine($"SQL script generated: {fileName}");
    }
}
