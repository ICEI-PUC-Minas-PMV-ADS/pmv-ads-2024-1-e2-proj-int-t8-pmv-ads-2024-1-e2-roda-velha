using RodaVelha.Models;
using System.Collections.Generic;

namespace RodaVelha.ViewModels{

    public class UserPageViewModel
    {
        public List<Events> events { get; set; }
        public List<Like> likes { get; set; }

        public User userData {get; set;}
    }
}