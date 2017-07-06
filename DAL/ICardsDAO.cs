using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public interface ICardsDAO
    {
        List<CardsDM> ReadCards(SqlParameter[] parameter, string statement);

        List<DeckDM> ReadDeck(SqlParameter[] parameter, string statement);

        List<CardsDM> GetCards();

        CardsDM GetCard(string name);

        void CreateCard(CardsDM card);

        void UpdateCard(CardsDM card);

        void DeleteCard(int id);

        List<DeckDM> GetDecks(int id);

        List<CardsDM> GetSingleDeck(int id);

        void AddCardToDeck(int cardid, int deckId);

        void DeleteCardFromDeck(int cardId, int deckId);

        void CreateDeck(DeckDM deck, int userID);

        void DeleteDeck(int id);
    }
}
