using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;

namespace DbDbDip
{
    public struct Users
    {
        public string _id { get; }
        public string _pw { get; }
        public Users(string id, string pw)
        {
            _id = id;
            _pw = pw;
        }
    }

    public class Student
    {
        public int id;
        public string name;
        public string gender;

        public float ffm;
        public float ffl;
        public float fsm;
        public float fsl;
        public float sfm;
        public float sfl;
        public float ssm;
        public float ssl;
        public float tfm;
        public float tfl;
        public float tsm;
        public float tsl;
    }

    

    class MyDBManager
    {
        MySqlConnection _connection;
        string _dbName;
        eTableName _tbName = eTableName.NULL;
        const string male = "'남'";
        const string female = "'여'";
        bool _isRun;

        public MyDBManager(string dbName)
        {
            _dbName = dbName;
        }

        public bool LoginSequence()
        {
            if (_dbName != string.Empty)
            {
                Console.Write("아이디를 입력하세요 : ");
                string id = Console.ReadLine();
                Console.Write("비밀번호를 입력하세요 : ");
                string pw = Console.ReadLine();

                ConnectDB(id, pw);
                return true;
            }
            else
            {
                Console.WriteLine("로그인 불가 : MyDBManager의 생성자가 호출되지 않았습니다.");
                LoginSequence();
            }
            return false;
        }

        // DB에 연결
        public bool ConnectDB(string id, string pw)
        {
            try
            {
                _connection = new MySqlConnection("Server=" + DefineValue._baseLocalIP+";Port="+DefineValue._port+";Database=" + _dbName + ";Uid=" + id + ";Pwd=" + pw) ;
                _connection.Open();
                _isRun = true;
                Console.WriteLine("DB 접속에 성공했습니다.");
                SelectTable();
                return true;
            }
            catch
            {
                Console.WriteLine("DB 접속 실패 : ID 혹은 PW 확인 바랍니다.");
                return false;
            }
        }

        public void SelectTable()
        {
            if (_dbName != string.Empty)
            {
                Console.Write("1. studentinfo \n2. novis_gura \n3. 종료 \n테이블을 선택하세요 : ");
                string selection = Console.ReadLine();
                int selectNum;
                if (int.TryParse(selection, out selectNum))
                {
                    switch (selectNum)
                    {
                        case 1:
                            _tbName = eTableName.studentinfo;
                            SelectAction();
                            break;
                        case 2:
                            _tbName = eTableName.novice_gura;
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            SelectTable();
                            break;
                    }
                }
                else
                    SelectTable();
            }
            else
                Console.WriteLine("테이블 선택 불가 : 데이터베이스가 선택되지 않았습니다.");
        }

        public void SelectAction()
        {
            if (_tbName != eTableName.NULL)
            {
                Console.Write("1. 삽입 \n2. 수정 \n3. 검색 \n4. 종료 \n 무엇을 하시겠습니까 : ");
                string selection = Console.ReadLine();
                int selectNum;
                if (int.TryParse(selection, out selectNum))
                {
                    switch (selectNum)
                    {
                        case 1:
                            Insert();
                            break;
                        case 2:
                            Update();
                            break;
                        case 3:
                            // Where();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            SelectAction();
                            break;
                    }
                }
                else
                    SelectTable();
            }
            else
                Console.WriteLine("기능 선택 불가 : 테이블이 선택되지 않았습니다.");
        }
        // DB 연결 종료
        public void TerminateConnection()
        {

        }

        // Main Process
        public void Run()
        {
            Console.Clear();
            while (_isRun)
            {
                Thread.Sleep(3000); // 3초에 한번 반응

                // 입력 처리
                // 임시
                // 학생 정보 한명 삽입
                //Insert(eTableName.studentinfo, "220777, '김박수', '남', 18.5, 20.3, 24.6, 16.1, 0, 0, 0, 0, 0, 0, 0, 0");

                //====
                
                _isRun = false;
            }
        }

        void Insert()
        {
            switch (_tbName)
            {
                case eTableName.studentinfo:
                    Student stu = new Student();
                    float avg = 0;

                    Console.Write("학생 ID를 입력하세요 : ");
                    string temp = Console.ReadLine();
                    if (int.TryParse(temp, out int tid))
                        stu.id = tid;
                    else
                        Insert();
                        
                    
                    Console.Write("학생 이름을 입력하세요(5자 이내) : ");
                    string name = Console.ReadLine();
                    if (name.Length <= 5)
                        stu.name = name;
                    else
                        Insert();

                    Console.Write("학생 성별을 입력하세요(1 : 남/ 2 : 여) : ");
                    temp = Console.ReadLine();
                    if(int.TryParse(temp, out int genInt))
                        switch (genInt)
                        {
                            case 1:
                                stu.gender = male;
                                break;
                            case 2:
                                stu.gender = female;
                                break;
                            default:
                                Insert();
                                break;
                        }    
                    else
                        Insert(); 
                    
                    Console.Write("1학년 1학기 중간고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.ffm = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("1학년 1학기 기말고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.ffl = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("1학년 2학기 중간고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.fsm = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("1학년 2학기 기말고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.fsl = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("2학년 1학기 중간고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.sfm = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("2학년 1학기 기말고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.sfl = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("2학년 2학기 중간고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.ssm = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("2학년 2학기 기말고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.ssl = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("3학년 1학기 중간고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.tfm = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("3학년 1학기 기말고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.tfl = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("3학년 2학기 중간고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.tsm = avg;
                        else
                            Insert();
                    else
                        Insert();

                    Console.Write("3학년 2학기 기말고사 점수를 입력하세요(0 ~ 100) : ");
                    temp = Console.ReadLine();
                    if (float.TryParse(temp, out avg))
                        if (avg <= 100 && avg >= 0)
                            stu.tsl = avg;
                        else
                            Insert();
                    else
                        Insert();

                    string colQuery = "STU_ID, Name, Gender, F_1S_M_Average, F_1S_L_Average, F_2S_M_Average, F_2S_L_Average, S_1S_M_Average, S_1S_L_Average, S_2S_M_Average, S_2S_L_Average, T_1S_M_Average, T_1S_L_Average, T_2S_M_Average, T_2S_L_Average";
                    string valQuery = stu.id + ", '" + stu.name + "', " + stu.gender + ", " + stu.ffm + ", " + stu.ffl + ", " + stu.fsm + ", " + stu.fsl + ", " + stu.sfm + ", " + stu.sfl + ", " + stu.ssm + ", " + stu.ssl + ", " + stu.tfm + ", " + stu.tfl + ", " + stu.tsm + ", " + stu.tsl;
                    string insertQuery = "INSERT INTO studentinfo" + "(" + colQuery + ")" + "VALUES(" + valQuery + ")";
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(insertQuery, _connection);
                        if (cmd.ExecuteNonQuery() == 1)
                            Console.WriteLine("삽입 성공");
                        else
                            Console.WriteLine("삽입 실패 : 쿼리 확인 필요");
                        SelectAction();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case eTableName.novice_gura:
                    Console.WriteLine("테이블이 존재하지 않습니다.");
                    SelectTable();
                    break;
                default:
                    Console.WriteLine("테이블이 존재하지 않습니다.");
                    SelectTable();
                    break;
            }
        }

        void Update()
        {
            string query = "UPDATE "+_dbName + "." + _tbName + " SET ";
            Console.WriteLine("수정할 학생의 ID를 입력하세요 : ");
            string input = Console.ReadLine();
            int.TryParse(input, out int id);

            Console.WriteLine("1) 이름");
            Console.WriteLine("2) 성별");
            Console.WriteLine("3) 1학년 1학기 중간고사 점수");
            Console.WriteLine("4) 1학년 1학기 기말고사 점수");
            Console.WriteLine("5) 1학년 2학기 중간고사 점수");
            Console.WriteLine("6) 1학년 2학기 기말고사 점수");
            Console.WriteLine("7) 2학년 1학기 중간고사 점수");
            Console.WriteLine("8) 2학년 1학기 기말고사 점수");
            Console.WriteLine("9) 2학년 2학기 중간고사 점수");
            Console.WriteLine("10) 2학년 2학기 기말고사 점수");
            Console.WriteLine("11) 3학년 1학기 중간고사 점수");
            Console.WriteLine("12) 3학년 1학기 기말고사 점수");
            Console.WriteLine("13) 3학년 2학기 중간고사 점수");
            Console.WriteLine("14) 3학년 2학기 기말고사 점수");
            Console.WriteLine("15) 이전 단계로 돌아가기");
            Console.WriteLine("어느 정보를 수정하시겠습니까 : ");
            input = Console.ReadLine();
            if(int.TryParse(input, out int select))
            {
                switch (select)
                {
                    case 1:
                        query += "Name";
                        break;
                    case 2:
                        query += "Gender";
                        break;
                    case 3:
                        query += "F_1S_M_Average";
                        break;
                    case 4:
                        query += "F_1S_L_Average";
                        break;
                    case 5:
                        query += "F_2S_M_Average";
                        break;
                    case 6:
                        query += "F_2S_L_Average";
                        break;
                    case 7:
                        query += "S_1S_M_Average";
                        break;
                    case 8:
                        query += "S_1S_L_Average";
                        break;
                    case 9:
                        query += "S_2S_M_Average";
                        break;
                    case 10:
                        query += "S_2S_L_Average";
                        break;
                    case 11:
                        query += "T_1S_M_Average";
                        break;
                    case 12:
                        query += "T_1S_L_Average";
                        break;
                    case 13:
                        query += "T_2S_M_Average";
                        break;
                    case 14:
                        query += "T_2S_L_Average";
                        break;
                    case 15:
                        SelectAction();
                        break;
                    default:
                        Update();
                        break;
                }
                
                query += " = ";
                Console.WriteLine("수정할 정보를 입력하세요 : ");
                string update = Console.ReadLine();
                if(select == 1 || select == 2)
                    query += "'" + update + "'";
                else
                    query += update ;

                query = query + " WHERE STU_ID = " + id;
                Console.WriteLine(query);

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, _connection);
                    if (cmd.ExecuteNonQuery() == 1)
                        Console.WriteLine("수정 성공");
                    else
                        Console.WriteLine("수정 실패 : 쿼리 확인 필요");
                    SelectAction();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Update();
            }
        }



        //void Insert(eTableName table, string valQuery)
        //{
        //    try
        //    {
        //        string colQuery = string.Empty;
        //        switch (table)
        //        {
        //            case eTableName.studentinfo:
        //                //컬럼에 따른 값 자동 입력 시 Dictionary 이용
        //                colQuery = "STU_ID, Name, Gender, F_1S_M_Average, F_1S_L_Average, F_2S_M_Average, F_2S_L_Average, S_1S_M_Average, S_1S_L_Average, S_2S_M_Average, S_2S_L_Average, T_1S_M_Average, T_1S_L_Average, T_2S_M_Average, T_2S_L_Average";
        //                break;
        //        }
        //        string insertQuery = "INSERT INTO " + table + "(" + colQuery + ")" + "VALUES(" + valQuery + ")";
        //        MySqlCommand cmd = new MySqlCommand(insertQuery, _connection);
        //        if (cmd.ExecuteNonQuery() == 1)
        //            Console.WriteLine("Insert Success");
        //        else
        //            Console.WriteLine("Insert Failed");
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}

        #region
        //public MyDBManager(string db, string server = "localhost", int port = 3306, string id = "root", string pw = "Dkfmvps0912^^")
        //{
        //    string connectInfoText = "Server=" + server + ";Port=" + port + ";Database=" + db + ";Uid=" + id + ";Pwd=" + pw;
        //    _connection = new MySqlConnection(connectInfoText);
        //    _connection.Open();
        //}

        //public void CreateTable(string tableName)
        //{
        //    try
        //    {
        //        string createQuery = "CREATE TABLE troop." + tableName + "(Name VARCHAR(12) PRIMARY KEY NOT NULL UNIQUE)ENGINE=INNODB;DESCRIBE troop."+tableName;
        //        MySqlCommand cmd = new MySqlCommand(createQuery, _connection);
        //        if (cmd.ExecuteNonQuery() == 1)
        //            Console.WriteLine("Create Success");
        //        else
        //            Console.WriteLine("Create Failed");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Create Failed : {0}", ex.ToString());
        //    }
        //}
        //public void AddColumn(string tableName, string colName, string type, bool pk = false, bool nn = false, bool uq = false, bool un = false, bool zf = false)
        //{
        //    try
        //    {
        //        string addQuery = "ALTER TABLE troop." + tableName + " ADD " + colName + " " + type;
        //        if (pk)
        //            addQuery += " PRIMARY KEY";
        //        if (nn)
        //            addQuery += " NOT NULL";
        //        if (uq)
        //            addQuery += " UNIQUE";
        //        if (un)
        //            addQuery += " UNSIGNED";
        //        if (zf)
        //            addQuery += " ZEROFILL";


        //        MySqlCommand cmd = new MySqlCommand(addQuery, _connection);
        //        if (cmd.ExecuteNonQuery() == 1)
        //            Console.WriteLine("Add Success");
        //        else
        //            Console.WriteLine("Add Failed");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Add Failed : {0}", ex.ToString());
        //    }
        //}
        //public void Insert(string tableName, string colQuery, string valQuery)
        //{
        //    string insertQuery = "INSERT INTO " + tableName + "(" + colQuery + ")" + "VALUES(" + valQuery + ")";
        //    MySqlCommand cmd = new MySqlCommand(insertQuery, _connection);
        //    if (cmd.ExecuteNonQuery() == 1)
        //        Console.WriteLine("Insert Success");
        //    else
        //        Console.WriteLine("Insert Failed");
        //}
        //public void Select(string tableName)
        //{
        //    string sql = "SELECT * FROM troop." + tableName;
        //    MySqlCommand cmd = new MySqlCommand(sql, _connection);
        //    MySqlDataReader table = cmd.ExecuteReader();

        //    while (table.Read())
        //    {
        //        Console.WriteLine("{0} | {1} | {2} | {3:#,###}", table["Name"], table["Job"], table["Lev"], table["Pow"]);
        //    }
        //}
        #endregion
    }
}
