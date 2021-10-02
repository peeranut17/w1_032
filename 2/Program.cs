using System;
using System.Collections;
using System.Collections.Generic;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {   
            _main(new List<Dictionary<string, string>>());                                  // สร้างคลัง Data ขึ้นมา (List ที่มี Dict ข้างใน) และนำไปรันต่อในฟังก์ชัน Main อันใหม่
        }

        static void _main(List<Dictionary<string, string>> data)                            // สร้างหน้า Main ใหม่ขึ้นมาอีกอันหนึ่ง
        {
            Console.Clear();                                                                // เคลียร์ Console เพื่อความสะอาดตาก่อน
            Console.WriteLine("Welcome to Digital Library");                                // Display หน้า Welcome
            Console.WriteLine("--------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine();
            Console.Write("Select Menu: ");                                                 // บอกให้ user กรอก mode ของ Menu
            string mode = Console.ReadLine();                                               // ดักจับ mode จาก Readline

            if (mode == "1") {                                                              // ถ้า mode คือ 1 หรือเป็นการเข้าสู่หน้า Login
                login(data);                                                                // เข้าสู่ฟังก์ชัน Login
            } else if (mode == "2") {                                                       // ถ้า mode คือ 1 หรือเป็นการเข้าสู่หน้า Login
                register(data);                                                             // เข้าสู่ฟังก์ชัน Register
            } else {                                                                        // แต่ถ้าไม่ใช่ ทั้ง 2 โหมด
                System.Environment.Exit(0);                                                 // ออกจากการทำงาน
            }
        }
        
        static void login(List<Dictionary<string, string>> data)                            // ฟังก์ชัน Login
        {
            Console.Clear();                                                                // เคลียร์ Console เพื่อความสะอาดตา
            Console.WriteLine("Login Screen");                                              // Display หน้า Login
            Console.WriteLine("------------");
            Console.WriteLine();
            
            Console.Write("Input name: ");                                                  // บอกให้ user กรอก name เพื่อ Login
            string user = Console.ReadLine();                                               // ดักจับ username จาก Readline

            Console.Write("Input Password: ");                                              // บอกให้ user กรอก password เพื่อ Register 
            string passs = Console.ReadLine();                                              // ดักจับ password จาก Readline

            for (int i = 0; i < data.Count; i++) {                                          // ลูปเข้าไปยัง ข้อมูลผู้ใช้ทั้งหมด ในคลัง Data
                if (user == data[i]["name"] && passs == data[i]["password"]) {              // ถ้า username มีอยู่ในคลัง Data และ password ถูกต้อง
                    menu(data[i]);                                                          // จะเข้าสู่หน้าหน้าเมนู
                }
            }
            _main(data);                                                                    // แต่ถ้า username ไม่มีในระบบ หรือ password ไม่ถูกต้อง จะกลับสู่ฟังก์ชัน Main
        }
        
        static void register(List<Dictionary<string, string>> data)                         // ฟังก์ชัน Register
        {
            Console.Clear();                                                                // เคลียร์ Console เพื่อความสะอาดตา
            Console.WriteLine("Register new Person");                                       // Display หน้า Register
            Console.WriteLine("-------------------");
            Console.WriteLine();

            Console.Write("Input name: ");                                                  // บอกให้ user กรอก name เพื่อ Register
            string name = Console.ReadLine();                                               // ดักจับ name จาก Readline

            Console.Write("Input Password: ");                                              // บอกให้ user กรอก password เพื่อ Register
            string password = Console.ReadLine();                                           // ดักจับ password จาก Readline

            Console.Write("Input User Type (1 = Student, 2 = Employee): ");                 // บอกให้ user กรอก type ของ user
            string type = Console.ReadLine();                                               // ดักจับ type จาก Readline
            if (type != "1" && type != "2") _main(data);                                    // ถ้า type ไม่ใช่ 1 หรือ 2 จะกลับไปหน้า Main

            Console.Write("Student ID: ");                                                  // บอกให้ user กรอก id ของ user
            string studentid = Console.ReadLine();                                          // ดักจับ id จาก Readline

            var thisinfo = new Dictionary<string, string>();                                // สร้าง Dict ใหม่ เพื่อเก็บข้อมูล user
            thisinfo.Add("name", name);                                                     // เพิ่ม name ลงใน Dict
            thisinfo.Add("type", type);                                                     // เพิ่ม type ลงใน Dict
            thisinfo.Add("password", password);                                             // เพิ่ม password ลงใน Dict
            thisinfo.Add("studentid", studentid);                                           // เพิ่ม id ลงใน Dict

            data.Add(thisinfo);                                                             // เพิ่ม Dict ของมูลของ user ลงใน List
            _main(data);                                                                    // กลับสู่ฟังก์ชัน Main
        }

        static void menu(Dictionary<string, string> datainfo)                               // ถ้า Login ผ่านมาได้ จะเข้าสู่หน้า Menu นั่นคือฟังก์ชันนี้
        {
            Console.Clear();                                                                // เคลียร์ Console เพื่อความสะอาดตา
            if (datainfo["type"] == "1") {                                                  // ถ้า type ของ user คือ Student
                Console.WriteLine("Student Management");                                    // Display ข้อมูล ของ user
                Console.WriteLine("------------------");
                Console.WriteLine();
                Console.WriteLine("Name: " + datainfo["name"]);                             // ดึง name ออกมากจาก Data เพื่อเอามาแสดงผล
                Console.WriteLine("Student ID: " + datainfo["studentid"]);                  // ดึง id ออกมากจาก Data เพื่อเอามาแสดงผล
                Console.WriteLine();
                Console.WriteLine("------------------");
                Console.WriteLine("1. Borrow Book");

                Console.Write("Input Menu: ");                                              // บอกให้ user กรอก mode ของ Menu
                string mode = Console.ReadLine();                                           // ดักจับ mode จาก Readline

                if (mode == "1") {                                                          // ถ้า mode คือ 1 หรือเป็นการเข้าสู่หน้า Borrow Book
                    var booklist = new List<Dictionary<string, string>>();                  // สร้างคลัง Data ขึ้นมาใหม่อีกอัน (List ที่มี Dict ข้างใน) เอาไว้
                    studentmenu(datainfo, booklist);                                        // ไปยังฟังก์ชัน ยืมหนังสือ พร้อมส่งคลังข้อมูลทั้งหมดไปด้วย
                } else {                                                                    // แต่ถ้า mode ไม่ใช่ 1
                    _main(new List<Dictionary<string, string>>());                          // จะกลับสู่ฟังก์ชัน Main
                }
            }
            if (datainfo["type"] == "2") {                                                  // ถ้า type ของ user คือ Employee
                Console.WriteLine("Employee Management");                                   // Display ข้อมูล ของ user
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Name: " + datainfo["name"]);                             // ดึง name ออกมากจาก Data เพื่อเอามาแสดงผล
                Console.WriteLine("Employee ID: " + datainfo["studentid"]);                 // ดึง id ออกมากจาก Data เพื่อเอามาแสดงผล
                Console.WriteLine();
                Console.WriteLine("------------------");
                Console.WriteLine("1. Get List Books");

                Console.Write("Input Menu: ");                                              // บอกให้ user กรอก mode ของ Menu
                string mode = Console.ReadLine();                                           // ดักจับ mode จาก Readline

                if (mode == "1") {                                                          // ถ้า mode คือ 1 หรือเป็นการเข้าสู่หน้า Get List Books
                    empmenu();                                                              // จะไปยังฟังก์ชัน Employee Menu
                } else {                                                                    // แต่ถ้า mode ไม่ใช่ 1
                    _main(new List<Dictionary<string, string>>());                          // จะกลับสู่ฟังก์ชัน Main
                }
            }
        }

        static void studentmenu(Dictionary<string, string> datainfo, List<Dictionary<string, string>> booklist) // ฟังก์ชัน ยืมหนังสือ ของ Student
        {

            Console.Clear();                                                                // เคลียร์ Console เพื่อความสะอาดตา
            Console.WriteLine("Book List");                                                 // Display หน้ายืมหนังสือ
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("Book ID: 1");
            Console.WriteLine("Book name: NOW I UNDERSTAND");
            Console.WriteLine("Book ID: 2");
            Console.WriteLine("Book name: REVOLUTIONARY WEALTH");
            Console.WriteLine("Book ID: 3");
            Console.WriteLine("Book name: Six Degrees");
            Console.WriteLine("Book ID: 4");
            Console.WriteLine("Book name: Les Vacances");
            Console.WriteLine();

            Console.Write("Input book ID: ");                                               // บอกให้ user กรอก id ของ หนังสือที่ต้องการจะยืม
            string input_book_id = Console.ReadLine();                                      // ดักจับ id จาก Readline

            if (input_book_id == "1") {                                                     // ถ้า id ของ หนังสือ คือ 1
                var thisbookinfo = new Dictionary<string, string>();                        // จะสร้าง dict ขึ้นมาใหม่
                thisbookinfo.Add("book_id", "1");                                           // และใส่ข้อมูลของหนังสือ id 1 ลงไป
                thisbookinfo.Add("book_name", "NOW I UNDERSTAND");
                booklist.Add(thisbookinfo);                                                 // และเพิ่มไปยังคลังข้อมูลของหนังสือ
                studentmenu(datainfo, booklist);                                            // และรันฟังก์ชันเดิมซ้ำ แต่ส่งข้อมูลของ user และหนังสือทั้งหมดไปด้วย
            }
            if (input_book_id == "2") {                                                     // ทำซ้ำ เหมือนอันก่อนหน้านี้
                var thisbookinfo = new Dictionary<string, string>();
                thisbookinfo.Add("book_id", "2");
                thisbookinfo.Add("book_name", "REVOLUTIONARY WEALTH");
                booklist.Add(thisbookinfo);
                studentmenu(datainfo, booklist);
            }
            if (input_book_id == "3") {                                                     // ทำซ้ำ เหมือนอันก่อนหน้านี้
                var thisbookinfo = new Dictionary<string, string>();
                thisbookinfo.Add("book_id", "3");
                thisbookinfo.Add("book_name", "Six Degrees");
                booklist.Add(thisbookinfo);
                studentmenu(datainfo, booklist);
            }
            if (input_book_id == "4") {                                                     // ทำซ้ำ เหมือนอันก่อนหน้านี้
                var thisbookinfo = new Dictionary<string, string>();
                thisbookinfo.Add("book_id", "4");
                thisbookinfo.Add("book_name", "Les Vacances");
                booklist.Add(thisbookinfo);
                studentmenu(datainfo, booklist);
            }
            if (input_book_id == "exit") {                                                  // ถ้า id ของหนังสือ คือ exit
                studentdisplay(datainfo, booklist);                                         // จะเข้าสู่ฟังก์ชัน แสดงผลข้อมูล ของ user และหนังสือที่ยืม
            }
            else {                                                                          // แต่ถ้า id ของหนังสือ ไม่ใช่ทั้งหมดที่ผ่านมา
                studentmenu(datainfo, booklist);                                            // ก็จะรันฟังก์ชันเดิมซ้ำ
            }
        }

        static void studentdisplay(Dictionary<string, string> datainfo, List<Dictionary<string, string>> booklist)  // ฟังก์ชัน แสดงผลข้อมูล ของ user และหนังสือที่ยืม สำหรับ Student
        {
            Console.Clear();                                                                // เคลียร์ Console เพื่อความสะอาดตา
            Console.WriteLine("Student name: " + datainfo["name"]);                         // ดึง name ออกมากจาก Data เพื่อเอามาแสดงผล
            Console.WriteLine("Student ID: " + datainfo["studentid"]);                      // ดึง id ออกมากจาก Data เพื่อเอามาแสดงผล
            Console.WriteLine();
            Console.WriteLine("Book List");
            Console.WriteLine("---------");
            Console.WriteLine();
            for (int i = 0; i < booklist.Count; i++) {                                      // ลูปเข้าไปยังข้อมูลของหนังสือทั้งหมดที่ user ยืมมา ทีละ Dict
                Console.WriteLine("Book ID: " + booklist[i]["book_id"]);                    // ดึง Book ID ออกมากจาก dict ของหนังสือเล่มนั้น เพื่อเอามาแสดงผล
                Console.WriteLine("Book name: " + booklist[i]["book_name"]);                // ดึง Book name ออกมากจาก dict ของหนังสือเล่มนั้น เพื่อเอามาแสดงผล
            }
            Console.WriteLine();
            System.Environment.Exit(0);                                                     // ออกจากการทำงาน
        }

        static void empmenu()                                                               // ฟังก์ชัน แสดงผลข้อมูลหนังสือทั้งหมด สำหรับ Employee
        {
            Console.Clear();                                                                // เคลียร์ Console เพื่อความสะอาดตา
            Console.WriteLine("Book List");                                                 // แสดงผลลิตส์หนังสือทั้งหมด
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("Book ID: 1");
            Console.WriteLine("Book name: NOW I UNDERSTAND");
            Console.WriteLine("Book ID: 2");
            Console.WriteLine("Book name: REVOLUTIONARY WEALTH");
            Console.WriteLine("Book ID: 3");
            Console.WriteLine("Book name: Six Degrees");
            Console.WriteLine("Book ID: 4");
            Console.WriteLine("Book name: Les Vacances");
            Console.WriteLine();
            System.Environment.Exit(0);                                                     // ออกจากการทำงาน
        }
    }
}
