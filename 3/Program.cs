using System;
using System.Collections;
using System.Collections.Generic;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            _main(new List<string>());                                                  // สร้าง List ขึ้นมาใหม่ ไว้สำหรับใส่ข้อมูลดอกไม้ และนำไปรันต่อในฟังก์ชัน Main อันใหม่
        }

        static void _main(List<string> data)
        {
            Console.Clear();                                                            // เคลียร์ Console เพื่อความสะอาดตา
            Console.WriteLine("Welcome to flower store.");                              // แสดงผล หน้า Welcome ของโปรแกรม
            Console.WriteLine("------------------------");
            Console.WriteLine("*your can finish this shopping by type 'exit'*");
            Console.WriteLine();
            Console.WriteLine("Flower List:");
            Console.WriteLine("1. Rose");
            Console.WriteLine("2. Lotus");
            Console.WriteLine();
            Console.Write("Select number for buy Flower : ");                           // บอกให้ user กรอก num ของ ของดอกไม้ที่ต้องการ
            string num = Console.ReadLine();                                            // ดักจับ user จาก Readline

            if (num == "1") {                                                           // ถ้า num คือ 1
                data.Add("Rose");                                                       // จะเพิ่ม Rose ไปยัง List
                _main(data);                                                            // และนำไปรันฟังก์ชันเดิมใหม่
            } else if (num == "2") {                                                    // ถ้า num คือ 2
                data.Add("Lotus");                                                      // จะเพิ่ม Lotus ไปยัง List
                _main(data);                                                            // และนำไปรันฟังก์ชันเดิมใหม่
            } else if (num == "exit") {                                                 // ถ้า num คือ exit
                display(data);                                                          // จะแสดงผลข้อมูลของดอกไม้ทั้งหมดที่ user ได้เลือกไว้
            } else {                                                                    // แต่ถ้าไม่ใช้ทั้งหมดที่กล่าวมา
                _main(data);                                                            // ก็ไปรันฟังก์ชันเดิมใหม่อยู่ดี
            }
        }

        static void display(List<string> data)                                          // ฟังก์ชัน แสดงผลข้อมูล
        {
            Console.Clear();                                                            // เคลียร์ Console เพื่อความสะอาดตา
            Console.WriteLine("Thank you for your shopping");                           // แสดงผล หน้าขอบคุณที่ใช้บริการ
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine("This is total Flowers in your cart : ");                 // แสดงผลดอกไม้ทั้งหมดที่เราเลือกไว้
            foreach (string i in data) {                                                // โดยการลูปเข้าไปใน List
                Console.WriteLine(i);                                                   // และแสดงผลข้อมูลทั้งหมด
            }
            Console.WriteLine();
            System.Environment.Exit(0);                                                 // จบการทำงาน
        }
    }
}
