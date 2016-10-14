using System;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace AvantGarde.DAL
{
    public class DataBaseFactory
    {
         #region"Constructor Definition Block."

        /// <summary>
        /// Cannot Instantiate this class
        /// </summary>
        private DataBaseFactory()
        {

        }

        #endregion

        #region"Cutom Functions Declaration/Definition Block."

        /// <summary>
        /// Returns a closed DbConnection object. User has to open/close it whenever required.
        /// </summary>
        /// <returns>DBConnection Object</returns>
        internal static DbConnection GetConnection()
        {
            return default(DbConnection);
        }

        /// <summary>
        /// Returns a closed DbConnection object. User has to open/close it whenever required.
        /// </summary>
        /// <param name="connectionString">Connection String for the connection object</param>
        /// <param name="providerName">DataBase Provider Name (e.g.) Oledb, Odbc, SqlClient etc. for getting the respective provider connection</param>
        /// <returns>DBConnection Object</returns>
        internal static DbConnection GetConnection(string connectionString, string providerName)
        {
            try
            {
                DbProviderFactory Dbfactory = DataBaseFactory.GetDbFactory(providerName);
                DbConnection connection = Dbfactory.CreateConnection();
                connection.ConnectionString = connectionString;
                return connection;
            }
            catch (DbException)
            {
                throw new ApplicationException("An exception has occured while" +
                "creating the connection. Please check Connection String settings" +
                "in the web.config file.");
            }
        }

        /// <summary>
        /// Provides with a DbProviderFactory object with the provider name from the config file.
        /// </summary>
        /// <returns>DbProviderFactory object</returns>
        internal static DbProviderFactory GetDbFactory()
        {
            try
            {
                string ProviderName = "";
                DbProviderFactory Dbfactory = DbProviderFactories.GetFactory(ProviderName);
                return Dbfactory;
            }
            catch (DbException)
            {
                throw new Exception("An exception has occured while creating the database provider factory. Please check the ProviderName specified in the web.config file.");
            }
        }

        /// <summary>
        /// Provides with a DbProviderFactory object with the supplied Provider name.
        /// </summary>
        /// <param name="ProviderName">DataBase Provider Name (e.g.) Oledb, Odbc, SqlClient</param> 
        /// <returns>DbProviderFactory object</returns>
        internal static DbProviderFactory GetDbFactory(string ProviderName)
        {
            DataTable dtProviders = DbProviderFactories.GetFactoryClasses();

            if (dtProviders.Rows.Count == 0)
            {
                throw new Exception("No Data Providers are installed in the .Net FrameWork that implement the abstract DbProviderFactory Classes. ");
            }

            bool errorFlag = false;
            foreach (DataRow dr in dtProviders.Rows)
            {
                if (dr[2] != null)
                {
                    string ExistingProviderName = dr[2].ToString();
                    if (ProviderName.ToLower() == ExistingProviderName.Trim().ToLower())
                    {
                        errorFlag = false;
                        break;
                    }
                    else
                    {
                        errorFlag = true;
                    }

                }
            }

            if (errorFlag)
            {
                throw new Exception("The ProviderName string supplied is not a valid Provider Name<BR>or it does not implement the abstract DbProviderFactory Classes. <BR>The string ProviderName is case-sensitive. Also please check it for proper spelling. ");
            }

            DbProviderFactory Dbfactory = DbProviderFactories.GetFactory(ProviderName);
            return Dbfactory;
        }

        #endregion              
    }
}
