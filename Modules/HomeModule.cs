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
        Stylist newStylist = newStylist(Form.Request["stylist-name"]);
        newStylist.Save();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml"];
      };
    }
  }
}
