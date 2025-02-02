# Library Management System - Biblio

## Overview

This project is a comprehensive Library Management System built with C# (Windows Forms) and MySQL. It is a multi-form application designed to handle both customer and admin functionalities through a user-friendly interface.

**Key Features:**

- **11 Forms in Total:**
  - **2 General Forms:** Sign In and Sign Up.
  - **4 Customer-Focused Forms:** Customers can explore books, requisition books, view and update their profile, etc.
  - **5 Admin-Focused Forms:** Admins can manage books (add, edit, delete), view and manage fines, and view customer information.
- **Database Connection:** A dedicated class handles MySQL database connections.
- **Robust Database Structure:** The system uses 6 interconnected tables to manage Users, Books, Categories, Stores, Requisitions, and Fines.

## Functionality

### User Authentication
- **Sign Up:** New users register by providing their email, name, date of birth, and password.
- **Sign In:** Existing users log in with their email and password.

### Customer Interface
After signing in, customers are directed to a dashboard where they can:
- **Explore Books:**  
  - A DataGridView lists all available books.
  - Filter options include text search and radio buttons for:
    - **All Books**
    - **Only Adult Books**
    - **Only Non-Adult Books**
  - Clicking a book displays its image.
  - Customers can mark a book as a favorite or requisition it.
- **Requisition Books:**  
  - Customers select a book from a ComboBox showing only the books they’ve requisitioned.
  - The form displays the book’s title, photo, and due date (deadline for return).
  - Once confirmed, the requisition is recorded, making the book available for pickup at the nearest store.
- **Profile:**  
  - Customers can view their profile details including name, email, total requisitions, total fines, and profile photo.
  - Their favorite book (with image, title, and author) is also displayed.
  - Customers can update their details (e.g., email, password) and add a phone number if missing.

### Admin Interface
Admins access a separate dashboard with functionalities including:
- **Change:**  
  - Edit book details (title, author, category, photo).
  - Delete books and add fines to a customer.
- **Add Book:**  
  - Add a new book by selecting a photo, entering the title, author, choosing a category, and indicating if it’s for adults.
- **Fines Information:**  
  - View all customer fines with the ability to search by customer name.
  - Delete fines as needed.
- **Customer Information:**  
  - View detailed customer information (name, email, total fines, total requisitions).
  - Option to delete customer accounts.

### Fines Management
- **Fine Record Details:**  
  - Each fine record stores the user ID, book ID, cost, the due date (from the corresponding requisition), an optional delivery date (set as NULL if the book has not been returned), and the date the fine was added.
- **Automatic Increment:**  
  - Each time a fine is added, the system increments the `fines` field in the user's record by 1.
  
### Database Structure
The MySQL database consists of 6 interconnected tables:
- **Users:** Contains user data (name, email, password, date of birth, profile image, fines count, favorite book, phone number, etc.).  
  *Note: Admin users are distinguished by the `is_adm` field (0 for customers, 1 for admins).*
- **Books:** Stores book details (title, author, category_id, image, adult flag).
- **Categories:** Lists all available book categories.
- **Stores:** Contains store data, including the available stock of each book.
- **Requisitions:** Tracks book requisitions by users, including request and due dates.
- **Fines:** Records fines with details like cost, due date, delivery date (nullable), and the date the fine was added (`date_fine`).

## FAQ

**Q: Where is the store information added for a new book?**  
**A:** Currently, the store information is automatically determined by the store that receives the book. This functionality may be expanded in future updates.

**Q: How are multiple stores handled for a book?**  
**A:** When a book is available in multiple stores, all associated stores are listed in a ComboBox. Changing the selected store automatically updates the displayed stock level.

**Q: What happens if the delivery date is left empty when adding a fine?**  
**A:** If the delivery date fields are left empty, the `date_delivered` is stored as NULL, indicating that the book has not yet been returned. Additionally, the fine record includes `date_fine` which captures the date the fine was added.

**Q: How does fine management work?**  
**A:** When a fine is added, the system:
- Inserts a record into the `fines` table with the corresponding details.
- Automatically increments the user's `fines` count by 1.

## Screenshots

### General Forms
<div align="center">
  <img src="![image](https://github.com/user-attachments/assets/683958c1-8317-4ac5-b407-c092d5fe13ff)
" alt="Sign In" width="300" style="margin: 10px;"/>
  <img src="![image](https://github.com/user-attachments/assets/15f02873-8939-425b-a5b6-5243019a6499)
" alt="Sign Up" width="300" style="margin: 10px;"/>
</div>

### Customer Interface
<div align="center">
  <img src="![image](https://github.com/user-attachments/assets/1df1a7cc-c8a3-40ac-a219-930361e32fd7)
" alt="Customer Dashboard" width="300" style="margin: 10px;"/>
  <img src="![image](https://github.com/user-attachments/assets/efe99cd3-7cb5-4845-a656-bf28ac3c805f)
" alt="Explore Books" width="300" style="margin: 10px;"/>
  <img src="![image](https://github.com/user-attachments/assets/cb1aaa86-73e2-4c80-9b94-d56ce5674017)
" alt="Requisition Book" width="300" style="margin: 10px;"/>
  <img src="![image](https://github.com/user-attachments/assets/3f59f2c5-64a9-408a-8448-50a4d2827d33)
" alt="Customer Profile" width="300" style="margin: 10px;"/>
</div>

### Admin Interface
<div align="center">
  <img src="![image](https://github.com/user-attachments/assets/165a9855-c74d-45e7-be27-dd690f3a673e)
" alt="Admin Dashboard" width="300" style="margin: 10px;"/>
  <img src="![image](https://github.com/user-attachments/assets/83fdfc4a-3704-40d9-b972-44171cfc704f)
" alt="Edit Book" width="300" style="margin: 10px;"/>
  <img src="![image](https://github.com/user-attachments/assets/55f8bf69-de2e-45e1-9c70-deae454afbc2)
" alt="Add Book" width="300" style="margin: 10px;"/>
  <img src="![image](https://github.com/user-attachments/assets/04181820-b61f-4893-9a53-a1ae1f749c80)
" alt="Fines Information" width="300" style="margin: 10px;"/>
  <img src="![image](https://github.com/user-attachments/assets/2fb96029-6b92-4c76-a73b-5457cf470de5)
" alt="Customer Information" width="300" style="margin: 10px;"/>
</div>

### Data Base
<div align="center">
  <img src="![bd](https://github.com/user-attachments/assets/cad7edf6-4220-4929-baa4-ef546331a14d)" alt="Admin Dashboard" width="300" style="margin: 10px;"/>
</div>

## How to Run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Ensure MySQL is installed and update the connection string in the database connection class.
4. Build and run the solution.

## FAQ & Troubleshooting

**Q: Where is the store added for a new book?**  
**A:** Initially, the store is determined by the store that receives the book. Future updates may include a dedicated function for managing store assignments.

**Q: How does the system handle multiple stores for a book?**  
**A:** All stores associated with a book are displayed in a ComboBox. Selecting a different store updates the stock information automatically.

**Q: What if the delivery date is not provided when adding a fine?**  
**A:** The delivery date will be stored as NULL, indicating the book has not been returned yet. A separate `date_fine` field records when the fine was added.

**Q: How is the user's fines count updated?**  
**A:** Each time a fine is added, the system increments the `fines` field in the user's record by 1.
