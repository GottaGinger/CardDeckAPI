using DeckOfCardsWebApp.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeckOfCardsWebApp.Controllers
{
    public class DeckController : Controller
    {
        public IActionResult Index()
        {
         
            return RedirectToAction("Draw5");
        }
        public IActionResult Draw5()
        {
            string apiUri = "https://deckofcardsapi.com/api/deck/new/shuffle";
            var apiTask = apiUri.GetJsonAsync<DeckAPI>();
            apiTask.Wait();
            DeckAPI result = apiTask.Result;

             apiUri = $"https://deckofcardsapi.com/api/deck/{result.deck_id}/draw/?count=5";
            var apiTaskCard = apiUri.GetJsonAsync<DrawAPI>(); //go here, get the info, bring it back as json, put in structure that shows class list
            apiTask.Wait();
            DrawAPI resultcard = apiTaskCard.Result;
            return View(resultcard.cards);
        }

    }
}
