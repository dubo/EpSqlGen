using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpSqlGen
{
    class Program
    {
        static void Main(string[] args)
        {                  
            var myReport = new EpSqlGenerator(args);
            SimpleLog.WriteLog("",false);
            SimpleLog.WriteLog("***  EpSqlGen started  ***");
            myReport.SetupEnviroment();
            
            using (var conn = DbTools.CreateOpenedDbConnection(ConfigurationManager.ConnectionStrings[myReport.repConnectString].ProviderName, ConfigurationManager.ConnectionStrings[myReport.repConnectString].ConnectionString))
            {

                if (myReport.outFormat == ".json")
                    myReport.GenerateJson(conn);
                else
                    myReport.GenerateXlsxReport(conn);
            }
            myReport.CloseEnviroment();
        }
    }
}
