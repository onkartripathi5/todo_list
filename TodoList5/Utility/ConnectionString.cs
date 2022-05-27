namespace TodoList5.Utility
{
    public static class ConnectionString
    {

        private static string cName = "Data Source=CPU-0191; Initial Catalog=TodoList;Trusted_Connection=True;";

        public static string CName { get => cName; }
    }
}
