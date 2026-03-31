# SqlTicketsGenerator

A C# console application that generates SQL seed data for a Help Desk system.  
This tool is designed to populate the HelpDeskApp database with large volumes of random test data.

---

## 🚀 Features

- Generate hundreds or thousands of help desk tickets
- Outputs SQL `INSERT` statements
- Randomised:
  - Ticket titles and descriptions
  - Priority (Low, Medium, High)
  - Status (Open, In Progress, Resolved)
  - Assigned users (or unassigned)
- Configurable number of tickets via command line
- Supports NULL assignment for unassigned tickets
- Uses enums for clean and maintainable logic

---

## 🛠️ Tech Stack

- C# (.NET Console Application)
- System.Random for data generation
- Enum-based modelling
- SQL script output

---

## ⚙️ Getting Started

### 1. Clone the repository

```

git clone [https://github.com/Ferddi/SqlTicketsGenerator.git](https://github.com/Ferddi/SqlTicketsGenerator.git)
cd SqlTicketsGenerator

```

---

### 2. Run the generator

```

dotnet run -- 100

```

This will generate **100 tickets**.

---

### 3. Output

The program outputs SQL like:

```

INSERT INTO Tickets (Title, Description, Priority, Status, AssignedToUserId, CreatedAt)
VALUES ('Login issue', 'User cannot login...', 2, 0, '<AspNetUsers Id>', '2026-03-31 10:15:00');

```

---

## 🔧 Command Line Arguments

| Argument | Description |
|----------|------------|
| number   | Number of tickets to generate |

Example:

```

dotnet run -- 1000

```

---

## 🧠 Data Generation Logic

- ~60% of tickets are **Open**
- Remaining tickets are randomly **In Progress** or **Resolved**
- Users:
  - `AspNetUsers Id 1` → `AspNetUsers Id 5`
  - Some tickets are **NULL (unassigned)**
- Titles and descriptions are randomly selected from predefined lists

---

## 🔗 Integration with HelpDeskApp

This project is designed to work with:

👉 https://github.com/Ferddi/HelpDeskApp

### Usage flow:

1. Generate SQL:
```

dotnet run -- 500 > seed.sql

```

2. Run in SQLite:
```

sqlite3 HelpDeskDb.db < seed.sql

```

3. Launch HelpDeskApp:
```

dotnet run

```

---

## 📄 Example Output

```

INSERT INTO Tickets (...)
VALUES (...);

INSERT INTO Tickets (...)
VALUES (...);

```

---

## 🧪 Use Cases

- Populate development database
- Performance testing
- UI testing with large datasets
- Demonstrating realistic enterprise scenarios

---

## 🧠 Key Concepts Demonstrated

- Enum usage and casting
- Random data generation
- Command-line argument parsing
- SQL script generation
- Separation of concerns (generator vs web app)

---
