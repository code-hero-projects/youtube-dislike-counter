namespace CodeHero.YouTubeDislikeCounter.Database.Configuration
{
    public class DatabaseConfiguration
    {
        public DatabaseType Type { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string[] Containers { get; set; }
        public string[] PartitionKeys { get; set; }
        public TimeSpan InitializeRetryDelay { get; set; } = TimeSpan.FromMinutes(0.1);
    }
}
