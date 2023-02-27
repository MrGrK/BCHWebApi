namespace BCH.Infrasructure.Configuration.Options
{
    public class BlockcyApiSettings
    {
        public const string BlockcyApi = "BlockcypherApi";

        public string ApiEndpoint { get; set; }

        public string Eth { get; set; }

        public string Btc { get; set; }

        public string Dash { get; set; }
    }
}
