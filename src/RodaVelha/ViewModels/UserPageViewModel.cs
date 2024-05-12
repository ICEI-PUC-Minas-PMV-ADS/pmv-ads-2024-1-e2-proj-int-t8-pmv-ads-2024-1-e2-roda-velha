using RodaVelha.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RodaVelha.ViewModels{

    public class UserPageViewModel
    {
        public List<Events> events {  get; set; }
        public User user {  get; set; }
        
        public List<Events> eventsLike {  get; set; }
    
    }
}