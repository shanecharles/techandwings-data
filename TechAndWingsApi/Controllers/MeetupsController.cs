using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Hosting;

namespace TechAndWingsApi.Controllers
{
  /// <summary>
  /// 
  /// </summary>
  public class MeetupsController : ApiController
  {
    /// <summary>
    /// Retrieves the current season's meetups for Tech and Wings Brandon.
    /// </summary>
    /// <returns>Json only</returns>
    public async Task<HttpResponseMessage> Get()
    {
      using (var stream = new StreamReader(File.OpenRead(HostingEnvironment.MapPath("~/app_data/meetups.json"))))
      {
        var meetupData = await stream.ReadToEndAsync();
        var response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(meetupData.Replace("\r\n",""), Encoding.UTF8, "application/json");
        return response;
      }
    }
  }
}
