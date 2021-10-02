using System;
using System.Collections.Generic;

namespace _1
{
    class Program
    {   
        static void Main(string[] args)
        {   
            Console.Clear();                                                    // เคลียร์ Console เพื่อความสะอาดตาก่อน
            Console.WriteLine("Welcome to Hangman Game");                       // Display หน้า Welcome ของเกม
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("1. Play game");
            Console.WriteLine("2. Exit");
            Console.WriteLine();
            Console.Write("Please Select Menu: ");                              // บอกให้ user กรอก mode ของ Menu
            string mode = Console.ReadLine();                                   // ดักจับ mode จาก Readline

            if (mode == "1") {                                                  // ถ้า mode คือ 1 หรือเป็นการเริ่มเล่นเกม
                play();                                                         // เข้าสู่ฟังก์ชันการเล่นเกม
            } else {                                                            // ถ้า mode ไม่ใช่ 1
                System.Environment.Exit(0);                                     // ออกจากการทำงาน
            }
        }

        static void play()                                                      // ฟังก์ชันนี้ เป็นการเตรียมข้อมูลต่างๆ ก่อนจะเริ่มเล่นเกม
        {
            var words = new List<string>() {
                "Tennis", "Football", "Badminton"                               // กำหนดคำทั้งหมดที่จะ Random ออกมา
            };
            
            Random random = new Random();                       
            int resultRamdom = random.Next(words.Count);
            string word = words[resultRamdom];                                  // Random คำออกมา

            var all_char_ = word.ToCharArray();                                 // แยก Char ของคำนั้นๆออกมา เป็น CharArray
            var all_char = new List<string>();                                  // เช่น ถ้าเป็นคำว่า "Tennis" ก็จะกลายเป็น List
            for (int i = 0; i < all_char_.Length; i++) {                        // ในรูปแบบดังนี้ => ["T","e","n","n","i","s"]
                all_char.Add(all_char_[i].ToString());                          // และยัด Char ทั้งหมด ใส่ List เพื่อที่จะได้ Modify ทีหลังได้
            }

            int correct_count = 0;                                              // กำหนด ค่า Default ของจำนวนครั้งที่ใส่ตัวอักษรถูก
            int incor_count = 0;                                                // กำหนด ค่า Default ของจำนวนครั้งที่ใส่ตัวอักษรผิด

            realplay(word, all_char, correct_count, incor_count);               // นำค่าทั้งหมดที่ได้ ไปเข้าสู่ฟังก์ชันเริ่มเล่นเกม
        }

        static void realplay(string word, List<string> all_char, int correct_count, int incor_count)
        {   
            Console.Clear();                                                    // เคลียร์ Console เพื่อความสะอาดตา
            Console.WriteLine("Play Game Hangman");                             // Display หน้าเล่นเกม
            Console.WriteLine("-----------------");
            Console.WriteLine();
            Console.WriteLine("Incorrect Score: " + incor_count);               // Display จำนวนครั้งที่ผิดทั้งหมด
            Console.WriteLine(gen_display(word, all_char));                     // Generate หน้าเล่นเกม ในส่วนของคำ (ใช้ฟังก์ชันแยกอีกที)
            Console.WriteLine();
            if (correct_count < (word.ToCharArray()).Length) {
                Console.Write("Input letter alphabet: ");                       // บอกให้ user กรอก Character
                string input = Console.ReadLine();                              // ดักจับ Character ที่ user กรอก จาก Readline
                if (all_char.Contains(input)) {                                 // ถ้า user กรอก Charac ที่อยู่ใน All Character list ของ word
                    correct_count += 1;                                         // จะเพิ่ม จำนวนครั้งที่ใส่ตัวอักษรถูก ไป 1 ครั้ง
                    for (int i = 0; i < all_char.Count; i++) {                  // ลูปเข้าไปใน All Character list
                        if (all_char[i] == input) {                             // ถ้า Charac ที่ user กรอกเข้ามา อยู่ในตัวอักษรสักตัว ของ All Character list ใน word
                            all_char[i] = "_";                                  // จะเปลี่ยน Charac ใน word ตัวนั้น เป็น "_" (เพื่อความสะดวกในการ Generate ในครั้งถัดไป)
                            break;                                              // จบการลูป ไว้ที่แค่ Charac ตัวเดียวพอ
                        }
                    }
                    realplay(word, all_char, correct_count, incor_count);       // นำข้อมูลทั้งหมด กลับไปเล่นอีกครั้ง จนกว่าจะครบทุก Character ของ word
                } else {                                                        // แต่ถ้า user กรอก Charac ที่ไม่ได้อยู่ใน All Character list ของ word
                    incor_count += 1;                                           // จะเพิ่ม จำนวนครั้งที่ใส่ตัวอักษรถูก ไป 1 ครั้ง
                    realplay(word, all_char, correct_count, incor_count);       // และนำข้อมูลทั้งหมด กลับไปเล่นอีกครั้ง จนกว่าจะครบทุก All Character list ของ word
                }
            } else if (correct_count == (word.ToCharArray()).Length) {          // แต่ถ้า จำนวนครั้งที่ใส่ตัวอักษรถูก เท่ากับ จำนวน All Character list ทั้งหมด ของ word
                Console.WriteLine("Input letter alphabet: ");
                Console.WriteLine();
                Console.WriteLine("You win!!");                                 // คุณชนะแล้ว!!
                System.Environment.Exit(0);                                     // ออกจากการทำงาน
            }
        }

        static string gen_display(string word, List<string> all_char)           // ฟังก์ชัน Generate หน้าเล่นเกม ในส่วนของคำ
        {   
            var gen = new List<string>();                                       // สร้าง List ขึ้นมาใหม่ เอาไว้ใส่คำที่คัดแยกออกมาอีกที
            for (int i = 0; i < all_char.Count; i++) {                          // ลูปเข้าไปใน All Character list ทีละตัว เพื่อคัดแยกคำ
                if (word.ToCharArray()[i].ToString() == all_char[i]) {          // ถ้า Charac ตัวนั้น ไม่ใช่ Charac ใหม่ ที่ user กรอกมา
                    gen.Add("_");                                               // จะเพิ่ม "_" ลงใน List
                    gen.Add(" ");                                               // และเพิ่ม " " (เว้นวรรค) เพื่อความสวยงาม
                } else {                                                        // แต่ถ้า Charac ตัวนั้น เป็น Charac ใหม่ ที่ user กรอกมา
                    gen.Add(word.ToCharArray()[i].ToString());                  // จะเพิ่มตัวอักษรจริงๆ ของ word ลงไปในลิสต์
                    gen.Add(" ");                                               // และเพิ่ม " " (เว้นวรรค) เพื่อความสวยงาม
                }
            }
            return string.Join("", gen);                                        // return กลับไปเป็น string โดยการเอา List มา Join รวมกัน
        }
    }
}
