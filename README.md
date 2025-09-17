# 🍎 Fruit List Management System (C# Windows Forms)

![C#](https://img.shields.io/badge/C%23-.NET%20Framework-blue?logo=csharp&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green)

## 📖 Project Overview
This project is developed as part of **EKT224 – Algorithm and Data Structures (Semester 1, 2020/2021)**.
It is a **C# Windows Forms application** that manages a list of products (fruits) stored in a text file.  
The system supports operations such as **insertion, deletion, editing, saving, clearing all, and sorting**.  

---

## ✨ Features
- **Load Data**: Reads an initial list of 30 fruits from a text file.  
- **Sorting**: Automatically maintains ascending order when items are added, edited, or deleted.  
- **Insert**: Add new fruit into the list dynamically.  
- **Edit**: Modify existing items and update the sorted list.  
- **Delete**: Remove specific items from the list.  
- **Clear All**: Option to delete all items at once.  
- **Save**: Save the updated list back into the file.  
- **Validation**: Displays warnings when the input is empty or invalid.  

---

## 🏗️ System Flow
1. Load fruit list from text file.  
2. Display items in ascending order.  
3. User can perform operations: `Add`, `Edit`, `Delete`, `Clear All`.  
4. Save results back to file.  

---

## ⚙️ Technical Details
- **Language**: C#  
- **Framework**: Windows Forms (.NET)  
- **Data Structure**: `List<T>` (ArrayList-like behavior)  
- **File Handling**: Uses `StreamReader` and `StreamWriter` for persistence.  

---

## 📊 Algorithm & Complexity
- **Sorting Algorithm**: Maintains ascending order with array-based sorting.  
- **Insertion**: `O(n)` worst case, `O(1)` best case.  
- **Deletion**: `O(n)` worst case, `O(1)` best case.  
- **Access by Index**: `O(1)` constant time.  

---

## 🔍 Example Scenarios
- **Insert Durian** → Appears in correct alphabetical order.  
- **Delete Cranberries** → Item disappears and list reorders.  
- **Edit Apple → Apricot** → Updates list and re-sorts.  
- **Clear All** → Removes all fruits and shows empty message.  
- **Save** → Final list stored into text file.  

---

## 🚀 Setup & Usage
1. Open the project in Visual Studio.
2. Run the application (Windows Forms App).
3. Ensure the test_file.txt (with 30 fruits) is in the correct directory.

---

4. 📈 Limitations
- Insertion & Deletion: Slower in worst cases (O(n)) due to ArrayList-like shifting.
- Not Optimized for Large Data: Works best for small to medium datasets.

---

🔮 Possible Enhancements
- Switch from List<T> to LinkedList for faster insert/delete (O(1)).
- Add search functionality (binary search).
- Improve UI/UX with modern .NET (WPF or .NET MAUI).
- Add unit tests for reliability.
- Implement error logging.
- 
---

## 📜 **License**
This project is licensed under the [MIT License](./LICENSE).
