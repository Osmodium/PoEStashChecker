namespace POEStashChecker.NinjaDB
{
    public class SubDb
    {
        public string Name;
        public string League;
        public dynamic Db;

        public SubDb(string name, string league, dynamic db)
        {
            Name = name;
            League = league;
            Db = db;
        }
    }
}