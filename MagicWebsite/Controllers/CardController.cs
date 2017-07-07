using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagicWebsite.Models;
using AutoMapper;
using BLL;

namespace MagicWebsite.Controllers
{
    public class CardController : Controller
    {
        private ISessionAccessor SessAcc;
        private ICardsLogic CardsLogic;

        public CardController(ICardsLogic logic, CardsLogic cardLogic, SessionAccessor session)
        {
            CardsLogic = logic;
            CardsLogic = cardLogic;
            SessAcc = session;
        }
        //Shows all cards in the database
        public ActionResult CardIndex()
        {
            List<CardsVM> cards = Mapper.Map<List<CardsVM>>(CardsLogic.GetAllCards());
            cards.Sort(delegate (CardsVM c1, CardsVM c2) { return c1.Name.CompareTo(c2.Name); });
            return View(cards);
        }
        //Shows a single card from the database
        public ActionResult SingleCard(string name)
        {
            try
            {
                CardsVM Model = Mapper.Map<CardsVM>(CardsLogic.GetSingleCard(name));
                return View(Model);
            }
            catch
            {
                return View();
            }
        }
        //Creates a new card
        public ActionResult CreateCard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCard(CardsVM card)
        {
            try
            {
                CardsLogic.CreateCard(Mapper.Map<CardsSM>(card));
                return RedirectToAction("CardIndex");
            }
            catch
            {
                return View();
            }
        }
        //Edits a card
        public ActionResult EditCard(string name)
        {
            try
            {
                CardsVM Model = Mapper.Map<CardsVM>(CardsLogic.GetSingleCard(name));
                return View(Model);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EditCard(CardsVM model)
        {
            try
            {
                CardsLogic.UpdateCardInfo(Mapper.Map<CardsSM>(model));
                return RedirectToAction("CardIndex");
            }
            catch
            {
                return View();
            }
        }
        //Deletes a card
        public ActionResult DeleteCard(string name)
        {
            try
            {
                CardsVM Model = Mapper.Map<CardsVM>(CardsLogic.GetSingleCard(name));
                return View(Model);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult DeleteCard(CardsVM model)
        {
            try
            {
                CardsLogic.DeleteCard(model.ID);
                return RedirectToAction("CardIndex");
            }
            catch
            {
                return View();
            }
        }
        //Shows all decks attached to a user
        public ActionResult UserDecks()
        {
            int userId = SessAcc.GetUserId();
            List<DeckVM> model = Mapper.Map<List<DeckVM>>(CardsLogic.UserDecks(userId));
            return View(model);
        }
        [HttpGet]
        public ActionResult AddCardToDeck(int cardid)
        {
            try
            {
                int deckId = SessAcc.GetDeckId();
                CardsLogic.AddCardToDeck(cardid, deckId);
                return RedirectToAction("CardIndex");
            }
            catch
            {
                return RedirectToAction("CardIndex");
            }
        }
        [HttpGet]
        public ActionResult AddCardToDeckFromDeck(int cardId)
        {
            try
            {
                int deckId = SessAcc.GetDeckId();
                CardsLogic.AddCardToDeck(cardId, deckId);
                return RedirectToAction("EditDeck", new { id = deckId });
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DeleteCardFromDeck(int cardid)
        {
            try
            {
                int deckid = SessAcc.GetDeckId();
                CardsLogic.DeleteCardFromDeck(cardid, deckid);
                return RedirectToAction("EditDeck", new { id = deckid });
            }
            catch
            {
                return View();
            }
        }
        //Creates a new card
        public ActionResult CreateDeck()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDeck(DeckVM deck)
        {
            try
            {
                int userId = SessAcc.GetUserId();
                CardsLogic.CreateDeck(Mapper.Map<DeckSM>(deck), userId);
                return RedirectToAction("UserDecks");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DeleteDeck()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteDeck(DeckVM model)
        {
            CardsLogic.DeleteDeck(model.ID);
            return RedirectToAction("UserDecks");
        }

        //Shows a single deck of cards attached to a user
        public ActionResult EditDeck(int id)
        {
            List<CardsVM> cards = Mapper.Map<List<CardsVM>>(CardsLogic.GetSingleDeck(id));
            cards.Sort(delegate (CardsVM c1, CardsVM c2) { return c1.Name.CompareTo(c2.Name); });
            return View(cards);
        }
        public void SetSessDeck(int id)
        {
            UserVM user = new UserVM();
            DeckVM deck = new DeckVM();
            user = SessAcc.GetUserInfoSess();
            deck.ID = id;
            SessAcc.SetSessionAccessor(user, deck);
        }
        //Shuffles cards attached to a user
        public ActionResult Shuffle()
        {
            try
            {
                int id = SessAcc.GetDeckId();
                List<CardsVM> cards = Mapper.Map<List<CardsVM>>(CardsLogic.GetSingleDeck(id));
                cards = Mapper.Map<List<CardsVM>>(CardsLogic.Shuffle(Mapper.Map<List<CardsSM>>(cards)));
                return View(cards);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult GoBackToEditDeckFromShuffle()
        {
            try
            {
                int deckid = SessAcc.GetDeckId();
                List<CardsVM> model = Mapper.Map<List<CardsVM>>(CardsLogic.GetSingleDeck(deckid));
                return RedirectToAction("EditDeck", new { id = deckid });
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult SetDeckFromUserDeck(int id)
        {
            try
            {
                SetSessDeck(id);
                return RedirectToAction("CardIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}