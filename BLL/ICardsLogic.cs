using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICardsLogic
    {
        List<CardsSM> GetAllCards();

        CardsSM GetSingleCard(string name);

        void CreateCard(CardsSM card);

        void UpdateCardInfo(CardsSM card);

        void DeleteCard(int id);

        List<CardsSM> GetSingleDeck(int id);

        List<DeckSM> UserDecks(int id);

        void AddCardToDeck(int cardid, int deckId);

        void DeleteCardFromDeck(int cardId, int deckId);

        void CreateDeck(DeckSM deck, int userID);

        void DeleteDeck(int id);

        List<CardsSM> Shuffle(List<CardsSM> cards);
    }
}

