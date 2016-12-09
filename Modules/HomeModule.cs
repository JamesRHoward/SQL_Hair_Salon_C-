using System.Collections.Generic;
using System;
using Nancy;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylist/new"] = _ => {
        return View["stylist_form.cshtml"];
      };
      Post["/stylist/add"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/client/{id}"] = parameter => {
        Stylist stylistClients = Stylist.Find(parameter.id);
        return View["stylist.cshtml", stylistClients];
      };
      Post["/client/add/{id}"] = parameter => {
        Client newClient = new Client(Request.Form["client-name"], parameter.id);
        newClient.Save();
        Stylist stylistClients = Stylist.Find(parameter.id);
        return View["stylist.cshtml", stylistClients];
      };
    }
  }
}
