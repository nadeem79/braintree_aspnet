using Braintree;
using Microsoft.Extensions.Options;

namespace BraintreeASPExample
{
    public class BraintreeConfiguration : IBraintreeConfiguration
    {
        private readonly BraintreeSettings _settings;
        private IBraintreeGateway BraintreeGateway { get; set; }
                
        public BraintreeConfiguration(IOptions<BraintreeSettings> options) 
        {
            _settings = options.Value;
        }

        public IBraintreeGateway CreateGateway()
        {
            return new BraintreeGateway(_settings.Environment, _settings.MerchantId, _settings.PublicKey, _settings.PrivateKey);
        }

        public IBraintreeGateway GetGateway()
        {
            if (BraintreeGateway == null)
            {
                BraintreeGateway = CreateGateway();
            }

            return BraintreeGateway;
        }
    }
}
