using Newtonsoft.Json.Linq;

namespace Xenox.Auth.Host.HttpJsonRpc.Dtos {
	public class CommandDto {
		public string Name { get; set; }
		public JObject Data { get; set; }
	}
}
