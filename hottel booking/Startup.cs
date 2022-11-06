using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hottel_booking.Startup))]
namespace hottel_booking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
