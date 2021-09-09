using System;
using System.Data;
using System.Data.Common;

namespace SP_PJT_3
{
    public class DBHelper
    {
        // DBHELPER 생성 
        private DbProviderFactory dataFactory = null; // 데이터 를 수집 하기 위한 데이터베이스 타입 모음 함수.
        private DbConnection _sConn = null; // 데이터 베이스 연결 관련 함수.
        private DbTransaction _sTran = null; // 데이터 베이스 등록,갱신,삭제 시 트랜잭션 선언


        private DbCommand oCmd = null;    // 데이터 베이스 에서 데이터를 추출 하기 위한 명령어 함수.
        public DBHelper(bool bTrans)
        {
            Init(bTrans); // 트랜잭션 여부를 가지고 DB HELPER 선언 
        }

        public bool Init(bool btran)
        {
            try
            {
                string conStr = Common.DbPath;                                                                                      
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);  // System.Data.SqlClient 형식의 Factory 사용 등록
                dataFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");                                          // 데이터 베이스 내용을 담아올 그릇의 DB 종류 선언   
                _sConn = dataFactory.CreateConnection();                                                                        // 데이터베이스 연결 함수 DbConnection 과 FACTORY 연동
                _sConn.ConnectionString = conStr;                                                                               // 연결 함수에 데이터베이스 주소 입력
                _sConn.Open();                                                                                                  // 데이터베이스 접속 
                if (btran) _sTran = _sConn.BeginTransaction();                                                                  // 트랜잭션 사용 일 경우 연결 함수에 트랜잭션 선언 후 트랜잭션 함수 선언.
            }
            catch (Exception ex)
            {
                return true;
            }
            return false;
        }
        #region < Helper FillTable 데이터 조회 >
        public DataTable FillTable(string query, CommandType commandType, params Object[] parameters)
        {
            //                      프로시저 명, 실행 타입(프로시저), 파라매터
            return FillTable_Detail(query, commandType, parameters); // 데이터 테이블 리턴.
        }


        public DataTable FillTable_Detail(string query, CommandType commandType, params Object[] parameters)
        {
            oCmd = _sConn.CreateCommand();   // 데이터 베이스 명령 함수 선언 
            oCmd.Connection = _sConn;        // 명령 함수에 연결 주소 입력
            oCmd.CommandText = query;        // 명령 SP 입력
            oCmd.CommandType = commandType;  // 명령 종류(프로시저) 입력.


            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);     // 파라매터 의 개수 별로 명령 함수에 파라매터 등록
                }
            }

            DbDataAdapter oAdap = dataFactory.CreateDataAdapter();  // DB 에 명령문 실행 및 반환 데이터를 리턴 받는 ADAPTER 선언.
            oAdap.SelectCommand = oCmd;                             // 어댑터에 명령어 입력.

            DataTable dt = new DataTable();
            oAdap.Fill(dt);                                         // 어뎁터 실행 하여 반환 값 리턴받음.

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.ToUpper();  // 컬럼 이름 대문자.
            }
            return dt;
        }

        #endregion

        #region < Helper ExecuteNoneQuery 데이터 등록 >
        public int ExecuteNoneQuery(string query, CommandType commandType, params Object[] parameters)
        {
            return ExecuteNoneQuery_Detail(query, commandType, true, true, parameters);
        }


        public int ExecuteNoneQuery_Detail(string query, CommandType commandType, bool baddLang, bool baddOut, params Object[] parameters)
        {
            oCmd = _sConn.CreateCommand();
            oCmd.Connection = _sConn;
            oCmd.CommandText = query;
            oCmd.CommandType = commandType;


            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    oCmd.Parameters.Add(parameters[i]);
                }
            }

            oCmd.Transaction = _sTran;
            int rtn = oCmd.ExecuteNonQuery();
            return rtn;
        }

        // 트랜잭션 Commit
        public void Commit()
        {
            if (_sTran != null)
            {
                _sTran.Commit();
                _sTran = null;
            }
        }

        // 트랜잭션 RollBack
        public void Rollback()
        {
            if (_sTran != null)
            {
                _sTran.Rollback();
                _sTran = null;
            }
        }
        #endregion


        public DbParameter CreateParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            DbParameter param = dataFactory.CreateParameter();
            param.ParameterName = name.ToUpper();
            param.Value = value;
            param.Direction = direction;

            return param;
        }
        public void Close()
        {
            Close(true);
        }
        public void Close(bool bCommit)
        {
            try
            {
                if (_sTran != null)
                {
                    if (bCommit)
                        _sTran.Commit();
                    else
                        _sTran.Rollback();
                }
                _sConn.Close();
            }
            catch { }
        }

    }
}
