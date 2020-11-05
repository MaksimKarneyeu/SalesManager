using System;
using System.Data;
using System.Data.SqlClient;
using Z.BulkOperations;

namespace SalesManager.Data.BulkOperations
{
    public abstract class BaseBulkOperator : IBulkOperator
	{
		public virtual void BulkInsert(DataTable dt, Guid DocumentID)
		{

        }    

        protected void PerformOperation(Action<SqlConnection> action)
        {
			using (var connection = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SalesManager;Integrated Security=SSPI;"))
			{
				connection.Open();

				
				action.Invoke(connection);
			}
		}

		public virtual void BulkUpdate(DataTable dt, Guid DocumentID)
        {

        }

	}
}
