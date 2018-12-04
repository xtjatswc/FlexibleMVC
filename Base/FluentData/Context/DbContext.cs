namespace FluentData
{
	public partial class DbContext : IDbContext
	{
		public DbContextData Data { get; private set; }

		public DbContext()
		{
			Data = new DbContextData();
		}

		internal void CloseSharedConnection()
		{
			if (Data.Connection == null)
				return;

			if (Data.UseTransaction
				&& Data.Transaction != null)
					Rollback();

			Data.Connection.Close();

			if (Data.OnConnectionClosed != null)
				Data.OnConnectionClosed(new ConnectionEventArgs(Data.Connection));
		}

		public void Dispose()
		{
			CloseSharedConnection();
            /*
             * using 结束后,事务的标志位仍然为 true ,如果之后还有更新追加操作,由于没有手动Commit,会导致数据丢失;
             * 现修改为 using 结束时,自动重置标志位为 false ,之后的数据操作不再会自动开启新事务,也就没有漏提交的问题了.
             */
            Data.UseTransaction = false;
        }
	}
}
