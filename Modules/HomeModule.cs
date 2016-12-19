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
      Get["/stylist/edit/{id}"] = parameter => {
        Stylist selectedStylist = Stylist.Find(parameter.id);
        return View["stylist_edit.cshtml", selectedStylist];
      };
      Patch["/stylist/edit/{id}"] = parameter => {
        Stylist selectedStylist = Stylist.Find(parameter.id);
        selectedStylist.Update(Request.Form["new-stylist-name"]);
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/stylist/delete/{id}"] = parameter => {
        Stylist selectedStylist = Stylist.Find(parameter.id);
        return View["stylist_delete.cshtml", selectedStylist];
      };
      Delete["/stylist/delete/{id}"] = parameter => {
        Stylist selectedStylist = Stylist.Find(parameter.id);
        selectedStylist.Delete();
        List<Stylist> allStylists = Stylist.GetAll();
        return View["index.cshtml", allStylists];
      };
      Get["/clients"] = _ => {
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };
      Get["/clients/{id}"] = parameter => {
        Client selectedClient = Client.Find(parameter.id);
        return View["client.cshtml", selectedClient];
      };
      Get["/client/edit/{id}"] = parameter => {
        Client selectedClient = Client.Find(parameter.id);
        return View["client_edit.cshtml", selectedClient];
      };
      Patch["/client/edit/{id}"] = parameter => {
        Client selectedClient = Client.Find(parameter.id);
        Stylist currentStylist = Stylist.Find(selectedClient.GetStylistId());
        selectedClient.Update(Request.Form["new-client-name"], currentStylist.GetId());
        List<Client> allClients = Client.GetAll();
        return View["clients.cshtml", allClients];
      };
    }
  }
}
