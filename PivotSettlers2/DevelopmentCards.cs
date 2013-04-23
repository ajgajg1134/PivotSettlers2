using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace PivotSettlers2
{
    class DevelopmentCards : ObservableCollection<DevelopmentCard>
    {
        public DevelopmentCards()
        {
            Add(new DevelopmentCard("test1"));
            Add(new DevelopmentCard("Soldier dude"));
        }
    }
}
