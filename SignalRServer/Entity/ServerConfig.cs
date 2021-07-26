namespace server.Entity
{
    public class ServerConfig
    {
        public ServerConfigItem Server { get; set; }
    }
    public class ServerConfigItem
    {
        public string ConncetionURL { get; set; }
        public string LogPath { get; set; }

    }
}
