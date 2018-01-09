using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using AutoMapper;

namespace BLL
{
    public class CardsLogic : ICardsLogic
    {
        private ICardsDAO CardData;

        public CardsLogic(CardsDAO cardData)
        {
            CardData = cardData;
        }
        //Gets  all cards
        public List<CardsSM> GetAllCards()
        {
            return Mapper.Map<List<CardsSM>>(CardData.GetCards());
        }
        //Gets cards of one color
        public List<CardsSM> GetCardsByColor(string color)
        {
            //Method in presentation needs to be made
            return Mapper.Map<List<CardsSM>>(CardData.GetCardsByColor(color));
        }
        //Gets cards by set
        public List<CardsSM> GetCardsBySet(string set)
        {
            //Method in presentation needs to be made
            return Mapper.Map<List<CardsSM>>(CardData.GetCardsBySet(set));
        }
        //Sorts the current cards by cost
        public List<CardsSM> SortAllCardsByCost(List<CardsSM> unfiltered)
        {
            List<CardsSM> filtered = unfiltered.OrderBy(o=>o.CMC).ToList();
            return filtered;
        }
        //Gets a card's details
        public CardsSM GetSingleCard(string name)
        {
            return Mapper.Map<CardsSM>(CardData.GetCard(name));
        }
        //Creates a new card
        public void CreateCard(CardsSM card)
        {
            CardData.CreateCard(Mapper.Map<CardsDM>(card));
        }
        //Edits a card
        public void UpdateCardInfo(CardsSM card)
        {
            CardData.UpdateCard(Mapper.Map<CardsDM>(card));
        }
        //Deletes a card
        public void DeleteCard(int id)
        {
            CardData.DeleteCard(id);
        }
        //Shows a single deck of cards attached to a user
        public List<CardsSM> GetSingleDeck(int id)
        {
            return Mapper.Map<List<CardsSM>>(CardData.GetSingleDeck(id));
        }
        public List<DeckSM> UserDecks(int id)
        {
            return Mapper.Map<List<DeckSM>>(CardData.GetDecks(id));
        }
        //Attaches a card to a user
        public void AddCardToDeck(int cardid, int deckId)
        {
            CardData.AddCardToDeck(cardid, deckId);
        }
        //Removes an instance of an attached card to a user
        public void DeleteCardFromDeck(int cardId, int deckId)
        {
            CardData.DeleteCardFromDeck(cardId, deckId);
        }
        public void CreateDeck(DeckSM deck, int userID)
        {
            CardData.CreateDeck(Mapper.Map<DeckDM>(deck), userID);
        }
        public void DeleteDeck(int id)
        {
            CardData.DeleteDeck(id);
        }
        //Fisher-Yattes shuffle to make a users deck randomly sorted
        public List<CardsSM> Shuffle(List<CardsSM> cards)
        {
            try
            {
                Random random = new Random();
                int count = cards.Count;
                for (int index = 0; index < count; index++)
                {
                    int rand = index + (int)(random.NextDouble() * (count - index));
                    CardsSM temp = cards[rand];
                    cards[rand] = cards[index];
                    cards[index] = temp;
                }
                return cards;
            }
            catch
            {
                return null;
            }
        }
    }
}
