using System;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace AvantGarde.DAL
{
    /// <summary>
    /// DBHelper class to the provider independent DataBase Access Layer 
    /// </summary>
    public class SQLHelper : IDisposable
    {
        #region"Class level private variable declaration block."

        private static string _connectionString = string.Empty;
        private static string _providerName = string.Empty;
        private static string _cursorName = string.Empty;
        private DbConnection _connection = null;
        private DbTransaction _sqlTransaction = null;

        ////If you manually want to release some managed & unmanaged resources then only declare this & would be used in virtual Dispose method
        private bool _disposed = false; // to detect redundant calls

        #endregion

        #region"Property declaration block."

        /// <summary>
        /// Defined for setting & getting the Connection String.
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
        /// <summary>
        /// Defined for setting & getting the Provider Name.
        /// </summary>
        private static string ProviderName
        {
            get
            {
                return _providerName;
            }
            set
            {
                _providerName = value;
            }
        }
        /// <summary>
        /// Defined for setting & getting the Cursor Name.
        /// </summary>
        private static string CursorName
        {
            get
            {
                return _cursorName;
            }
            set
            {
                _cursorName = value;
            }
        }

        #endregion

        #region"Constructor Definition Block"

        /// <summary>
        /// Cannot Instantiate this class.
        /// </summary>
        public SQLHelper()
        {
            InitializeDbLayer();
        }

        #endregion

        #region"Cutom Functions Declaration/Definition Block."

        /// <summary>
        /// Initializing the required data base properties
        /// </summary>
        /// <param name="configConnectionPropertyName">accept connection properties from web.config </param>
        /// <param name="configCursorName">accept common cursor name from web.config, if data base provider is Oracle</param>
        public static void InitializeDbLayer()
        {
            if (ConnectionString != null)
                ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString.ToString();
            if (ProviderName != null)
                ProviderName = ConfigurationManager.ConnectionStrings[0].ProviderName.ToString();
            if (ProviderName == "System.Data.OracleClient")
            {
                CursorName = ConfigurationManager.AppSettings["CursorName"].ToString();
            }
        }

        /// <summary>
        /// Returns a DbCommand object.
        /// </summary>
        /// <returns>Returns a DbCommand object.</returns>
        public DbCommand GetCommand()
        {
            DbCommand command = DataBaseFactory.GetDbFactory(ProviderName).CreateCommand();
            return command;
        }

        /// <summary>
        /// Returns an array of DbParameter objects.
        /// </summary>
        /// <param name="parameterCount">Denotes the size of the required parameter array. Should be greater than 0.</param>
        /// <returns>Returns an array of DbParameter objects.</returns>
        public DbParameter[] GetParameters(ushort parameterCount)
        {
            DbProviderFactory Dbfactory = DataBaseFactory.GetDbFactory(ProviderName);
            DbParameter[] parameters = new DbParameter[parameterCount];

            try
            {
                for (int counter = 0; counter < parameterCount; counter++)
                {
                    parameters[counter] = Dbfactory.CreateParameter();
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new Exception("ParameterCount has to be greater than zero and less than 100", new IndexOutOfRangeException());
            }

            return parameters;
        }

        /// <summary>
        /// Returns a single DbParameter object 
        /// </summary>
        /// <returns>Returns a single DbParameter object </returns>
        public DbParameter GetParameter()
        {
            DbProviderFactory Dbfactory = DataBaseFactory.GetDbFactory(ProviderName);
            DbParameter parameter = Dbfactory.CreateParameter();
            return parameter;
        }

        /// <summary>
        /// For Begining the transaction after opening the connection.
        /// </summary>        
        public void BeginTransaction()
        {
            bool chkError = false;

            try
            {
                // opens connection therefore checks if connString is valid
                _connection = DataBaseFactory.GetConnection(ConnectionString, ProviderName);

                _connection.Open();
                _sqlTransaction = _connection.BeginTransaction();

                chkError = true;
            }
            finally
            {
                if (!chkError)
                {
                    _connection.Close();
                    _connection.Dispose();
                    _sqlTransaction.Dispose();
                }
            }
        }

        /// <summary>
        /// For ending the transaction
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                if (_sqlTransaction != null)
                {
                    _sqlTransaction.Commit();
                }
            }
            finally
            {
                // Always close underlying database connection 
                if (_connection != null)
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                // Disposed transaction that now is no more useful
                _sqlTransaction.Dispose();
                _sqlTransaction = null;
            }
        }

        /// <summary>
        /// To rollback the transaction
        /// </summary>
        public void RollBackTransaction()
        {
            try
            {
                // Rollbacks the transaction
                if (_sqlTransaction != null)
                {
                    _sqlTransaction.Rollback();
                }
            }
            finally
            {
                // Always close underlying database connection 
                if (_connection != null)
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                // Disposed transaction that now is no more useful
                _sqlTransaction.Dispose();
                _sqlTransaction = null;
            }
        }

        /// <summary>
        /// For opening the connection.
        /// </summary>        
        public void OpenConnection()
        {
            bool chkError = false;

            try
            {
                if (_connection != null)
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }

                _connection = DataBaseFactory.GetConnection(ConnectionString, ProviderName);
                _connection.Open();

                chkError = true;
            }
            finally
            {
                if (!chkError)
                {
                    _connection.Close();
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }

        /// <summary>
        /// For closing the connection
        /// </summary>
        public void CloseConnection()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }

                _connection.Dispose();
                _connection = null;
            }
        }

        /// <summary>
        /// Defined for getting a DataSet object filled with data from the execution of the Command Object.
        /// </summary>
        /// <param name="commandText">Used for accepting command text or store procedure name</param>
        /// <param name="parameterList">Used for accepting collection of list of parameters, if any.</param>
        /// <param name="sqlType">Used for accepting type of SqlCommandType e.g StoredProcedure or Text</param>
        /// <returns>A DataSet filled with data from the execution of the Command.</returns>
        public DataSet GetDataSet(string commandText, DbParameter[] parameterList, DBCommandType sqlType)
        {
            DbCommand command = null;
            DataSet resultDataSet = null;
            DbDataAdapter dbAdapter = null;

            try
            {
                command = GetPreparedCommand(commandText, parameterList, sqlType, CursorName);

                command.Connection = DataBaseFactory.GetConnection(ConnectionString, ProviderName);
                DbProviderFactory Dbfactory = DataBaseFactory.GetDbFactory(ProviderName);
                dbAdapter = Dbfactory.CreateDataAdapter();
                dbAdapter.SelectCommand = command;
                resultDataSet = new DataSet();
                dbAdapter.Fill(resultDataSet, "menu");
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
                if (dbAdapter != null)
                {
                    dbAdapter.Dispose();
                    dbAdapter = null;
                }
            }
            return resultDataSet;
        }

        /// <summary>
        /// Defined for getting a DataTable object filled with data from the execution of the Command Object.
        /// </summary>
        /// <param name="commandText">Used for accepting command text or store procedure name</param>
        /// <param name="parameterList">Used for accepting collection of list of parameters, if any.</param>
        /// <param name="sqlType">Used for accepting type of SqlCommandType e.g StoredProcedure or Text</param>
        /// <returns>A DataTable object filled with data from the execution of the Command.</returns>
        public DataTable GetDataTable(string commandText, DbParameter[] parameterList, DBCommandType sqlType)
        {
            DbConnection dbConn = null;
            DbCommand command = null;
            DbDataReader reader = null;
            DataTable resultDataTable = null;

            try
            {
                command = GetPreparedCommand(commandText, parameterList, sqlType, CursorName);

                dbConn = DataBaseFactory.GetConnection(ConnectionString, ProviderName);
                dbConn.Open();
                command.Connection = dbConn;
                reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    resultDataTable = new DataTable();
                    resultDataTable.Load(reader);
                }
            }

            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }

                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }

                if (dbConn != null)
                {
                    if (dbConn.State == ConnectionState.Open)
                        dbConn.Close();
                    dbConn.Dispose();
                    dbConn = null;
                }
            }
            return resultDataTable;
        }

        /// <summary>
        /// Defined for getting a DB Data Reader object filled with data from the execution of the Command Object.
        /// </summary>
        /// <param name="commandText">Used for accepting command text or store procedure name</param>
        /// <param name="parameterList">Used for accepting collection of list of parameters, if any.</param>
        /// <param name="sqlType">Used for accepting type of SqlCommandType e.g StoredProcedure or Text</param>
        /// <returns>A DataTable object filled with data from the execution of the Command.</returns>
        public DbDataReader GetDbDataReader(string commandText, DbParameter[] parameterList, DBCommandType sqlType)
        {
            DbCommand command = null;
            DbDataReader reader = null;

            try
            {
                command = GetPreparedCommand(commandText, parameterList, sqlType, CursorName);

                command.Connection = _connection;

                reader = command.ExecuteReader();

            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            }

            return reader;
        }

        /// <summary>
        /// Defined for getting an integer value after executing the table manipulation(Insert,Update,Delete) command object.
        /// </summary>
        /// <param name="commandText">Used for accepting command text or store procedure name</param>
        /// <param name="parameterList">Used for accepting collection of list of parameters</param>
        /// <param name="sqlType">Used for accepting type of SqlCommandType e.g StoredProcedure or Text</param>
        /// <returns>An Integer value after the table manipulation execution</returns>
        public int ExecuteNonQuery(string commandText, DbParameter[] parameterList, DBCommandType sqlType)
        {
            DbConnection dbConn = null;
            DbCommand command = null;

            int result = 0;

            try
            {
                command = GetPreparedCommand(commandText, parameterList, sqlType, string.Empty);

                if (_sqlTransaction == null)
                {
                    dbConn = DataBaseFactory.GetConnection(ConnectionString, ProviderName);
                    dbConn.Open();
                    command.Connection = dbConn;
                }
                else
                {
                    command.Transaction = _sqlTransaction;
                    command.Connection = _connection;
                }

                result = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                if (_sqlTransaction != null)
                {
                    //_sqlTransaction.Rollback();
                    RollBackTransaction();
                }
                throw ex;
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }

                if (_sqlTransaction == null)
                {
                    if (dbConn != null)
                    {
                        if (dbConn.State == ConnectionState.Open)
                            dbConn.Close();
                        dbConn.Dispose();
                        dbConn = null;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Defined for getting the first column of the first row after executing the table manipulation command object.
        /// </summary>
        /// <param name="commandText">Used for accepting command text or store procedure name</param>
        /// <param name="parameterList">Used for accepting collection of list of parameters, if any.</param>
        /// <param name="sqlType">Used for accepting type of SqlCommandType e.g StoredProcedure or Text</param>
        /// <returns>An object containing the first column of the first row.</returns>
        public object ExecuteScalar(string commandText, DbParameter[] parameterList, DBCommandType sqlType)
        {
            DbConnection dbConn = null;
            DbCommand command = null;

            object result = null;

            try
            {
                command = GetPreparedCommand(commandText, parameterList, sqlType, CursorName);

                if (_sqlTransaction == null)
                {
                    dbConn = DataBaseFactory.GetConnection(ConnectionString, ProviderName);
                    dbConn.Open();
                    command.Connection = dbConn;
                }
                else
                {
                    command.Transaction = _sqlTransaction;
                    command.Connection = _connection;
                }

                result = command.ExecuteScalar();

            }
            catch (Exception ex)
            {
                if (_sqlTransaction != null)
                {
                    RollBackTransaction();
                }
                throw ex;
            }
            finally
            {
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }

                if (_sqlTransaction == null)
                {
                    if (dbConn != null)
                    {
                        if (dbConn.State == ConnectionState.Open)
                            dbConn.Close();
                        dbConn.Dispose();
                        dbConn = null;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Defined for preparing or filling the command object on the given parameters.
        /// </summary>
        /// <param name="commandText">Used for accepting command text or store procedure name</param>
        /// <param name="parameterList">Used for accepting collection of list of parameters, if any.</param>
        /// <param name="sqlType">Used for accepting type of SqlCommandType e.g StoredProcedure or Text</param>
        /// <returns>A DBCommand Object</returns>
        private DbCommand GetPreparedCommand(string commandText, DbParameter[] parameterList, DBCommandType sqlType, string cursorName)
        {
            DbCommand command = null;

            try
            {
                command = GetCommand();
                command.CommandText = commandText;
                command.CommandTimeout = 600000000;


                if (sqlType == DBCommandType.Text)
                {
                    command.CommandType = System.Data.CommandType.Text;
                }
                else
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                }

                if (parameterList != null)
                {
                    if (parameterList.Length > 0)
                    {
                        command.Parameters.AddRange(parameterList);

                        if (ProviderName == "System.Data.OracleClient")
                        {
                            if (!cursorName.Length.Equals(0) && sqlType == DBCommandType.StoredProcedure)
                            {
                                System.Data.OracleClient.OracleParameter parameter = new System.Data.OracleClient.OracleParameter();
                                parameter.ParameterName = commandText + "_" + cursorName;
                                parameter.OracleType = System.Data.OracleClient.OracleType.Cursor;
                                parameter.Direction = ParameterDirection.Output;
                                command.Parameters.Add(parameter);
                            }
                        }
                    }
                }

            }
            finally { }
            return command;
        }

        /// <summary>
        /// This method might be required to attach parameters in case the 
        /// provider is System.Data.SqlClient
        /// </summary>
        /// <param name="command"></param>
        /// <param name="commandParameters"></param>
        private void AttachParameters(System.Data.SqlClient.SqlCommand command, System.Data.SqlClient.SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (System.Data.SqlClient.SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// Converts list to datatable
        /// </summary>
        /// <param name="data"></param>
        /// <returns>A datatable object</returns>
        public DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /// <summary>
        /// Converts list to datatable
        /// </summary>
        /// <returns></returns>
        public SqlBulkCopy GetSqlBulkCopyCommand()
        {
            SqlBulkCopy sqlBulkCopyCmd = new SqlBulkCopy(ConnectionString);
            return sqlBulkCopyCmd;
        }


        #endregion

        #region "Implementing IDisposable to the class"

        protected virtual void Dispose(bool disposing)
        {
            #region "If you manually want to release some managed & unmanaged resources then only this function will be defined"
            //if (!disposed)
            //{
            //    if (disposing)
            //    {
            //        // dispose-only, i.e. non-finalizable logic
            //    }

            //    // shared cleanup logic
            //    disposed = true;
            //}
            #endregion

            if (_disposed) { return; }

            if (disposing)
            {
                // Avoid runtime error when disposing 
                // (connection broken, etc.)
                try
                {
                    // if transaction has not been committed or 
                    // rolled back, we need to close it
                    if (_sqlTransaction != null)
                    {
                        _sqlTransaction.Rollback();
                    }
                }
                finally
                {
                    // -- Important: closes and releases reference to transaction
                    if (_connection != null)
                        CloseConnection();
                    if (_sqlTransaction != null)
                        _sqlTransaction.Dispose();
                    _sqlTransaction = null;
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }

    /// <summary>
    /// Defined custom command types
    /// </summary>
    public enum DBCommandType
    {
        StoredProcedure,
        Text
    }
}
