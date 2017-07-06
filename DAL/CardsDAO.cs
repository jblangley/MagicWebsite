using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class CardsDAO : ICardsDAO
    {
        public string ConnectionString = @"Server=.\SQLEXPRESS;Database=Capstone;Trusted_Connection=True;";
        private IDAO DataWriter;

        public CardsDAO(IDAO dataWriter)
        {
            DataWriter = dataWriter;
        }
        public List<CardsDM> ReadCards(SqlParameter[] parameter, string statement)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameter != null)
                        {
                            command.Parameters.AddRange(parameter);
                        }
                        connection.Open();
                        SqlDataReader data = command.ExecuteReader();
                        List<CardsDM> cards = new List<CardsDM>();
                        while (data.Read())
                        {
                            CardsDM card = new CardsDM();
                            card.ID = (Int32)data["ID"];
                            card.PictureURL = data["PictureURL"].ToString();
                            card.Name = data["Name"].ToString();
                            card.CMC = (Int32)data["CMC"];
                            card.CardColor = data["CardColor"].ToString();
                            card.Attack = (Int32)data["Attack"];
                            card.Defense = (Int32)data["Defense"];
                            card.Cardtype = data["Cardtype"].ToString();
                            card.Subtype = data["Subtype"].ToString();
                            card.Ability = data["Ability"].ToString();
                            card.Rarity = data["Rarity"].ToString();
                            card.Set = data["Set"].ToString();
                            card.Flavortext = data["Flavortext"].ToString();
                            cards.Add(card);
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
        public List<DeckDM> ReadDeck(SqlParameter[] parameter, string statement)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameter != null)
                        {
                            command.Parameters.AddRange(parameter);
                        }
                        connection.Open();
                        SqlDataReader data = command.ExecuteReader();
                        List<DeckDM> decks = new List<DeckDM>();
                        while (data.Read())
                        {
                            DeckDM deck = new DeckDM();
                            deck.ID = (Int32)data["Id"];
                            deck.Name = data["Name"].ToString();
                            deck.CardCount = (Int32)data["CardCount"];
                            decks.Add(deck);
                        }
                        return decks;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
        //Gets a list of all cards in the database
        public List<CardsDM> GetCards()
        {
            try
            {
                return ReadCards(null, "ReadAllCards");
            }
            catch
            {
                return null;
            }
        }
        //Gets the details of a single card
        public CardsDM GetCard(string name)
        {
            try
            {
                return ReadCards(new SqlParameter[] { new SqlParameter("@Name", name) }, "GetCardDetail")[0];
            }
            catch
            {
                return null;
            }
        }
        //Creates a new card
        public void CreateCard(CardsDM card)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@PictureURL",  card.PictureURL)
                ,new SqlParameter("@Name", card.Name)
                ,new SqlParameter("@CMC", card.CMC)
                ,new SqlParameter("@CardColor",  card.CardColor)
                ,new SqlParameter("@Attack", card.Attack)
                ,new SqlParameter("@Defense",card.Defense)
                ,new SqlParameter("@Cardtype", card.Cardtype)
                ,new SqlParameter("@Subtype",card.Subtype)
                ,new SqlParameter("@Rarity", card.Rarity)
                ,new SqlParameter("@Ability",card.Ability)
                ,new SqlParameter("@Set", card.Set)
                ,new SqlParameter("@Flavortext",card.Flavortext)
        };
                DAO dataWriter = new DAO();
                dataWriter.Write(parameter, "CreateCard");
            }
            catch
            {
            }
        }
        //Changes information on a card
        public void UpdateCard(CardsDM card)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
               new SqlParameter("@PictureURL",  card.PictureURL)
                ,new SqlParameter("@Name", card.Name)
                ,new SqlParameter("@ID", card.ID)
                ,new SqlParameter("@CMC", card.CMC)
                ,new SqlParameter("@CardColor",  card.CardColor)
                ,new SqlParameter("@Attack", card.Attack)
                ,new SqlParameter("@Defense",card.Defense)
                ,new SqlParameter("@Cardtype", card.Cardtype)
                ,new SqlParameter("@Subtype",card.Subtype)
                ,new SqlParameter("@Rarity", card.Rarity)
                ,new SqlParameter("@Ability",card.Ability)
                ,new SqlParameter("@Set", card.Set)
                ,new SqlParameter("@Flavortext",card.Flavortext)
        };
                DAO dataWriter = new DAO();
                dataWriter.Write(parameter, "UpdateCard");
            }
            catch
            {
            }

        }
        //Delete a card from the database
        public void DeleteCard(int id)
        {
            SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@ID", id)
            };
            DAO dataWriter = new DAO();
            dataWriter.Write(parameter, "DeleteCard");
        }
        //Get all decks related to a user
        public List<DeckDM> GetDecks(int id)
        {
            try
            {
                return ReadDeck(new SqlParameter[] { new SqlParameter("@Id", id) }, "GetDecks");
            }
            catch
            {
                return null;
            }

        }
        public List<CardsDM> GetSingleDeck(int id)
        {
            try
            {
                return ReadCards(new SqlParameter[] { new SqlParameter("@Id", id) }, "GetSingleDeck");
            }
            catch
            {
                return null;
            }
        }
        public void CreateDeck(DeckDM deck, int user)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@Name", deck.Name)
                ,new SqlParameter("@CardCount", deck.CardCount)
                ,new SqlParameter("@UserId", user)
                ,new SqlParameter("@DeckId", deck.ID)
                };
                DAO dataWriter = new DAO();
                dataWriter.Write(parameter, "CreateDeck");
            }
            catch
            {
            }
        }
        public void DeleteDeck(int id)
        {
            SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@ID", id)
            };
            DAO dataWriter = new DAO();
            dataWriter.Write(parameter, "DeleteDeck");
        }
        //Attach an instance of a card to a User
        public void AddCardToDeck(int cardid, int deckId)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@CardId", cardid)
                ,new SqlParameter("DeckID", deckId)
            };
                DAO dataWriter = new DAO();
                dataWriter.Write(parameter, "AddCardToDeck");
            }
            catch
            {
            }
        }
        //Removes an instance of a card to a User
        public void DeleteCardFromDeck(int cardId, int deckId)
        {
            try
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@CardId", cardId)
                ,new SqlParameter("@DeckId", deckId)
            };
                DAO dataWriter = new DAO();
                dataWriter.Write(parameter, "DeleteCardDeckConnection");
            }
            catch
            {
            }
        }
    }
}
