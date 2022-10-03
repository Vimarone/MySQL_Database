using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;

namespace DbDbDip
{
    class Program
    {
        static void Main(string[] args)
        {
            // "Server=서버IP; Port=포트번호; Database=데이터베이스명; Uid=접속계정아이디; Pwd=패스워드"
            // 원격 서버일 경우 IP 주소가 들어가는게 맞지만, 로컬 서버일 경우 localhost로 한다
            {
                //using (MySqlConnection connection = new MySqlConnection(connectInfoText))
                //{
                //    try
                //    {
                //        connection.Open();
                //        { 
                //            //string sql = "SELECT * FROM studentinfo";
                //            //MySqlCommand cmd = new MySqlCommand(sql, connection);
                //            //MySqlDataReader table = cmd.ExecuteReader();

                //            ////table.Read(); // 첫 번째꺼 하나만 가져오기
                //            ////Console.WriteLine("ID : {0}, name : {1}", table["STU_ID"], table["Name"]);
                //            ////table.Close();

                //            //int count = 0;
                //            //while (table.Read())
                //            //{
                //            //    Console.WriteLine("ID : {0, 6}, name : {1, 5}, Gender : {2, 1}\n, " +
                //            //        "1학년 1학기 중간고사 평균 : {3:##.#}\t, 1학년 1학기 기말고사 평균 : {4:##.#}\n, " +
                //            //        "1학년 2학기 중간고사 평균 : {5:##.#}\t, 1학년 2학기 기말고사 평균 : {6:##.#}\n" + 
                //            //        "================================================================"
                //            //        , table["STU_ID"], table["Name"], table["Gender"],
                //            //        table["F_1S_M_Average"], table["F_1S_L_Average"], table["F_2S_M_Average"], table["F_2S_L_Average"]);
                //            //    // if(++count % 5 == 0)
                //            //    //      Console.WriteLine("=================================");
                //            //    table.Close();
                //            //}
                //        }
                //        {
                //            //string insertQuery = "INSERT INTO studentinfo(STU_ID, Name, Gender, " +
                //            //    "F_1S_M_Average, F_1S_L_Average, F_2S_M_Average, F_2S_L_Average," +
                //            //    "S_1S_M_Average, S_1S_L_Average, S_2S_M_Average, S_2S_L_Average," +
                //            //    "T_1S_M_Average, T_1S_L_Average, T_2S_M_Average, T_2S_L_Average)" +
                //            //    "VALUES(221349,'조연', '여', 79.8, 88.5, 87.2, 92.4, 0, 0, 0, 0, 0, 0, 0, 0)";
                //            //MySqlCommand cmd = new MySqlCommand(insertQuery, connection);
                //            //if (cmd.ExecuteNonQuery() == 1)
                //            //    Console.WriteLine("Insert Success");
                //            //else
                //            //    Console.WriteLine("Insert Failed");
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine("실패!!");
                //        Console.WriteLine(ex.ToString());
                //    }
                //}
            }
            {
                //MyDBManager troopDBM = new MyDBManager("troop");
                //string tableName = "kingdom_leaf";
                //troopDBM.CreateTable(tableName);
                //troopDBM.AddColumn(tableName, "Name", "VARCHAR(12)", true, true, true);
                //troopDBM.AddColumn(tableName, "Job", "VARCHAR(8)", false, true, false);
                //troopDBM.AddColumn(tableName, "Lev", "INT", false, false, false, true, true);
                //troopDBM.AddColumn(tableName, "Pow", "INT", false, false, false, true, true);

                //string colQuery = "Name, Job, Lev, Pow";
                //troopDBM.Insert(tableName, colQuery, "'카미오', '소드맨', 145, 3869330");
                //troopDBM.Insert(tableName, colQuery, "'슬라임맛물고기', '위치', 151, 3970836");
                //troopDBM.Insert(tableName, colQuery, "'정피치', '로그', 140, 3724243");
                //troopDBM.Insert(tableName, colQuery, "'비셰인', '위치', 139, 3568418");
                //troopDBM.Insert(tableName, colQuery, "'연꽃뿌리', '엔지니어', 136, 3536269");
                //troopDBM.Insert(tableName, colQuery, "'복붙', '디스트로이어', 135, 3202364");
                //troopDBM.Insert(tableName, colQuery, "'붉은래서판다', '로그', 133, 3135773");
                //troopDBM.Insert(tableName, colQuery, "'에스테이아', '엔지니어', 126, 2718311");
                //troopDBM.Insert(tableName, colQuery, "'후냐의선장', '디스트로이어', 130, 2699024");
                //troopDBM.Insert(tableName, colQuery, "'레냐냥', '엔지니어', 128, 2524253");


                //troopDBM.Select(tableName);
            }


            #region Insert 함수용
            MyDBManager myDBM = new MyDBManager("score");

            myDBM.LoginSequence();
            //if (myDBM.LoginSequence())
            //{
            //    myDBM.Run();
            //}
            //myDBM.SelectTable();
            //myDBM.TerminateConnection();
            #endregion

            #region Thread 사용법
            //Thread dumpThread = new Thread(DumpFunc);
            //dumpThread.Start(myDBM);
            //for(int n = 0; n < 26; n++)
            //{
            //    Console.WriteLine(n);
            //    //Thread.Sleep(100);
            //}
            //Console.WriteLine("종료합니다.");

            #endregion



            Console.ReadKey();
        }

        static void DumpFunc(object manager)
        {
            MyDBManager dbM = (MyDBManager)manager;

            char ch = 'a';
            for(int n = 0; n < 26; n++)
            {
                Console.WriteLine((char)(ch + n));
                //Thread.Sleep(100);
            }
        }

        
    }
}
