using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDbDip
{
    class DefineValue
    {
        public const string _baseLocalIP = "localhost";
        public const int _port = 3306;
        public const string _scoreValueFormat = "VALUES({0}, '{1}', '{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}";
        public const string _novisValueFormat = "VALUES({0}, '{1}', {2})";
    }
    public enum eTableName
    {
        studentinfo,
        novice_gura,

        NULL
    }
}
