using Microsoft.AspNetCore.Builder;

namespace CdpDotnetTracing.Test.Config;

public class EnvironmentTest
{

   [Fact]
   public void IsNotDevModeByDefault()
   { 
       var builder = WebApplication.CreateEmptyBuilder(new WebApplicationOptions());
       var isDev = CdpDotnetTracing.Config.Environment.IsDevMode(builder);
       Assert.False(isDev);
   }
}
