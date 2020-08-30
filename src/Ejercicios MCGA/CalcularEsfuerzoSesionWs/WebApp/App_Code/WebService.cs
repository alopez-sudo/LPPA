using System;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService
{

	public WebService() { }

	[WebMethod]
	public double CalculaEsfuerzo(double l, double ck, double td)
	{
		return Math.Pow(l, 3.0) / (Math.Pow(ck, 3.0) * Math.Pow(td, 4.0));
	}
}
