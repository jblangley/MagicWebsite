using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWebsite.Models
{
    public interface ISessionAccessor
    {
        void SetSessionAccessor(UserVM user, DeckVM deck);

        UserVM GetUserInfoSess();

        int GetUserId();

        int GetDeckId();

        void Clear();
    }
}
