
namespace GameStore.Common
{
    /// <summary>
    /// Provides database connection strings
    /// </summary>
    public static class ConnectionStrings
    {
        public const string CONNECTION = "GamesStoreContext";
        public const string TEST_DB_CONNECTION = "Data Source=.\\SQLEXPRESS;Initial Catalog=TestGamesStoreContext;Integrated Security=True;MultipleActiveResultSets=True";
    }
}
