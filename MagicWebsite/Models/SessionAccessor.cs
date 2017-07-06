using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicWebsite.Models
{
    public class SessionAccessor : ISessionAccessor
    {
        public void SetSessionAccessor(UserVM user, DeckVM deck)
        {
            HttpContext.Current.Session["Role"] = user.Role;
            HttpContext.Current.Session["Id"] = user.ID;
            HttpContext.Current.Session["Email"] = user.Email;
            HttpContext.Current.Session["UserName"] = user.UserName;
            HttpContext.Current.Session["DeckId"] = deck.ID;
        }
        public UserVM GetUserInfoSess()
        {
            UserVM user = new UserVM();
            user.Role = (string)HttpContext.Current.Session["Role"];
            user.ID = (int)HttpContext.Current.Session["Id"];
            user.Email = (string)HttpContext.Current.Session["Email"];
            user.UserName = (string)HttpContext.Current.Session["UserName"];
            return user;
        }
        public int GetUserId()
        {
            int userId = 0;
            if (HttpContext.Current.Session["Id"] != null)
            {
                userId = (int)HttpContext.Current.Session["Id"];
            }
            else
            {
                userId = -1;
            }
            return userId;
        }
        public int GetDeckId()
        {
            int deckId = 0;
            if (HttpContext.Current.Session["DeckId"] != null)
            {
                deckId = (int)System.Web.HttpContext.Current.Session["DeckId"];
            }
            else
            {
                deckId = -1;
            }
            return deckId;
        }
        public void Clear()
        {
            //Removes all current keys
            HttpContext.Current.Session.Clear();
            //Cancel the current Session
            HttpContext.Current.Session.Abandon();
        }
    }
}