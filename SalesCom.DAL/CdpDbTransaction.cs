using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace SalesCom.DAL
{
   public class CdpDbTransaction : IDisposable
    {
        
            internal OracleTransaction CurrentTransaction = null;
            private OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=172.16.10.89)(PORT=2636)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=salcomtst))); User Id=salescom;Password=salescom0987;");

            public void Begin()
            {

                conn.Open();
                CurrentTransaction = conn.BeginTransaction();
            }

            public void Commit()
            {
                CurrentTransaction.Commit();
            }

            public void RollBack()
            {
                CurrentTransaction.Rollback();

            }

            public void Dispose()
            {
                CurrentTransaction.Dispose();
                conn.Dispose();

            }

            #region IDisposable Members

            void IDisposable.Dispose()
            {
                CurrentTransaction.Dispose();
                conn.Dispose();
            }

            #endregion
        
    }
}
